using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearShell_obolonka__windowsFrom
{
    public partial class Form1 : Form
    {
        private LinearShell linearShell;

        public Form1()
        {
            InitializeComponent();
            this.linearShell = new LinearShell();
        }

        private void readFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linearShell.ReadFromFile(openFileDialog1.FileName);
            }
        }

        private void showToListBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearShell.ShowToList(listBox1);
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearShell.Drawing(pictureBox1);
        }

        private void extremeLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Point> obolonka = linearShell.MethodJarvis();
            listBox1.Items.Add("variable starting point");

            foreach(Point el in obolonka)
            {
                listBox1.Items.Add(el);
            }
        }

        private void drawingHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearShell.DrawHull(pictureBox1.CreateGraphics());
        }
    }
}
