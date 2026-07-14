namespace ESDentalLab
{
    partial class frmIsListesi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvIsler = new DataGridView();
            colSec = new DataGridViewCheckBoxColumn();
            colHastaAdi = new DataGridViewTextBoxColumn();
            colDoktor = new DataGridViewTextBoxColumn();
            colIsTuru = new DataGridViewTextBoxColumn();
            colDisNumarasi = new DataGridViewTextBoxColumn();
            colKayitTarihi = new DataGridViewTextBoxColumn();
            colTeslimTarihi = new DataGridViewTextBoxColumn();
            colDurum = new DataGridViewTextBoxColumn();
            colAciklama = new DataGridViewTextBoxColumn();
            colFiyat = new DataGridViewTextBoxColumn();
            colRptMi = new DataGridViewCheckBoxColumn();
            btnYenile = new Button();
            btnDuzenle = new Button();
            btnSil = new Button();
            btnYazdir = new Button();
            btnPdf = new Button();
            btnHepsiniSec = new Button();
            btnSecimiKaldir = new Button();
            lblHastaAra = new Label();
            txtHastaAra = new TextBox();
            lblDoktorFiltresi = new Label();
            cmbDoktor = new ComboBox();
            lblDurumFiltresi = new Label();
            cmbDurumFiltresi = new ComboBox();
            lblRptFiltresi = new Label();
            cmbRptFiltresi = new ComboBox();
            chkTeslimTarihi = new CheckBox();
            dtpTeslimBaslangic = new DateTimePicker();
            lblTarihAyirac = new Label();
            dtpTeslimBitis = new DateTimePicker();
            chkAlinmaTarihi = new CheckBox();
            dtpAlinmaBaslangic = new DateTimePicker();
            lblAlinmaAyirac = new Label();
            dtpAlinmaBitis = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvIsler).BeginInit();
            SuspendLayout();
            // 
            // dgvIsler
            // 
            dgvIsler.AllowUserToAddRows = false;
            dgvIsler.AllowUserToDeleteRows = false;
            dgvIsler.AutoGenerateColumns = false;
            dgvIsler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIsler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIsler.Columns.AddRange(new DataGridViewColumn[] { colSec, colHastaAdi, colDoktor, colIsTuru, colDisNumarasi, colKayitTarihi, colTeslimTarihi, colDurum, colAciklama, colFiyat, colRptMi });
            dgvIsler.Location = new Point(12, 100);
            dgvIsler.MultiSelect = true;
            dgvIsler.Name = "dgvIsler";
            dgvIsler.ReadOnly = false;
            dgvIsler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIsler.Size = new Size(1060, 382);
            dgvIsler.TabIndex = 0;
            // 
            // colSec
            // 
            colSec.HeaderText = "Seç";
            colSec.Name = "colSec";
            colSec.Width = 45;
            colSec.FillWeight = 8F;
            colSec.ReadOnly = false;
            colSec.TrueValue = true;
            colSec.FalseValue = false;
            // 
            // lblHastaAra
            // 
            lblHastaAra.AutoSize = true;
            lblHastaAra.Location = new Point(12, 22);
            lblHastaAra.Name = "lblHastaAra";
            lblHastaAra.Size = new Size(56, 15);
            lblHastaAra.TabIndex = 3;
            lblHastaAra.Text = "Hasta ara";
            // 
            // txtHastaAra
            // 
            txtHastaAra.Location = new Point(75, 19);
            txtHastaAra.Name = "txtHastaAra";
            txtHastaAra.Size = new Size(165, 23);
            txtHastaAra.TabIndex = 4;
            txtHastaAra.TextChanged += FiltreDegisti;
            // 
            // lblDoktorFiltresi
            // 
            lblDoktorFiltresi.AutoSize = true;
            lblDoktorFiltresi.Location = new Point(258, 22);
            lblDoktorFiltresi.Name = "lblDoktorFiltresi";
            lblDoktorFiltresi.Size = new Size(48, 15);
            lblDoktorFiltresi.TabIndex = 5;
            lblDoktorFiltresi.Text = "Doktor";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(315, 19);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(170, 23);
            cmbDoktor.TabIndex = 6;
            cmbDoktor.SelectedIndexChanged += FiltreDegisti;
            // 
            // lblDurumFiltresi
            // 
            lblDurumFiltresi.AutoSize = true;
            lblDurumFiltresi.Location = new Point(505, 22);
            lblDurumFiltresi.Name = "lblDurumFiltresi";
            lblDurumFiltresi.Size = new Size(43, 15);
            lblDurumFiltresi.TabIndex = 7;
            lblDurumFiltresi.Text = "Durum";
            // 
            // cmbDurumFiltresi
            // 
            cmbDurumFiltresi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurumFiltresi.FormattingEnabled = true;
            cmbDurumFiltresi.Items.AddRange(new object[] { "Tümü", "Alındı", "Üretimde", "Kontrolde", "Teslime hazır", "Teslim edildi" });
            cmbDurumFiltresi.Location = new Point(555, 19);
            cmbDurumFiltresi.Name = "cmbDurumFiltresi";
            cmbDurumFiltresi.Size = new Size(140, 23);
            cmbDurumFiltresi.TabIndex = 8;
            cmbDurumFiltresi.SelectedIndexChanged += FiltreDegisti;
            // 
            // lblRptFiltresi
            // 
            lblRptFiltresi.AutoSize = true;
            lblRptFiltresi.Location = new Point(715, 22);
            lblRptFiltresi.Name = "lblRptFiltresi";
            lblRptFiltresi.Size = new Size(27, 15);
            lblRptFiltresi.TabIndex = 9;
            lblRptFiltresi.Text = "RPT";
            // 
            // cmbRptFiltresi
            // 
            cmbRptFiltresi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRptFiltresi.FormattingEnabled = true;
            cmbRptFiltresi.Items.AddRange(new object[] { "Tümü", "RPT olan", "RPT olmayan" });
            cmbRptFiltresi.Location = new Point(750, 19);
            cmbRptFiltresi.Name = "cmbRptFiltresi";
            cmbRptFiltresi.Size = new Size(135, 23);
            cmbRptFiltresi.TabIndex = 10;
            cmbRptFiltresi.SelectedIndexChanged += FiltreDegisti;
            // 
            // chkTeslimTarihi
            // 
            chkTeslimTarihi.AutoSize = true;
            chkTeslimTarihi.Location = new Point(12, 60);
            chkTeslimTarihi.Name = "chkTeslimTarihi";
            chkTeslimTarihi.Size = new Size(129, 19);
            chkTeslimTarihi.TabIndex = 11;
            chkTeslimTarihi.Text = "Teslim tarihi aralığı";
            chkTeslimTarihi.UseVisualStyleBackColor = true;
            chkTeslimTarihi.CheckedChanged += chkTeslimTarihi_CheckedChanged;
            // 
            // dtpTeslimBaslangic
            // 
            dtpTeslimBaslangic.Format = DateTimePickerFormat.Short;
            dtpTeslimBaslangic.Location = new Point(150, 57);
            dtpTeslimBaslangic.Name = "dtpTeslimBaslangic";
            dtpTeslimBaslangic.Size = new Size(120, 23);
            dtpTeslimBaslangic.TabIndex = 12;
            dtpTeslimBaslangic.ValueChanged += FiltreDegisti;
            // 
            // lblTarihAyirac
            // 
            lblTarihAyirac.AutoSize = true;
            lblTarihAyirac.Location = new Point(278, 60);
            lblTarihAyirac.Name = "lblTarihAyirac";
            lblTarihAyirac.Size = new Size(12, 15);
            lblTarihAyirac.TabIndex = 13;
            lblTarihAyirac.Text = "-";
            // 
            // dtpTeslimBitis
            // 
            dtpTeslimBitis.Format = DateTimePickerFormat.Short;
            dtpTeslimBitis.Location = new Point(298, 57);
            dtpTeslimBitis.Name = "dtpTeslimBitis";
            dtpTeslimBitis.Size = new Size(120, 23);
            dtpTeslimBitis.TabIndex = 14;
            dtpTeslimBitis.ValueChanged += FiltreDegisti;
            // 
            // chkAlinmaTarihi
            // 
            chkAlinmaTarihi.AutoSize = true;
            chkAlinmaTarihi.Location = new Point(440, 60);
            chkAlinmaTarihi.Name = "chkAlinmaTarihi";
            chkAlinmaTarihi.Size = new Size(136, 19);
            chkAlinmaTarihi.TabIndex = 20;
            chkAlinmaTarihi.Text = "Alınma tarihi aralığı";
            chkAlinmaTarihi.UseVisualStyleBackColor = true;
            chkAlinmaTarihi.CheckedChanged += chkAlinmaTarihi_CheckedChanged;
            // 
            // dtpAlinmaBaslangic
            // 
            dtpAlinmaBaslangic.Format = DateTimePickerFormat.Short;
            dtpAlinmaBaslangic.Location = new Point(585, 57);
            dtpAlinmaBaslangic.Name = "dtpAlinmaBaslangic";
            dtpAlinmaBaslangic.Size = new Size(120, 23);
            dtpAlinmaBaslangic.TabIndex = 21;
            dtpAlinmaBaslangic.ValueChanged += FiltreDegisti;
            // 
            // lblAlinmaAyirac
            // 
            lblAlinmaAyirac.AutoSize = true;
            lblAlinmaAyirac.Location = new Point(712, 60);
            lblAlinmaAyirac.Name = "lblAlinmaAyirac";
            lblAlinmaAyirac.Size = new Size(12, 15);
            lblAlinmaAyirac.TabIndex = 22;
            lblAlinmaAyirac.Text = "-";
            // 
            // dtpAlinmaBitis
            // 
            dtpAlinmaBitis.Format = DateTimePickerFormat.Short;
            dtpAlinmaBitis.Location = new Point(732, 57);
            dtpAlinmaBitis.Name = "dtpAlinmaBitis";
            dtpAlinmaBitis.Size = new Size(120, 23);
            dtpAlinmaBitis.TabIndex = 23;
            dtpAlinmaBitis.ValueChanged += FiltreDegisti;
            // 
            // colHastaAdi
            // 
            colHastaAdi.DataPropertyName = "HastaAdi";
            colHastaAdi.HeaderText = "Hasta adı";
            colHastaAdi.Name = "colHastaAdi";
            colHastaAdi.ReadOnly = true;
            // 
            // colDoktor
            // 
            colDoktor.DataPropertyName = "Doktor";
            colDoktor.HeaderText = "Doktor";
            colDoktor.Name = "colDoktor";
            colDoktor.ReadOnly = true;
            // 
            // colIsTuru
            // 
            colIsTuru.DataPropertyName = "IsTuru";
            colIsTuru.HeaderText = "İş türü";
            colIsTuru.Name = "colIsTuru";
            colIsTuru.ReadOnly = true;
            // 
            // colDisNumarasi
            // 
            colDisNumarasi.DataPropertyName = "DisNumarasi";
            colDisNumarasi.HeaderText = "Diş no";
            colDisNumarasi.Name = "colDisNumarasi";
            colDisNumarasi.ReadOnly = true;
            // 
            // colKayitTarihi
            // 
            colKayitTarihi.DataPropertyName = "KayitTarihi";
            colKayitTarihi.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            colKayitTarihi.HeaderText = "Alınma tarihi";
            colKayitTarihi.Name = "colKayitTarihi";
            colKayitTarihi.ReadOnly = true;
            // 
            // colTeslimTarihi
            // 
            colTeslimTarihi.DataPropertyName = "TeslimTarihi";
            colTeslimTarihi.DefaultCellStyle.Format = "dd.MM.yyyy";
            colTeslimTarihi.HeaderText = "Teslim tarihi";
            colTeslimTarihi.Name = "colTeslimTarihi";
            colTeslimTarihi.ReadOnly = true;
            // 
            // colDurum
            // 
            colDurum.DataPropertyName = "Durum";
            colDurum.HeaderText = "Durum";
            colDurum.Name = "colDurum";
            colDurum.ReadOnly = true;
            // 
            // colAciklama
            // 
            colAciklama.DataPropertyName = "Aciklama";
            colAciklama.HeaderText = "Açıklama";
            colAciklama.Name = "colAciklama";
            colAciklama.ReadOnly = true;
            // 
            // colFiyat
            // 
            colFiyat.DataPropertyName = "Fiyat";
            colFiyat.HeaderText = "Fiyat";
            colFiyat.Name = "colFiyat";
            colFiyat.ReadOnly = true;
            colFiyat.DefaultCellStyle.Format = "N2";
            // 
            // colRptMi
            // 
            colRptMi.DataPropertyName = "RptMi";
            colRptMi.HeaderText = "RPT";
            colRptMi.Name = "colRptMi";
            colRptMi.ReadOnly = true;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(952, 495);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(120, 35);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Location = new Point(826, 495);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(120, 35);
            btnDuzenle.TabIndex = 2;
            btnDuzenle.Text = "Seçileni Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(574, 495);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(120, 35);
            btnSil.TabIndex = 16;
            btnSil.Text = "Seçileni Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYazdir
            // 
            btnYazdir.Location = new Point(700, 495);
            btnYazdir.Name = "btnYazdir";
            btnYazdir.Size = new Size(120, 35);
            btnYazdir.TabIndex = 15;
            btnYazdir.Text = "İş Fişi Yazdır";
            btnYazdir.UseVisualStyleBackColor = true;
            btnYazdir.Click += btnYazdir_Click;
            // 
            // btnPdf
            // 
            btnPdf.Location = new Point(448, 495);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(120, 35);
            btnPdf.TabIndex = 17;
            btnPdf.Text = "PDF Kaydet";
            btnPdf.UseVisualStyleBackColor = true;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnHepsiniSec
            // 
            btnHepsiniSec.Location = new Point(196, 495);
            btnHepsiniSec.Name = "btnHepsiniSec";
            btnHepsiniSec.Size = new Size(100, 35);
            btnHepsiniSec.TabIndex = 18;
            btnHepsiniSec.Text = "Tümünü Seç";
            btnHepsiniSec.UseVisualStyleBackColor = true;
            btnHepsiniSec.Click += btnHepsiniSec_Click;
            // 
            // btnSecimiKaldir
            // 
            btnSecimiKaldir.Location = new Point(302, 495);
            btnSecimiKaldir.Name = "btnSecimiKaldir";
            btnSecimiKaldir.Size = new Size(110, 35);
            btnSecimiKaldir.TabIndex = 19;
            btnSecimiKaldir.Text = "Seçimi Kaldır";
            btnSecimiKaldir.UseVisualStyleBackColor = true;
            btnSecimiKaldir.Click += btnSecimiKaldir_Click;
            // 
            // frmIsListesi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 542);
            Controls.Add(dtpAlinmaBitis);
            Controls.Add(lblAlinmaAyirac);
            Controls.Add(dtpAlinmaBaslangic);
            Controls.Add(chkAlinmaTarihi);
            Controls.Add(cmbRptFiltresi);
            Controls.Add(lblRptFiltresi);
            Controls.Add(dtpTeslimBitis);
            Controls.Add(lblTarihAyirac);
            Controls.Add(dtpTeslimBaslangic);
            Controls.Add(chkTeslimTarihi);
            Controls.Add(cmbDurumFiltresi);
            Controls.Add(lblDurumFiltresi);
            Controls.Add(cmbDoktor);
            Controls.Add(lblDoktorFiltresi);
            Controls.Add(txtHastaAra);
            Controls.Add(lblHastaAra);
            Controls.Add(btnSecimiKaldir);
            Controls.Add(btnHepsiniSec);
            Controls.Add(btnPdf);
            Controls.Add(btnYazdir);
            Controls.Add(btnSil);
            Controls.Add(btnDuzenle);
            Controls.Add(btnYenile);
            Controls.Add(dgvIsler);
            Name = "frmIsListesi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "İş Listesi";
            Load += frmIsListesi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIsler).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvIsler;
        private DataGridViewCheckBoxColumn colSec;
        private DataGridViewTextBoxColumn colHastaAdi;
        private DataGridViewTextBoxColumn colDoktor;
        private DataGridViewTextBoxColumn colIsTuru;
        private DataGridViewTextBoxColumn colDisNumarasi;
        private DataGridViewTextBoxColumn colKayitTarihi;
        private DataGridViewTextBoxColumn colTeslimTarihi;
        private DataGridViewTextBoxColumn colDurum;
        private DataGridViewTextBoxColumn colAciklama;
        private DataGridViewTextBoxColumn colFiyat;
        private DataGridViewCheckBoxColumn colRptMi;
        private Button btnYenile;
        private Button btnDuzenle;
        private Button btnSil;
        private Button btnYazdir;
        private Button btnPdf;
        private Button btnHepsiniSec;
        private Button btnSecimiKaldir;
        private Label lblHastaAra;
        private TextBox txtHastaAra;
        private Label lblDoktorFiltresi;
        private ComboBox cmbDoktor;
        private Label lblDurumFiltresi;
        private ComboBox cmbDurumFiltresi;
        private Label lblRptFiltresi;
        private ComboBox cmbRptFiltresi;
        private CheckBox chkTeslimTarihi;
        private DateTimePicker dtpTeslimBaslangic;
        private Label lblTarihAyirac;
        private DateTimePicker dtpTeslimBitis;
        private CheckBox chkAlinmaTarihi;
        private DateTimePicker dtpAlinmaBaslangic;
        private Label lblAlinmaAyirac;
        private DateTimePicker dtpAlinmaBitis;
    }
}
