using System.ComponentModel;

namespace ESDentalLab
{
    public class frmDenetim : Form
    {
        private readonly DataGridView dgv = new();
        private readonly ComboBox cmbKategori = new();
        private readonly TextBox txtAra = new();
        private readonly CheckBox chkTarih = new();
        private readonly DateTimePicker dtpBaslangic = new();
        private readonly DateTimePicker dtpBitis = new();
        private readonly Button btnFiltrele = new();
        private readonly Label lblOzet = new();
        private readonly BindingList<DenetimSatir> _satirlar = new();

        public frmDenetim()
        {
            Text = "Denetim Kayıtları";
            Size = new Size(1000, 640);

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TarihMetni",
                    HeaderText = "Tarih",
                    FillWeight = 90,
                    MinimumWidth = 120
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Kullanici",
                    HeaderText = "Kullanıcı",
                    FillWeight = 90
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Kategori",
                    HeaderText = "Kategori",
                    FillWeight = 70
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Islem",
                    HeaderText = "İşlem",
                    FillWeight = 110
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Detay",
                    HeaderText = "Detay",
                    FillWeight = 220
                });

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv.DataSource = _satirlar;
            dgv.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DetayGoster();
                }
            };

            Label lblKategori = new Label { Text = "Kategori", AutoSize = true };
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Width = 130;
            cmbKategori.Items.AddRange(
            [
                "Tümü",
                DenetimKategori.Oturum,
                DenetimKategori.Is,
                DenetimKategori.Odeme,
                DenetimKategori.Doktor,
                DenetimKategori.Kasa,
                DenetimKategori.Kullanici,
                DenetimKategori.Sistem
            ]);
            cmbKategori.SelectedIndex = 0;

            Label lblAra = new Label { Text = "Ara", AutoSize = true };
            txtAra.Width = 180;
            txtAra.PlaceholderText = "işlem, kullanıcı, detay…";

            chkTarih.Text = "Tarih filtresi";
            chkTarih.AutoSize = true;
            chkTarih.Checked = true;
            chkTarih.CheckedChanged += (_, _) => TarihKontrolleriniAyarla();

            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Width = 110;
            dtpBaslangic.Value = DateTime.Today.AddDays(-30);

            Label lblAyirac = new Label { Text = "—", AutoSize = true };

            dtpBitis.Format = DateTimePickerFormat.Short;
            dtpBitis.Width = 110;
            dtpBitis.Value = DateTime.Today;

            btnFiltrele.Text = "Filtrele";
            btnFiltrele.Click += (_, _) => ListeyiYukle();

            Button btnDetay = new Button { Text = "Detay" };
            btnDetay.Click += (_, _) => DetayGoster();

            lblOzet.AutoSize = true;
            lblOzet.ForeColor = Color.FromArgb(70, 90, 105);
            lblOzet.Padding = new Padding(8, 8, 0, 0);

            Controls.Add(dgv);
            Controls.Add(lblKategori);
            Controls.Add(cmbKategori);
            Controls.Add(lblAra);
            Controls.Add(txtAra);
            Controls.Add(chkTarih);
            Controls.Add(dtpBaslangic);
            Controls.Add(lblAyirac);
            Controls.Add(dtpBitis);
            Controls.Add(btnFiltrele);
            Controls.Add(btnDetay);
            Controls.Add(lblOzet);

            ArayuzTema.Uygula(this, "Denetim Kayıtları", "Kim ne yaptı — işlem geçmişini inceleyin");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgv,
                [
                    lblKategori, cmbKategori,
                    lblAra, txtAra,
                    chkTarih, dtpBaslangic, lblAyirac, dtpBitis,
                    btnFiltrele
                ],
                [btnDetay, lblOzet],
                ustYukseklik: 70,
                altYukseklik: 48);

            TarihKontrolleriniAyarla();
            Load += (_, _) => ListeyiYukle();
        }

        private void TarihKontrolleriniAyarla()
        {
            dtpBaslangic.Enabled = chkTarih.Checked;
            dtpBitis.Enabled = chkTarih.Checked;
        }

        private void ListeyiYukle()
        {
            string? kategori = cmbKategori.SelectedItem as string;
            DateTime? baslangic = chkTarih.Checked ? dtpBaslangic.Value.Date : null;
            DateTime? bitis = chkTarih.Checked ? dtpBitis.Value.Date : null;

            List<DenetimKaydi> kayitlar = VeriDeposu.DenetimleriListele(
                kategori,
                txtAra.Text,
                baslangic,
                bitis).ToList();

            _satirlar.Clear();
            foreach (DenetimKaydi k in kayitlar)
            {
                _satirlar.Add(new DenetimSatir(k));
            }

            lblOzet.Text = $"{kayitlar.Count} kayıt";
        }

        private void DetayGoster()
        {
            if (dgv.CurrentRow?.DataBoundItem is not DenetimSatir satir)
            {
                MessageBox.Show("Detay için bir kayıt seçin.", "Seçim yok");
                return;
            }

            DenetimKaydi k = satir.Kaynak;
            MessageBox.Show(
                $"Tarih: {k.Tarih:dd.MM.yyyy HH:mm:ss}\n" +
                $"Kullanıcı: {k.AdSoyad} ({k.KullaniciAdi})\n" +
                $"Kategori: {k.Kategori}\n" +
                $"İşlem: {k.Islem}\n\n" +
                $"{(string.IsNullOrWhiteSpace(k.Detay) ? "Ek detay yok." : k.Detay)}",
                "Denetim detayı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private sealed class DenetimSatir
        {
            public DenetimSatir(DenetimKaydi kaynak)
            {
                Kaynak = kaynak;
            }

            public DenetimKaydi Kaynak { get; }
            public string TarihMetni => Kaynak.Tarih.ToString("dd.MM.yyyy HH:mm");
            public string Kullanici => string.IsNullOrWhiteSpace(Kaynak.AdSoyad)
                ? Kaynak.KullaniciAdi
                : $"{Kaynak.AdSoyad}";
            public string Kategori => Kaynak.Kategori;
            public string Islem => Kaynak.Islem;
            public string Detay => Kaynak.Detay;
        }
    }
}
