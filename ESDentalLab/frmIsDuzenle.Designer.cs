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
            lblIsTuru = new Label();
            cmbIsTuru = new ComboBox();
            btnIsTuruEkle = new Button();
            btnIsTuruSil = new Button();
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
            ((System.ComponentModel.ISupportInitialize)nudFiyat).BeginInit();
            SuspendLayout();
            // 
            // lblIsNumarasi
            // 
            lblIsNumarasi.AutoSize = true;
            lblIsNumarasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsNumarasi.Location = new Point(24, 20);
            lblIsNumarasi.Name = "lblIsNumarasi";
            lblIsNumarasi.Size = new Size(0, 19);
            lblIsNumarasi.TabIndex = 0;
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(24, 58);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.TabIndex = 1;
            lblDoktor.Text = "Doktor";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(135, 55);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(250, 23);
            cmbDoktor.TabIndex = 2;
            // 
            // lblHastaAdi
            // 
            lblHastaAdi.AutoSize = true;
            lblHastaAdi.Location = new Point(24, 98);
            lblHastaAdi.Name = "lblHastaAdi";
            lblHastaAdi.Size = new Size(56, 15);
            lblHastaAdi.TabIndex = 3;
            lblHastaAdi.Text = "Hasta adı";
            // 
            // txtHastaAdi
            // 
            txtHastaAdi.Location = new Point(135, 95);
            txtHastaAdi.Name = "txtHastaAdi";
            txtHastaAdi.Size = new Size(250, 23);
            txtHastaAdi.TabIndex = 4;
            // 
            // lblIsTuru
            // 
            lblIsTuru.AutoSize = true;
            lblIsTuru.Location = new Point(24, 138);
            lblIsTuru.Name = "lblIsTuru";
            lblIsTuru.Size = new Size(41, 15);
            lblIsTuru.TabIndex = 5;
            lblIsTuru.Text = "İş türü";
            // 
            // cmbIsTuru
            // 
            cmbIsTuru.FormattingEnabled = true;
            cmbIsTuru.Location = new Point(135, 135);
            cmbIsTuru.Name = "cmbIsTuru";
            cmbIsTuru.Size = new Size(200, 23);
            cmbIsTuru.TabIndex = 6;
            // 
            // btnIsTuruEkle
            // 
            btnIsTuruEkle.Location = new Point(341, 133);
            btnIsTuruEkle.Name = "btnIsTuruEkle";
            btnIsTuruEkle.Size = new Size(28, 28);
            btnIsTuruEkle.TabIndex = 21;
            btnIsTuruEkle.Text = "+";
            btnIsTuruEkle.UseVisualStyleBackColor = true;
            btnIsTuruEkle.Click += btnIsTuruEkle_Click;
            // 
            // btnIsTuruSil
            // 
            btnIsTuruSil.Location = new Point(375, 133);
            btnIsTuruSil.Name = "btnIsTuruSil";
            btnIsTuruSil.Size = new Size(28, 28);
            btnIsTuruSil.TabIndex = 22;
            btnIsTuruSil.Text = "−";
            btnIsTuruSil.UseVisualStyleBackColor = true;
            btnIsTuruSil.Click += btnIsTuruSil_Click;
            // 
            // lblDisNumarasi
            // 
            lblDisNumarasi.AutoSize = true;
            lblDisNumarasi.Location = new Point(24, 178);
            lblDisNumarasi.Name = "lblDisNumarasi";
            lblDisNumarasi.Size = new Size(72, 15);
            lblDisNumarasi.TabIndex = 7;
            lblDisNumarasi.Text = "Diş numarası";
            // 
            // txtDisNumarasi
            // 
            txtDisNumarasi.Location = new Point(135, 175);
            txtDisNumarasi.Name = "txtDisNumarasi";
            txtDisNumarasi.Size = new Size(250, 23);
            txtDisNumarasi.TabIndex = 8;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(24, 218);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(43, 15);
            lblDurum.TabIndex = 9;
            lblDurum.Text = "Durum";
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Alındı", "Üretimde", "Kontrolde", "Teslime hazır", "Teslim edildi" });
            cmbDurum.Location = new Point(135, 215);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(250, 23);
            cmbDurum.TabIndex = 10;
            // 
            // lblTeslimTarihi
            // 
            lblTeslimTarihi.AutoSize = true;
            lblTeslimTarihi.Location = new Point(24, 258);
            lblTeslimTarihi.Name = "lblTeslimTarihi";
            lblTeslimTarihi.Size = new Size(76, 15);
            lblTeslimTarihi.TabIndex = 11;
            lblTeslimTarihi.Text = "Teslim tarihi";
            // 
            // dtpTeslimTarihi
            // 
            dtpTeslimTarihi.Format = DateTimePickerFormat.Short;
            dtpTeslimTarihi.Location = new Point(135, 255);
            dtpTeslimTarihi.Name = "dtpTeslimTarihi";
            dtpTeslimTarihi.Size = new Size(250, 23);
            dtpTeslimTarihi.TabIndex = 12;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(24, 298);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(56, 15);
            lblAciklama.TabIndex = 13;
            lblAciklama.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(135, 295);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(250, 80);
            txtAciklama.TabIndex = 14;
            // 
            // lblFiyat
            // 
            lblFiyat.AutoSize = true;
            lblFiyat.Location = new Point(24, 395);
            lblFiyat.Name = "lblFiyat";
            lblFiyat.Size = new Size(35, 15);
            lblFiyat.TabIndex = 15;
            lblFiyat.Text = "Fiyat";
            // 
            // nudFiyat
            // 
            nudFiyat.DecimalPlaces = 2;
            nudFiyat.Location = new Point(135, 392);
            nudFiyat.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFiyat.Name = "nudFiyat";
            nudFiyat.Size = new Size(120, 23);
            nudFiyat.TabIndex = 16;
            nudFiyat.ThousandsSeparator = true;
            // 
            // lblFiyatTl
            // 
            lblFiyatTl.AutoSize = true;
            lblFiyatTl.Location = new Point(261, 395);
            lblFiyatTl.Name = "lblFiyatTl";
            lblFiyatTl.Size = new Size(20, 15);
            lblFiyatTl.TabIndex = 20;
            lblFiyatTl.Text = "TL";
            // 
            // chkRptMi
            // 
            chkRptMi.AutoSize = true;
            chkRptMi.Location = new Point(300, 394);
            chkRptMi.Name = "chkRptMi";
            chkRptMi.Size = new Size(70, 19);
            chkRptMi.TabIndex = 17;
            chkRptMi.Text = "RPT işi";
            chkRptMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(135, 435);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 35);
            btnKaydet.TabIndex = 18;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(265, 435);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 35);
            btnIptal.TabIndex = 19;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // frmIsDuzenle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 620);
            MinimumSize = new Size(440, 580);
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
            Controls.Add(btnIsTuruSil);
            Controls.Add(btnIsTuruEkle);
            Controls.Add(cmbIsTuru);
            Controls.Add(lblIsTuru);
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
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblIsNumarasi;
        private Label lblDoktor;
        private ComboBox cmbDoktor;
        private Label lblHastaAdi;
        private TextBox txtHastaAdi;
        private Label lblIsTuru;
        private ComboBox cmbIsTuru;
        private Button btnIsTuruEkle;
        private Button btnIsTuruSil;
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
    }
}
