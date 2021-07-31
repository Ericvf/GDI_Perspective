using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Perspective
{
    public class Face: IComparable
    {
        private List<Vertex> Vertices;
        public Color Color;

        public Face(Color c)
        {
            this.Vertices = new List<Vertex>();
            this.Color = c;
        }

        public Face Copy()
        {
            return new Face(this.Color);
        }

        public double MeanDepth
        {
            get
            {
                Vertex v1 = this.Vertices[0];
                Vertex v2 = this.Vertices[1];
                Vertex v3 = this.Vertices[2];

                return ((v1.rZ + v2.rZ + v3.rZ) / 3);
            }
        }

        public Color CalculateShading()
        {
            Vector FaceNormal = this.FindNormal();
		    double NormalLen  = FaceNormal.CalculateNormal();
            int currentColor  = this.Color.ToArgb();
            double r, g, b, a;

            a = (currentColor >> 24) & 0xff;
            r = (currentColor >> 16) & 0xff;
            g = (currentColor >> 8) & 0xff;
            b = (currentColor) & 0xff;

            if (NormalLen != 0)
            {
                double Diffuse = 1 - Math.Acos(-FaceNormal.z / NormalLen) / Math.PI;
                r = Math.Min(r * Diffuse, 255);
                g = Math.Min(g * Diffuse, 255);
                b = Math.Min(b * Diffuse, 255);
            }

            return System.Drawing.Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
/*
        public var Engine: TEngine3D;
        public var Vertices: Array;
        private var VClip: MovieClip;
        public var Style: TStyle;
        public var Type: Number;
        */
       // Constructor
        /*
        function TFace($fcolor, $falpha, $lthick, $lcolor, $lalpha)
        {
	        // Init Array
            Vertices = new Array();
            Style    = new TStyle(true, $lthick, $lcolor, $lalpha, true, $fcolor, $falpha);
	        Type = 0;
        }
    	
        // Getters and Setters
        function get length(): Number { return Vertices.length; }
        function get Clip(): MovieClip { return VClip; }
        function set Clip($mc: MovieClip) 
        {
	        var i = this;
	        VClip = $mc; 
	        VClip.onPress = function()
	        {
		        trace(this);
		        if (Key.isDown(Key.SHIFT))
		        {
			        _root.SelectedShapes.push(i);
			        return;
		        } 
		        else 
		        {
			        _root.SelectedShapes = new Array();
			        _root.SelectedShapes.push(i);
		        }
	        }
	        VClip.useHandCursor = false;
        }
    	
        public function Reverse()
        {
	        var p1 = Vertices[0];
	        var p3 = Vertices[2];
	        Vertices[0] = p3;
	        Vertices[2] = p1;
        }
    	
        public function ChangePlane()
        {
	        var p1 = Vertices[0];
	        var p2 = Vertices[1];
	        var p3 = Vertices[2];
	        Vertices[0] = p2;
	        Vertices[1] = p3;
	        Vertices[2] = p1;
        }
    	*/

        public void AddVertex(Vertex v)
        {
            this.Vertices.Add(v);
        }

        public bool FaceCulling()
        {
            Vertex v1 = this.Vertices[0];
            Vertex v2 = this.Vertices[1];
            Vertex v3 = this.Vertices[2];

	        double p0x = v1.x2d;
            double p0y = v1.y2d;
            double p1x = v2.x2d;
            double p1y = v2.y2d;
            double p2x = v3.x2d;
            double p2y = v3.y2d;
    		
	        return (p1x - p0x) * (p2y - p0y) - (p1y - p0y) * (p2x - p0x) > 0;
        }
    	
        public Vector FindNormal()
        {
            Vertex v1 = this.Vertices[0];
            Vertex v2 = this.Vertices[1];
            Vertex v3 = this.Vertices[2];

            Vector p0 = new Vector(v1.rX, v1.rY, v1.rZ);
            Vector p1 = new Vector(v2.rX, v2.rY, v2.rZ);
            Vector p2 = new Vector(v3.rX, v3.rY, v3.rZ);

	        Vector d1 = p0.New_SubtractVector(p1);
	        Vector d2 = p1.New_SubtractVector(p2);

            d1.Normalize();
            d2.Normalize();

            return d1.CrossProduct(d2);
        }


        public Vertex getVertex(int p)
        {
            if (this.Vertices.Count <= p)
                throw new ApplicationException("Vertex not found");

            return this.Vertices[p];
        }

        public int CompareTo(object obj)
        {
            if ((obj as Face).MeanDepth > this.MeanDepth)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
