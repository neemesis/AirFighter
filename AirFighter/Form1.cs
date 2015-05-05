using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFighter {
    public partial class Form1 : Form {

        private bool IsPlaying;
        private Scene Window;
        private bool[] Fields;
        public Form1() {
            InitializeComponent();
            Fields = new bool[3];
            Fields[0] = Fields[1] = Fields[2] = false;
            IsPlaying = false;
            Window = new Scene(this);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void NewGame() {
            InvalidateTimer.Start();
            EnemiesTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            if (IsPlaying) {
                Window.Draw(e.Graphics);
            } else {
                Graphics g = e.Graphics;

                Brush b = new SolidBrush(Color.MediumOrchid);
                Brush b2 = new SolidBrush(Color.PaleVioletRed);

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

                b = new SolidBrush(Color.Black);

                g.DrawString("Нова игра", testFont, b, 110, 85);
                g.DrawString("Најдобри резултати", testFont, b, 35, 265);
                g.DrawString("Инструкции", testFont, b, 108, 445);

                b.Dispose();
            }
        }

        private void InvalidateTimer_Tick(object sender, EventArgs e) {
            Window.Move();
            Invalidate(true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left)
                Window.MovePlayer(2, Point.Empty);
            else if (e.KeyCode == Keys.Right)
                Window.MovePlayer(1, Point.Empty);
            else if (e.KeyCode == Keys.Enter)
                Window.AddBullet();
        }

        private void EnemiesTimer_Tick(object sender, EventArgs e) {
            Window.GenerateEnemies();
            Window.SpeedUpEnemies();
            if (EnemiesTimer.Interval > 180)
                EnemiesTimer.Interval -= 50;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (IsPlaying) {
                Window.MovePlayer(3, e.Location);
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
                }

                Invalidate();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            if (IsPlaying) {
                Window.AddBullet();
            } else {
                if (e.Y >= 20 && e.Y <= 190) {
                    IsPlaying = true;
                    NewGame();
                    Invalidate();
                }
            }
        }

        public void EndGame() {
            InvalidateTimer.Stop();
            EnemiesTimer.Stop();
        }
    }
}
