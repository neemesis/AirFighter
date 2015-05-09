using AirFighter.Properties;
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
        public bool IsDead { get; set; }
        private Image Explosion;

        /// <summary>
        /// Default konstruktor koj sluzhi za inicijaliziranje.
        /// </summary>
        public SpaceShip() {
            IsDead = false;
            Position = Point.Empty;
            Explosion = Resources.bang;
        }

        /// <summary>
        /// Konstruktor so site parametri.
        /// </summary>
        /// <param name="Position">Na koja pozicija da se naogja objektot.</param>
        /// <param name="Health">Kolku pati mozhe da primi udar.</param>
        /// <param name="ShipImage">Slikata koja go pretstavuva objektot.</param>
        public SpaceShip(Point Position, int Health, Bitmap ShipImage) {
            this.IsDead = false;
            this.Position = Position;
            this.Health = Health;
            this.ShipImage = ShipImage;
            this.Explosion = Resources.bang;
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
            if (IsDead) {
                g.DrawImage(Explosion, Position.X - 50, Position.Y, 160, 70);
                if (this is PlayerShip) {
                    Console.WriteLine("Dead");
                }
            } else {
                g.DrawImage(ShipImage, Position);
            }
        }
        
    }
}
