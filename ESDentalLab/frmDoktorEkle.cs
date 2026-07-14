namespace ESDentalLab
{
    public partial class frmDoktorEkle : Form
    {
        private readonly Doctor? _duzenlenenDoktor;
        private bool _adSoyadGuncelleniyor;

        public frmDoktorEkle() : this(null)
        {
        }

        public frmDoktorEkle(Doctor? doktor)
        {
            _duzenlenenDoktor = doktor;
            InitializeComponent();
            ArayuzTema.BaslikLogosuEkle(pnlUst);
            txtAdSoyad.KeyPress += txtAdSoyad_KeyPress;
            txtAdSoyad.TextChanged += txtAdSoyad_TextChanged;

            if (_duzenlenenDoktor is not null)
            {
                Text = "ES Dental Lab | Doktor Düzenle";
                lblBaslik.Text = "Doktor Düzenle";
                lblAltBaslik.Text = "Doktor ve klinik bilgilerini güncelleyin";
                lblBilgi.Text = "Bilgileri güncelleyip kaydedin.";
                btnKaydet.Text = "Güncelle";
            }
        }

        private void frmDoktorEkle_Load(object sender, EventArgs e)
        {
            if (_duzenlenenDoktor is null)
            {
                return;
            }

            txtAdSoyad.Text = _duzenlenenDoktor.AdSoyad;
            txtTelefon.Text = _duzenlenenDoktor.Telefon;
            txtKlinik.Text = _duzenlenenDoktor.Klinik;
        }

        private void txtAdSoyad_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsLetter(e.KeyChar) &&
                e.KeyChar is not ' ' and not '\'' and not '-' and not '.')
            {
                e.Handled = true;
            }
        }

        private void txtAdSoyad_TextChanged(object? sender, EventArgs e)
        {
            if (_adSoyadGuncelleniyor)
            {
                return;
            }

            string temiz = new string(txtAdSoyad.Text
                .Where(c => char.IsLetter(c) || c is ' ' or '\'' or '-' or '.')
                .ToArray());

            if (temiz == txtAdSoyad.Text)
            {
                return;
            }

            int imlec = txtAdSoyad.SelectionStart;
            _adSoyadGuncelleniyor = true;
            txtAdSoyad.Text = temiz;
            txtAdSoyad.SelectionStart = Math.Min(imlec, txtAdSoyad.Text.Length);
            _adSoyadGuncelleniyor = false;
        }

        private static bool AdSoyadGecerliMi(string adSoyad) =>
            adSoyad.Length > 0 &&
            !adSoyad.Any(char.IsDigit) &&
            adSoyad.Any(char.IsLetter);

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            string klinik = txtKlinik.Text.Trim();

            if (string.IsNullOrWhiteSpace(adSoyad))
            {
                MessageBox.Show("Ad soyad zorunludur.", "Eksik bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            if (!AdSoyadGecerliMi(adSoyad))
            {
                MessageBox.Show("Ad soyad yalnızca harf içermelidir; rakam kullanılamaz.", "Geçersiz ad soyad",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            bool ayniIsimVar = VeriDeposu.Doktorlar.Any(doktor =>
                !ReferenceEquals(doktor, _duzenlenenDoktor) &&
                string.Equals(doktor.AdSoyad.Trim(), adSoyad, StringComparison.CurrentCultureIgnoreCase));

            if (ayniIsimVar)
            {
                MessageBox.Show("Bu ad soyad ile kayıtlı bir doktor zaten var.", "Tekrarlayan kayıt",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            if (_duzenlenenDoktor is null)
            {
                VeriDeposu.Doktorlar.Add(new Doctor
                {
                    AdSoyad = adSoyad,
                    Telefon = telefon,
                    Klinik = klinik,
                    Aktif = true
                });

                VeriDeposu.DenetimEkle(DenetimKategori.Doktor, "Doktor eklendi",
                    $"{adSoyad} · {klinik}");

                MessageBox.Show($"{adSoyad} başarıyla eklendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAdSoyad.Clear();
                txtTelefon.Clear();
                txtKlinik.Clear();
                txtAdSoyad.Focus();
                return;
            }

            _duzenlenenDoktor.AdSoyad = adSoyad;
            _duzenlenenDoktor.Telefon = telefon;
            _duzenlenenDoktor.Klinik = klinik;

            VeriDeposu.DenetimEkle(DenetimKategori.Doktor, "Doktor güncellendi",
                $"{adSoyad} · {klinik}");

            MessageBox.Show("Doktor bilgileri güncellendi.", "Başarılı",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
