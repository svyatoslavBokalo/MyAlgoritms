using System;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts_LinearShell
{
    class MoveShipGraffic
    {
        private Ship ship;
        private Graphics g;
        private int minX;
        private int maxX;
        private int minY;
        private int maxY;
        private int dX;
        private int dY;
        private Point locationGraphics;
        private Size sizeGraphics;
        private GraphicsBox graphicsBox;

        public MoveShipGraffic(Graphics g, GraphicsBox graphicsBox) : this(new Ship(), g, 0, 0, 0, 0, 0, 0, graphicsBox)
        {
            
        }

        public MoveShipGraffic(Ship ship, Graphics g, int minX, int maxX, int minY, int maxY, int dX, int dY, GraphicsBox graphicsBox)
        {
            this.ship = ship;
            this.g = g;
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.dX = dX;
            this.dY = dY;
            this.graphicsBox = graphicsBox;
            locationGraphics = graphicsBox.TransformationPoint(ship.Location, minX, maxX, minY, maxY, dX, dY);
            sizeGraphics = new Size(graphicsBox.TransformationPoint(ship.SizeShip, minX, maxX, minY, maxY, dX, dY));
            this.Draw(Brushes.Red);
        }

        public void DrawingMove(int speed, int time, Color color)
        {
            Thread.Sleep(100);
            this.Draw(new SolidBrush(color));
            ship.Move(time);
            locationGraphics = graphicsBox.TransformationPoint(ship.Location, minX, maxX, minY, maxY, dX, dY);
            this.Draw(Brushes.Red);
           
            
        }

        public void Draw(Brush brush)
        {
            g.FillRectangle(brush, new Rectangle(locationGraphics, this.sizeGraphics));

        }
    }
}
