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

        /// <summary>
        /// Default konstruktor koj sluzhi za inicijaliziranje.
        /// </summary>
        public SpaceShip() {
            Position = Point.Empty;
        }

        /// <summary>
        /// Konstruktor so site parametri.
        /// </summary>
        /// <param name="Position">Na koja pozicija da se naogja objektot.</param>
        /// <param name="Health">Kolku pati mozhe da primi udar.</param>
        /// <param name="ShipImage">Slikata koja go pretstavuva objektot.</param>
        public SpaceShip(Point Position, int Health, Bitmap ShipImage) {
            this.Position = Position;
            this.Health = Health;
            this.ShipImage = ShipImage;
        }

        /// <summary>
        /// Odzemanje na health.
        /// </summary>
        public void RemoveHealth() {
            Health -= 1;
        }

        /// <summary>
        /// Metod za iscrtuvanje
        /// </summary>
        public void Draw(Graphics g) {
            g.DrawImage(ShipImage, Position);
        }
        
    }
}
