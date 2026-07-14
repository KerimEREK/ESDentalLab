namespace ESDentalLab
{
    partial class frmKasa
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
            lblKasaFiltre = new Label();
            cmbKasaFiltre = new ComboBox();
            btnYenile = new Button();
            btnBankaEkle = new Button();
            lblToplamBakiye = new Label();
            dgvHareketler = new DataGridView();
            lblCikisBaslik = new Label();
            lblCikisKasa = new Label();
            cmbCikisKasa = new ComboBox();
            lblCikisTutar = new Label();
            nudCikisTutar = new NumericUpDown();
            lblCikisAciklama = new Label();
            txtCikisAciklama = new TextBox();
            btnCikisKaydet = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHareketler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCikisTutar).BeginInit();
            SuspendLayout();
            // 
            // lblKasaFiltre
            // 
            lblKasaFiltre.AutoSize = true;
            lblKasaFiltre.Location = new Point(12, 18);
            lblKasaFiltre.Margin = new Padding(0, 8, 8, 0);
            lblKasaFiltre.Name = "lblKasaFiltre";
            lblKasaFiltre.Size = new Size(32, 15);
            lblKasaFiltre.Text = "Kasa";
            // 
            // cmbKasaFiltre
            // 
            cmbKasaFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKasaFiltre.Location = new Point(50, 14);
            cmbKasaFiltre.Margin = new Padding(0, 4, 12, 0);
            cmbKasaFiltre.Name = "cmbKasaFiltre";
            cmbKasaFiltre.Size = new Size(200, 23);
            cmbKasaFiltre.SelectedIndexChanged += cmbKasaFiltre_SelectedIndexChanged;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(260, 12);
            btnYenile.Margin = new Padding(0, 2, 8, 0);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(90, 30);
            btnYenile.Text = "Yenile";
            btnYenile.Click += btnYenile_Click;
            // 
            // btnBankaEkle
            // 
            btnBankaEkle.Location = new Point(358, 12);
            btnBankaEkle.Margin = new Padding(0, 2, 12, 0);
            btnBankaEkle.Name = "btnBankaEkle";
            btnBankaEkle.Size = new Size(130, 30);
            btnBankaEkle.Text = "Banka Hesabı Ekle";
            btnBankaEkle.Click += btnBankaEkle_Click;
            // 
            // lblToplamBakiye
            // 
            lblToplamBakiye.AutoSize = true;
            lblToplamBakiye.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblToplamBakiye.ForeColor = Color.FromArgb(22, 54, 78);
            lblToplamBakiye.Location = new Point(500, 16);
            lblToplamBakiye.Margin = new Padding(8, 6, 0, 0);
            lblToplamBakiye.Name = "lblToplamBakiye";
            lblToplamBakiye.Size = new Size(140, 19);
            lblToplamBakiye.Text = "Toplam kasa: 0 TL";
            // 
            // dgvHareketler
            // 
            dgvHareketler.AllowUserToAddRows = false;
            dgvHareketler.AllowUserToDeleteRows = false;
            dgvHareketler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHareketler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHareketler.Location = new Point(12, 56);
            dgvHareketler.MultiSelect = false;
            dgvHareketler.Name = "dgvHareketler";
            dgvHareketler.ReadOnly = true;
            dgvHareketler.RowHeadersVisible = false;
            dgvHareketler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHareketler.Size = new Size(900, 280);
            // 
            // lblCikisBaslik
            // 
            lblCikisBaslik.AutoSize = true;
            lblCikisBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCikisBaslik.Location = new Point(12, 350);
            lblCikisBaslik.Name = "lblCikisBaslik";
            lblCikisBaslik.Size = new Size(180, 15);
            lblCikisBaslik.Text = "Kasadan para çıkışı";
            // 
            // lblCikisKasa
            // 
            lblCikisKasa.AutoSize = true;
            lblCikisKasa.Location = new Point(12, 382);
            lblCikisKasa.Name = "lblCikisKasa";
            lblCikisKasa.Size = new Size(32, 15);
            lblCikisKasa.Text = "Kasa";
            // 
            // cmbCikisKasa
            // 
            cmbCikisKasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCikisKasa.Location = new Point(100, 379);
            cmbCikisKasa.Name = "cmbCikisKasa";
            cmbCikisKasa.Size = new Size(200, 23);
            // 
            // lblCikisTutar
            // 
            lblCikisTutar.AutoSize = true;
            lblCikisTutar.Location = new Point(320, 382);
            lblCikisTutar.Name = "lblCikisTutar";
            lblCikisTutar.Size = new Size(37, 15);
            lblCikisTutar.Text = "Tutar";
            // 
            // nudCikisTutar
            // 
            nudCikisTutar.DecimalPlaces = 2;
            nudCikisTutar.Location = new Point(370, 379);
            nudCikisTutar.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCikisTutar.Name = "nudCikisTutar";
            nudCikisTutar.Size = new Size(140, 23);
            nudCikisTutar.ThousandsSeparator = true;
            // 
            // lblCikisAciklama
            // 
            lblCikisAciklama.AutoSize = true;
            lblCikisAciklama.Location = new Point(12, 416);
            lblCikisAciklama.Name = "lblCikisAciklama";
            lblCikisAciklama.Size = new Size(56, 15);
            lblCikisAciklama.Text = "Açıklama";
            // 
            // txtCikisAciklama
            // 
            txtCikisAciklama.Location = new Point(100, 413);
            txtCikisAciklama.Name = "txtCikisAciklama";
            txtCikisAciklama.PlaceholderText = "Örn: Mutfak harcaması";
            txtCikisAciklama.Size = new Size(410, 23);
            // 
            // btnCikisKaydet
            // 
            btnCikisKaydet.Location = new Point(100, 450);
            btnCikisKaydet.Name = "btnCikisKaydet";
            btnCikisKaydet.Size = new Size(140, 34);
            btnCikisKaydet.Text = "Çıkış Kaydet";
            btnCikisKaydet.Click += btnCikisKaydet_Click;
            // 
            // frmKasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 520);
            Controls.Add(btnCikisKaydet);
            Controls.Add(txtCikisAciklama);
            Controls.Add(lblCikisAciklama);
            Controls.Add(nudCikisTutar);
            Controls.Add(lblCikisTutar);
            Controls.Add(cmbCikisKasa);
            Controls.Add(lblCikisKasa);
            Controls.Add(lblCikisBaslik);
            Controls.Add(dgvHareketler);
            Controls.Add(lblToplamBakiye);
            Controls.Add(btnBankaEkle);
            Controls.Add(btnYenile);
            Controls.Add(cmbKasaFiltre);
            Controls.Add(lblKasaFiltre);
            Name = "frmKasa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kasa İşlemleri";
            Load += frmKasa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHareketler).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCikisTutar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblKasaFiltre;
        private ComboBox cmbKasaFiltre;
        private Button btnYenile;
        private Button btnBankaEkle;
        private Label lblToplamBakiye;
        private DataGridView dgvHareketler;
        private Label lblCikisBaslik;
        private Label lblCikisKasa;
        private ComboBox cmbCikisKasa;
        private Label lblCikisTutar;
        private NumericUpDown nudCikisTutar;
        private Label lblCikisAciklama;
        private TextBox txtCikisAciklama;
        private Button btnCikisKaydet;
    }
}
