using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class EnemyShip : SpaceShip {

        public EnemyShip(int x, int y) : base(new Point(x, y), 1, Resources.planeEnemy) { }

        public override void Shot() {
        }

        public void Move() {
            Position = new Point(Position.X, Position.Y + 1);
        }
    }
}
