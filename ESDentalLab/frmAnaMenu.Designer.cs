namespace ESDentalLab
{
    partial class frmAnaMenu
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
            lblMarka = new Label();
            lblAltBaslik = new Label();
            lblHosgeldiniz = new Label();
            lblHizliIslemler = new Label();
            btnDoktorEkle = new Button();
            btnDoktorListesi = new Button();
            btnIsEkle = new Button();
            btnIsListesi = new Button();
            btnOdemeEkle = new Button();
            btnOdemeRaporu = new Button();
            lblAltBilgi = new Label();
            pnlBugunTeslim = new Panel();
            lblBugunTeslimBaslik = new Label();
            lblBugunTeslimDeger = new Label();
            pnlGeciken = new Panel();
            lblGecikenBaslik = new Label();
            lblGecikenDeger = new Label();
            pnlUretimde = new Panel();
            lblUretimdeBaslik = new Label();
            lblUretimdeDeger = new Label();
            pnlBakiye = new Panel();
            lblBakiyeBaslik = new Label();
            lblBakiyeDeger = new Label();
            pnlUst.SuspendLayout();
            pnlBugunTeslim.SuspendLayout();
            pnlGeciken.SuspendLayout();
            pnlUretimde.SuspendLayout();
            pnlBakiye.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUst
            // 
            pnlUst.BackColor = Color.FromArgb(30, 52, 60);
            pnlUst.Controls.Add(lblAltBaslik);
            pnlUst.Controls.Add(lblMarka);
            pnlUst.Dock = DockStyle.Top;
            pnlUst.Location = new Point(0, 0);
            pnlUst.Name = "pnlUst";
            pnlUst.Size = new Size(900, 145);
            pnlUst.TabIndex = 0;
            // 
            // lblMarka
            // 
            lblMarka.AutoSize = true;
            lblMarka.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblMarka.ForeColor = Color.White;
            lblMarka.Location = new Point(38, 30);
            lblMarka.Name = "lblMarka";
            lblMarka.Size = new Size(285, 46);
            lblMarka.TabIndex = 0;
            lblMarka.Text = "ES DENTAL LAB";
            // 
            // lblAltBaslik
            // 
            lblAltBaslik.AutoSize = true;
            lblAltBaslik.Font = new Font("Segoe UI", 10F);
            lblAltBaslik.ForeColor = Color.FromArgb(176, 204, 198);
            lblAltBaslik.Location = new Point(42, 87);
            lblAltBaslik.Name = "lblAltBaslik";
            lblAltBaslik.Size = new Size(276, 19);
            lblAltBaslik.TabIndex = 1;
            lblAltBaslik.Text = "Diş laboratuvarı iş ve finans takip sistemi";
            // 
            // lblHosgeldiniz
            // 
            lblHosgeldiniz.AutoSize = true;
            lblHosgeldiniz.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHosgeldiniz.ForeColor = Color.FromArgb(37, 58, 75);
            lblHosgeldiniz.Location = new Point(38, 171);
            lblHosgeldiniz.Name = "lblHosgeldiniz";
            lblHosgeldiniz.Size = new Size(160, 25);
            lblHosgeldiniz.TabIndex = 1;
            lblHosgeldiniz.Text = "Kontrol Merkezi";
            // 
            // lblHizliIslemler
            // 
            lblHizliIslemler.AutoSize = true;
            lblHizliIslemler.Font = new Font("Segoe UI", 9F);
            lblHizliIslemler.ForeColor = Color.FromArgb(100, 116, 130);
            lblHizliIslemler.Location = new Point(40, 309);
            lblHizliIslemler.Name = "lblHizliIslemler";
            lblHizliIslemler.Size = new Size(480, 15);
            lblHizliIslemler.TabIndex = 2;
            lblHizliIslemler.Text = "Özet kutularına tıklayarak filtrelenmiş listelere gidin · Sık kullanılan işlemler";
            // 
            // btnDoktorEkle
            // 
            btnDoktorEkle.BackColor = Color.White;
            btnDoktorEkle.Cursor = Cursors.Hand;
            btnDoktorEkle.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            btnDoktorEkle.FlatStyle = FlatStyle.Flat;
            btnDoktorEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDoktorEkle.ForeColor = Color.FromArgb(30, 52, 60);
            btnDoktorEkle.Location = new Point(38, 345);
            btnDoktorEkle.Name = "btnDoktorEkle";
            btnDoktorEkle.Size = new Size(250, 82);
            btnDoktorEkle.TabIndex = 3;
            btnDoktorEkle.Text = "Doktor Ekle";
            btnDoktorEkle.UseVisualStyleBackColor = false;
            btnDoktorEkle.Click += btnDoktorEkle_Click;
            // 
            // btnDoktorListesi
            // 
            btnDoktorListesi.BackColor = Color.White;
            btnDoktorListesi.Cursor = Cursors.Hand;
            btnDoktorListesi.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            btnDoktorListesi.FlatStyle = FlatStyle.Flat;
            btnDoktorListesi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDoktorListesi.ForeColor = Color.FromArgb(30, 52, 60);
            btnDoktorListesi.Location = new Point(325, 345);
            btnDoktorListesi.Name = "btnDoktorListesi";
            btnDoktorListesi.Size = new Size(250, 82);
            btnDoktorListesi.TabIndex = 4;
            btnDoktorListesi.Text = "Doktor Listesi";
            btnDoktorListesi.UseVisualStyleBackColor = false;
            btnDoktorListesi.Click += btnDoktorListesi_Click;
            // 
            // btnIsEkle
            // 
            btnIsEkle.BackColor = Color.FromArgb(26, 155, 142);
            btnIsEkle.Cursor = Cursors.Hand;
            btnIsEkle.FlatAppearance.BorderSize = 0;
            btnIsEkle.FlatStyle = FlatStyle.Flat;
            btnIsEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIsEkle.ForeColor = Color.White;
            btnIsEkle.Location = new Point(612, 345);
            btnIsEkle.Name = "btnIsEkle";
            btnIsEkle.Size = new Size(250, 82);
            btnIsEkle.TabIndex = 5;
            btnIsEkle.Text = "Yeni İş Ekle";
            btnIsEkle.UseVisualStyleBackColor = false;
            btnIsEkle.Click += btnIsEkle_Click;
            // 
            // btnIsListesi
            // 
            btnIsListesi.BackColor = Color.White;
            btnIsListesi.Cursor = Cursors.Hand;
            btnIsListesi.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            btnIsListesi.FlatStyle = FlatStyle.Flat;
            btnIsListesi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIsListesi.ForeColor = Color.FromArgb(30, 52, 60);
            btnIsListesi.Location = new Point(38, 447);
            btnIsListesi.Name = "btnIsListesi";
            btnIsListesi.Size = new Size(250, 82);
            btnIsListesi.TabIndex = 6;
            btnIsListesi.Text = "İş Listesi";
            btnIsListesi.UseVisualStyleBackColor = false;
            btnIsListesi.Click += btnIsListesi_Click;
            // 
            // btnOdemeEkle
            // 
            btnOdemeEkle.BackColor = Color.White;
            btnOdemeEkle.Cursor = Cursors.Hand;
            btnOdemeEkle.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            btnOdemeEkle.FlatStyle = FlatStyle.Flat;
            btnOdemeEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOdemeEkle.ForeColor = Color.FromArgb(30, 52, 60);
            btnOdemeEkle.Location = new Point(325, 447);
            btnOdemeEkle.Name = "btnOdemeEkle";
            btnOdemeEkle.Size = new Size(250, 82);
            btnOdemeEkle.TabIndex = 7;
            btnOdemeEkle.Text = "Doktor Ödemesi Ekle";
            btnOdemeEkle.UseVisualStyleBackColor = false;
            btnOdemeEkle.Click += btnOdemeEkle_Click;
            // 
            // btnOdemeRaporu
            // 
            btnOdemeRaporu.BackColor = Color.White;
            btnOdemeRaporu.Cursor = Cursors.Hand;
            btnOdemeRaporu.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            btnOdemeRaporu.FlatStyle = FlatStyle.Flat;
            btnOdemeRaporu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOdemeRaporu.ForeColor = Color.FromArgb(30, 52, 60);
            btnOdemeRaporu.Location = new Point(612, 447);
            btnOdemeRaporu.Name = "btnOdemeRaporu";
            btnOdemeRaporu.Size = new Size(250, 82);
            btnOdemeRaporu.TabIndex = 8;
            btnOdemeRaporu.Text = "Ödeme Raporları";
            btnOdemeRaporu.UseVisualStyleBackColor = false;
            btnOdemeRaporu.Click += btnOdemeRaporu_Click;
            // 
            // lblAltBilgi
            // 
            lblAltBilgi.AutoSize = true;
            lblAltBilgi.ForeColor = Color.FromArgb(130, 145, 155);
            lblAltBilgi.Location = new Point(38, 586);
            lblAltBilgi.Name = "lblAltBilgi";
            lblAltBilgi.Size = new Size(180, 15);
            lblAltBilgi.TabIndex = 8;
            lblAltBilgi.Text = "ES Dental Lab Yönetim Sistemi";
            // 
            // pnlBugunTeslim
            // 
            pnlBugunTeslim.BackColor = Color.White;
            pnlBugunTeslim.BorderStyle = BorderStyle.FixedSingle;
            pnlBugunTeslim.Controls.Add(lblBugunTeslimDeger);
            pnlBugunTeslim.Controls.Add(lblBugunTeslimBaslik);
            pnlBugunTeslim.Cursor = Cursors.Hand;
            pnlBugunTeslim.Location = new Point(38, 225);
            pnlBugunTeslim.Name = "pnlBugunTeslim";
            pnlBugunTeslim.Size = new Size(200, 65);
            pnlBugunTeslim.TabIndex = 9;
            pnlBugunTeslim.Click += pnlBugunTeslim_Click;
            // 
            // lblBugunTeslimBaslik
            // 
            lblBugunTeslimBaslik.AutoSize = true;
            lblBugunTeslimBaslik.Cursor = Cursors.Hand;
            lblBugunTeslimBaslik.ForeColor = Color.FromArgb(91, 107, 119);
            lblBugunTeslimBaslik.Location = new Point(12, 10);
            lblBugunTeslimBaslik.Name = "lblBugunTeslimBaslik";
            lblBugunTeslimBaslik.Size = new Size(115, 15);
            lblBugunTeslimBaslik.TabIndex = 0;
            lblBugunTeslimBaslik.Text = "Bugün teslim edilecek";
            lblBugunTeslimBaslik.Click += pnlBugunTeslim_Click;
            // 
            // lblBugunTeslimDeger
            // 
            lblBugunTeslimDeger.AutoSize = true;
            lblBugunTeslimDeger.Cursor = Cursors.Hand;
            lblBugunTeslimDeger.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBugunTeslimDeger.ForeColor = Color.FromArgb(26, 155, 142);
            lblBugunTeslimDeger.Location = new Point(12, 27);
            lblBugunTeslimDeger.Name = "lblBugunTeslimDeger";
            lblBugunTeslimDeger.Size = new Size(27, 31);
            lblBugunTeslimDeger.TabIndex = 1;
            lblBugunTeslimDeger.Text = "0";
            lblBugunTeslimDeger.Click += pnlBugunTeslim_Click;
            // 
            // pnlGeciken
            // 
            pnlGeciken.BackColor = Color.White;
            pnlGeciken.BorderStyle = BorderStyle.FixedSingle;
            pnlGeciken.Controls.Add(lblGecikenDeger);
            pnlGeciken.Controls.Add(lblGecikenBaslik);
            pnlGeciken.Cursor = Cursors.Hand;
            pnlGeciken.Location = new Point(250, 225);
            pnlGeciken.Name = "pnlGeciken";
            pnlGeciken.Size = new Size(200, 65);
            pnlGeciken.TabIndex = 10;
            pnlGeciken.Click += pnlGeciken_Click;
            // 
            // lblGecikenBaslik
            // 
            lblGecikenBaslik.AutoSize = true;
            lblGecikenBaslik.Cursor = Cursors.Hand;
            lblGecikenBaslik.ForeColor = Color.FromArgb(91, 107, 119);
            lblGecikenBaslik.Location = new Point(12, 10);
            lblGecikenBaslik.Name = "lblGecikenBaslik";
            lblGecikenBaslik.Size = new Size(82, 15);
            lblGecikenBaslik.TabIndex = 0;
            lblGecikenBaslik.Text = "Geciken işler";
            lblGecikenBaslik.Click += pnlGeciken_Click;
            // 
            // lblGecikenDeger
            // 
            lblGecikenDeger.AutoSize = true;
            lblGecikenDeger.Cursor = Cursors.Hand;
            lblGecikenDeger.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblGecikenDeger.ForeColor = Color.FromArgb(195, 85, 65);
            lblGecikenDeger.Location = new Point(12, 27);
            lblGecikenDeger.Name = "lblGecikenDeger";
            lblGecikenDeger.Size = new Size(27, 31);
            lblGecikenDeger.TabIndex = 1;
            lblGecikenDeger.Text = "0";
            lblGecikenDeger.Click += pnlGeciken_Click;
            // 
            // pnlUretimde
            // 
            pnlUretimde.BackColor = Color.White;
            pnlUretimde.BorderStyle = BorderStyle.FixedSingle;
            pnlUretimde.Controls.Add(lblUretimdeDeger);
            pnlUretimde.Controls.Add(lblUretimdeBaslik);
            pnlUretimde.Cursor = Cursors.Hand;
            pnlUretimde.Location = new Point(462, 225);
            pnlUretimde.Name = "pnlUretimde";
            pnlUretimde.Size = new Size(200, 65);
            pnlUretimde.TabIndex = 11;
            pnlUretimde.Click += pnlUretimde_Click;
            // 
            // lblUretimdeBaslik
            // 
            lblUretimdeBaslik.AutoSize = true;
            lblUretimdeBaslik.Cursor = Cursors.Hand;
            lblUretimdeBaslik.ForeColor = Color.FromArgb(91, 107, 119);
            lblUretimdeBaslik.Location = new Point(12, 10);
            lblUretimdeBaslik.Name = "lblUretimdeBaslik";
            lblUretimdeBaslik.Size = new Size(86, 15);
            lblUretimdeBaslik.TabIndex = 0;
            lblUretimdeBaslik.Text = "Üretimdeki işler";
            lblUretimdeBaslik.Click += pnlUretimde_Click;
            // 
            // lblUretimdeDeger
            // 
            lblUretimdeDeger.AutoSize = true;
            lblUretimdeDeger.Cursor = Cursors.Hand;
            lblUretimdeDeger.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUretimdeDeger.ForeColor = Color.FromArgb(92, 129, 83);
            lblUretimdeDeger.Location = new Point(12, 27);
            lblUretimdeDeger.Name = "lblUretimdeDeger";
            lblUretimdeDeger.Size = new Size(27, 31);
            lblUretimdeDeger.TabIndex = 1;
            lblUretimdeDeger.Text = "0";
            lblUretimdeDeger.Click += pnlUretimde_Click;
            // 
            // pnlBakiye
            // 
            pnlBakiye.BackColor = Color.White;
            pnlBakiye.BorderStyle = BorderStyle.FixedSingle;
            pnlBakiye.Controls.Add(lblBakiyeDeger);
            pnlBakiye.Controls.Add(lblBakiyeBaslik);
            pnlBakiye.Cursor = Cursors.Hand;
            pnlBakiye.Location = new Point(674, 225);
            pnlBakiye.Name = "pnlBakiye";
            pnlBakiye.Size = new Size(188, 65);
            pnlBakiye.TabIndex = 12;
            pnlBakiye.Click += pnlBakiye_Click;
            // 
            // lblBakiyeBaslik
            // 
            lblBakiyeBaslik.AutoSize = true;
            lblBakiyeBaslik.Cursor = Cursors.Hand;
            lblBakiyeBaslik.ForeColor = Color.FromArgb(91, 107, 119);
            lblBakiyeBaslik.Location = new Point(12, 10);
            lblBakiyeBaslik.Name = "lblBakiyeBaslik";
            lblBakiyeBaslik.Size = new Size(92, 15);
            lblBakiyeBaslik.TabIndex = 0;
            lblBakiyeBaslik.Text = "Toplam bakiye";
            lblBakiyeBaslik.Click += pnlBakiye_Click;
            // 
            // lblBakiyeDeger
            // 
            lblBakiyeDeger.AutoSize = true;
            lblBakiyeDeger.Cursor = Cursors.Hand;
            lblBakiyeDeger.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBakiyeDeger.ForeColor = Color.FromArgb(30, 52, 60);
            lblBakiyeDeger.Location = new Point(12, 34);
            lblBakiyeDeger.Name = "lblBakiyeDeger";
            lblBakiyeDeger.Size = new Size(47, 21);
            lblBakiyeDeger.TabIndex = 1;
            lblBakiyeDeger.Text = "0 TL";
            lblBakiyeDeger.Click += pnlBakiye_Click;
            // 
            // frmAnaMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 242, 241);
            ClientSize = new Size(900, 630);
            Controls.Add(pnlBakiye);
            Controls.Add(pnlUretimde);
            Controls.Add(pnlGeciken);
            Controls.Add(pnlBugunTeslim);
            Controls.Add(lblAltBilgi);
            Controls.Add(btnOdemeRaporu);
            Controls.Add(btnOdemeEkle);
            Controls.Add(btnIsListesi);
            Controls.Add(btnIsEkle);
            Controls.Add(btnDoktorListesi);
            Controls.Add(btnDoktorEkle);
            Controls.Add(lblHizliIslemler);
            Controls.Add(lblHosgeldiniz);
            Controls.Add(pnlUst);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAnaMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ES Dental Lab";
            Activated += frmAnaMenu_Activated;
            Load += frmAnaMenu_Load;
            pnlUst.ResumeLayout(false);
            pnlUst.PerformLayout();
            pnlBugunTeslim.ResumeLayout(false);
            pnlBugunTeslim.PerformLayout();
            pnlGeciken.ResumeLayout(false);
            pnlGeciken.PerformLayout();
            pnlUretimde.ResumeLayout(false);
            pnlUretimde.PerformLayout();
            pnlBakiye.ResumeLayout(false);
            pnlBakiye.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlUst;
        private Label lblMarka;
        private Label lblAltBaslik;
        private Label lblHosgeldiniz;
        private Label lblHizliIslemler;
        private Button btnDoktorEkle;
        private Button btnDoktorListesi;
        private Button btnIsEkle;
        private Button btnIsListesi;
        private Button btnOdemeEkle;
        private Button btnOdemeRaporu;
        private Label lblAltBilgi;
        private Panel pnlBugunTeslim;
        private Label lblBugunTeslimBaslik;
        private Label lblBugunTeslimDeger;
        private Panel pnlGeciken;
        private Label lblGecikenBaslik;
        private Label lblGecikenDeger;
        private Panel pnlUretimde;
        private Label lblUretimdeBaslik;
        private Label lblUretimdeDeger;
        private Panel pnlBakiye;
        private Label lblBakiyeBaslik;
        private Label lblBakiyeDeger;
    }
}
