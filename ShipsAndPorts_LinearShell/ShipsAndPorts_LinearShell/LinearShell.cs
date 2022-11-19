using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndPorts_LinearShell
{
    class LinearShell
    {

        private List<MyPoint> lineS;
        int minX = -200;
        int maxX = 200;
        int minY = -200;
        int maxY = 200;
        int dX;
        int dY;

        public int MinX { get => minX; set => minX = value; }
        public int MaxX { get => maxX; set => maxX = value; }
        public int MinY { get => minY; set => minY = value; }
        public int MaxY { get => maxY; set => maxY = value; }
        public int DX { get => dX; set => dX = value; }
        public int DY { get => dY; set => dY = value; }

        public LinearShell()
        {
            this.lineS = new List<MyPoint>();
        }

        public LinearShell(List<MyPoint> lineS)
        {
            this.lineS = lineS;
        }

        public void ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string line = null;

            while ((line = sr.ReadLine()) != null)
            {
                MyPoint point = new MyPoint();
                point.Parse(line);

                lineS.Add(point);
            }

            sr.Close();
        }

        public void Show()
        {
            foreach (MyPoint el in lineS)
            {
                Console.WriteLine(el);
            }
        }

        public void ShowToList(ListBox listBox)
        {
            listBox.Items.Clear();

            foreach (MyPoint el in lineS)
            {
                listBox.Items.Add(el);
            }
        }

        public void Drawing(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            //g.DrawLine(Pens.Black, new System.Drawing.Point(pictureBox.Width / 2, 0), new System.Drawing.Point(pictureBox.Width / 2, pictureBox.Height));
            //g.DrawLine(Pens.Black, new System.Drawing.Point(0, pictureBox.Height / 2), new System.Drawing.Point(pictureBox.Width, pictureBox.Height / 2));

            //minX = int.MaxValue;
            //maxX = int.MinValue;

            //minY = int.MaxValue;
            //maxY = int.MinValue;

            //foreach (MyPoint el in lineS)
            //{
            //    if (el.X < minX)
            //    {
            //        minX = el.X;
            //    }
            //    if (el.X > maxX)
            //    {
            //        maxX = el.X;
            //    }
            //    if (el.Y < minY)
            //    {
            //        minY = el.Y;
            //    }
            //    if (el.Y > maxY)
            //    {
            //        maxY = el.Y;
            //    }
            //}

            dX = (pictureBox.Width - 20) / (maxX - minX);
            dY = (pictureBox.Height - 20) / (maxY - minY);

            foreach (MyPoint el in lineS)
            {
                System.Drawing.Point pointGraphics = TransformationPoint(el, minX, maxX, minY, maxY, dX, dY);
                pointGraphics.X = pointGraphics.X - 2;
                pointGraphics.Y = pointGraphics.Y - 2;

                g.DrawEllipse(Pens.Red, new Rectangle(pointGraphics.X, pointGraphics.Y, 4, 4));
            }

            //for (int i = minX; i <= maxX; i++)
            //{
            //    g.DrawLine(Pens.Green, new System.Drawing.Point((i - minX) * dX + 10, 0), new System.Drawing.Point((i - minX) * dX + 10, pictureBox.Height));
            //}

            //for (int i = minY; i <= maxY; i++)
            //{
            //    g.DrawLine(Pens.Green, new System.Drawing.Point(0, (maxY - i) * dY + 10), new System.Drawing.Point(pictureBox.Width, (maxY - i) * dY + 10));

            //}

            g.DrawLine(new Pen(Color.Black, 2), new System.Drawing.Point((0 - minX) * dX + 10, 0), new System.Drawing.Point((0 - minX) * dX + 10, pictureBox.Height));
            g.DrawLine(new Pen(Color.Black, 2), new System.Drawing.Point(0, (maxY - 0) * dY + 10), new System.Drawing.Point(pictureBox.Width, (maxY - 0) * dY + 10));
        }

        public System.Drawing.Point TransformationPoint(MyPoint point, int minX, int maxX, int minY, int maxY, int dX, int dY)
        {
            return new System.Drawing.Point((point.X - minX) * dX + 10, (maxY - point.Y) * dY + 10);
        }

        private int Orientation(MyPoint p1, MyPoint p2, MyPoint p)
        {
            // Determinant
            int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1; //          (* Orientation is to the left-hand side  *)
            if (Orin < 0)
                return 1; // (* Orientation is to the right-hand side *)

            return 0; //  (* Orientation is neutral aka collinear  *)
        }

        public List<MyPoint> MethodJarvis()
        {
            List<MyPoint> res = new List<MyPoint>(lineS);
            MyPoint p1 = lineS[0];
            int numberMin = 0;
            int i = 0;

            foreach (MyPoint el in lineS)
            {
                if (el.Y < p1.Y)
                {
                    p1 = el;
                    numberMin = i;
                }
                else
                {
                    if (el.Y == p1.Y)
                    {
                        if (el.X < p1.X)
                        {
                            p1 = el;
                            numberMin = i;
                        }
                    }
                }

                i++;
            }

            MyPoint buff = p1;
            res[numberMin] = res[0];
            res[0] = buff;

            if (res.Count < 3)
            {
                throw new ArgumentException("At least 3 points reqired", "points");
            }

            List<MyPoint> hull = new List<MyPoint>();

            // get leftmost point
            MyPoint vPointOnHull = res.Where(p => p.X == res.Min(min => min.X)).First();

            MyPoint vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = res[0];

                for (int j = 1; j < res.Count; j++)
                {
                    if ((vPointOnHull == vEndpoint)
                        || (Orientation(vPointOnHull, vEndpoint, res[j]) == -1))
                    {
                        vEndpoint = res[j];
                    }
                }

                vPointOnHull = vEndpoint;

            }
            while (vEndpoint != hull[0]);

            return hull;
        }

        public void DrawHull(Graphics g)
        {
            List<MyPoint> hull = MethodJarvis();

            for (int i = 0; i < hull.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, TransformationPoint(hull[i], minX, maxX, minY, maxY, dX, dY), TransformationPoint(hull[i + 1], minX, maxX, minY, maxY, dX, dY));
            }

            g.DrawLine(Pens.Black, TransformationPoint(hull[0], minX, maxX, minY, maxY, dX, dY), TransformationPoint(hull[hull.Count - 1], minX, maxX, minY, maxY, dX, dY));


        }

        public void TransformMinMaxXY()
        {
            minX = lineS[0].X;
            maxX = lineS[0].X;
            minY = lineS[0].Y;
            maxY = lineS[0].Y;

            foreach (MyPoint el in lineS)
            {
                if(el.X < minX)
                {
                    minX = el.X;
                }
                if (el.X > maxX)
                {
                    maxX = el.X;
                }
                if (el.Y < minY)
                {
                    minY = el.Y;
                }
                if (el.Y > maxY)
                {
                    maxY = el.Y;
                }
            }
        }
    }
}
