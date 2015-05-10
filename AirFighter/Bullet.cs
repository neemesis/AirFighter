using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    /// <summary>
    /// Klasa vo koja se chuvaat osnovnite podatoci za oruzhjeto.
    /// </summary>
    public class Bullet {
        private Image BulletImage;
        public Point Position;
        public bool Active;

        /// <summary>
        /// Konstruktor za metakot.
        /// </summary>
        /// <param name="P">Predefinirana tochka od kade kje se pojavi objektot, po default kaj igrachot.</param>
        public Bullet(Point P) {
            BulletImage = Resources.smallBullet;
            Position = new Point(P.X + 23, P.Y - 5);
            Active = true;
        }

        /// <summary>
        /// Pridvizhuvanje na metakot.
        /// </summary>
        public void Move() {
            Position = new Point(Position.X, Position.Y - 40);
        }

        /// <summary>
        /// Iscrtuvanje na metakot.
        /// </summary>
        public void Draw(Graphics g) {
            g.DrawImage(BulletImage, Position);
        }
    }
}
