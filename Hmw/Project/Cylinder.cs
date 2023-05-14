using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project
{
    internal class Cylinder : Shape
    {
        private Point3D p;
        private float r;
        private float h;

        public Cylinder(Point3D center, float radius, float height)
        {
            p = center;
            r = radius;
            h = height;
        }

        public  Point3D center
        {
            get => p;
            set => p = value;
        }

        public float radius
        {
            get => r;
            set => r = value;
        }

        public float height
        {
            get => h;
            set => h = value;
        }

    }
    
}
