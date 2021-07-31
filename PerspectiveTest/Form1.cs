using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perspective;
using System.Collections;

namespace PerspectiveTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Light l1 = new Light(50, 0, -50, 0, 0, 1);
            Light l2 = new Light(35, 0, -50, 0, 0, -1);

            Face f2 = new Face(Color.DarkBlue);
            Face f = new Face(Color.Goldenrod);

            this.perspectiveControl1.CreateTorus(f2, 10, 10, 20, 50, 1,1,1);
            this.perspectiveControl1.CreateCube(f, 20, 50);
            this.perspectiveControl1.CreateCube(f, 20, -50);


            //this.perspectiveControl1.AddModal(new Light(0, 0, -75, 0, 2, 0));
            /*
            this.perspectiveControl1.AddLight(new Light(0, 0, -75, -1, -1, 0.2));
            this.perspectiveControl1.AddLight(new Light(0, 0, -75, -1.5, -1, 0.2));
            this.perspectiveControl1.AddLight(new Light(0, 0, -75, -1, 0.9, 0.2));
            this.perspectiveControl1.AddLight(new Light(0, 0, -75, 0, -0.2, 0.5));
            */
            //this.perspectiveControl1.AddLight(l1);
            //this.perspectiveControl1.AddLight(l2);

            this.perspectiveControl1.DrawVertices = this.cb_DrawVertices.Checked;
            this.perspectiveControl1.UseShading = this.cb_UseShading.Checked;
            this.perspectiveControl1.UseCulling = this.cb_UseCulling.Checked;
            this.perspectiveControl1.DrawFaces = this.cb_DrawFaces.Checked;
            this.perspectiveControl1.AntiAlias = this.cb_AntiAlias.Checked;

            this.perspectiveControl1.DrawLines = true;
            this.perspectiveControl1.Scale = 150;
        }

        private void Renderer_Tick(object sender, EventArgs e)
        {
            // this.perspectiveControl1.RenderWorld();
            this.perspectiveControl1.Invalidate();
        }
    }
}