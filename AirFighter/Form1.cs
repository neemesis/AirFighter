using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFighter {
    public partial class Form1 : Form {

        private Scene Window;
        public Form1() {
            InitializeComponent();
            Window = new Scene();
            this.DoubleBuffered = true;
            InvalidateTimer.Start();
            MoveTimer.Start();
            EnemiesTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics g = Workspace.CreateGraphics();
            Window.Draw(g);
        }

        private void InvalidateTimer_Tick(object sender, EventArgs e) {
            Invalidate();
        }

        private void MoveTimer_Tick(object sender, EventArgs e) {
            Window.Move();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left)
                Window.MovePlayer(false);
            else if (e.KeyCode == Keys.Right)
                Window.MovePlayer(true);
            else if (e.KeyCode == Keys.Enter || true)
                Window.AddBullet();
        }

        private void EnemiesTimer_Tick(object sender, EventArgs e) {
            Window.GenerateEnemies();
            if (EnemiesTimer.Interval > 80)
                EnemiesTimer.Interval -= 50;
        }
    }
}
