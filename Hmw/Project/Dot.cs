using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project
{
    internal class Dot:Shape
    {
        private Point3D p;

        public Dot(Point3D center)
        {
            p = center;
        }

        public Point3D center
        {
            get => p;
            set => p = value;
        }


    }


}

