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
            lblIsTuru = new Label();
            lblDisNumarasi = new Label();
            lblTeslimTarihi = new Label();
            lblDurum = new Label();
            lblAciklama = new Label();
            cmbDoktor = new ComboBox();
            txtHastaAdi = new TextBox();
            cmbIsTuru = new ComboBox();
            btnIsTuruEkle = new Button();
            btnIsTuruSil = new Button();
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
            ((System.ComponentModel.ISupportInitialize)nudFiyat).BeginInit();
            SuspendLayout();
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(40, 38);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.TabIndex = 0;
            lblDoktor.Text = "Doktor";
            // 
            // lblHastaAdi
            // 
            lblHastaAdi.AutoSize = true;
            lblHastaAdi.Location = new Point(40, 78);
            lblHastaAdi.Name = "lblHastaAdi";
            lblHastaAdi.Size = new Size(56, 15);
            lblHastaAdi.TabIndex = 1;
            lblHastaAdi.Text = "Hasta adı";
            // 
            // lblIsTuru
            // 
            lblIsTuru.AutoSize = true;
            lblIsTuru.Location = new Point(40, 118);
            lblIsTuru.Name = "lblIsTuru";
            lblIsTuru.Size = new Size(41, 15);
            lblIsTuru.TabIndex = 2;
            lblIsTuru.Text = "İş türü";
            // 
            // lblDisNumarasi
            // 
            lblDisNumarasi.AutoSize = true;
            lblDisNumarasi.Location = new Point(40, 158);
            lblDisNumarasi.Name = "lblDisNumarasi";
            lblDisNumarasi.Size = new Size(72, 15);
            lblDisNumarasi.TabIndex = 3;
            lblDisNumarasi.Text = "Diş numarası";
            // 
            // lblTeslimTarihi
            // 
            lblTeslimTarihi.AutoSize = true;
            lblTeslimTarihi.Location = new Point(40, 198);
            lblTeslimTarihi.Name = "lblTeslimTarihi";
            lblTeslimTarihi.Size = new Size(76, 15);
            lblTeslimTarihi.TabIndex = 4;
            lblTeslimTarihi.Text = "Teslim tarihi";
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(40, 238);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(43, 15);
            lblDurum.TabIndex = 5;
            lblDurum.Text = "Durum";
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(40, 278);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(56, 15);
            lblAciklama.TabIndex = 6;
            lblAciklama.Text = "Açıklama";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(145, 35);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(250, 23);
            cmbDoktor.TabIndex = 7;
            // 
            // txtHastaAdi
            // 
            txtHastaAdi.Location = new Point(145, 75);
            txtHastaAdi.Name = "txtHastaAdi";
            txtHastaAdi.Size = new Size(250, 23);
            txtHastaAdi.TabIndex = 8;
            // 
            // cmbIsTuru
            // 
            cmbIsTuru.FormattingEnabled = true;
            cmbIsTuru.Location = new Point(145, 115);
            cmbIsTuru.Name = "cmbIsTuru";
            cmbIsTuru.Size = new Size(200, 23);
            cmbIsTuru.TabIndex = 9;
            // 
            // btnIsTuruEkle
            // 
            btnIsTuruEkle.Location = new Point(351, 113);
            btnIsTuruEkle.Name = "btnIsTuruEkle";
            btnIsTuruEkle.Size = new Size(28, 28);
            btnIsTuruEkle.TabIndex = 19;
            btnIsTuruEkle.Text = "+";
            btnIsTuruEkle.UseVisualStyleBackColor = true;
            btnIsTuruEkle.Click += btnIsTuruEkle_Click;
            // 
            // btnIsTuruSil
            // 
            btnIsTuruSil.Location = new Point(385, 113);
            btnIsTuruSil.Name = "btnIsTuruSil";
            btnIsTuruSil.Size = new Size(28, 28);
            btnIsTuruSil.TabIndex = 20;
            btnIsTuruSil.Text = "−";
            btnIsTuruSil.UseVisualStyleBackColor = true;
            btnIsTuruSil.Click += btnIsTuruSil_Click;
            // 
            // txtDisNumarasi
            // 
            txtDisNumarasi.Location = new Point(145, 155);
            txtDisNumarasi.Name = "txtDisNumarasi";
            txtDisNumarasi.Size = new Size(250, 23);
            txtDisNumarasi.TabIndex = 10;
            // 
            // dtpTeslimTarihi
            // 
            dtpTeslimTarihi.Format = DateTimePickerFormat.Short;
            dtpTeslimTarihi.Location = new Point(145, 195);
            dtpTeslimTarihi.Name = "dtpTeslimTarihi";
            dtpTeslimTarihi.Size = new Size(250, 23);
            dtpTeslimTarihi.TabIndex = 11;
            // 
            // cmbDurum
            // 
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Alındı", "Üretimde", "Kontrolde", "Teslime hazır", "Teslim edildi" });
            cmbDurum.Location = new Point(145, 235);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(250, 23);
            cmbDurum.TabIndex = 12;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(145, 275);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(250, 80);
            txtAciklama.TabIndex = 13;
            // 
            // lblFiyat
            // 
            lblFiyat.AutoSize = true;
            lblFiyat.Location = new Point(40, 370);
            lblFiyat.Name = "lblFiyat";
            lblFiyat.Size = new Size(35, 15);
            lblFiyat.TabIndex = 14;
            lblFiyat.Text = "Fiyat";
            // 
            // nudFiyat
            // 
            nudFiyat.DecimalPlaces = 2;
            nudFiyat.Location = new Point(145, 367);
            nudFiyat.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFiyat.Name = "nudFiyat";
            nudFiyat.Size = new Size(120, 23);
            nudFiyat.TabIndex = 15;
            nudFiyat.ThousandsSeparator = true;
            // 
            // lblFiyatTl
            // 
            lblFiyatTl.AutoSize = true;
            lblFiyatTl.Location = new Point(271, 370);
            lblFiyatTl.Name = "lblFiyatTl";
            lblFiyatTl.Size = new Size(20, 15);
            lblFiyatTl.TabIndex = 20;
            lblFiyatTl.Text = "TL";
            // 
            // chkRptMi
            // 
            chkRptMi.AutoSize = true;
            chkRptMi.Location = new Point(310, 369);
            chkRptMi.Name = "chkRptMi";
            chkRptMi.Size = new Size(70, 19);
            chkRptMi.TabIndex = 16;
            chkRptMi.Text = "RPT işi";
            chkRptMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(145, 410);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 36);
            btnKaydet.TabIndex = 17;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(275, 410);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(120, 36);
            btnIptal.TabIndex = 18;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // frmIsEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 465);
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
            Controls.Add(btnIsTuruSil);
            Controls.Add(btnIsTuruEkle);
            Controls.Add(cmbIsTuru);
            Controls.Add(txtHastaAdi);
            Controls.Add(cmbDoktor);
            Controls.Add(lblAciklama);
            Controls.Add(lblDurum);
            Controls.Add(lblTeslimTarihi);
            Controls.Add(lblDisNumarasi);
            Controls.Add(lblIsTuru);
            Controls.Add(lblHastaAdi);
            Controls.Add(lblDoktor);
            Name = "frmIsEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yeni İş Ekle";
            Load += frmIsEkle_Load;
            ((System.ComponentModel.ISupportInitialize)nudFiyat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDoktor;
        private Label lblHastaAdi;
        private Label lblIsTuru;
        private Label lblDisNumarasi;
        private Label lblTeslimTarihi;
        private Label lblDurum;
        private Label lblAciklama;
        private ComboBox cmbDoktor;
        private TextBox txtHastaAdi;
        private ComboBox cmbIsTuru;
        private Button btnIsTuruEkle;
        private Button btnIsTuruSil;
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
    }
}
