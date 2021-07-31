using System;
using System.Collections.Generic;
using System.Text;

namespace Perspective
{
    public class Vector
    {
        public double x;
        public double y;
        public double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector Copy()
        {
            return new Vector(this.x, this.y, this.x);
        }

        public override string ToString()
        {
            return "{x: " + this.x + ",y: " + this.y + ",z: " + this.z + "}";
        }

        public double CalculateNormal()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public double DotProduct(Vector v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector CrossProduct(Vector v)
        {
            Vector r = new Vector();
            r.x = this.y * v.z - this.z * v.y;
            r.y = this.z * v.x - this.x * v.z;
            r.z = this.x * v.y - this.y * v.x;

            return r;
        }

        public Vector UnitVector()
        {
            Vector Unit = this.Copy();
            double Normal = this.CalculateNormal();

            if (Normal != 0)
            {
                Unit.x = Unit.x / Normal;
                Unit.y = Unit.y / Normal;
                Unit.z = Unit.z / Normal;
            }

            return Unit;
        }

        public void Normalize()
        {
            double Normal = this.CalculateNormal();

            if (Normal != 0)
            {
                this.x /= Normal;
                this.y /= Normal;
                this.z /= Normal;
            }
        }

        public void AddVector(Vector v)
        {
            this.x += v.x;
            this.y += v.y;
            this.z += v.z;

        }
        /*
	    function New_AddVector($v: TVector): TVector
	    {
		    var v = new TVector(0,0,0);
		    v.x = x + $v.x;
		    v.y = y + $v.y;
		    v.z = z + $v.z;
    		
		    return v;
	    }
    	*/
        public void SubtractVector(Vector v)
        {
            this.x -= v.x;
            this.y -= v.y;
            this.z -= v.z;

        }
        
	    public Vector New_SubtractVector(Vector v)
	    {
		    Vector n = new Vector();
		    n.x = this.x - v.x;
		    n.y = this.y - v.y;
		    n.z = this.z - v.z;
    		
		    return n;
	    }

        public void Multiply(double d)
        {
            this.x *= d;
            this.y *= d;
            this.z *= d;

        }

	    public Vector New_Multiply(double v)
	    {
		    Vector n = new Vector();
		    n.x = this.x * v;
		    n.y = this.y * v;
		    n.z = this.z * v;
    		
		    return n;
	    }

    }
}
