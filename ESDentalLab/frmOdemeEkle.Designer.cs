namespace ESDentalLab
{
    partial class frmOdemeEkle
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
            cmbDoktor = new ComboBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblTutar = new Label();
            nudTutar = new NumericUpDown();
            lblOdemeYontemi = new Label();
            cmbOdemeYontemi = new ComboBox();
            lblKasa = new Label();
            cmbKasa = new ComboBox();
            lblAciklama = new Label();
            txtAciklama = new TextBox();
            btnKaydet = new Button();
            btnIptal = new Button();
            lblIsListesi = new Label();
            dgvIsler = new DataGridView();
            colSec = new DataGridViewCheckBoxColumn();
            colHasta = new DataGridViewTextBoxColumn();
            colIsTuru = new DataGridViewTextBoxColumn();
            colFiyat = new DataGridViewTextBoxColumn();
            colOdendi = new DataGridViewTextBoxColumn();
            colKalan = new DataGridViewTextBoxColumn();
            lblSecimOzet = new Label();
            lblBakiye = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTutar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIsler).BeginInit();
            SuspendLayout();
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(16, 16);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.Text = "Doktor";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.Location = new Point(120, 13);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(240, 23);
            cmbDoktor.SelectedIndexChanged += cmbDoktor_SelectedIndexChanged;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(16, 52);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(37, 15);
            lblTarih.Text = "Tarih";
            // 
            // dtpTarih
            // 
            dtpTarih.Format = DateTimePickerFormat.Short;
            dtpTarih.Location = new Point(120, 49);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(240, 23);
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Location = new Point(16, 88);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(37, 15);
            lblTutar.Text = "Tutar";
            // 
            // nudTutar
            // 
            nudTutar.DecimalPlaces = 2;
            nudTutar.Location = new Point(120, 85);
            nudTutar.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTutar.Name = "nudTutar";
            nudTutar.Size = new Size(240, 23);
            nudTutar.ThousandsSeparator = true;
            // 
            // lblOdemeYontemi
            // 
            lblOdemeYontemi.AutoSize = true;
            lblOdemeYontemi.Location = new Point(16, 124);
            lblOdemeYontemi.Name = "lblOdemeYontemi";
            lblOdemeYontemi.Size = new Size(89, 15);
            lblOdemeYontemi.Text = "Ödeme yöntemi";
            // 
            // cmbOdemeYontemi
            // 
            cmbOdemeYontemi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOdemeYontemi.Items.AddRange(new object[] { "Nakit", "Havale / EFT", "Kredi kartı", "Banka kartı", "Çek / Senet", "Diğer" });
            cmbOdemeYontemi.Location = new Point(120, 121);
            cmbOdemeYontemi.Name = "cmbOdemeYontemi";
            cmbOdemeYontemi.Size = new Size(240, 23);
            cmbOdemeYontemi.SelectedIndexChanged += cmbOdemeYontemi_SelectedIndexChanged;
            // 
            // lblKasa
            // 
            lblKasa.AutoSize = true;
            lblKasa.Location = new Point(16, 160);
            lblKasa.Name = "lblKasa";
            lblKasa.Size = new Size(32, 15);
            lblKasa.Text = "Kasa";
            // 
            // cmbKasa
            // 
            cmbKasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKasa.Location = new Point(120, 157);
            cmbKasa.Name = "cmbKasa";
            cmbKasa.Size = new Size(240, 23);
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(16, 196);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(56, 15);
            lblAciklama.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(120, 193);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(240, 70);
            // 
            // lblBakiye
            // 
            lblBakiye.AutoSize = true;
            lblBakiye.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBakiye.ForeColor = Color.FromArgb(22, 54, 78);
            lblBakiye.Location = new Point(16, 278);
            lblBakiye.Name = "lblBakiye";
            lblBakiye.Size = new Size(100, 15);
            lblBakiye.Text = "Toplam bakiye: 0,00 TL";
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(120, 310);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(110, 34);
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(250, 310);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(110, 34);
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // lblIsListesi
            // 
            lblIsListesi.AutoSize = true;
            lblIsListesi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIsListesi.Location = new Point(400, 16);
            lblIsListesi.Name = "lblIsListesi";
            lblIsListesi.Size = new Size(220, 15);
            lblIsListesi.Text = "Doktora ait ödenebilir işler";
            // 
            // dgvIsler
            // 
            dgvIsler.AllowUserToAddRows = false;
            dgvIsler.AllowUserToDeleteRows = false;
            dgvIsler.AutoGenerateColumns = false;
            dgvIsler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIsler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIsler.Columns.AddRange(new DataGridViewColumn[] { colSec, colHasta, colIsTuru, colFiyat, colOdendi, colKalan });
            dgvIsler.Location = new Point(400, 40);
            dgvIsler.MultiSelect = true;
            dgvIsler.Name = "dgvIsler";
            dgvIsler.RowHeadersVisible = false;
            dgvIsler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIsler.Size = new Size(520, 250);
            dgvIsler.CellContentClick += dgvIsler_CellContentClick;
            dgvIsler.CellValueChanged += dgvIsler_CellValueChanged;
            dgvIsler.CurrentCellDirtyStateChanged += dgvIsler_CurrentCellDirtyStateChanged;
            // 
            // colSec
            // 
            colSec.HeaderText = "Seç";
            colSec.Name = "colSec";
            colSec.Width = 45;
            colSec.FillWeight = 12F;
            // 
            // colHasta
            // 
            colHasta.DataPropertyName = "HastaAdi";
            colHasta.HeaderText = "Hasta";
            colHasta.Name = "colHasta";
            colHasta.ReadOnly = true;
            colHasta.FillWeight = 28F;
            // 
            // colIsTuru
            // 
            colIsTuru.DataPropertyName = "IsTuru";
            colIsTuru.HeaderText = "İş türü";
            colIsTuru.Name = "colIsTuru";
            colIsTuru.ReadOnly = true;
            colIsTuru.FillWeight = 20F;
            // 
            // colFiyat
            // 
            colFiyat.DataPropertyName = "Fiyat";
            colFiyat.DefaultCellStyle.Format = "N2";
            colFiyat.HeaderText = "Fiyat";
            colFiyat.Name = "colFiyat";
            colFiyat.ReadOnly = true;
            colFiyat.FillWeight = 14F;
            // 
            // colOdendi
            // 
            colOdendi.DataPropertyName = "OdendiTutari";
            colOdendi.DefaultCellStyle.Format = "N2";
            colOdendi.HeaderText = "Ödenen";
            colOdendi.Name = "colOdendi";
            colOdendi.ReadOnly = true;
            colOdendi.FillWeight = 14F;
            // 
            // colKalan
            // 
            colKalan.DataPropertyName = "KalanTutar";
            colKalan.DefaultCellStyle.Format = "N2";
            colKalan.HeaderText = "Kalan";
            colKalan.Name = "colKalan";
            colKalan.ReadOnly = true;
            colKalan.FillWeight = 14F;
            // 
            // lblSecimOzet
            // 
            lblSecimOzet.AutoSize = true;
            lblSecimOzet.Location = new Point(400, 300);
            lblSecimOzet.Name = "lblSecimOzet";
            lblSecimOzet.Size = new Size(180, 15);
            lblSecimOzet.Text = "Seçili iş yok · genel ödeme yapılabilir";
            // 
            // frmOdemeEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 580);
            MinimumSize = new Size(920, 520);
            Controls.Add(lblSecimOzet);
            Controls.Add(dgvIsler);
            Controls.Add(lblIsListesi);
            Controls.Add(lblBakiye);
            Controls.Add(btnIptal);
            Controls.Add(btnKaydet);
            Controls.Add(txtAciklama);
            Controls.Add(lblAciklama);
            Controls.Add(cmbKasa);
            Controls.Add(lblKasa);
            Controls.Add(cmbOdemeYontemi);
            Controls.Add(lblOdemeYontemi);
            Controls.Add(nudTutar);
            Controls.Add(lblTutar);
            Controls.Add(dtpTarih);
            Controls.Add(lblTarih);
            Controls.Add(cmbDoktor);
            Controls.Add(lblDoktor);
            Name = "frmOdemeEkle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Doktor Ödemesi Ekle";
            Load += frmOdemeEkle_Load;
            ((System.ComponentModel.ISupportInitialize)nudTutar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIsler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDoktor;
        private ComboBox cmbDoktor;
        private Label lblTarih;
        private DateTimePicker dtpTarih;
        private Label lblTutar;
        private NumericUpDown nudTutar;
        private Label lblOdemeYontemi;
        private ComboBox cmbOdemeYontemi;
        private Label lblKasa;
        private ComboBox cmbKasa;
        private Label lblAciklama;
        private TextBox txtAciklama;
        private Button btnKaydet;
        private Button btnIptal;
        private Label lblIsListesi;
        private DataGridView dgvIsler;
        private DataGridViewCheckBoxColumn colSec;
        private DataGridViewTextBoxColumn colHasta;
        private DataGridViewTextBoxColumn colIsTuru;
        private DataGridViewTextBoxColumn colFiyat;
        private DataGridViewTextBoxColumn colOdendi;
        private DataGridViewTextBoxColumn colKalan;
        private Label lblSecimOzet;
        private Label lblBakiye;
    }
}
