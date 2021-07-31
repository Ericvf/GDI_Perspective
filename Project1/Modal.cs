using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Perspective
{
    public class Modal : Vertex
    {
        protected const float RAD = 0.0174F;
        protected double x_dir;
        protected double y_dir;
        protected double z_dir;

        public Modal(): base()
        {
          //  this.Vertices = new List<Vertex>();
            // this.Faces = new List<Face>();
        }
        public Modal(double x, double y, double z): base(x, y, z)
        {
            //this.Vertices = new List<Vertex>();
            //this.Faces = new List<Face>();
        }
        public Modal(double x, double y, double z, double xd, double yd, double zd): base (x, y, z)
        {
            this.x_dir = xd;
            this.y_dir = yd;
            this.z_dir = zd;
        }

        protected virtual void DrawScene(Graphics g, Size offset)
        {

        }
        public void Draw(Graphics g, Size offset)
        {
            this.DrawScene(g, offset);
        }

        public virtual void Rotate()
        {
            if (this.x_dir == 0 && this.y_dir == 0 && this.z_dir == 0)
                return;

            double cosX = Math.Cos(this.x_dir * RAD);
            double sinX = Math.Sin(this.x_dir * RAD);

            double cosY = Math.Cos(this.y_dir * RAD);
            double sinY = Math.Sin(this.y_dir * RAD);

            double cosZ = Math.Cos(this.z_dir * RAD);
            double sinZ = Math.Sin(this.z_dir * RAD);

            double xy, xz, yx, yz, zx, zy;

            // Rotate around X-axis
            xy = cosX * this.y - sinX * this.z;
            xz = sinX * this.y + cosX * this.z;

            // Rotate around Y-axis
            yz = cosY * xz - sinY * this.x;
            yx = sinY * xz + cosY * this.x;

            // Rotate around Z-axis
            zx = cosZ * yx - sinZ * xy;
            zy = sinZ * yx + cosZ * xy;

            this.rX = zx;
            this.rY = zy;
            this.rZ = yz;

            this.x = zx;
            this.y = zy;
            this.z = yz;

            this.To2d(100);
        }

        public double DirectionX
        {
            get { return this.x_dir; }
            set { this.x_dir = value; }
        }
        public double DirectionY
        {
            get { return this.y_dir; }
            set { this.y_dir = value; }
        }
        public double DirectionZ
        {
            get { return this.z_dir; }
            set { this.z_dir = value; }
        }
    }
}
