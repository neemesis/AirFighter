using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public abstract class SpaceShip {
        public Point Position { get; protected set; }
        public int Health { get; protected set; }
        protected Image ShipImage;

        public SpaceShip() {
            Position = Point.Empty;
        }

        public SpaceShip(Point Position, int Health, Bitmap ShipImage) {
            this.Position = Position;
            this.Health = Health;
            this.ShipImage = ShipImage;
        }

        public void RemoveHealth() {
            Health -= 1;
        }

        public void Draw(Graphics g) {
            g.DrawImage(ShipImage, Position);
        }
        
        public abstract void Shot();
    }
}
