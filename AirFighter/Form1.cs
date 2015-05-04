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
    }
}
