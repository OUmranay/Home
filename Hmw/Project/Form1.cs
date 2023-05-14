using System;
using System.Drawing;
using System.Windows.Media.Media3D;
namespace Project
{

    public partial class Form1 : Form
    {
        Random random = new Random();
        private List<Shape> shapes = new List<Shape>();
        Boolean carpisma = false;

        int oteleme = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void btn_nokta_Click(object sender, EventArgs e)
        {

            Dot nokta = new Dot(new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(5, 10)));
            Quadrilateral dortgen = new Quadrilateral((new Point3D(random.Next(50, 100), random.Next(5, 10), random.Next(5, 10))), random.Next(50, 100), random.Next(50, 100));
            Circle cember = new Circle((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            Sphere kure = new Sphere((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            RectangularPrism dikdortgenPrizma = new RectangularPrism((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100), random.Next(50, 100));
            Cylinder silindir = new Cylinder((new Point3D(random.Next(50, 100), random.Next(50, 100), random.Next(30, 50))), random.Next(50, 100), random.Next(100, 150));


            shapes.Add(dortgen);
            shapes.Add(cember);
            shapes.Add(kure);
            shapes.Add(dikdortgenPrizma);
            shapes.Add(silindir);


            int rdm = random.Next(0, shapes.Count);



            Graphics graphics = panel1.CreateGraphics();

            graphics.DrawRectangle(Pens.White, (float)nokta.center.X + oteleme, (float)nokta.center.Y + oteleme, 1, 1);

            if (shapes[rdm] is Quadrilateral)
            {

                graphics.DrawRectangle(Pens.White, (float)dortgen.center.X - (dortgen.width / 2), (float)dortgen.center.Y - (dortgen.height / 2), dortgen.width, dortgen.height);
                carpisma = CollisionDetector.DotQuadrilateral(nokta, dortgen);
            }
            else if (shapes[rdm] is Circle)
            {
                graphics.DrawEllipse(Pens.White, (float)cember.center.X - cember.radius, (float)cember.center.Y - cember.radius, 2 * cember.radius, 2 * cember.radius);
                carpisma = CollisionDetector.DotCircle(nokta, cember);
            }
            else if (shapes[rdm] is Sphere)
            {
                graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y - kure.radius, 2 * kure.radius, 2 * kure.radius);
                graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y, (float)kure.center.X + kure.radius, (float)kure.center.Y - kure.radius);
                carpisma = CollisionDetector.DotSphere(nokta, kure);

            }
            else if (shapes[rdm] is RectangularPrism)
            {
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width / 2), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height / 2), dikdortgenPrizma.width, dikdortgenPrizma.height);
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height), dikdortgenPrizma.width, dikdortgenPrizma.height);
                // Calculate the corners of the first rectangle
                float x1 = (float)dikdortgenPrizma.center.X - (float)(dikdortgenPrizma.width / 2);
                float y1 = (float)dikdortgenPrizma.center.Y - (float)(dikdortgenPrizma.height / 2);
                float x2 = (float)dikdortgenPrizma.center.X + (float)(dikdortgenPrizma.width / 2);
                float y2 = (float)dikdortgenPrizma.center.Y + (float)(dikdortgenPrizma.height / 2);

                // Calculate the corners of the second rectangle
                float x3 = (float)dikdortgenPrizma.center.X - (float)dikdortgenPrizma.width;
                float y3 = (float)dikdortgenPrizma.center.Y - (float)dikdortgenPrizma.height;
                float x4 = (float)dikdortgenPrizma.center.X;
                float y4 = (float)dikdortgenPrizma.center.Y;

                // Draw the four connecting lines
                graphics.DrawLine(Pens.White, x1, y1, x3, y3);
                graphics.DrawLine(Pens.White, x2, y1, x4, y3);
                graphics.DrawLine(Pens.White, x2, y2, x4, y4);
                graphics.DrawLine(Pens.White, x1, y2, x3, y4);

                carpisma = CollisionDetector.DotRectangularPrism(nokta, dikdortgenPrizma);
            }

            else if (shapes[rdm] is Cylinder)
            {

                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the bottom circle
                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the vertical lines connecting the two circles
                graphics.DrawLine(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height);
                graphics.DrawLine(Pens.White, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y + silindir.height);

                carpisma = CollisionDetector.DotCylinder(nokta, silindir);
            }


            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;
            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }
        }
        private void btn_dikdortgen_Click(object sender, EventArgs e)
        {

            Circle cember = new Circle((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            Rectangle dikdortgen = new Rectangle((new Point3D(random.Next(50, 100), random.Next(5, 10), random.Next(5, 10))), random.Next(50, 100), random.Next(50, 100));

            Rectangle dikdortgen_2 = new Rectangle((new Point3D(random.Next(50, 100), random.Next(5, 10), random.Next(5, 10))), random.Next(50, 100), random.Next(50, 100));

            shapes.Add(cember);

            shapes.Add(dikdortgen_2);



            int rdm = random.Next(0, shapes.Count);


            Graphics graphics = panel1.CreateGraphics();
            graphics.DrawRectangle(Pens.White, (float)dikdortgen.center.X - (dikdortgen.width / 2) + oteleme, (float)dikdortgen.center.Y - (dikdortgen.height / 2) + oteleme, dikdortgen.width, dikdortgen.height);


            if (shapes[rdm] is Rectangle)
            {
                graphics.DrawRectangle(Pens.White, (float)dikdortgen.center.X - (dikdortgen.width / 2), (float)dikdortgen.center.Y - (dikdortgen.height / 2), dikdortgen.width, dikdortgen.height);

                carpisma = CollisionDetector.RectangleRectangle(dikdortgen, dikdortgen_2);
            }

            else if (shapes[rdm] is Circle)
            {

                graphics.DrawEllipse(Pens.White, (float)cember.center.X - cember.radius, (float)cember.center.Y - cember.radius, 2 * cember.radius, 2 * cember.radius);
                carpisma = CollisionDetector.RectangleCircle(dikdortgen, cember);
            }

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;
            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }
        }

        private void btn_cember_Click(object sender, EventArgs e)
        {


            Graphics graphics = panel1.CreateGraphics();
            Circle cember_1 = new Circle((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));

            Circle cember_2 = new Circle((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));

            graphics.DrawEllipse(Pens.White, (float)cember_1.center.X - cember_1.radius + oteleme, (float)cember_1.center.Y - cember_1.radius + oteleme, 2 * cember_1.radius, 2 * cember_1.radius);
            graphics.DrawEllipse(Pens.White, (float)cember_2.center.X - cember_2.radius, (float)cember_2.center.Y - cember_2.radius, 2 * cember_2.radius, 2 * cember_2.radius);


            carpisma = CollisionDetector.CircleCircle(cember_1, cember_2);

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;
            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }

        }

        private void btn_silindir_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Cylinder silindir_1 = new Cylinder((new Point3D(random.Next(50, 100), random.Next(50, 100), random.Next(30, 50))), random.Next(50, 100), random.Next(100, 150));

            Cylinder silindir_2 = new Cylinder((new Point3D(random.Next(50, 100), random.Next(50, 100), random.Next(30, 50))), random.Next(50, 100), random.Next(100, 150));


            graphics.DrawEllipse(Pens.White, (float)silindir_1.center.X - silindir_1.radius, (float)silindir_1.center.Y - silindir_1.radius, 2 * silindir_1.radius, 2 * silindir_1.radius);
            graphics.DrawEllipse(Pens.White, (float)silindir_1.center.X - silindir_1.radius, (float)silindir_1.center.Y + silindir_1.height - silindir_1.radius, 2 * silindir_1.radius, 2 * silindir_1.radius);
            graphics.DrawLine(Pens.White, (float)silindir_1.center.X - silindir_1.radius, (float)silindir_1.center.Y, (float)silindir_1.center.X - silindir_1.radius, (float)silindir_1.center.Y + silindir_1.height);
            graphics.DrawLine(Pens.White, (float)silindir_1.center.X + silindir_1.radius, (float)silindir_1.center.Y, (float)silindir_1.center.X + silindir_1.radius, (float)silindir_1.center.Y + silindir_1.height);

            graphics.DrawEllipse(Pens.White, (float)silindir_2.center.X - silindir_2.radius, (float)silindir_2.center.Y - silindir_2.radius, 2 * silindir_2.radius, 2 * silindir_2.radius);
            graphics.DrawEllipse(Pens.White, (float)silindir_2.center.X - silindir_2.radius, (float)silindir_2.center.Y + silindir_2.height - silindir_2.radius, 2 * silindir_2.radius, 2 * silindir_2.radius);
            graphics.DrawLine(Pens.White, (float)silindir_2.center.X - silindir_2.radius, (float)silindir_2.center.Y, (float)silindir_2.center.X - silindir_2.radius, (float)silindir_2.center.Y + silindir_2.height);
            graphics.DrawLine(Pens.White, (float)silindir_2.center.X + silindir_2.radius, (float)silindir_2.center.Y, (float)silindir_2.center.X + silindir_2.radius, (float)silindir_2.center.Y + silindir_2.height);

            carpisma = CollisionDetector.CylinderCylinder(silindir_1, silindir_2);

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;
            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }

        }

        private void btn_kure_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Sphere kure = new Sphere((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            Sphere kure_2 = new Sphere((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            shapes.Add(kure_2);
            Cylinder silindir = new Cylinder((new Point3D(random.Next(50, 100), random.Next(50, 100), random.Next(30, 50))), random.Next(50, 100), random.Next(100, 150));
            shapes.Add(silindir);
            RectangularPrism dikdortgenPrizma = new RectangularPrism((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100), random.Next(50, 100));
            shapes.Add(dikdortgenPrizma);

            graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y - kure.radius, 2 * kure.radius, 2 * kure.radius);
            graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y, (float)kure.center.X + kure.radius, (float)kure.center.Y - kure.radius);

            int rdm = random.Next(0, shapes.Count);


            if (shapes[rdm] is Sphere)
            {
                graphics.DrawEllipse(Pens.White, (float)kure_2.center.X - kure_2.radius, (float)kure_2.center.Y - kure_2.radius, 2 * kure_2.radius, 2 * kure_2.radius);
                graphics.DrawEllipse(Pens.White, (float)kure_2.center.X - kure_2.radius, (float)kure_2.center.Y, (float)kure_2.center.X + kure_2.radius, (float)kure_2.center.Y - kure_2.radius);

                carpisma = CollisionDetector.SphereSphere(kure, kure_2);
            }

            else if (shapes[rdm] is Cylinder)
            {
                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the bottom circle
                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the vertical lines connecting the two circles
                graphics.DrawLine(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height);
                graphics.DrawLine(Pens.White, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y + silindir.height);

                carpisma = CollisionDetector.SphereCylinder(kure, silindir);

            }

            else if (shapes[rdm] is RectangularPrism)
            {
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width / 2), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height / 2), dikdortgenPrizma.width, dikdortgenPrizma.height);
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height), dikdortgenPrizma.width, dikdortgenPrizma.height);
                // Calculate the corners of the first rectangle
                float x1 = (float)dikdortgenPrizma.center.X - (float)(dikdortgenPrizma.width / 2);
                float y1 = (float)dikdortgenPrizma.center.Y - (float)(dikdortgenPrizma.height / 2);
                float x2 = (float)dikdortgenPrizma.center.X + (float)(dikdortgenPrizma.width / 2);
                float y2 = (float)dikdortgenPrizma.center.Y + (float)(dikdortgenPrizma.height / 2);

                // Calculate the corners of the second rectangle
                float x3 = (float)dikdortgenPrizma.center.X - (float)dikdortgenPrizma.width;
                float y3 = (float)dikdortgenPrizma.center.Y - (float)dikdortgenPrizma.height;
                float x4 = (float)dikdortgenPrizma.center.X;
                float y4 = (float)dikdortgenPrizma.center.Y;

                // Draw the four connecting lines
                graphics.DrawLine(Pens.White, x1, y1, x3, y3);
                graphics.DrawLine(Pens.White, x2, y1, x4, y3);
                graphics.DrawLine(Pens.White, x2, y2, x4, y4);
                graphics.DrawLine(Pens.White, x1, y2, x3, y4);

                carpisma = CollisionDetector.SphereRectangularPrism(kure, dikdortgenPrizma);
            }

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;
            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }

        }

        private void btn_yuzey_Click(object sender, EventArgs e)
        {
            Surface yuzey = new Surface((new Point3D(random.Next(50, 100), random.Next(5, 10), random.Next(5, 10))), random.Next(50, 100), random.Next(50, 100));
            shapes.Add(yuzey);
            Sphere kure = new Sphere((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100));
            shapes.Add(kure);
            RectangularPrism dikdortgenPrizma = new RectangularPrism((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100), random.Next(50, 100));
            shapes.Add(dikdortgenPrizma);
            Cylinder silindir = new Cylinder((new Point3D(random.Next(50, 100), random.Next(50, 100), random.Next(30, 50))), random.Next(50, 100), random.Next(100, 150));
            shapes.Add(silindir);

            Graphics graphics = panel1.CreateGraphics();
            graphics.DrawRectangle(Pens.White, (float)yuzey.center.X - (yuzey.width / 2) + oteleme, (float)yuzey.center.Y - (yuzey.height / 2) + oteleme, yuzey.width, yuzey.height);


            int rdm = random.Next(0, shapes.Count);


            if (shapes[rdm] is Sphere)
            {
                graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y - kure.radius, 2 * kure.radius, 2 * kure.radius);
                graphics.DrawEllipse(Pens.White, (float)kure.center.X - kure.radius, (float)kure.center.Y, (float)kure.center.X + kure.radius, (float)kure.center.Y - kure.radius);

                carpisma = CollisionDetector.SurfaceSphere(yuzey, kure);
            }

            else if (shapes[rdm] is RectangularPrism)
            {
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width / 2), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height / 2), dikdortgenPrizma.width, dikdortgenPrizma.height);
                graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma.center.X - (dikdortgenPrizma.width), (float)dikdortgenPrizma.center.Y - (dikdortgenPrizma.height), dikdortgenPrizma.width, dikdortgenPrizma.height);
                // Calculate the corners of the first rectangle
                float x1 = (float)dikdortgenPrizma.center.X - (float)(dikdortgenPrizma.width / 2);
                float y1 = (float)dikdortgenPrizma.center.Y - (float)(dikdortgenPrizma.height / 2);
                float x2 = (float)dikdortgenPrizma.center.X + (float)(dikdortgenPrizma.width / 2);
                float y2 = (float)dikdortgenPrizma.center.Y + (float)(dikdortgenPrizma.height / 2);

                // Calculate the corners of the second rectangle
                float x3 = (float)dikdortgenPrizma.center.X - (float)dikdortgenPrizma.width;
                float y3 = (float)dikdortgenPrizma.center.Y - (float)dikdortgenPrizma.height;
                float x4 = (float)dikdortgenPrizma.center.X;
                float y4 = (float)dikdortgenPrizma.center.Y;

                // Draw the four connecting lines
                graphics.DrawLine(Pens.White, x1, y1, x3, y3);
                graphics.DrawLine(Pens.White, x2, y1, x4, y3);
                graphics.DrawLine(Pens.White, x2, y2, x4, y4);
                graphics.DrawLine(Pens.White, x1, y2, x3, y4);

                carpisma = CollisionDetector.SurfaceRectangularPrism(yuzey, dikdortgenPrizma);


            }

            else if (shapes[rdm] is Cylinder)
            {
                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the bottom circle
                graphics.DrawEllipse(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height - silindir.radius, 2 * silindir.radius, 2 * silindir.radius);

                // Draw the vertical lines connecting the two circles
                graphics.DrawLine(Pens.White, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y, (float)silindir.center.X - silindir.radius, (float)silindir.center.Y + silindir.height);
                graphics.DrawLine(Pens.White, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y, (float)silindir.center.X + silindir.radius, (float)silindir.center.Y + silindir.height);

                carpisma = CollisionDetector.SurfaceCylinder(yuzey, silindir);
            }

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;

            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }
        }

        private void btn_prizma_Click(object sender, EventArgs e)
        {
            RectangularPrism dikdortgenPrizma_1 = new RectangularPrism((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100), random.Next(50, 100));
            shapes.Add(dikdortgenPrizma_1);
            RectangularPrism dikdortgenPrizma_2 = new RectangularPrism((new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(50, 100))), random.Next(50, 100), random.Next(50, 100));
            shapes.Add(dikdortgenPrizma_2);

            Graphics graphics = panel1.CreateGraphics();

            graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma_1.center.X - (dikdortgenPrizma_1.width / 2), (float)dikdortgenPrizma_1.center.Y - (dikdortgenPrizma_1.height / 2), dikdortgenPrizma_1.width, dikdortgenPrizma_1.height);
            graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma_1.center.X - (dikdortgenPrizma_1.width), (float)dikdortgenPrizma_1.center.Y - (dikdortgenPrizma_1.height), dikdortgenPrizma_1.width, dikdortgenPrizma_1.height);

            float x1 = (float)dikdortgenPrizma_1.center.X - (float)(dikdortgenPrizma_1.width / 2);
            float y1 = (float)dikdortgenPrizma_1.center.Y - (float)(dikdortgenPrizma_1.height / 2);
            float x2 = (float)dikdortgenPrizma_1.center.X + (float)(dikdortgenPrizma_1.width / 2);
            float y2 = (float)dikdortgenPrizma_1.center.Y + (float)(dikdortgenPrizma_1.height / 2);
            float x3 = (float)dikdortgenPrizma_1.center.X - (float)dikdortgenPrizma_1.width;
            float y3 = (float)dikdortgenPrizma_1.center.Y - (float)dikdortgenPrizma_1.height;
            float x4 = (float)dikdortgenPrizma_1.center.X;
            float y4 = (float)dikdortgenPrizma_1.center.Y;

            graphics.DrawLine(Pens.White, x1, y1, x3, y3);
            graphics.DrawLine(Pens.White, x2, y1, x4, y3);
            graphics.DrawLine(Pens.White, x2, y2, x4, y4);
            graphics.DrawLine(Pens.White, x1, y2, x3, y4);


            graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma_2.center.X - (dikdortgenPrizma_2.width / 2), (float)dikdortgenPrizma_2.center.Y - (dikdortgenPrizma_2.height / 2), dikdortgenPrizma_2.width, dikdortgenPrizma_2.height);
            graphics.DrawRectangle(Pens.White, (float)dikdortgenPrizma_2.center.X - (dikdortgenPrizma_2.width), (float)dikdortgenPrizma_2.center.Y - (dikdortgenPrizma_2.height), dikdortgenPrizma_2.width, dikdortgenPrizma_2.height);

            float x_1 = (float)dikdortgenPrizma_2.center.X - (float)(dikdortgenPrizma_2.width / 2);
            float y_1 = (float)dikdortgenPrizma_2.center.Y - (float)(dikdortgenPrizma_2.height / 2);
            float x_2 = (float)dikdortgenPrizma_2.center.X + (float)(dikdortgenPrizma_2.width / 2);
            float y_2 = (float)dikdortgenPrizma_2.center.Y + (float)(dikdortgenPrizma_2.height / 2);
            float x_3 = (float)dikdortgenPrizma_2.center.X - (float)dikdortgenPrizma_2.width;
            float y_3 = (float)dikdortgenPrizma_2.center.Y - (float)dikdortgenPrizma_2.height;
            float x_4 = (float)dikdortgenPrizma_2.center.X;
            float y_4 = (float)dikdortgenPrizma_2.center.Y;

            graphics.DrawLine(Pens.White, x_1, y_1, x_3, y_3);
            graphics.DrawLine(Pens.White, x_2, y_1, x_4, y_3);
            graphics.DrawLine(Pens.White, x_2, y_2, x_4, y_4);
            graphics.DrawLine(Pens.White, x_1, y_2, x_3, y_4);

            carpisma = CollisionDetector.RectangularPrism_RectangularPrism(dikdortgenPrizma_1, dikdortgenPrizma_2);

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;

            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }
        }

        private void btn_dortgen_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Quadrilateral dortgen = new Quadrilateral((new Point3D(random.Next(50, 100), random.Next(5, 10), random.Next(5, 10))), random.Next(50, 100), random.Next(50, 100));
            Dot nokta = new Dot(new Point3D(random.Next(70, 100), random.Next(50, 100), random.Next(5, 10)));

            graphics.DrawRectangle(Pens.White, (float)dortgen.center.X - (dortgen.width / 2) + oteleme, (float)dortgen.center.Y - (dortgen.height / 2), dortgen.width, dortgen.height);
            graphics.DrawRectangle(Pens.White, (float)nokta.center.X, (float)nokta.center.Y, 1, 1);

            carpisma = CollisionDetector.DotQuadrilateral(nokta, dortgen);

            if (carpisma)
            {
                btn_carpisma.BackColor = Color.Green;

            }
            else
            {
                btn_carpisma.BackColor = Color.Red;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            panel1.BackColor = Color.Transparent;
            panel1.BackColor = Color.Black;


        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            oteleme += oteleme + 10;


        }
    }
}