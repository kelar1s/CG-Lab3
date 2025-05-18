#version 330 core
const float EPSILON = 0.001;
const float BIG     = 1e6;

const int DIFFUSE_REFLECTION = 1;
const int MIRROR_REFLECTION  = 2;

struct SCamera   { vec3 Position, View, Up, Side; vec2 Scale; };
struct SRay      { vec3 Origin, Direction; };

struct SSphere   { vec3 Center; float Radius; int MaterialIdx; };
struct STriangle { vec3 v1, v2, v3; int MaterialIdx; };

struct SMaterial {
    vec3  Color;          
    vec4  LightCoeffs;    // (Ka, Kd, Ks, specPow)
    float ReflectionCoef;
    float RefractionCoef;
    int   MaterialType;   // DIFFUSE_REFLECTION / MIRROR_REFLECTION
};

struct SLight { vec3 Position; };

struct SIntersection {
    float Time;
    vec3  Point;
    vec3  Normal;
    vec3  Color;
    vec4  LightCoeffs;
    float ReflectionCoef;
    float RefractionCoef;
    int   MaterialType;
};

struct STracingRay {
    SRay  ray;
    float contribution;
    int   depth;
};

const int TRI_COUNT = 16;
const int SPH_COUNT =  2;
const int MAT_COUNT =  7;

STriangle triangles[TRI_COUNT];
SSphere   spheres  [SPH_COUNT];
SMaterial materials[MAT_COUNT];
SLight    light;

const int MAX_STACK = 32;
const int MAX_DEPTH =  5;

STracingRay stackRays[MAX_STACK];
int sp = 0;

void pushRay(STracingRay r) { if (sp < MAX_STACK) stackRays[sp++] = r; }
STracingRay popRay()        { return stackRays[--sp]; }
bool isEmpty()              { return sp == 0; }

uniform SCamera uCamera;
uniform vec3  uSphereColor;  
uniform float uKr;            // 0 – диффузный, 1 – зеркало
uniform int   uMaxDepth;     

in  vec3 glPosition;
out vec4 FragColor;

SRay GenerateRay(SCamera cam)
{
    vec2 c = glPosition.xy * cam.Scale;
    vec3 d = cam.View + cam.Side * c.x + cam.Up * c.y;
    return SRay(cam.Position, normalize(d));
}

bool IntersectSphere(SSphere s, SRay r, float start, float final, out float tHit)
{
    r.Origin -= s.Center;
    float A = dot(r.Direction, r.Direction);
    float B = dot(r.Direction, r.Origin);
    float C = dot(r.Origin, r.Origin) - s.Radius * s.Radius;
    float D = B*B - A*C;
    if (D <= 0.0) return false;
    D = sqrt(D);
    float t1 = (-B - D) / A;
    float t2 = (-B + D) / A;
    if (t1 < start && t2 < start) return false;
    tHit = (min(t1,t2) < start) ? max(t1,t2) : min(t1,t2);
    return tHit < final;
}

bool IntersectTriangle(SRay r, vec3 v1, vec3 v2, vec3 v3, out float tHit)
{
    tHit = -1.0;
    vec3 N = cross(v2-v1, v3-v1);
    float NdD = dot(N, r.Direction);
    if (abs(NdD) < 1e-3) return false;
    float d = dot(N, v1);
    float t = -(dot(N, r.Origin) - d) / NdD;
    if (t < 0.0) return false;
    vec3 P = r.Origin + t * r.Direction;
    if (dot(N, cross(v2-v1, P-v1)) < 0.0) return false;
    if (dot(N, cross(v3-v2, P-v2)) < 0.0) return false;
    if (dot(N, cross(v1-v3, P-v3)) < 0.0) return false;
    tHit = t;
    return true;
}

bool Raytrace(SRay r, float start, float final, inout SIntersection hit)
{
    bool found = false;
    float t;

    for(int i=0;i<SPH_COUNT;++i)
        if (IntersectSphere(spheres[i], r, start, final, t) && t < hit.Time)
        {
            int m = spheres[i].MaterialIdx;
            hit.Time   = t;
            hit.Point  = r.Origin + r.Direction * t;
            hit.Normal = normalize(hit.Point - spheres[i].Center);
            hit.Color            = materials[m].Color;
            hit.LightCoeffs      = materials[m].LightCoeffs;
            hit.ReflectionCoef   = materials[m].ReflectionCoef;
            hit.MaterialType     = materials[m].MaterialType;
            found = true;
        }

    for(int i=0;i<TRI_COUNT;++i)
        if (IntersectTriangle(r, triangles[i].v1, triangles[i].v2, triangles[i].v3, t) && t < hit.Time)
        {
            int m = triangles[i].MaterialIdx;
            hit.Time   = t;
            hit.Point  = r.Origin + r.Direction * t;
            hit.Normal = normalize(cross(triangles[i].v1 - triangles[i].v2,
                                         triangles[i].v3 - triangles[i].v2));
            hit.Color            = materials[m].Color;
            hit.LightCoeffs      = materials[m].LightCoeffs;
            hit.ReflectionCoef   = materials[m].ReflectionCoef;
            hit.MaterialType     = materials[m].MaterialType;
            found = true;
        }
    return found;
}

float Shadow(SLight L, SIntersection inter)
{
    vec3 dir  = normalize(L.Position - inter.Point);
    float dist = distance(L.Position, inter.Point);
    SRay sray = SRay(inter.Point + dir*EPSILON, dir);
    SIntersection tmp; tmp.Time = BIG;
    return Raytrace(sray,0.0,dist,tmp) ? 0.0 : 1.0;
}

vec3 Phong(SIntersection i, SLight L, float sh)
{
    vec3 Ld = normalize(L.Position - i.Point);
    float diff = max(dot(Ld, i.Normal), 0.0);
    vec3 V  = normalize(uCamera.Position - i.Point);
    vec3 R  = reflect(-V, i.Normal);
    float spec = pow(max(dot(R, Ld),0.0), i.LightCoeffs.w);

    float Ka = i.LightCoeffs.x;
    float Kd = i.LightCoeffs.y;
    float Ks = i.LightCoeffs.z;

    vec3 ambient  = Ka * i.Color;
    vec3 diffuse  = Kd * diff * i.Color * sh;
    vec3 specular = Ks * spec * sh * vec3(1.0);
    return ambient + diffuse + specular;
}

void initScene()
{
    triangles[0] = STriangle(vec3(-5,-5,-5), vec3(-5, 5, 5), vec3(-5, 5,-5), 1); // красная
    triangles[1] = STriangle(vec3(-5,-5,-5), vec3(-5,-5, 5), vec3(-5, 5, 5), 1);

    triangles[2] = STriangle(vec3(-5,-5, 5), vec3( 5,-5, 5), vec3(-5, 5, 5), 2); // голубая
    triangles[3] = STriangle(vec3( 5, 5, 5), vec3(-5, 5, 5), vec3( 5,-5, 5), 2);

    triangles[4] = STriangle(vec3( 5,-5, 5), vec3( 5,-5,-5), vec3( 5, 5,-5), 0); // зелёная
    triangles[5] = STriangle(vec3( 5,-5, 5), vec3( 5, 5,-5), vec3( 5, 5, 5), 0);

    triangles[6] = STriangle(vec3(-5,-5,-5), vec3( 5,-5,-5), vec3( 5,-5, 5), 4); // пол
    triangles[7] = STriangle(vec3(-5,-5,-5), vec3( 5,-5, 5), vec3(-5,-5, 5), 4);

    triangles[8] = STriangle(vec3(-5, 5,-5), vec3(-5, 5, 5), vec3( 5, 5, 5), 4); // потолок
    triangles[9] = STriangle(vec3(-5, 5,-5), vec3( 5, 5, 5), vec3( 5, 5,-5), 4);

    vec3 B0 = vec3( 5,-1.5,-1.5);          // основание квадрат 2×2
    vec3 B1 = vec3( 5,-1.5, 1.5);
    vec3 B2 = vec3( 5, 1.5, 1.5);
    vec3 B3 = vec3( 5, 1.5,-1.5);
    vec3 Apex = vec3(3, 0, 0);        // вершина в комнату
    int id = 10;                 

    triangles[id++] = STriangle(B0, B1, Apex, 6);
    triangles[id++] = STriangle(B1, B2, Apex, 6);
    triangles[id++] = STriangle(B2, B3, Apex, 6);
    triangles[id++] = STriangle(B3, B0, Apex, 6);

    triangles[id++] = STriangle(B0, B1, B2, 6);
    triangles[id++] = STriangle(B0, B2, B3, 6);

    spheres[0] = SSphere(vec3(-1,-1,-2), 2.0, 3); 
    spheres[1] = SSphere(vec3( 2, 1, 2), 1.0, 5);   // зеркало
}

void initLightMaterials()
{
    /* свет */
    light.Position = vec3(1.5,2,-4);

    vec4 lc = vec4(0.4, 0.9, 0.3, 128.0);

    materials[0] = SMaterial(vec3(0,1,0), lc, 0.0, 1.0, DIFFUSE_REFLECTION); // зелёный
    materials[1] = SMaterial(vec3(1,0,0), lc, 0.0, 1.0, DIFFUSE_REFLECTION); // красный
    materials[2] = SMaterial(vec3(0,0.8,1), lc, 0.0, 1.0, DIFFUSE_REFLECTION);// голубой
    materials[3] = SMaterial(uSphereColor, lc, uKr, 1.0, (uKr > 0.0) ? MIRROR_REFLECTION : DIFFUSE_REFLECTION);
    materials[4] = SMaterial(vec3(0.6),  lc, 0.0, 1.0, DIFFUSE_REFLECTION); // серый
    materials[5] = SMaterial(vec3(1),    lc, 1.0, 1.0, MIRROR_REFLECTION);  // зеркало
    materials[6]=SMaterial(vec3(0.7,0,1),lc,0,1,DIFFUSE_REFLECTION); //фиолетовый

}

void main()
{
    initScene();
    initLightMaterials();

    vec3 result = vec3(0);

    pushRay(STracingRay(GenerateRay(uCamera), 1.0, 0));

    while(!isEmpty())
    {
        STracingRay cur = popRay();
        if(cur.depth >= uMaxDepth) continue;                   
        
        SRay ray = cur.ray;

        SIntersection hit; hit.Time = BIG;

        if (Raytrace(ray, 0.0, BIG, hit))
        {
            if (hit.MaterialType == DIFFUSE_REFLECTION)
            {
                float sh = (abs(hit.Normal.x + 1.0) < 0.001) ? 1.0:  Shadow(light, hit);                                
                result += cur.contribution * Phong(hit, light, sh); 
            }
            else if(hit.MaterialType == MIRROR_REFLECTION)
            {
                float reflW = cur.contribution * hit.ReflectionCoef;

                if(hit.ReflectionCoef < 1.0)
                {
                    float sh = Shadow(light, hit);
                    result += cur.contribution * (1.0 - hit.ReflectionCoef)
                              * Phong(hit, light, sh);
                }

                vec3 reflDir = reflect(ray.Direction, hit.Normal);
                pushRay(STracingRay(
                    SRay(hit.Point + reflDir * EPSILON, reflDir),
                    reflW,
                    cur.depth + 1));
            }
        }
    }

    FragColor = vec4(result, 1.0);
}