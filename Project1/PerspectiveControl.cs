using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace Perspective
{
    public class PerspectiveControl: Panel 
    {
        private List<Modal> Modals;

        private bool _drawVertices;
        private bool _useShading;
        private bool _useCulling;
        private bool _drawFaces;
        private bool _drawLines;
        private bool _antiAlias;
        private int scale = 100;

        public PerspectiveControl(): base()
        {
            this.Modals = new List<Modal>();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this._drawVertices = false;
            this._useCulling = false;
            this._useShading = false;
            this._drawFaces = false;
            this._drawLines = false;
            this._antiAlias = false;
        }

        public Object CreateTorus(Face f, int Sides, int Tubes, int Radius, int TRadius, int xDir, int yDir, int zDir)
        {
            Object torus = new Object(0, 0, 0, xDir, yDir, zDir);

            ArrayList TubeList;
            ArrayList Vertices;
                    	
	        double r1 = Math.PI / (Tubes / 2);
	        double r2 = Math.PI / (Sides / 2);
	        double X, Y, Z;

            TubeList = new ArrayList();
            for (int i = 0; i < Tubes; i++)
	        {
		        Vertices = new ArrayList();
        		
                for (int j = 0; j < Sides; j++)
                {
                    X = (TRadius + Radius * Math.Cos(j * r2)) * Math.Cos(i * r1);
                    Y = (TRadius + Radius * Math.Cos(j * r2)) * Math.Sin(i * r1);
                    Z = Radius * Math.Sin(j * r2);

			        Vertex v = new Vertex(X, Y, Z);
                    torus.AddVertex(v);
			        Vertices.Add(v);
                }

                TubeList.Add(Vertices);
            }

            for (int i = 0; i < TubeList.Count; i++)
	        {
                Vertices = (ArrayList)TubeList[i];
                ArrayList VerticesN = TubeList[(i + 1) % TubeList.Count] as ArrayList;
        		
		        for (int j = 0; j < Vertices.Count; j++)
		        {
			        int j2 = (j + 1) % Vertices.Count;
			        Vertex p1 = Vertices[j] as Vertex;
                    Vertex p2 = Vertices[j2] as Vertex;
                    Vertex p3 = VerticesN[j] as Vertex;
                    Vertex p4 = VerticesN[j2] as Vertex;

                    torus.AddFace(f.Copy(), p3, p2, p1);
                    torus.AddFace(f.Copy(), p2, p3, p4);
		        }

	        }

            this.AddModal(torus);
            torus.Scale = 150;

            return torus;
        }
        public void CreateCube(Face f, int Height, int xPos)
        {
            Object cube = new Object(xPos, 0, 0, 0, -1, 0);

            Vertex p1 = cube.AddVertex(-Height, -Height, -Height);
            Vertex p2 = cube.AddVertex(-Height, Height, -Height);
            Vertex p3 = cube.AddVertex(Height, Height, -Height);
            Vertex p4 = cube.AddVertex(Height, -Height, -Height);
            Vertex p5 = cube.AddVertex(-Height, -Height, Height);
            Vertex p6 = cube.AddVertex(-Height, Height, Height);
            Vertex p7 = cube.AddVertex(Height, Height, Height);
            Vertex p8 = cube.AddVertex(Height, -Height, Height);

            cube.AddFace(f.Copy(), p1, p2, p3);
            cube.AddFace(f.Copy(), p1, p3, p4);
            cube.AddFace(f.Copy(), p5, p7, p6);
            cube.AddFace(f.Copy(), p5, p8, p7);
            cube.AddFace(f.Copy(), p5, p2, p1);
            cube.AddFace(f.Copy(), p5, p6, p2);
            cube.AddFace(f.Copy(), p4, p7, p8);
            cube.AddFace(f.Copy(), p4, p3, p7);
            cube.AddFace(f.Copy(), p5, p1, p8);
            cube.AddFace(f.Copy(), p8, p1, p4);
            cube.AddFace(f.Copy(), p2, p6, p3);
            cube.AddFace(f.Copy(), p3, p6, p7);

            this.AddModal(cube);
        }

        public bool DrawVertices
        {
            get { return this._drawVertices; }
            set { this._drawVertices = value; }
        }
        public bool UseShading
        {
            get { return this._useShading; }
            set { this._useShading = value; }
        }
        public bool UseCulling
        {
            get { return this._useCulling; }
            set { this._useCulling = value; }
        }
        public bool DrawFaces
        {
            get { return this._drawFaces; }
            set { this._drawFaces = value; }
        }
        public bool DrawLines
        {
            get { return this._drawLines; }
            set { this._drawLines = value; }
        }
        public bool AntiAlias
        {
            get { return this._antiAlias; }
            set { this._antiAlias = value; }
        }
        public new int Scale
        {
            get { return this.scale; }
            set { this.scale = Math.Max(value, 100); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.DrawScene(e.Graphics);
        }
        protected void DrawScene(Graphics g)
        {
            if (this._antiAlias)
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Size offset = new Size(Convert.ToInt16(this.Width / 2), Convert.ToInt16(this.Height / 2));
            g.Clear(Color.White);

            foreach (Modal m in this.Modals)
            {
                m.Rotate();
                m.Draw(g, offset);
            }
        }

        public Modal AddModal(Modal m)
        {
            this.Modals.Add(m);
            return m;
        }
    }
}
