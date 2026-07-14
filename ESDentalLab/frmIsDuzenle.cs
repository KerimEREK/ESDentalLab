namespace ESDentalLab
{
    public partial class frmIsDuzenle : Form
    {
        private readonly Is _isKaydi;

        public frmIsDuzenle(Is isKaydi)
        {
            InitializeComponent();
            _isKaydi = isKaydi;
            ArayuzTema.Uygula(this, "İş Kaydını Düzenle", "Hasta, doktor, durum ve fiyat bilgilerini güncelleyin");
            // Tema başlığı içerik alanını küçültür; fiyat/RPT/butonlar görünsün
            ClientSize = new Size(Math.Max(ClientSize.Width, 460), Math.Max(ClientSize.Height, 620));
        }

        private void frmIsDuzenle_Load(object sender, EventArgs e)
        {
            lblIsNumarasi.Text = $"İş no: {_isKaydi.IsNumarasi}    |    Alınma: {_isKaydi.KayitTarihi:dd.MM.yyyy HH:mm}";

            List<Doctor> doktorlar = VeriDeposu.AktifDoktorlar.ToList();
            if (!doktorlar.Any(doktor => ReferenceEquals(doktor, _isKaydi.Doktor)))
            {
                doktorlar.Insert(0, _isKaydi.Doktor);
            }

            cmbDoktor.DataSource = doktorlar;
            cmbDoktor.SelectedItem = _isKaydi.Doktor;
            cmbIsTuru.DataSource = VeriDeposu.IsTurleri.ToList();
            cmbIsTuru.Text = _isKaydi.IsTuru;
            txtHastaAdi.Text = _isKaydi.HastaAdi;
            txtDisNumarasi.Text = _isKaydi.DisNumarasi;
            cmbDurum.SelectedItem = _isKaydi.Durum;
            dtpTeslimTarihi.Value = _isKaydi.TeslimTarihi == default ? DateTime.Today : _isKaydi.TeslimTarihi;
            txtAciklama.Text = _isKaydi.Aciklama;
            nudFiyat.Value = Math.Min(_isKaydi.Fiyat, nudFiyat.Maximum);
            chkRptMi.Checked = _isKaydi.RptMi;
            chkRptMi.CheckedChanged += chkRptMi_CheckedChanged;
            RptAlanlariniAyarla();

            ArayuzTema.ComboboxAramaEtkinlestir(cmbDoktor);
            ArayuzTema.ComboboxAramaEtkinlestir(cmbIsTuru, serbestMetinIzin: true);
        }

        private void chkRptMi_CheckedChanged(object? sender, EventArgs e)
        {
            RptAlanlariniAyarla();
        }

        private void RptAlanlariniAyarla()
        {
            if (chkRptMi.Checked)
            {
                nudFiyat.Value = 0;
                nudFiyat.Enabled = false;
            }
            else
            {
                nudFiyat.Enabled = true;
            }
        }

        private void btnIsTuruEkle_Click(object sender, EventArgs e)
        {
            string tur = cmbIsTuru.Text.Trim();
            if (string.IsNullOrWhiteSpace(tur))
            {
                tur = IsTuruAdiSor();
                if (string.IsNullOrWhiteSpace(tur))
                {
                    return;
                }
            }

            (bool basarili, string mesaj) = VeriDeposu.IsTuruEkle(tur);
            if (!basarili)
            {
                MessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IsTuruListesiniYenile(tur);
            MessageBox.Show(mesaj, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIsTuruSil_Click(object sender, EventArgs e)
        {
            string tur = cmbIsTuru.Text.Trim();
            if (string.IsNullOrWhiteSpace(tur))
            {
                MessageBox.Show("Silmek için listeden bir iş türü seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"\"{tur}\" iş türünü listeden silmek istiyor musunuz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.IsTuruSil(tur);
            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Uyarı",
                MessageBoxButtons.OK, basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili)
            {
                IsTuruListesiniYenile(_isKaydi.IsTuru);
            }
        }

        private void IsTuruListesiniYenile(string? secili)
        {
            ArayuzTema.ComboboxAramaKaynaginiYenile(
                cmbIsTuru,
                VeriDeposu.IsTurleri.Cast<object>(),
                secili);
        }

        private string IsTuruAdiSor()
        {
            using Form dialog = new Form
            {
                Text = "Yeni İş Türü",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(340, 130),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label { Text = "İş türü adı", Location = new Point(20, 18), AutoSize = true };
            TextBox txt = new TextBox { Location = new Point(20, 42), Width = 290 };
            Button btnTamam = new Button
            {
                Text = "Ekle",
                DialogResult = DialogResult.OK,
                Location = new Point(130, 80),
                Size = new Size(85, 30)
            };
            Button btnVazgec = new Button
            {
                Text = "İptal",
                DialogResult = DialogResult.Cancel,
                Location = new Point(225, 80),
                Size = new Size(85, 30)
            };

            dialog.Controls.AddRange([lbl, txt, btnTamam, btnVazgec]);
            dialog.AcceptButton = btnTamam;
            dialog.CancelButton = btnVazgec;

            return dialog.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbDoktor.SelectedItem is not Doctor doktor)
            {
                MessageBox.Show("Lütfen bir doktor seçin.", "Eksik bilgi");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHastaAdi.Text) || string.IsNullOrWhiteSpace(cmbIsTuru.Text))
            {
                MessageBox.Show("Hasta adı ve iş türü zorunludur.", "Eksik bilgi");
                return;
            }

            // Ödemesi olan iş RPT yapılamaz — bakiye bozulmasın
            if (chkRptMi.Checked && VeriDeposu.IsinOdemesiVarMi(_isKaydi))
            {
                MessageBox.Show(
                    "Bu işe bağlı ödeme kaydı var.\n\n" +
                    "RPT yapmak için önce Ödeme Raporu’ndan ilgili tahsilatı iptal edin.\n" +
                    "Sonra işi RPT olarak işaretleyebilirsiniz (fiyat 0 olur).",
                    "RPT yapılamaz",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                chkRptMi.Checked = false;
                return;
            }

            string isTuru = cmbIsTuru.Text.Trim();
            VeriDeposu.IsTuruEkle(isTuru);

            _isKaydi.Doktor = doktor;
            _isKaydi.HastaAdi = txtHastaAdi.Text.Trim();
            _isKaydi.IsTuru = isTuru;
            _isKaydi.DisNumarasi = txtDisNumarasi.Text.Trim();
            _isKaydi.Durum = cmbDurum.Text;
            _isKaydi.TeslimTarihi = dtpTeslimTarihi.Value.Date;
            _isKaydi.Aciklama = txtAciklama.Text.Trim();
            _isKaydi.RptMi = chkRptMi.Checked;
            _isKaydi.Fiyat = chkRptMi.Checked ? 0 : nudFiyat.Value;

            VeriDeposu.DenetimEkle(DenetimKategori.Is, "İş güncellendi",
                $"{_isKaydi.IsNumarasi} · {_isKaydi.HastaAdi} · {doktor.AdSoyad} · {_isKaydi.Fiyat:N2} TL{(_isKaydi.RptMi ? " · RPT" : "")}");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
