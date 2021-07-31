using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Perspective
{
    public class Object : Light
    {
        protected List<Vertex> Vertices;
        protected List<Face> Faces;

        private int scale = 100;

        public Object(): base()
        {
            this.Vertices = new List<Vertex>();
            this.Faces = new List<Face>();
        }
        public Object(double x, double y, double z, double xd, double yd, double zd): base(x, y, z, xd, yd, zd)
        {
            this.Vertices = new List<Vertex>();
            this.Faces = new List<Face>();
        }

        public Vertex AddVertex(Vertex v)
        {
            this.Vertices.Add(v);
            return v;
        }
        public Vertex AddVertex(double x, double y, double z)
        {
            Vertex v = new Vertex(x, y, z);
            return this.AddVertex(v);
        }
        public Face AddFace(Face f, Vertex v1, Vertex v2, Vertex v3)
        {
            Face nf = f.Copy();

            nf.AddVertex(v1);
            nf.AddVertex(v2);
            nf.AddVertex(v3);

            this.Faces.Add(nf);
            return nf;
        }
        public int Scale
        {
            get { return this.scale; }
            set { this.scale = Math.Max(value, 100); }
        }

        public void RenderWorld(double xa, double ya, double za)
        {
            double cosX = Math.Cos(xa * RAD);
            double sinX = Math.Sin(xa * RAD);

            double cosY = Math.Cos(ya * RAD);
            double sinY = Math.Sin(ya * RAD);

            double cosZ = Math.Cos(za * RAD);
            double sinZ = Math.Sin(za * RAD);

            double xy, xz, yx, yz, zx, zy;
            foreach (Vertex v in this.Vertices)
            {
                // Rotate around X-axis
                xy = cosX * v.y - sinX * v.z;
                xz = sinX * v.y + cosX * v.z;

                // Rotate around Y-axis
                yz = cosY * xz - sinY * v.x;
                yx = sinY * xz + cosY * v.x;

                // Rotate around Z-axis
                zx = cosZ * yx - sinZ * xy;
                zy = sinZ * yx + cosZ * xy;

                // Scale distances
                v.rX = (zx / 100) * this.Scale;
                v.rY = (zy / 100) * this.Scale;
                v.rZ = (yz / 100) * this.Scale;

                v.x = zx;
                v.y = zy;
                v.z = yz;

                v.To2d(100);
            }
        }
        protected override void DrawScene(System.Drawing.Graphics g, System.Drawing.Size offset)
        {
            

            this.DoDrawFaces(g, offset);
            //this.DoDrawVertices(g, offset);

            base.DrawScene(g, offset);
        }

        protected void DoDrawVertices(Graphics g, Size offset)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            Pen pen = new Pen(Color.Red, 2);

            foreach (Vertex v in this.Vertices)
            {
                Point p = Point.Add(v.p2d, offset);
                pen.Width = Convert.ToInt32(-v.rZ / 15);

                float x = (float)p.X + this.p2d.X;
                float y = (float)p.Y + this.p2d.Y;
                float r = 0.5F;

                g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
            }
        }
        protected void DoDrawFaces(Graphics g, Size offset)
        {
            Pen pen = new Pen(Color.Red, 1);
            Color brush;

            this.Faces.Sort();
            offset.Width += this.p2d.X;
            offset.Height += this.p2d.Y;

            foreach (Face f in this.Faces)
            {
                if (f.FaceCulling())
                    continue;


                Point p1 = Point.Add(f.getVertex(0).p2d, offset);
                Point p2 = Point.Add(f.getVertex(1).p2d, offset);
                Point p3 = Point.Add(f.getVertex(2).p2d, offset);

                Point[] Points = new Point[] { p1, p2, p3 };
                brush = f.Color;
                /*
                if (this._useShading)
                {
                    if (this.Lights.Count > 0)
                    {
                        double Diffuse = 0;

                        double r, gc, b;
                        int currentColor = f.Color.ToArgb();
                        r = (currentColor >> 16) & 0xff;
                        gc = (currentColor >> 8) & 0xff;
                        b = (currentColor) & 0xff;

                        foreach (Light l in this.Lights)
                        {
                            Light light = l.Copy();
                            Vector FaceNormal = f.FindNormal();
                            FaceNormal.Normalize();
                            light.Normalize();
                            double LightAngle = light.DotProduct(FaceNormal) / 100;
                            double B = light.Brightness * Math.Max(LightAngle, 0);
                            if (B > 0) Diffuse += B;
                        }

                        r = Math.Min(r * Diffuse, 255);
                        gc = Math.Min(gc * Diffuse, 255);
                        b = Math.Min(b * Diffuse, 255);

                        brush = System.Drawing.Color.FromArgb((int)r, (int)gc, (int)b);
                    }
                    else
                    {
                        

                    }
                }
                */
                brush = f.CalculateShading();
                g.FillPolygon(new SolidBrush(brush), Points);

                //if (this._drawLines)
                //{
                    pen.Color = brush;
                    g.DrawPolygon(pen, Points);
                //}

                
            }
            pen.Dispose();
        }

        public override void Rotate()
        {
            base.Rotate();

            this.RenderWorld(this.x_dir, this.y_dir, this.z_dir);
        }
    }
}
