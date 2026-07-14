namespace ESDentalLab
{
    partial class frmIsDuzenle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblIsNumarasi = new Label();
            lblDoktor = new Label();
            cmbDoktor = new ComboBox();
            lblHastaAdi = new Label();
            txtHastaAdi = new TextBox();
            lblDisNumarasi = new Label();
            txtDisNumarasi = new TextBox();
            lblDurum = new Label();
            cmbDurum = new ComboBox();
            lblTeslimTarihi = new Label();
            dtpTeslimTarihi = new DateTimePicker();
            lblAciklama = new Label();
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
            // lblIsNumarasi
            // 
            lblIsNumarasi.AutoSize = true;
            lblIsNumarasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsNumarasi.Location = new Point(24, 16);
            lblIsNumarasi.Name = "lblIsNumarasi";
            lblIsNumarasi.Size = new Size(0, 19);
            lblIsNumarasi.TabIndex = 0;
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(24, 52);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.TabIndex = 1;
            lblDoktor.Text = "Doktor";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(120, 49);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(250, 23);
            cmbDoktor.TabIndex = 2;
            // 
            // lblHastaAdi
            // 
            lblHastaAdi.AutoSize = true;
            lblHastaAdi.Location = new Point(24, 92);
            lblHastaAdi.Name = "lblHastaAdi";
            lblHastaAdi.Size = new Size(56, 15);
            lblHastaAdi.TabIndex = 3;
            lblHastaAdi.Text = "Hasta adı";
            // 
            // txtHastaAdi
            // 
            txtHastaAdi.Location = new Point(120, 89);
            txtHastaAdi.Name = "txtHastaAdi";
            txtHastaAdi.Size = new Size(250, 23);
            txtHastaAdi.TabIndex = 4;
            // 
            // lblDisNumarasi
            // 
            lblDisNumarasi.AutoSize = true;
            lblDisNumarasi.Location = new Point(24, 132);
            lblDisNumarasi.Name = "lblDisNumarasi";
            lblDisNumarasi.Size = new Size(72, 15);
            lblDisNumarasi.TabIndex = 5;
            lblDisNumarasi.Text = "Diş numarası";
            // 
            // txtDisNumarasi
            // 
            txtDisNumarasi.Location = new Point(120, 129);
            txtDisNumarasi.Name = "txtDisNumarasi";
            txtDisNumarasi.Size = new Size(250, 23);
            txtDisNumarasi.TabIndex = 6;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(24, 172);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(43, 15);
            lblDurum.TabIndex = 7;
            lblDurum.Text = "Durum";
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Alındı", "Üretimde", "Kontrolde", "Teslime hazır", "Teslim edildi" });
            cmbDurum.Location = new Point(120, 169);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(250, 23);
            cmbDurum.TabIndex = 8;
            // 
            // lblTeslimTarihi
            // 
            lblTeslimTarihi.AutoSize = true;
            lblTeslimTarihi.Location = new Point(24, 212);
            lblTeslimTarihi.Name = "lblTeslimTarihi";
            lblTeslimTarihi.Size = new Size(76, 15);
            lblTeslimTarihi.TabIndex = 9;
            lblTeslimTarihi.Text = "Teslim tarihi";
            // 
            // dtpTeslimTarihi
            // 
            dtpTeslimTarihi.Format = DateTimePickerFormat.Short;
            dtpTeslimTarihi.Location = new Point(120, 209);
            dtpTeslimTarihi.Name = "dtpTeslimTarihi";
            dtpTeslimTarihi.Size = new Size(250, 23);
            dtpTeslimTarihi.TabIndex = 10;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(24, 252);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(56, 15);
            lblAciklama.TabIndex = 11;
            lblAciklama.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(120, 249);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(250, 80);
            txtAciklama.TabIndex = 12;
            // 
            // lblFiyat
            // 
            lblFiyat.AutoSize = true;
            lblFiyat.Location = new Point(24, 346);
            lblFiyat.Name = "lblFiyat";
            lblFiyat.Size = new Size(35, 15);
            lblFiyat.TabIndex = 13;
            lblFiyat.Text = "Fiyat";
            // 
            // nudFiyat
            // 
            nudFiyat.DecimalPlaces = 2;
            nudFiyat.Location = new Point(120, 343);
            nudFiyat.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFiyat.Name = "nudFiyat";
            nudFiyat.Size = new Size(120, 23);
            nudFiyat.TabIndex = 14;
            nudFiyat.ThousandsSeparator = true;
            // 
            // lblFiyatTl
            // 
            lblFiyatTl.AutoSize = true;
            lblFiyatTl.Location = new Point(246, 346);
            lblFiyatTl.Name = "lblFiyatTl";
            lblFiyatTl.Size = new Size(20, 15);
            lblFiyatTl.TabIndex = 15;
            lblFiyatTl.Text = "TL";
            // 
            // chkRptMi
            // 
            chkRptMi.AutoSize = true;
            chkRptMi.Location = new Point(285, 345);
            chkRptMi.Name = "chkRptMi";
            chkRptMi.Size = new Size(70, 19);
            chkRptMi.TabIndex = 16;
            chkRptMi.Text = "RPT işi";
            chkRptMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(120, 385);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 35);
            btnKaydet.TabIndex = 17;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(250, 385);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 35);
            btnIptal.TabIndex = 18;
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
            pnlIsTurleri.Location = new Point(400, 40);
            pnlIsTurleri.Name = "pnlIsTurleri";
            pnlIsTurleri.Size = new Size(290, 390);
            pnlIsTurleri.TabIndex = 19;
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
            // frmIsDuzenle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 455);
            MinimumSize = new Size(730, 550);
            Controls.Add(pnlIsTurleri);
            Controls.Add(btnIptal);
            Controls.Add(btnKaydet);
            Controls.Add(chkRptMi);
            Controls.Add(lblFiyatTl);
            Controls.Add(nudFiyat);
            Controls.Add(lblFiyat);
            Controls.Add(txtAciklama);
            Controls.Add(lblAciklama);
            Controls.Add(dtpTeslimTarihi);
            Controls.Add(lblTeslimTarihi);
            Controls.Add(cmbDurum);
            Controls.Add(lblDurum);
            Controls.Add(txtDisNumarasi);
            Controls.Add(lblDisNumarasi);
            Controls.Add(txtHastaAdi);
            Controls.Add(lblHastaAdi);
            Controls.Add(cmbDoktor);
            Controls.Add(lblDoktor);
            Controls.Add(lblIsNumarasi);
            Name = "frmIsDuzenle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "İş Düzenle";
            Load += frmIsDuzenle_Load;
            ((System.ComponentModel.ISupportInitialize)nudFiyat).EndInit();
            pnlIsTuruListe.ResumeLayout(false);
            pnlIsTuruBaslik.ResumeLayout(false);
            pnlIsTurleri.ResumeLayout(false);
            pnlIsTurleri.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblIsNumarasi;
        private Label lblDoktor;
        private ComboBox cmbDoktor;
        private Label lblHastaAdi;
        private TextBox txtHastaAdi;
        private Label lblDisNumarasi;
        private TextBox txtDisNumarasi;
        private Label lblDurum;
        private ComboBox cmbDurum;
        private Label lblTeslimTarihi;
        private DateTimePicker dtpTeslimTarihi;
        private Label lblAciklama;
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
