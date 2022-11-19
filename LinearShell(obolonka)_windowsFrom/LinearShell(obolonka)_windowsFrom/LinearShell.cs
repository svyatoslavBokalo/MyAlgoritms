using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearShell_obolonka__windowsFrom
{
    class LinearShell
    {
        private List<Point> lineS;
        int minX;
        int maxX;
        int minY;
        int maxY;
        int dX;
        int dY;

        public LinearShell()
        {
            this.lineS = new List<Point>();
        }

        public LinearShell(List<Point> lineS)
        {
            this.lineS = lineS;
        }

        public void ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string line = null;

            while ((line = sr.ReadLine()) != null)
            {
                Point point = new Point();
                point.Parse(line);

                lineS.Add(point);
            }

            sr.Close();
        }

        public void Show()
        {
            foreach (Point el in lineS)
            {
                Console.WriteLine(el);
            }
        }

        public void ShowToList(ListBox listBox)
        {
            listBox.Items.Clear();

            foreach(Point el in lineS)
            {
                listBox.Items.Add(el);
            }
        }

        public void Drawing(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            //g.DrawLine(Pens.Black, new System.Drawing.Point(pictureBox.Width / 2, 0), new System.Drawing.Point(pictureBox.Width / 2, pictureBox.Height));
            //g.DrawLine(Pens.Black, new System.Drawing.Point(0, pictureBox.Height / 2), new System.Drawing.Point(pictureBox.Width, pictureBox.Height / 2));

            minX = int.MaxValue;
            maxX = int.MinValue;

            minY = int.MaxValue;
            maxY = int.MinValue;

            foreach(Point el in lineS)
            {
                if(el.X < minX)
                {
                    minX = el.X;
                }
                if(el.X> maxX)
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

            dX = (pictureBox.Width - 20) / (maxX - minX);
            dY = (pictureBox.Height - 20) / (maxY - minY);

            foreach (Point el in lineS)
            {
                System.Drawing.Point pointGraphics = TransformationPoint(el, minX, maxX, minY, maxY, dX, dY);
                pointGraphics.X = pointGraphics.X - 5;
                pointGraphics.Y = pointGraphics.Y - 5;

                g.DrawEllipse(Pens.Red, new Rectangle(pointGraphics.X, pointGraphics.Y , 3, 3));
            }

            //for(int i = minX; i <= maxX; i++)
            //{
            //    g.DrawLine(Pens.Green, new System.Drawing.Point((i - minX) * dX + 10, 0), new System.Drawing.Point((i - minX) * dX + 10, pictureBox.Height));
            //}

            //for(int i = minY; i <= maxY; i++)
            //{
            //    g.DrawLine(Pens.Green, new System.Drawing.Point(0, (maxY - i) * dY + 10), new System.Drawing.Point(pictureBox.Width, (maxY - i) * dY + 10));

            //}

            g.DrawLine(new Pen(Color.Black, 2), new System.Drawing.Point((0 - minX) * dX + 10, 0), new System.Drawing.Point((0 - minX) * dX + 10, pictureBox.Height));
            g.DrawLine(new Pen(Color.Black, 2), new System.Drawing.Point(0, (maxY - 0) * dY + 10), new System.Drawing.Point(pictureBox.Width, (maxY - 0) * dY + 10));
        }

        public System.Drawing.Point TransformationPoint(Point point, int minX, int maxX, int minY, int maxY, int dX, int dY)
        {
            return new System.Drawing.Point((point.X - minX) * dX + 10, (maxY - point.Y) * dY + 10);
        }

        private int Orientation(Point p1, Point p2, Point p)
        {
            // Determinant
            int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1; //          (* Orientation is to the left-hand side  *)
            if (Orin < 0)
                return 1; // (* Orientation is to the right-hand side *)

            return 0; //  (* Orientation is neutral aka collinear  *)
        }

        public List<Point> MethodJarvis()
        {
            List<Point> res = new List<Point>(lineS);
            Point p1 = lineS[0];
            int numberMin = 0;
            int i = 0;

            foreach(Point el in lineS)
            {
                if(el.Y < p1.Y)
                {
                    p1 = el;
                    numberMin = i;
                }
                else
                {
                    if(el.Y == p1.Y)
                    {
                        if(el.X < p1.X)
                        {
                            p1 = el;
                            numberMin = i;
                        }
                    }
                }

                i++;
            }

            Point buff = p1;
            res[numberMin] = res[0];
            res[0] = buff;

            if (res.Count < 3)
            {
                throw new ArgumentException("At least 3 points reqired", "points");
            }

            List<Point> hull = new List<Point>();

            // get leftmost point
            Point vPointOnHull = res.Where(p => p.X == res.Min(min => min.X)).First();

            Point vEndpoint;
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
            List<Point> hull = MethodJarvis();

            for(int i = 0; i < hull.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, TransformationPoint(hull[i], minX,maxX,minY,maxY,dX,dY), TransformationPoint(hull[i+1], minX, maxX, minY, maxY, dX, dY));
            }

            g.DrawLine(Pens.Black, TransformationPoint(hull[0], minX, maxX, minY, maxY, dX, dY), TransformationPoint(hull[hull.Count-1], minX, maxX, minY, maxY, dX, dY));

            
        }
        
        

    }
}
