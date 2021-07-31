using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Perspective
{
    public class Light: Modal
    {
        public int Brightness = 35;

        public Light(): base()
        {
        }
        public Light(double x, double y, double z): base(x, y, z)
        {

        }
        public Light(double x, double y, double z, double xd, double yd, double zd): base(x, y, z, xd, yd, zd)
        {

        }

        protected override void DrawScene(Graphics g, Size offset)
        {
            Point p = Point.Add(this.p2d, offset);
            int r = Convert.ToInt32(-this.rZ / 20);

            if (r <= 0) r = 1;
                g.FillEllipse(new SolidBrush(Color.Red), p.X-r, p.Y-r, r*2, r*2);
        }

        public override string ToString()
        {
            return "{x: " + this.x + ", y: " + this.y + ", z: " + this.z + "}";
        }
        public new Light Copy()
        {
            return new Light(this.x, this.y, this.z, this.DirectionX, this.DirectionY, this.DirectionZ);
        }
    }
}
