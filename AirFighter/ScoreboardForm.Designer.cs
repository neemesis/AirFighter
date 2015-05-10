namespace AirFighter {
    partial class ScoreboardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOtkazhi = new System.Windows.Forms.Button();
            this.btnZachuvaj = new System.Windows.Forms.Button();
            this.lblPoeni = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вашето име";
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(16, 49);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(279, 20);
            this.tbIme.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Освоивте вкупно";
            // 
            // btnOtkazhi
            // 
            this.btnOtkazhi.Location = new System.Drawing.Point(139, 75);
            this.btnOtkazhi.Name = "btnOtkazhi";
            this.btnOtkazhi.Size = new System.Drawing.Size(75, 23);
            this.btnOtkazhi.TabIndex = 3;
            this.btnOtkazhi.Text = "Откажи";
            this.btnOtkazhi.UseVisualStyleBackColor = true;
            this.btnOtkazhi.Click += new System.EventHandler(this.btnOtkazhi_Click);
            // 
            // btnZachuvaj
            // 
            this.btnZachuvaj.Location = new System.Drawing.Point(220, 75);
            this.btnZachuvaj.Name = "btnZachuvaj";
            this.btnZachuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnZachuvaj.TabIndex = 4;
            this.btnZachuvaj.Text = "Зачувај";
            this.btnZachuvaj.UseVisualStyleBackColor = true;
            this.btnZachuvaj.Click += new System.EventHandler(this.btnZachuvaj_Click);
            // 
            // lblPoeni
            // 
            this.lblPoeni.AutoSize = true;
            this.lblPoeni.Location = new System.Drawing.Point(115, 9);
            this.lblPoeni.Name = "lblPoeni";
            this.lblPoeni.Size = new System.Drawing.Size(0, 13);
            this.lblPoeni.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "поени.";
            // 
            // ScoreboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 107);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPoeni);
            this.Controls.Add(this.btnZachuvaj);
            this.Controls.Add(this.btnOtkazhi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIme);
            this.Controls.Add(this.label1);
            this.Name = "ScoreboardForm";
            this.Text = "ScoreboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOtkazhi;
        private System.Windows.Forms.Button btnZachuvaj;
        private System.Windows.Forms.Label lblPoeni;
        private System.Windows.Forms.Label label4;
    }
}