using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class Scene {
        private PlayerShip Player;
        List<EnemyShip> Enemies;

        public Scene() {
            Player = new PlayerShip();
            Enemies = new List<EnemyShip>();

            for (int i = 0; i < 3; i++) {
                EnemyShip es = new EnemyShip(i * 120, i * 180);
                Enemies.Add(es);
            }
        }

        public void Draw(Graphics g) {
            g.Clear(Color.White);
            Player.Draw(g);
            foreach (EnemyShip es in Enemies) {
                es.Draw(g);
            }
        }

        public void Move() {
            foreach (EnemyShip es in Enemies) {
                es.Move();
            }
        }
    }
}
