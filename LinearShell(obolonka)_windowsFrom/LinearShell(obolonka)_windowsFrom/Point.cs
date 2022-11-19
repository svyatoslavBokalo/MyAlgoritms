using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearShell_obolonka__windowsFrom
{
    class Point
    {
        private int x;
        private int y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Parse(string line)
        {
            x = int.Parse(line.Split()[0]);
            y = int.Parse(line.Split()[1]);
        }

        public override string ToString()
        {
            return "x = " + x + ";  y = " + y;
        }
    }
}
