namespace ESDentalLab
{
    partial class frmIsEkle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDoktor = new Label();
            lblHastaAdi = new Label();
            lblDisNumarasi = new Label();
            lblTeslimTarihi = new Label();
            lblDurum = new Label();
            lblAciklama = new Label();
            cmbDoktor = new ComboBox();
            txtHastaAdi = new TextBox();
            txtDisNumarasi = new TextBox();
            dtpTeslimTarihi = new DateTimePicker();
            cmbDurum = new ComboBox();
            txtAciklama = new TextBox();
            lblFiyat = new Label();
            nudFiyat = new NumericUpDown();
            lblFiyatTl = new Label();
            chkRptMi = new CheckBox();
            btnKaydet = new Button();
            btnIptal = new Button();
            pnlIsTurleri = new Panel();
            pnlIsTuruBaslik = new Panel();
            lblIsTuruBaslik = new Label();
            txtIsTuruAra = new TextBox();
            pnlIsTuruListe = new Panel();
            lstIsTurleri = new ListBox();
            btnIsTuruEkle = new Button();
            btnIsTuruSil = new Button();
            ((System.ComponentModel.ISupportInitialize)nudFiyat).BeginInit();
            pnlIsTurleri.SuspendLayout();
            pnlIsTuruBaslik.SuspendLayout();
            pnlIsTuruListe.SuspendLayout();
            SuspendLayout();
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(24, 28);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.TabIndex = 0;
            lblDoktor.Text = "Doktor";
            // 
            // lblHastaAdi
            // 
            lblHastaAdi.AutoSize = true;
            lblHastaAdi.Location = new Point(24, 68);
            lblHastaAdi.Name = "lblHastaAdi";
            lblHastaAdi.Size = new Size(56, 15);
            lblHastaAdi.TabIndex = 1;
            lblHastaAdi.Text = "Hasta adı";
            // 
            // lblDisNumarasi
            // 
            lblDisNumarasi.AutoSize = true;
            lblDisNumarasi.Location = new Point(24, 108);
            lblDisNumarasi.Name = "lblDisNumarasi";
            lblDisNumarasi.Size = new Size(72, 15);
            lblDisNumarasi.TabIndex = 2;
            lblDisNumarasi.Text = "Diş numarası";
            // 
            // lblTeslimTarihi
            // 
            lblTeslimTarihi.AutoSize = true;
            lblTeslimTarihi.Location = new Point(24, 148);
            lblTeslimTarihi.Name = "lblTeslimTarihi";
            lblTeslimTarihi.Size = new Size(76, 15);
            lblTeslimTarihi.TabIndex = 3;
            lblTeslimTarihi.Text = "Teslim tarihi";
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(24, 188);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(43, 15);
            lblDurum.TabIndex = 4;
            lblDurum.Text = "Durum";
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(24, 228);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(56, 15);
            lblAciklama.TabIndex = 5;
            lblAciklama.Text = "Açıklama";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(120, 25);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(250, 23);
            cmbDoktor.TabIndex = 6;
            // 
            // txtHastaAdi
            // 
            txtHastaAdi.Location = new Point(120, 65);
            txtHastaAdi.Name = "txtHastaAdi";
            txtHastaAdi.Size = new Size(250, 23);
            txtHastaAdi.TabIndex = 7;
            // 
            // txtDisNumarasi
            // 
            txtDisNumarasi.Location = new Point(120, 105);
            txtDisNumarasi.Name = "txtDisNumarasi";
            txtDisNumarasi.Size = new Size(250, 23);
            txtDisNumarasi.TabIndex = 8;
            // 
            // dtpTeslimTarihi
            // 
            dtpTeslimTarihi.Format = DateTimePickerFormat.Short;
            dtpTeslimTarihi.Location = new Point(120, 145);
            dtpTeslimTarihi.Name = "dtpTeslimTarihi";
            dtpTeslimTarihi.Size = new Size(250, 23);
            dtpTeslimTarihi.TabIndex = 9;
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Alındı", "Üretimde", "Kontrolde", "Teslime hazır", "Teslim edildi" });
            cmbDurum.Location = new Point(120, 185);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(250, 23);
            cmbDurum.TabIndex = 10;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(120, 225);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(250, 80);
            txtAciklama.TabIndex = 11;
            // 
            // lblFiyat
            // 
            lblFiyat.AutoSize = true;
            lblFiyat.Location = new Point(24, 320);
            lblFiyat.Name = "lblFiyat";
            lblFiyat.Size = new Size(35, 15);
            lblFiyat.TabIndex = 12;
            lblFiyat.Text = "Fiyat";
            // 
            // nudFiyat
            // 
            nudFiyat.DecimalPlaces = 2;
            nudFiyat.Location = new Point(120, 317);
            nudFiyat.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFiyat.Name = "nudFiyat";
            nudFiyat.Size = new Size(120, 23);
            nudFiyat.TabIndex = 13;
            nudFiyat.ThousandsSeparator = true;
            // 
            // lblFiyatTl
            // 
            lblFiyatTl.AutoSize = true;
            lblFiyatTl.Location = new Point(246, 320);
            lblFiyatTl.Name = "lblFiyatTl";
            lblFiyatTl.Size = new Size(20, 15);
            lblFiyatTl.TabIndex = 14;
            lblFiyatTl.Text = "TL";
            // 
            // chkRptMi
            // 
            chkRptMi.AutoSize = true;
            chkRptMi.Location = new Point(285, 319);
            chkRptMi.Name = "chkRptMi";
            chkRptMi.Size = new Size(70, 19);
            chkRptMi.TabIndex = 15;
            chkRptMi.Text = "RPT işi";
            chkRptMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(120, 360);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 36);
            btnKaydet.TabIndex = 16;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(250, 360);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 36);
            btnIptal.TabIndex = 17;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // pnlIsTurleri
            // 
            pnlIsTurleri.Controls.Add(pnlIsTuruListe);
            pnlIsTurleri.Controls.Add(btnIsTuruSil);
            pnlIsTurleri.Controls.Add(btnIsTuruEkle);
            pnlIsTurleri.Controls.Add(txtIsTuruAra);
            pnlIsTurleri.Controls.Add(pnlIsTuruBaslik);
            pnlIsTurleri.Location = new Point(400, 16);
            pnlIsTurleri.Name = "pnlIsTurleri";
            pnlIsTurleri.Size = new Size(290, 390);
            pnlIsTurleri.TabIndex = 18;
            // 
            // pnlIsTuruBaslik
            // 
            pnlIsTuruBaslik.Controls.Add(lblIsTuruBaslik);
            pnlIsTuruBaslik.Dock = DockStyle.Top;
            pnlIsTuruBaslik.Location = new Point(0, 0);
            pnlIsTuruBaslik.Name = "pnlIsTuruBaslik";
            pnlIsTuruBaslik.Size = new Size(290, 40);
            pnlIsTuruBaslik.TabIndex = 0;
            // 
            // lblIsTuruBaslik
            // 
            lblIsTuruBaslik.Dock = DockStyle.Fill;
            lblIsTuruBaslik.Location = new Point(0, 0);
            lblIsTuruBaslik.Name = "lblIsTuruBaslik";
            lblIsTuruBaslik.Padding = new Padding(14, 0, 0, 0);
            lblIsTuruBaslik.Size = new Size(290, 40);
            lblIsTuruBaslik.TabIndex = 0;
            lblIsTuruBaslik.Text = "İş türleri";
            lblIsTuruBaslik.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtIsTuruAra
            // 
            txtIsTuruAra.Location = new Point(14, 52);
            txtIsTuruAra.Name = "txtIsTuruAra";
            txtIsTuruAra.PlaceholderText = "Tür ara...";
            txtIsTuruAra.Size = new Size(262, 23);
            txtIsTuruAra.TabIndex = 1;
            txtIsTuruAra.TextChanged += txtIsTuruAra_TextChanged;
            // 
            // pnlIsTuruListe
            // 
            pnlIsTuruListe.Controls.Add(lstIsTurleri);
            pnlIsTuruListe.Location = new Point(14, 86);
            pnlIsTuruListe.Name = "pnlIsTuruListe";
            pnlIsTuruListe.Padding = new Padding(1);
            pnlIsTuruListe.Size = new Size(262, 256);
            pnlIsTuruListe.TabIndex = 2;
            // 
            // lstIsTurleri
            // 
            lstIsTurleri.BorderStyle = BorderStyle.None;
            lstIsTurleri.Dock = DockStyle.Fill;
            lstIsTurleri.FormattingEnabled = true;
            lstIsTurleri.IntegralHeight = false;
            lstIsTurleri.ItemHeight = 32;
            lstIsTurleri.Location = new Point(1, 1);
            lstIsTurleri.Name = "lstIsTurleri";
            lstIsTurleri.Size = new Size(260, 254);
            lstIsTurleri.TabIndex = 0;
            // 
            // btnIsTuruEkle
            // 
            btnIsTuruEkle.Location = new Point(14, 352);
            btnIsTuruEkle.Name = "btnIsTuruEkle";
            btnIsTuruEkle.Size = new Size(126, 28);
            btnIsTuruEkle.TabIndex = 3;
            btnIsTuruEkle.Text = "Ekle";
            btnIsTuruEkle.UseVisualStyleBackColor = true;
            btnIsTuruEkle.Click += btnIsTuruEkle_Click;
            // 
            // btnIsTuruSil
            // 
            btnIsTuruSil.Location = new Point(150, 352);
            btnIsTuruSil.Name = "btnIsTuruSil";
            btnIsTuruSil.Size = new Size(126, 28);
            btnIsTuruSil.TabIndex = 4;
            btnIsTuruSil.Text = "Sil";
            btnIsTuruSil.UseVisualStyleBackColor = true;
            btnIsTuruSil.Click += btnIsTuruSil_Click;
            // 
            // frmIsEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 430);
            Controls.Add(pnlIsTurleri);
            Controls.Add(btnIptal);
            Controls.Add(btnKaydet);
            Controls.Add(chkRptMi);
            Controls.Add(lblFiyatTl);
            Controls.Add(nudFiyat);
            Controls.Add(lblFiyat);
            Controls.Add(txtAciklama);
            Controls.Add(cmbDurum);
            Controls.Add(dtpTeslimTarihi);
            Controls.Add(txtDisNumarasi);
            Controls.Add(txtHastaAdi);
            Controls.Add(cmbDoktor);
            Controls.Add(lblAciklama);
            Controls.Add(lblDurum);
            Controls.Add(lblTeslimTarihi);
            Controls.Add(lblDisNumarasi);
            Controls.Add(lblHastaAdi);
            Controls.Add(lblDoktor);
            MinimumSize = new Size(730, 510);
            Name = "frmIsEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yeni İş Ekle";
            Load += frmIsEkle_Load;
            ((System.ComponentModel.ISupportInitialize)nudFiyat).EndInit();
            pnlIsTuruListe.ResumeLayout(false);
            pnlIsTuruBaslik.ResumeLayout(false);
            pnlIsTurleri.ResumeLayout(false);
            pnlIsTurleri.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDoktor;
        private Label lblHastaAdi;
        private Label lblDisNumarasi;
        private Label lblTeslimTarihi;
        private Label lblDurum;
        private Label lblAciklama;
        private ComboBox cmbDoktor;
        private TextBox txtHastaAdi;
        private TextBox txtDisNumarasi;
        private DateTimePicker dtpTeslimTarihi;
        private ComboBox cmbDurum;
        private TextBox txtAciklama;
        private Label lblFiyat;
        private NumericUpDown nudFiyat;
        private Label lblFiyatTl;
        private CheckBox chkRptMi;
        private Button btnKaydet;
        private Button btnIptal;
        private Panel pnlIsTurleri;
        private Panel pnlIsTuruBaslik;
        private Label lblIsTuruBaslik;
        private TextBox txtIsTuruAra;
        private Panel pnlIsTuruListe;
        private ListBox lstIsTurleri;
        private Button btnIsTuruEkle;
        private Button btnIsTuruSil;
    }
}
