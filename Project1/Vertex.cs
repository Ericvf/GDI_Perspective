using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Perspective
{
    public class Vertex: Vector
    {
        private double rx;
        private double ry;
        private double rz;

        private double _x2d;
        private double _y2d;

        public Vertex(): base()
        {
        }
        public Vertex(double x, double y, double z): base(x, y, z)
        {
            this.rx = x;
            this.ry = y;
            this.rz = z;
        }

        public double rX
        {
            get { return this.rx; }
            set { this.rx = value; }
        }
        public double rY
        {
            get { return this.ry; }
            set { this.ry = value; }
        }
        public double rZ
        {
            get { return this.rz; }
            set { this.rz = value; }
        }

        public double x2d
        {
            get
            {
                return this._x2d;
            }
        }
        public double y2d
        {
            get
            {
                return this._y2d;
            }
        }
        public Point p2d
        {
            get { return new Point(Convert.ToInt32(this._x2d), Convert.ToInt32(this._y2d)); }
        }

        
        public void To2d(int FocalLength)
        {
            double d = FocalLength / (FocalLength + this.z);

		    this._x2d = this.rx * d;
		    this._y2d = this.ry * d;
        }
    }
}
