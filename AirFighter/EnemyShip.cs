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
        public EnemyShip(int x, int y) : base(new Point(x, y), 1, Resources.enemySmall) {
            EnemySpeed = 2;
        }

        public override void Shot() {
        }

        /// <summary>
        /// Pridvizhuvanje na neprijatelskite objekti nadolu po Y - oskata.
        /// </summary>
        public void Move() {
            Position = new Point(Position.X, Position.Y + EnemySpeed);
        }

        /// <summary>
        /// Ja setira brzinata so koja kje se dvizhat neprijatelite.
        /// </summary>
        /// <param name="EnemySpeed">Promenliva koja ja oznachuva brzinata na dvizhenje.</param>
        public void SetEnemySpeed(int EnemySpeed) {
            this.EnemySpeed = EnemySpeed;
        }
    }
}
