using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts_LinearShell
{
    class Ship
    {
        private MyPoint location;
        private MyPoint sizeShip;
        private MyPoint direction;
        private int speed = 60;

        public Ship()
        {
            this.location = new MyPoint();
            this.sizeShip = new MyPoint();
            this.direction = new MyPoint();
            this.speed = 0;
        }

        public Ship(MyPoint location, MyPoint sizeShip, MyPoint direction)
        {
            this.location = location;
            this.sizeShip = sizeShip;
            this.direction = direction;
        }

        internal MyPoint Location { get => location; set => location = value; }
        internal MyPoint SizeShip { get => sizeShip; set => sizeShip = value; }
        internal MyPoint Direction { get => direction; set => direction = value; }

        public override string ToString()
        {
            return "location = (" + location.X + ", " + location.Y + ")";
        }

        public void Move(int time)
        {
            this.location.X = location.X * speed * time + direction.X;
            this.location.Y = location.Y * speed * time + direction.Y;
        }
        
    }
}
