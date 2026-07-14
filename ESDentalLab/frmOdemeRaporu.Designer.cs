namespace ESDentalLab
{
    partial class frmOdemeRaporu
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
            lblOdemeYontemi = new Label();
            cmbOdemeYontemi = new ComboBox();
            chkTarihFiltrele = new CheckBox();
            dtpBaslangic = new DateTimePicker();
            lblTarihAyirac = new Label();
            dtpBitis = new DateTimePicker();
            btnFiltrele = new Button();
            chkIptalleriGoster = new CheckBox();
            dgvOdemeler = new DataGridView();
            colDoktor = new DataGridViewTextBoxColumn();
            colTarih = new DataGridViewTextBoxColumn();
            colTutar = new DataGridViewTextBoxColumn();
            colYontem = new DataGridViewTextBoxColumn();
            colDurum = new DataGridViewTextBoxColumn();
            colAciklama = new DataGridViewTextBoxColumn();
            btnDetay = new Button();
            btnIptal = new Button();
            lblToplam = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).BeginInit();
            SuspendLayout();
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(18, 20);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(48, 15);
            lblDoktor.TabIndex = 0;
            lblDoktor.Text = "Doktor";
            // 
            // cmbDoktor
            // 
            cmbDoktor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(75, 17);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(175, 23);
            cmbDoktor.TabIndex = 1;
            // 
            // lblOdemeYontemi
            // 
            lblOdemeYontemi.AutoSize = true;
            lblOdemeYontemi.Location = new Point(270, 20);
            lblOdemeYontemi.Name = "lblOdemeYontemi";
            lblOdemeYontemi.Size = new Size(89, 15);
            lblOdemeYontemi.TabIndex = 2;
            lblOdemeYontemi.Text = "Ödeme yöntemi";
            // 
            // cmbOdemeYontemi
            // 
            cmbOdemeYontemi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOdemeYontemi.FormattingEnabled = true;
            cmbOdemeYontemi.Items.AddRange(new object[] { "Tümü", "Nakit", "Havale / EFT", "Kredi kartı", "Banka kartı", "Çek / Senet", "Diğer" });
            cmbOdemeYontemi.Location = new Point(368, 17);
            cmbOdemeYontemi.Name = "cmbOdemeYontemi";
            cmbOdemeYontemi.Size = new Size(150, 23);
            cmbOdemeYontemi.TabIndex = 3;
            // 
            // chkTarihFiltrele
            // 
            chkTarihFiltrele.AutoSize = true;
            chkTarihFiltrele.Location = new Point(18, 58);
            chkTarihFiltrele.Name = "chkTarihFiltrele";
            chkTarihFiltrele.Size = new Size(95, 19);
            chkTarihFiltrele.TabIndex = 4;
            chkTarihFiltrele.Text = "Tarih aralığı";
            chkTarihFiltrele.UseVisualStyleBackColor = true;
            chkTarihFiltrele.CheckedChanged += chkTarihFiltrele_CheckedChanged;
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Location = new Point(122, 55);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(120, 23);
            dtpBaslangic.TabIndex = 5;
            // 
            // lblTarihAyirac
            // 
            lblTarihAyirac.AutoSize = true;
            lblTarihAyirac.Location = new Point(250, 58);
            lblTarihAyirac.Name = "lblTarihAyirac";
            lblTarihAyirac.Size = new Size(12, 15);
            lblTarihAyirac.TabIndex = 6;
            lblTarihAyirac.Text = "-";
            // 
            // dtpBitis
            // 
            dtpBitis.Format = DateTimePickerFormat.Short;
            dtpBitis.Location = new Point(270, 55);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(120, 23);
            dtpBitis.TabIndex = 7;
            // 
            // btnFiltrele
            // 
            btnFiltrele.Location = new Point(750, 44);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(120, 35);
            btnFiltrele.TabIndex = 8;
            btnFiltrele.Text = "Filtrele";
            btnFiltrele.UseVisualStyleBackColor = true;
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // chkIptalleriGoster
            // 
            chkIptalleriGoster.AutoSize = true;
            chkIptalleriGoster.Location = new Point(540, 52);
            chkIptalleriGoster.Name = "chkIptalleriGoster";
            chkIptalleriGoster.Size = new Size(120, 19);
            chkIptalleriGoster.TabIndex = 11;
            chkIptalleriGoster.Text = "İptalleri göster";
            chkIptalleriGoster.UseVisualStyleBackColor = true;
            chkIptalleriGoster.CheckedChanged += chkIptalleriGoster_CheckedChanged;
            // 
            // dgvOdemeler
            // 
            dgvOdemeler.AllowUserToAddRows = false;
            dgvOdemeler.AllowUserToDeleteRows = false;
            dgvOdemeler.AutoGenerateColumns = false;
            dgvOdemeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOdemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOdemeler.Columns.AddRange(new DataGridViewColumn[] { colDoktor, colTarih, colTutar, colYontem, colDurum, colAciklama });
            dgvOdemeler.Location = new Point(18, 100);
            dgvOdemeler.Name = "dgvOdemeler";
            dgvOdemeler.ReadOnly = true;
            dgvOdemeler.RowHeadersVisible = false;
            dgvOdemeler.ScrollBars = ScrollBars.Both;
            dgvOdemeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOdemeler.Size = new Size(852, 330);
            dgvOdemeler.TabIndex = 9;
            dgvOdemeler.MultiSelect = false;
            // 
            // colDoktor
            // 
            colDoktor.DataPropertyName = "Doktor";
            colDoktor.FillWeight = 18F;
            colDoktor.HeaderText = "Doktor";
            colDoktor.Name = "colDoktor";
            colDoktor.ReadOnly = true;
            // 
            // colTarih
            // 
            colTarih.DataPropertyName = "Tarih";
            colTarih.FillWeight = 12F;
            colTarih.HeaderText = "Tarih";
            colTarih.Name = "colTarih";
            colTarih.ReadOnly = true;
            colTarih.DefaultCellStyle.Format = "d";
            // 
            // colTutar
            // 
            colTutar.DataPropertyName = "Tutar";
            colTutar.FillWeight = 12F;
            colTutar.HeaderText = "Tutar";
            colTutar.Name = "colTutar";
            colTutar.ReadOnly = true;
            colTutar.DefaultCellStyle.Format = "N2";
            // 
            // colYontem
            // 
            colYontem.DataPropertyName = "OdemeYontemi";
            colYontem.FillWeight = 14F;
            colYontem.HeaderText = "Ödeme yöntemi";
            colYontem.Name = "colYontem";
            colYontem.ReadOnly = true;
            // 
            // colDurum
            // 
            colDurum.DataPropertyName = "Durum";
            colDurum.FillWeight = 8F;
            colDurum.HeaderText = "Durum";
            colDurum.Name = "colDurum";
            colDurum.ReadOnly = true;
            // 
            // colAciklama
            // 
            colAciklama.DataPropertyName = "DagitimOzeti";
            colAciklama.FillWeight = 36F;
            colAciklama.HeaderText = "Dağılım";
            colAciklama.MinimumWidth = 180;
            colAciklama.Name = "colAciklama";
            colAciklama.ReadOnly = true;
            // 
            // btnDetay
            // 
            btnDetay.Location = new Point(18, 445);
            btnDetay.Name = "btnDetay";
            btnDetay.Size = new Size(110, 34);
            btnDetay.TabIndex = 12;
            btnDetay.Text = "Detay";
            btnDetay.UseVisualStyleBackColor = true;
            btnDetay.Click += btnDetay_Click;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(140, 445);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(110, 34);
            btnIptal.TabIndex = 13;
            btnIptal.Text = "İptal et";
            btnIptal.UseVisualStyleBackColor = true;
            btnIptal.Click += btnIptal_Click;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblToplam.ForeColor = Color.FromArgb(22, 54, 78);
            lblToplam.Location = new Point(270, 452);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(120, 20);
            lblToplam.TabIndex = 10;
            lblToplam.Text = "Toplam ödeme: 0";
            // 
            // frmOdemeRaporu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 490);
            Controls.Add(lblToplam);
            Controls.Add(btnIptal);
            Controls.Add(btnDetay);
            Controls.Add(dgvOdemeler);
            Controls.Add(chkIptalleriGoster);
            Controls.Add(btnFiltrele);
            Controls.Add(dtpBitis);
            Controls.Add(lblTarihAyirac);
            Controls.Add(dtpBaslangic);
            Controls.Add(chkTarihFiltrele);
            Controls.Add(cmbOdemeYontemi);
            Controls.Add(lblOdemeYontemi);
            Controls.Add(cmbDoktor);
            Controls.Add(lblDoktor);
            Name = "frmOdemeRaporu";
            Text = "Ödeme Raporları";
            Load += frmOdemeRaporu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDoktor;
        private ComboBox cmbDoktor;
        private Label lblOdemeYontemi;
        private ComboBox cmbOdemeYontemi;
        private CheckBox chkTarihFiltrele;
        private DateTimePicker dtpBaslangic;
        private Label lblTarihAyirac;
        private DateTimePicker dtpBitis;
        private Button btnFiltrele;
        private CheckBox chkIptalleriGoster;
        private DataGridView dgvOdemeler;
        private DataGridViewTextBoxColumn colDoktor;
        private DataGridViewTextBoxColumn colTarih;
        private DataGridViewTextBoxColumn colTutar;
        private DataGridViewTextBoxColumn colYontem;
        private DataGridViewTextBoxColumn colDurum;
        private DataGridViewTextBoxColumn colAciklama;
        private Button btnDetay;
        private Button btnIptal;
        private Label lblToplam;
    }
}
