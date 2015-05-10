using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
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
        private Timer BackgroundTimer;
        private bool IsPlaying;
        private bool[] Fields;
        private SoundPlayer BombSound;
        private SoundPlayer GunSound;
        private SoundPlayer DeadEnemySound;
        private Image Background1, Background2;
        private bool FirstBackground, SecondBackground;
        private int BackgroundPosition1, BackgroundPosition2;
        private static readonly int BackgroundEnd = 600;
        private static readonly int BackgroundHeight = -3310;
        private List<ScoreboardEntry> Scoreboard;
        private int DeadCounter;

        /// <summary>
        /// Konstruktor na scenata.
        /// </summary>
        public Scene() {
            Player = new PlayerShip();
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
            BombSound = new SoundPlayer("bomb_sound.wav");
            GunSound = new SoundPlayer("shot_gun_2.wav");
            DeadEnemySound = new SoundPlayer("BangShort.wav");
            Background1 = Background2 = Resources.sky;
            BackgroundTimer = new Timer();
            BackgroundTimer.Interval = 10;
            BackgroundTimer.Tick += BackgroundTimer_Tick;
            Init();
            Scoreboard = new List<ScoreboardEntry>();
        }

        private void BackgroundTimer_Tick(object sender, EventArgs e) {
            if (FirstBackground) {
                if (BackgroundPosition1 == 0) {
                    SecondBackground = true;
                    BackgroundPosition2 = BackgroundHeight;
                } else if (BackgroundPosition1 == BackgroundEnd) {
                    FirstBackground = false;
                }
                ++BackgroundPosition1;
            }

            if (SecondBackground) {
                if (BackgroundPosition2 == 0) {
                    FirstBackground = true;
                    BackgroundPosition1 = BackgroundHeight;
                } else if (BackgroundPosition2 == BackgroundEnd) {
                    SecondBackground = false;
                }
                ++BackgroundPosition2;
            }
        }

        private void Init() {
            Enemies = new List<EnemyShip>();
            Bullets = new List<Bullet>();
            FirstBackground = true;
            SecondBackground = false;
            BackgroundPosition1 = 0;
            DeadCounter = 0;
            Player = new PlayerShip();
            Score = Counter = 0;
            EnemySpeed = 2;
            EnemiesTimer.Interval = 4000;
        }

        private void NewGame() {
            Init();
            IsPlaying = true;
            MoveTimer.Start();
            EnemiesTimer.Start();
            BackgroundTimer.Start();
        }

        public void EndGame() {
            MoveTimer.Stop();
            EnemiesTimer.Stop();
            System.Threading.Thread.Sleep(2000);
            IsPlaying = false;
            ScoreboardForm sbf = new ScoreboardForm(Score);
            if (sbf.ShowDialog() == DialogResult.OK) {
                Scoreboard.Add(sbf.Entry);
            }
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
            g.Clear(Color.White);

            if (IsPlaying) {
                if (!Player.IsDead) {
                    if (FirstBackground)
                        g.DrawImage(Background1, -26, BackgroundPosition1, 426, 3313);
                    if (SecondBackground)
                        g.DrawImage(Background2, -26, BackgroundPosition2, 426, 3313);
                }

                Brush brush = new SolidBrush(Color.Black);
                g.DrawString(Score.ToString(), new Font("Arial", 24, FontStyle.Bold), brush, 10, 10);
                g.DrawString(Player.Health.ToString(), new Font("Arial", 24, FontStyle.Bold), brush, 330, 10);
                brush.Dispose();

                Player.Draw(g);

                if (Player.IsDead) {
                    Font testFont = new Font("Consolas", 130.0f, FontStyle.Bold, GraphicsUnit.Pixel);
                    Brush b = new SolidBrush(Color.Black);
                    g.DrawString("Крај", testFont, b, 20, 100);
                    b.Dispose();
                    BombSound.Play();
                    if (++Counter == 10)
                        EndGame();
                    return;
                }

                foreach (EnemyShip es in Enemies) {
                    es.Draw(g);
                }

                foreach (Bullet b in Bullets) {
                    b.Draw(g);
                }
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
                GunSound.Play();
            } else {
                if (e.Y >= 20 && e.Y <= 190) {
                    IsPlaying = true;
                    NewGame();
                } else if (e.Y >= 200 && e.Y <= 370) {
                    Scoreboard = Scoreboard.OrderByDescending(x => x.Score).ToList();
                    string Result = "";

                    int i = 0;
                    foreach (ScoreboardEntry se in Scoreboard) {
                        Result += ++i + ". " + se.Name + " : " + se.Score + "\n";
                    }

                    MessageBox.Show(Result);

                } else if (e.Y >= 380 && e.Y <= 550) {
                    MessageBox.Show("Instrukcii");
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
            if (es.Position.Y > 550) {
                Player.RemoveHealth();
                if (Player.Health == 0)
                    Player.IsDead = true;
                es.RemoveHealth();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pridvizhuvanje na site objekti na scenata.
        /// </summary>
        public void Move() {
            Enemies.RemoveAll(x => x.IsDead == true);
            Enemies.RemoveAll(x => x.Health == 0);

            foreach (EnemyShip es in Enemies) {
                if (CheckEnemy(es))
                    continue;
                foreach (Bullet b in Bullets) {
                    if (CheckHit(es, b)) {
                        DeadEnemySound.Play();
                        ++Score;
                        es.RemoveHealth();
                        es.IsDead = true;
                        b.Active = false;
                    }
                }
                es.Move();
            }

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
