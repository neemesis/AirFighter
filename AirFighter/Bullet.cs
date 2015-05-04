using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class Bullet {
        private Image BulletImage;
        private Point Position;

        public Bullet(Point P) {
            BulletImage = Resources.smallBullet;
            Position = new Point(P.X + 23, P.Y - 5);
        }

        public void Move() {
            Position = new Point(Position.X, Position.Y - 4);
        }

        public void Draw(Graphics g) {
            g.DrawImage(BulletImage, Position);
        }
    }
}
