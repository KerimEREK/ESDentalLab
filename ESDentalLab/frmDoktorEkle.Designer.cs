namespace ESDentalLab
{
    partial class frmDoktorEkle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlUst = new Panel();
            lblBaslik = new Label();
            lblAltBaslik = new Label();
            pnlForm = new Panel();
            lblBilgi = new Label();
            txtAdSoyad = new TextBox();
            txtTelefon = new TextBox();
            txtKlinik = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnKaydet = new Button();
            btnCikis = new Button();
            pnlUst.SuspendLayout();
            pnlForm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUst
            // 
            pnlUst.BackColor = Color.FromArgb(22, 54, 78);
            pnlUst.Controls.Add(lblAltBaslik);
            pnlUst.Controls.Add(lblBaslik);
            pnlUst.Dock = DockStyle.Top;
            pnlUst.Location = new Point(0, 0);
            pnlUst.Name = "pnlUst";
            pnlUst.Size = new Size(500, 112);
            pnlUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Location = new Point(30, 22);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(140, 32);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Doktor Ekle";
            // 
            // lblAltBaslik
            // 
            lblAltBaslik.AutoSize = true;
            lblAltBaslik.ForeColor = Color.FromArgb(204, 222, 235);
            lblAltBaslik.Location = new Point(32, 65);
            lblAltBaslik.Name = "lblAltBaslik";
            lblAltBaslik.Size = new Size(305, 15);
            lblAltBaslik.TabIndex = 1;
            lblAltBaslik.Text = "Yeni doktor veya klinik iletişim bilgilerini kaydedin";
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(lblBilgi);
            pnlForm.Controls.Add(txtAdSoyad);
            pnlForm.Controls.Add(txtTelefon);
            pnlForm.Controls.Add(txtKlinik);
            pnlForm.Controls.Add(label1);
            pnlForm.Controls.Add(label2);
            pnlForm.Controls.Add(label3);
            pnlForm.Controls.Add(btnKaydet);
            pnlForm.Controls.Add(btnCikis);
            pnlForm.Location = new Point(24, 136);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(452, 270);
            pnlForm.TabIndex = 1;
            // 
            // lblBilgi
            // 
            lblBilgi.AutoSize = true;
            lblBilgi.ForeColor = Color.FromArgb(104, 120, 132);
            lblBilgi.Location = new Point(28, 22);
            lblBilgi.Name = "lblBilgi";
            lblBilgi.Size = new Size(243, 15);
            lblBilgi.TabIndex = 0;
            lblBilgi.Text = "Lütfen aşağıdaki alanları eksiksiz doldurun.";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.BorderStyle = BorderStyle.FixedSingle;
            txtAdSoyad.Location = new Point(142, 58);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(275, 23);
            txtAdSoyad.TabIndex = 2;
            // 
            // txtTelefon
            // 
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Location = new Point(142, 101);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(275, 23);
            txtTelefon.TabIndex = 4;
            // 
            // txtKlinik
            // 
            txtKlinik.BorderStyle = BorderStyle.FixedSingle;
            txtKlinik.Location = new Point(142, 144);
            txtKlinik.Name = "txtKlinik";
            txtKlinik.Size = new Size(275, 23);
            txtKlinik.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(47, 65, 80);
            label1.Location = new Point(28, 61);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "Ad soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(47, 65, 80);
            label2.Location = new Point(28, 104);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 3;
            label2.Text = "Telefon";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(47, 65, 80);
            label3.Location = new Point(28, 147);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Klinik";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.FromArgb(30, 121, 159);
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKaydet.ForeColor = Color.White;
            btnKaydet.Location = new Point(142, 204);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(132, 38);
            btnKaydet.TabIndex = 7;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.FromArgb(239, 243, 246);
            btnCikis.Cursor = Cursors.Hand;
            btnCikis.FlatAppearance.BorderColor = Color.FromArgb(210, 220, 228);
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCikis.ForeColor = Color.FromArgb(62, 79, 92);
            btnCikis.Location = new Point(285, 204);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(132, 38);
            btnCikis.TabIndex = 8;
            btnCikis.Text = "İptal";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // frmDoktorEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 248);
            ClientSize = new Size(500, 430);
            Controls.Add(pnlForm);
            Controls.Add(pnlUst);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDoktorEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ES Dental Lab | Doktor Ekle";
            Load += frmDoktorEkle_Load;
            pnlUst.ResumeLayout(false);
            pnlUst.PerformLayout();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlUst;
        private Label lblBaslik;
        private Label lblAltBaslik;
        private Panel pnlForm;
        private Label lblBilgi;
        private TextBox txtTelefon;
        private TextBox txtAdSoyad;
        private TextBox txtKlinik;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnKaydet;
        private Button btnCikis;
    }
}
