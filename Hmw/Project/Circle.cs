using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project
{
    internal class Circle : Shape
    {
        private Point3D p;
        private float r;

        public Circle(Point3D center, float radius)
        {
            p = center;
            r = radius;
        }

        public Point3D center
        {
            get => p;
            set => p = value;
        }

        public float radius
        {
            get => r;
            set => r = value;
        }

    }
}
