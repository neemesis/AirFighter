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
    public partial class ScoreboardForm : Form {
        public ScoreboardEntry Entry;

        public ScoreboardForm(int Poeni) {
            InitializeComponent();
            this.lblPoeni.Text = Poeni.ToString();
            Entry = new ScoreboardEntry(Poeni);
        }

        private void btnZachuvaj_Click(object sender, EventArgs e) {
            Entry.Name = tbIme.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnOtkazhi_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
