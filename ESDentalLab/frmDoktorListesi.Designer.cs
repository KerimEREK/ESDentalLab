namespace ESDentalLab
{
    partial class frmDoktorListesi
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvDoktorlar = new DataGridView();
            lblBaslik = new Label();
            btnDuzenle = new Button();
            btnKaldir = new Button();
            btnAktiflestir = new Button();
            chkPasifleriGoster = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).BeginInit();
            SuspendLayout();
            // 
            // dgvDoktorlar
            // 
            dgvDoktorlar.AllowUserToAddRows = false;
            dgvDoktorlar.AllowUserToDeleteRows = false;
            dgvDoktorlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoktorlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoktorlar.Location = new Point(20, 65);
            dgvDoktorlar.MultiSelect = false;
            dgvDoktorlar.Name = "dgvDoktorlar";
            dgvDoktorlar.ReadOnly = true;
            dgvDoktorlar.RowHeadersVisible = false;
            dgvDoktorlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoktorlar.Size = new Size(760, 310);
            dgvDoktorlar.TabIndex = 0;
            dgvDoktorlar.CellDoubleClick += dgvDoktorlar_CellDoubleClick;
            dgvDoktorlar.SelectionChanged += dgvDoktorlar_SelectionChanged;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBaslik.Location = new Point(20, 22);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(138, 25);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "Doktor Listesi";
            // 
            // btnDuzenle
            // 
            btnDuzenle.Location = new Point(20, 390);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(120, 34);
            btnDuzenle.TabIndex = 2;
            btnDuzenle.Text = "Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnKaldir
            // 
            btnKaldir.Location = new Point(150, 390);
            btnKaldir.Name = "btnKaldir";
            btnKaldir.Size = new Size(140, 34);
            btnKaldir.TabIndex = 3;
            btnKaldir.Text = "Kaldır / Pasif Yap";
            btnKaldir.UseVisualStyleBackColor = true;
            btnKaldir.Click += btnKaldir_Click;
            // 
            // btnAktiflestir
            // 
            btnAktiflestir.Location = new Point(300, 390);
            btnAktiflestir.Name = "btnAktiflestir";
            btnAktiflestir.Size = new Size(140, 34);
            btnAktiflestir.TabIndex = 4;
            btnAktiflestir.Text = "Tekrar Aktif Yap";
            btnAktiflestir.UseVisualStyleBackColor = true;
            btnAktiflestir.Click += btnAktiflestir_Click;
            // 
            // chkPasifleriGoster
            // 
            chkPasifleriGoster.AutoSize = true;
            chkPasifleriGoster.Location = new Point(620, 398);
            chkPasifleriGoster.Name = "chkPasifleriGoster";
            chkPasifleriGoster.Size = new Size(160, 19);
            chkPasifleriGoster.TabIndex = 5;
            chkPasifleriGoster.Text = "Pasif doktorları da göster";
            chkPasifleriGoster.UseVisualStyleBackColor = true;
            chkPasifleriGoster.CheckedChanged += chkPasifleriGoster_CheckedChanged;
            // 
            // frmDoktorListesi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 440);
            Controls.Add(chkPasifleriGoster);
            Controls.Add(btnAktiflestir);
            Controls.Add(btnKaldir);
            Controls.Add(btnDuzenle);
            Controls.Add(lblBaslik);
            Controls.Add(dgvDoktorlar);
            Name = "frmDoktorListesi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Doktor Listesi";
            Load += frmDoktorListesi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDoktorlar;
        private Label lblBaslik;
        private Button btnDuzenle;
        private Button btnKaldir;
        private Button btnAktiflestir;
        private CheckBox chkPasifleriGoster;
    }
}
