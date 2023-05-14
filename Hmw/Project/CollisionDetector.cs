using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project
{
    internal static class CollisionDetector
    {


        public static bool DotQuadrilateral(Dot dot, Quadrilateral quad)
        {
            // Calculate the minimum and maximum x and y values for the rectangle
            double quadMinX = quad.center.X - quad.width / 2;
            double quadMaxX = quad.center.X + quad.width / 2;
            double quadMinY = quad.center.Y - quad.height / 2;
            double quadMaxY = quad.center.Y + quad.height / 2;

            // Check if the dot's center point is inside the rectangle
            if (dot.center.X >= quadMinX && dot.center.X <= quadMaxX &&
                dot.center.Y >= quadMinY && dot.center.Y <= quadMaxY)
            {
                return true;
            }

            // Otherwise, there is no collision
            return false;
        }



        public static bool DotCircle(Dot dot, Circle circle)
        {
            // Calculate the distance between the center of the dot and the center of the circle
            double distance = Math.Sqrt(Math.Pow(dot.center.X - circle.center.X, 2) + Math.Pow(dot.center.Y - circle.center.Y, 2));

            // Check if the distance is less than or equal to the radius of the circle
            if (distance <= circle.radius)
            {
                return true;
            }

            // Otherwise, there is no collision
            return false;
        }


        public static bool RectangleRectangle(Rectangle rect1, Rectangle rect2)
        {
            double rect1Left = rect1.center.X - rect1.width / 2.0;
            double rect1Right = rect1.center.X + rect1.width / 2.0;
            double rect1Top = rect1.center.Y + rect1.height / 2.0;
            double rect1Bottom = rect1.center.Y - rect1.height / 2.0;

            double rect2Left = rect2.center.X - rect2.width / 2.0;
            double rect2Right = rect2.center.X + rect2.width / 2.0;
            double rect2Top = rect2.center.Y + rect2.height / 2.0;
            double rect2Bottom = rect2.center.Y - rect2.height / 2.0;

            if (rect1Left > rect2Right || rect1Right < rect2Left || rect1Top < rect2Bottom || rect1Bottom > rect2Top)
            {
                return false; // No collision
            }
            else
            {
                return true; // Collision detected
            }
        }


        public static bool RectangleCircle(Rectangle rect, Circle circle)
        {
            // Find the closest point to the circle within the rectangle
            double closestX = Math.Max(rect.center.X - rect.width / 2, Math.Min(circle.center.X, rect.center.X + rect.width / 2));
            double closestY = Math.Max(rect.center.Y - rect.height / 2, Math.Min(circle.center.Y, rect.center.Y + rect.height / 2));

            // Calculate the distance between the closest point and the circle's center
            double distanceX = circle.center.X - closestX;
            double distanceY = circle.center.Y - closestY;
            double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            // If the distance is less than the circle's radius, there is a collision
            return distance <= circle.radius;
        }


        public static bool CircleCircle(Circle circle1, Circle circle2)
        {
            // Calculate the distance between the centers of the circles
            double distance = Math.Sqrt(Math.Pow(circle2.center.X - circle1.center.X, 2) + Math.Pow(circle2.center.Y - circle1.center.Y, 2));

            // If the distance is less than the sum of the radii, there is a collision
            return distance <= circle1.radius + circle2.radius;
        }


        public static bool DotSphere(Dot dot, Sphere sphere)
        {
            // Calculate the distance between the center of the sphere and the point
            double distance = Math.Sqrt(Math.Pow(sphere.center.X - dot.center.X, 2) + Math.Pow(sphere.center.Y - dot.center.Y, 2) + Math.Pow(sphere.center.Z - dot.center.Z, 2));

            // If the distance is less than or equal to the radius of the sphere, there is a collision
            return distance <= sphere.radius;
        }


        public static bool DotRectangularPrism(Dot dot, RectangularPrism prism)
        {
            // Find the closest point on the prism to the dot
            double closestX = Math.Max(prism.center.X - prism.width / 2, Math.Min(dot.center.X, prism.center.X + prism.width / 2));
            double closestY = Math.Max(prism.center.Y - prism.height / 2, Math.Min(dot.center.Y, prism.center.Y + prism.height / 2));

            // Find the distance between the closest point and the dot
            double distance = Math.Sqrt(Math.Pow(closestX - dot.center.X, 2) + Math.Pow(closestY - dot.center.Y, 2));

            // If the distance is less than or equal to the dot radius, they collide
            return distance <= 0;
        }


        public static bool DotCylinder(Dot dot, Cylinder cylinder)
        {
            double distance = Math.Sqrt(Math.Pow(dot.center.X - cylinder.center.X, 2) + Math.Pow(dot.center.Y - cylinder.center.Y, 2));
            // Check if the distance is less than the sum of the radius of the cylinder and the radius of the dot  // Check if the dot is inside the height of the cylinder
            if (distance <= cylinder.radius && dot.center.Z >= cylinder.center.Z && dot.center.Z <= cylinder.center.Z + cylinder.height)
            {
                return true;
            }

            return false;
        }

        public static bool CylinderCylinder(Cylinder cylinder1, Cylinder cylinder2)
        {
            //İki silindirin merkezleri arasındaki mesafeyi hesaplar
            double distance = Math.Sqrt(Math.Pow(cylinder1.center.X - cylinder2.center.X, 2) +
                                        Math.Pow(cylinder1.center.Y - cylinder2.center.Y, 2) +
                                        Math.Pow(cylinder1.center.Z - cylinder2.center.Z, 2));
           
            //bu mesafenin, silindirlerin yarıçaplarının toplamından küçük ve silindirlerin yüksekliklerinin farkının mutlak değeri, yüksekliklerin toplamının yarısından küçük veya eşit olması durumunda silindirlerin çarpıştığına karar verir
            return distance <= (cylinder1.radius + cylinder2.radius) &&
              Math.Abs(cylinder1.center.Z - cylinder2.center.Z) <= (cylinder1.height + cylinder2.height) / 2;
        }


        public static bool SphereSphere(Sphere sphere1, Sphere sphere2)
        {
            // Küreler arası mesafe hesaplanıyor.
            // düzelt double distance = (sphere1.center - sphere2.center).Length;
            double distance = sphere1.center.X-  sphere2.center.X;
            // Kürelerin yarıçaplarının toplamı alınıyor.
            double sumOfRadius = sphere1.radius + sphere2.radius;

            // Küreler arası mesafe yarıçapların toplamından küçük veya eşitse çarpışma var.
            return distance <= sumOfRadius;
        }


        public static bool SphereCylinder(Sphere sphere, Cylinder cylinder)
        {
            // Küre merkezi ile silindir merkezi arasındaki uzaklığı hesaplayın
            double distance = Math.Sqrt(Math.Pow(sphere.center.X - cylinder.center.X, 2) +
                                        Math.Pow(sphere.center.Y - cylinder.center.Y, 2) +
                                        Math.Pow(sphere.center.Z - cylinder.center.Z, 2));

            // Kürenin yarıçapı ile silindirin yarıçapı toplamı
            // silindir ve kürenin birbirine çarpması için gereken minimum mesafedir.
            double minDistance = sphere.radius + cylinder.radius;

            // Eğer minimum mesafeden daha küçükse, çarpışma var demektir
            if (distance < minDistance)
            {
                return true;
            }

            // Aksi takdirde, çarpışma yok demektir.
            return false;
        }


        public static bool SurfaceSphere(Surface surface, Sphere sphere)
        {
            float dx = Math.Max(surface.center.X - sphere.center.X, 0);
            dx = Math.Max(dx, sphere.center.X - (surface.center.X + surface.width));

            float dy = Math.Max(surface.center.Y - sphere.center.Y, 0);
            dy = Math.Max(dy, sphere.center.Y - (surface.center.Y + surface.height));

            float dz = Math.Max(surface.center.Z - sphere.center.Z, 0);
            dz = Math.Max(dz, sphere.center.Z - (surface.center.Z + surface.center.Z));

            float distance = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);

            // If the distance is less than or equal to the sphere radius, they are colliding
            return distance <= sphere.radius;
        }


        public static bool SurfaceRectangularPrism(Surface surface, RectangularPrism prism)
        {
            float halfWidth = prism.width / 2;
            float halfHeight = prism.height / 2;
            Point3D prismCenter = prism.center;

            // Calculate the distances between the centers of the shapes
            float dx = Math.Abs(prismCenter.X - surface.center.X);
            float dy = Math.Abs(prismCenter.Y - surface.center.Y);
            float dz = Math.Abs(prismCenter.Z - surface.center.Z);

            // Check if the shapes intersect in the x-axis
            if (dx > (halfWidth + surface.width / 2)) return false;

            // Check if the shapes intersect in the y-axis
            if (dy > (halfHeight + surface.height / 2)) return false;

            // Check if the shapes intersect in the z-axis
            if (dz > (halfWidth + surface.width / 2)) return false;

            // The shapes intersect
            return true;
        }


        public static bool SurfaceCylinder(Surface surface, Cylinder cyl)
        {
            float minX = surface.center.X - surface.width / 2;
            float maxX = surface.center.X + surface.width / 2;
            float minZ = surface.center.Z - surface.height / 2;
            float maxZ = surface.center.Z + surface.height / 2;

            // Calculate the distance between the cylinder center and the rectangle center on the xz plane
            float dx = cyl.center.X - surface.center.X;
            float dz = cyl.center.Z - surface.center.Z;
            float dist2D = (float)Math.Sqrt(dx * dx + dz * dz);

            // If the distance between the centers on the xz plane is greater than the sum of the
            // cylinder radius and half the rectangle diagonal length, they don't intersect
            if (dist2D > cyl.radius + (float)Math.Sqrt(surface.width * surface.width + surface.height * surface.height) / 2)
            {
                return false;
            }

            // If the distance between the cylinder center and the rectangle center on the y axis
            // is greater than half the cylinder height plus half the rectangle height, they don't intersect
            if (Math.Abs(cyl.center.Y - surface.center.Y) > cyl.height / 2 + surface.height / 2)
            {
                return false;
            }

            // They intersect
            return true;
        }


        public static bool SphereRectangularPrism(Sphere sphere, RectangularPrism prism) 
        {
            float distanceX = Math.Abs(sphere.center.X - prism.center.X);
            float distanceY = Math.Abs(sphere.center.Y - prism.center.Y);
            float distanceZ = Math.Abs(sphere.center.Z - prism.center.Z);

            // Check if sphere is outside prism bounds
            if (distanceX > (prism.width / 2 + sphere.radius)) return false;
            if (distanceY > (prism.height / 2 + sphere.radius)) return false;
            if (distanceZ > (prism.center.Z / 2 + sphere.radius)) return false;

            // Check if sphere is inside prism bounds
            if (distanceX <= (prism.width / 2)) return true;
            if (distanceY <= (prism.height / 2)) return true;
            if (distanceZ <= (prism.center.Z / 2)) return true;

            // Check if sphere collides with prism edges
            float distX = distanceX - prism.width / 2;
            float distY = distanceY - prism.height / 2;
            float distZ = distanceZ - prism.center.Z / 2;
            float cornerDist = distX * distX + distY * distY + distZ * distZ;

            return cornerDist <= (sphere.radius * sphere.radius);

        }

        public static bool RectangularPrism_RectangularPrism(RectangularPrism prism1, RectangularPrism prism2)
        {
            // find the min and max x, y, z values for each prism
            float min1X = prism1.center.X - prism1.width / 2f;
            float max1X = prism1.center.X + prism1.width / 2f;
            float min1Y = prism1.center.Y - prism1.height / 2f;
            float max1Y = prism1.center.Y + prism1.height / 2f;
            float min1Z = prism1.center.Z - prism1.center.Z / 2f;
            float max1Z = prism1.center.Z + prism1.center.Z / 2f;

            float min2X = prism2.center.X - prism2.width / 2f;
            float max2X = prism2.center.X + prism2.width / 2f;
            float min2Y = prism2.center.Y - prism2.height / 2f;
            float max2Y = prism2.center.Y + prism2.height / 2f;
            float min2Z = prism2.center.Z - prism2.center.Z / 2f;
            float max2Z = prism2.center.Z + prism2.center.Z / 2f;

            // check for overlap in x, y, and z
            if (min1X <= max2X && max1X >= min2X &&
                min1Y <= max2Y && max1Y >= min2Y &&
                min1Z <= max2Z && max1Z >= min2Z)
            {
                // the prisms are colliding
                return true;
            }
            else
            {
                // the prisms are not colliding
                return false;
            }
        }
    }
}
