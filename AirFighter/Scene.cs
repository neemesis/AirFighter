using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFighter {
    public class Scene {
        private int Score;
        private PlayerShip Player;
        private List<EnemyShip> Enemies;
        private List<Bullet> Bullets;
        private Random Randomizer;
        private int Counter;
        private int EnemySpeed;
        private Timer MoveTimer;
        private Timer EnemiesTimer;
        private bool IsPlaying;
        private bool[] Fields;

        /// <summary>
        /// Konstruktor na scenata.
        /// </summary>
        public Scene() {
            Player = new PlayerShip();
            Enemies = new List<EnemyShip>();
            Bullets = new List<Bullet>();
            Score = Counter = 0;
            EnemySpeed = 2;
            Randomizer = new Random();
            MoveTimer = new Timer();
            MoveTimer.Interval = 20;
            MoveTimer.Tick += MoveTimer_Tick;
            EnemiesTimer = new Timer();
            EnemiesTimer.Interval = 4000;
            EnemiesTimer.Tick += EnemiesTimer_Tick;
            IsPlaying = false;
            Fields = new bool[3];
            Fields[0] = Fields[1] = Fields[2] = false;
        }

        private void NewGame() {
            MoveTimer.Start();
            EnemiesTimer.Start();
        }

        public void EndGame() {
            MoveTimer.Stop();
            EnemiesTimer.Stop();
            IsPlaying = false;
        }

        public void KeyDown(KeyEventArgs e) {
            if (e.KeyCode == Keys.Left)
                MovePlayer(2, Point.Empty);
            else if (e.KeyCode == Keys.Right)
                MovePlayer(1, Point.Empty);
            else if (e.KeyCode == Keys.Enter)
                AddBullet();
        }

        private void EnemiesTimer_Tick(object sender, EventArgs e) {
            GenerateEnemies();
            SpeedUpEnemies();
            if (EnemiesTimer.Interval > 280)
                EnemiesTimer.Interval -= 50;
        }

        private void MoveTimer_Tick(object sender, EventArgs e) {
            Move();
        }

        public void Draw(Graphics g) {
            if (IsPlaying) {
                g.Clear(Color.White);
                Player.Draw(g);

                foreach (EnemyShip es in Enemies) {
                    es.Draw(g);
                }

                foreach (Bullet b in Bullets) {
                    b.Draw(g);
                }

                Brush brush = new SolidBrush(Color.Black);
                g.DrawString(Score.ToString(), new Font("Arial", 24, FontStyle.Bold), brush, 10, 10);
                g.DrawString(Player.Health.ToString(), new Font("Arial", 24, FontStyle.Bold), brush, 330, 10);
                brush.Dispose();
            } else {
                Brush b = new SolidBrush(Color.FromArgb(18, 44, 127));
                Brush b2 = new SolidBrush(Color.FromArgb(37, 89, 255));

                if (Fields[0])
                    g.FillRectangle(b, 10, 20, 365, 170);
                else
                    g.FillRectangle(b2, 10, 20, 365, 170);
                if (Fields[1])
                    g.FillRectangle(b, 10, 200, 365, 170);
                else
                    g.FillRectangle(b2, 10, 200, 365, 170);
                if (Fields[2])
                    g.FillRectangle(b, 10, 380, 365, 170);
                else
                    g.FillRectangle(b2, 10, 380, 365, 170);

                Font testFont = new Font("Consolas", 30.0f, FontStyle.Bold, GraphicsUnit.Pixel);

                b = new SolidBrush(Color.White);

                g.DrawString("Нова игра", testFont, b, 110, 85);
                g.DrawString("Најдобри резултати", testFont, b, 35, 265);
                g.DrawString("Инструкции", testFont, b, 108, 445);

                b.Dispose();
            }
        }

        public void MouseMove(Point e) {
            if (IsPlaying) {
                MovePlayer(3, e);
            } else {
                if (e.Y >= 20 && e.Y <= 190) {
                    Fields[0] = true;
                    Fields[1] = false;
                    Fields[2] = false;
                } else if (e.Y >= 200 && e.Y <= 370) {
                    Fields[0] = false;
                    Fields[1] = true;
                    Fields[2] = false;
                } else if (e.Y >= 380 && e.Y <= 550) {
                    Fields[0] = false;
                    Fields[1] = false;
                    Fields[2] = true;
                } else {
                    Fields[0] = false;
                    Fields[1] = false;
                    Fields[2] = false;
                }
            }
        }

        public void MouseClick(Point e) {
            if (IsPlaying) {
                AddBullet();
            } else {
                if (e.Y >= 20 && e.Y <= 190) {
                    IsPlaying = true;
                    NewGame();
                }
            }
        }

        /// <summary>
        /// Metoda koja ja povikuva metodata "Move" kaj igrachot.
        /// </summary>
        /// <param name="Side">Na koja strana da se dvizhi igrachot.</param>
        /// <param name="p">Ako se dvizhime so gluvcheto, so "p" ja prenosime pozicijata.</param>
        public void MovePlayer(int Side, Point p) {
            Player.Move(Side, p);
        }

        /// <summary>
        /// Metoda koja proveruva dali daden neprijatel (es) e vo dopir so metak (b).
        /// </summary>
        /// <param name="es">Neprijatel (EnemyShip)</param>
        /// <param name="b">Metak (Bullet)</param>
        /// <returns>Rezultatot e "true" ako dvata objekti se vo dopir.</returns>
        private bool CheckHit(EnemyShip es, Bullet b) {
            if (b.Position.Y < -180) {
                b.Active = false;
                return false;
            }
            bool x = es.Position.Y + 41 > b.Position.Y;
            bool y = (b.Position.X > es.Position.X - 8) && (b.Position.X < es.Position.X + 38);
            return x && y;
        }

        /// <summary>
        /// Gi brishe avionite shto se nadvor od vidliviot del.
        /// </summary>
        /// <param name="es">EnemyShip</param>
        /// <returns>Vrakaj "true" ako avionot e pod opredelenata granica.</returns>
        private bool CheckEnemy(EnemyShip es) {
            if (es.Position.Y > 520) {
                Player.RemoveHealth();
                if (Player.Health == 0)
                    EndGame();
                es.RemoveHealth();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pridvizhuvanje na site objekti na scenata.
        /// </summary>
        public void Move() {
            foreach (EnemyShip es in Enemies) {
                if (CheckEnemy(es))
                    continue;
                foreach (Bullet b in Bullets) {
                    if (CheckHit(es, b)) {
                        ++Score;
                        es.RemoveHealth();
                        b.Active = false;
                    }
                }
                es.Move();
            }

            Enemies.RemoveAll(x => x.Health == 0);
            Bullets.RemoveAll(x => x.Active == false);

            foreach (Bullet b in Bullets) {
                b.Move();
            }
        }

        /// <summary>
        /// Metoda za dodavanje na metak.
        /// </summary>
        public void AddBullet() {
            Bullet b = new Bullet(Player.Position);
            Bullets.Add(b);
        }

        /// <summary>
        /// Funkcija koja gi zabrzuva neprijatelite.
        /// </summary>
        public void SpeedUpEnemies() {
            Counter = ++Counter % 5;
            if (Counter == 4) {
                ++EnemySpeed;
                Console.WriteLine("Speed: " + EnemySpeed);
            }
        }

        /// <summary>
        /// Funkcija za generiranje na neprijateli.
        /// Prvo se generira kolku neprijateli.
        /// Potoa se stavat na random mesto i se dodavaat vo listata na neprijateli.
        /// </summary>
        public void GenerateEnemies() {
            int c = Randomizer.Next(1, 4);
            int from = 0;
            if (c != 0) from = 300 / c;
            for (int i = 0; i < c; i++) {
                EnemyShip es = new EnemyShip(Randomizer.Next(i * from, (i + 1) * from), -10 * i, EnemySpeed);
                Enemies.Add(es);
            }
        }
    }
}
