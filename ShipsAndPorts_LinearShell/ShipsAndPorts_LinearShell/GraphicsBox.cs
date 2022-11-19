using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts_LinearShell
{
    class GraphicsBox
    {
        private MyPoint point;
        private int minX;
        private int maxX;
        private int minY;
        private int maxY;
        private int dX;
        private int dY;

        public GraphicsBox():this(new MyPoint(), 0, 0, 0, 0, 0, 0)
        {

        }

        public GraphicsBox(MyPoint point, int minX, int maxX, int minY, int maxY, int dX, int dY)
        {
            this.point = point;
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.dX = dX;
            this.dY = dY;
        }

        public System.Drawing.Point TransformationPoint(MyPoint point, int minX, int maxX, int minY, int maxY, int dX, int dY)
        {
            return new System.Drawing.Point((point.X - minX) * dX + 10, (maxY - point.Y) * dY + 10);
        }

    }
}
