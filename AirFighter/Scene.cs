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
        List<Bullet> Bullets;

        public Scene() {
            Player = new PlayerShip();
            Enemies = new List<EnemyShip>();
            Bullets = new List<Bullet>();

            for (int i = 0; i < 3; i++) {
                EnemyShip es = new EnemyShip(i * 120, 10);
                Enemies.Add(es);
            }

            Bullet b = new Bullet(Player.Position);
            Bullets.Add(b);
        }

        public void Draw(Graphics g) {
            g.Clear(Color.White);
            Player.Draw(g);
            foreach (EnemyShip es in Enemies) {
                es.Draw(g);
            }

            foreach (Bullet b in Bullets) {
                b.Draw(g);
            }
        }

        public void MovePlayer(bool ToLeft) {
            Player.Move(ToLeft);
        }

        public void Move() {
            foreach (EnemyShip es in Enemies) {
                es.Move();
            }

            foreach (Bullet b in Bullets) {
                b.Move();
            }
        }
    }
}
