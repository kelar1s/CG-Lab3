using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Lab3RayTracing
{
    internal class View
    {
        Vector3 camPos = new Vector3(0, 0, -8);

        int BasicProgramID;
        int BasicVertexShader;
        int BasicFragmentShader;

        int locSphereCol, locKr, locMaxDepth;
        int vao;
        int vbo_position;        // массив вершин
        int attribute_vpos = 0;
        int locCamScale;
        int prog, vsh, fsh;
        int vbo;
        int locCamPos;

        public View()
        {
            InitShaders();
        }
        void loadShader(string file, ShaderType type, int program, out int handle)
        {
            if (!File.Exists(file))
                Console.WriteLine($"[ERROR] File not found: {file}");

            handle = GL.CreateShader(type);
            GL.ShaderSource(handle, File.ReadAllText(file));
            GL.CompileShader(handle);

            Console.WriteLine($"--- {type} compile log ---");
            Console.WriteLine(GL.GetShaderInfoLog(handle));

            GL.GetShader(handle, ShaderParameter.CompileStatus, out int ok);
            if (ok == 0) Console.WriteLine($"[ERROR] {type} compilation failed");

            GL.AttachShader(program, handle);
        }

        void InitShaders()
        {

            BasicProgramID = GL.CreateProgram();

            loadShader("shaders/raytracing.vert", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);
            loadShader("shaders/raytracing.frag", ShaderType.FragmentShader, BasicProgramID, out BasicFragmentShader);

            GL.LinkProgram(BasicProgramID);
            Console.WriteLine("--- Program link log ---");
            Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));
            GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out int linked);

            if (linked == 0)
            {
                Console.WriteLine($"Link failed:\n{GL.GetProgramInfoLog(BasicProgramID)}");
                return;
            }

            locCamPos = GL.GetUniformLocation(BasicProgramID, "uCamera.Position");
            locCamScale = GL.GetUniformLocation(BasicProgramID, "uCamera.Scale");
            locSphereCol = GL.GetUniformLocation(BasicProgramID, "uSphereColor");
            locKr = GL.GetUniformLocation(BasicProgramID, "uKr");
            locMaxDepth = GL.GetUniformLocation(BasicProgramID, "uMaxDepth");
            int locCamView = GL.GetUniformLocation(BasicProgramID, "uCamera.View");
            int locCamUp = GL.GetUniformLocation(BasicProgramID, "uCamera.Up");
            int locCamSide = GL.GetUniformLocation(BasicProgramID, "uCamera.Side");



            GL.UseProgram(BasicProgramID);
            GL.Uniform3(locCamPos, camPos);
            GL.Uniform3(locCamView, 0f, 0f, 1f);
            GL.Uniform3(locCamUp, 0f, 1f, 0f);
            GL.Uniform3(locCamSide, 1f, 0f, 0f);

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            Vector3[] vertdata =
            {
                new Vector3(-1f, -1f, 0f),
                new Vector3( 1f, -1f, 0f),
                new Vector3(-1f,  1f, 0f),
                new Vector3( 1f,  1f, 0f)
            };

            vbo_position = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.BufferData(BufferTarget.ArrayBuffer,
                          new IntPtr(vertdata.Length * Vector3.SizeInBytes),
                          vertdata,
                          BufferUsageHint.StaticDraw);
            Console.WriteLine($"vao = {vao}, vbo = {vbo_position}, attr = {attribute_vpos}");
            GL.EnableVertexAttribArray(attribute_vpos);
            GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            int[] vp = new int[4];
            GL.GetInteger(GetPName.Viewport, vp);
            float aspect = (float)vp[2] / vp[3];

            Vector2 scale = aspect >= 1f
                            ? new Vector2(aspect, 1f)
                            : new Vector2(1f, 1f / aspect);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(BasicProgramID);
            GL.Uniform3(locCamPos, camPos);
            GL.Uniform2(locCamScale, scale);

            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }

        public void UpdateDynamicUniforms(Vector3 col, float kr, int depth)
        {
            GL.UseProgram(BasicProgramID);
            GL.Uniform3(locSphereCol, col);
            GL.Uniform1(locKr, kr);
            GL.Uniform1(locMaxDepth, depth);
        }
        public void MoveCamera(float dx, float dy, float dz)
        {
            camPos += new Vector3(dx, dy, dz);
        }

    }
}