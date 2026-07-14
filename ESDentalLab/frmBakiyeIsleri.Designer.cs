namespace ESDentalLab
{
    partial class frmBakiyeIsleri
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvIsler = new DataGridView();
            colHastaAdi = new DataGridViewTextBoxColumn();
            colDoktor = new DataGridViewTextBoxColumn();
            colIsTuru = new DataGridViewTextBoxColumn();
            colDisNumarasi = new DataGridViewTextBoxColumn();
            colKayitTarihi = new DataGridViewTextBoxColumn();
            colTeslimTarihi = new DataGridViewTextBoxColumn();
            colDurum = new DataGridViewTextBoxColumn();
            colFiyat = new DataGridViewTextBoxColumn();
            colRptMi = new DataGridViewCheckBoxColumn();
            btnYenile = new Button();
            btnOdemeEkle = new Button();
            lblOzet = new Label();
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
            dgvIsler.Columns.AddRange(new DataGridViewColumn[] { colHastaAdi, colDoktor, colIsTuru, colDisNumarasi, colKayitTarihi, colTeslimTarihi, colDurum, colFiyat, colRptMi });
            dgvIsler.Location = new Point(12, 20);
            dgvIsler.MultiSelect = false;
            dgvIsler.Name = "dgvIsler";
            dgvIsler.ReadOnly = true;
            dgvIsler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIsler.Size = new Size(1060, 400);
            dgvIsler.TabIndex = 0;
            dgvIsler.CellDoubleClick += dgvIsler_CellDoubleClick;
            dgvIsler.SelectionChanged += dgvIsler_SelectionChanged;
            // 
            // colHastaAdi
            // 
            colHastaAdi.DataPropertyName = "HastaAdi";
            colHastaAdi.HeaderText = "Hasta";
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
            colTeslimTarihi.HeaderText = "Teslim";
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
            // colFiyat
            // 
            colFiyat.DataPropertyName = "Fiyat";
            colFiyat.DefaultCellStyle.Format = "N2";
            colFiyat.HeaderText = "Fiyat (TL)";
            colFiyat.Name = "colFiyat";
            colFiyat.ReadOnly = true;
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
            btnYenile.Location = new Point(12, 435);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(100, 34);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnOdemeEkle
            // 
            btnOdemeEkle.Location = new Point(120, 435);
            btnOdemeEkle.Name = "btnOdemeEkle";
            btnOdemeEkle.Size = new Size(150, 34);
            btnOdemeEkle.TabIndex = 2;
            btnOdemeEkle.Text = "Ödeme Ekle";
            btnOdemeEkle.UseVisualStyleBackColor = true;
            btnOdemeEkle.Click += btnOdemeEkle_Click;
            // 
            // lblOzet
            // 
            lblOzet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOzet.AutoSize = true;
            lblOzet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOzet.ForeColor = Color.FromArgb(22, 54, 78);
            lblOzet.Location = new Point(620, 443);
            lblOzet.Name = "lblOzet";
            lblOzet.Size = new Size(0, 15);
            lblOzet.TabIndex = 3;
            // 
            // frmBakiyeIsleri
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 480);
            Controls.Add(lblOzet);
            Controls.Add(btnOdemeEkle);
            Controls.Add(btnYenile);
            Controls.Add(dgvIsler);
            Name = "frmBakiyeIsleri";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bakiye İşleri";
            Load += frmBakiyeIsleri_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIsler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvIsler;
        private DataGridViewTextBoxColumn colHastaAdi;
        private DataGridViewTextBoxColumn colDoktor;
        private DataGridViewTextBoxColumn colIsTuru;
        private DataGridViewTextBoxColumn colDisNumarasi;
        private DataGridViewTextBoxColumn colKayitTarihi;
        private DataGridViewTextBoxColumn colTeslimTarihi;
        private DataGridViewTextBoxColumn colDurum;
        private DataGridViewTextBoxColumn colFiyat;
        private DataGridViewCheckBoxColumn colRptMi;
        private Button btnYenile;
        private Button btnOdemeEkle;
        private Label lblOzet;
    }
}
