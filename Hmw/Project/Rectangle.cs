using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project
{
    internal class Rectangle: Shape
    {
        private Point3D p;
        private float w;
        private float h;

        public Rectangle(Point3D center, float width, float height)
        {
            p = center;
            w = width;
            h = height;
        }

        public Point3D center
        {
            get => p;
            set => p = value;
        }

        public float width
        {
            get => w;
            set => w = value;
        }

        public float height
        {
            get => h;
            set => h = value;
        }
    }
}
