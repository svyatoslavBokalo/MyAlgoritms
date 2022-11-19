using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndPorts_LinearShell
{
    public partial class Form1 : Form
    {
        private LinearShell linearShell;
        private List<LinearShell> linearShellGroup = new List<LinearShell>();
        int globalMinX = int.MaxValue;
        int globalMaxX = int.MinValue;
        int globalMinY = int.MaxValue;
        int globalMaxY = int.MinValue;
        int dX = 0;
        int dY = 0;
        MoveShipGraffic moveShipGraffic;
        int countTime = 0;

        public Form1()
        {
            InitializeComponent();
            this.linearShell = new LinearShell();
        }

        private void readFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linearShell.ReadFromFile(openFileDialog1.FileName);
            }
        }

        private void drawPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearShell.Drawing(pictureBox1);
        }

        private void drawHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearShell.DrawHull(pictureBox1.CreateGraphics());
        }

        private void methodJarviusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<MyPoint> obolonka = linearShell.MethodJarvis();
            listBox1.Items.Add("variable starting point");

            foreach (MyPoint el in obolonka)
            {
                listBox1.Items.Add(el);
            }
        }

        private void readFromFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                globalMinX = int.MaxValue;
                globalMaxX = int.MinValue;
                globalMinY = int.MaxValue;
                globalMaxY = int.MinValue;

                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                while (!sr.EndOfStream)
                {
                    string fileNameCurrent = sr.ReadLine();
                    LinearShell lS = new LinearShell();
                    lS.ReadFromFile(fileNameCurrent);
                    lS.TransformMinMaxXY();
                    if(globalMinX > lS.MinX)
                    {
                        globalMinX = lS.MinX;
                    }
                    if (globalMaxX < lS.MaxX)
                    {
                        globalMaxX = lS.MaxX;
                    }
                    if (globalMinY > lS.MinY)
                    {
                        globalMinY = lS.MinY;
                    }
                    if (globalMaxY < lS.MaxY)
                    {
                        globalMaxY = lS.MaxY;
                    }
                }

                sr.Close();

                sr = new StreamReader(openFileDialog1.FileName);

                while (!sr.EndOfStream)
                {
                    string fileNameCurrent = sr.ReadLine();
                    LinearShell lS = new LinearShell();

                    lS.MinX = globalMinX;
                    lS.MinY = globalMinY;
                    lS.MaxY = globalMaxY;
                    lS.MaxX = globalMaxX;

                    lS.ReadFromFile(fileNameCurrent);
                    linearShellGroup.Add(lS);
                }

                sr.Close();
            }
        }

        private void drawPointGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(LinearShell el in linearShellGroup)
            {
                el.Drawing(pictureBox1);
            }
        }

        private void drawShellGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(LinearShell el in linearShellGroup)
            {
                el.DrawHull(pictureBox1.CreateGraphics());
            }
        }

        private void drawToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dX = (pictureBox1.Width - 20) / (globalMaxX - globalMinX);
            dY = (pictureBox1.Height - 20) / (globalMaxY - globalMinY);
            Graphics g = pictureBox1.CreateGraphics();
            MyPoint myPoint = new MyPoint(0, pictureBox1.Height / 2);
            MyPoint sizeShip = new MyPoint(10, 20);
            MyPoint direction = new MyPoint(1, 0);
            Ship ship = new Ship(myPoint, sizeShip, direction);

            moveShipGraffic = new MoveShipGraffic(ship, g, globalMinX, globalMaxX, globalMinY, globalMaxY, dX, dY, new GraphicsBox());
            timer1.Start();
            countTime = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveShipGraffic.DrawingMove(1, 1, pictureBox1.BackColor);
            countTime++;
            if (countTime > 10)
            {
                timer1.Stop();
            }
        }
    }
}
