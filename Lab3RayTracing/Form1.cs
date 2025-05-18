using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;


namespace Lab3RayTracing
{
    public partial class Form1 : Form
    {
        View view;
        const float step = 0.2f;//перемещение

        int prevX, prevY, prevZ;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += OnKeyDown;

            trackbarX.Scroll += OnTrackMove;
            trackbarY.Scroll += OnTrackMove;
            trackbarZ.Scroll += OnTrackMove;

            trackbarR.Scroll += AnyControlChanged;
            trackbarG.Scroll += AnyControlChanged;
            trackbarB.Scroll += AnyControlChanged;
            trackbarDepth.Scroll += AnyControlChanged;
            cbMirror.CheckedChanged += AnyControlChanged;

            glControl1.Load += GlLoad;
            glControl1.Paint += GlPaint;
            glControl1.Dock = DockStyle.Fill;
            Application.Idle += (s, e) => glControl1.Invalidate();
        }
        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (view == null) return;

            switch (e.KeyCode)
            {
                case Keys.W: view.MoveCamera(0, 0, step); break; //Вперёд+Z
                case Keys.S: view.MoveCamera(0, 0, -step); break; //Назад-Z
                case Keys.A: view.MoveCamera(-step, 0, 0); break;//Налево-X
                case Keys.D: view.MoveCamera(step, 0, 0); break;//Направо+X
                case Keys.Q: view.MoveCamera(0, step, 0); break;//Вверх+Y
                case Keys.E: view.MoveCamera(0, -step, 0); break;//Вниз-Y
            }
        }

        void GlLoad(object sender, EventArgs e)
        {
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1f);
            view = new View();
            ApplyUiToShader();
            glControl1.Focus();
        }

        void GlPaint(object sender, PaintEventArgs e)
        {
            view.Draw();
            glControl1.SwapBuffers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void AnyControlChanged(object sender, EventArgs e) => ApplyUiToShader();

        void ApplyUiToShader()
        {
            var col = new Vector3(trackbarR.Value / 255f,
                                  trackbarG.Value / 255f,
                                  trackbarB.Value / 255f);

            float kr = cbMirror.Checked ? 1f : 0f;
            int depth = trackbarDepth.Value;
            view.UpdateDynamicUniforms(col, kr, depth);
        }

        void OnTrackMove(object sender, EventArgs e)
        {
            float dx = (trackbarX.Value - prevX) * 0.1f;
            float dy = (trackbarY.Value - prevY) * 0.1f;
            float dz = (trackbarZ.Value - prevZ) * 0.1f;
            prevX = trackbarX.Value; prevY = trackbarY.Value; prevZ = trackbarZ.Value;

            view.MoveCamera(dx, dy, dz);
        }
    }
}
