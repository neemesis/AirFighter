using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class EnemyShip : SpaceShip {
        private int EnemySpeed;
        public EnemyShip(int x, int y, int EnemySpeed) : base(new Point(x, y), 1, Resources.enemySmall) {
            this.EnemySpeed = EnemySpeed;
        }

        /// <summary>
        /// Pridvizhuvanje na neprijatelskite objekti nadolu po Y - oskata.
        /// </summary>
        public void Move() {
            Position = new Point(Position.X, Position.Y + EnemySpeed);
        }
    }
}
