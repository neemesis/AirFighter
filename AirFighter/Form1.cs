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

        private Scene Window;

        public Form1() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            Window = new Scene();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Cursor = Cursors.Cross;
            InvalidateTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Window.Draw(e.Graphics);
        }

        private void InvalidateTimer_Tick(object sender, EventArgs e) {
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            Window.KeyDown(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            Window.MouseMove(e.Location);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            Window.MouseClick(e.Location);
        }

        private void OnProcessExit(object sender, EventArgs e) {
            Console.WriteLine("On Exit");
            Window.SaveScoreboard();
        }
    }
}
