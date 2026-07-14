using System.ComponentModel;

namespace ESDentalLab
{
    public class frmKullaniciYonetimi : Form
    {
        private readonly DataGridView dgv = new();
        private readonly CheckBox chkPasifleriGoster = new();
        private readonly Button btnEkle = new();
        private readonly Button btnYetki = new();
        private readonly Button btnPasif = new();
        private readonly Button btnAktif = new();
        private readonly Button btnSifre = new();
        private readonly BindingList<KullaniciSatir> _satirlar = new();

        public frmKullaniciYonetimi()
        {
            Text = "Kullanıcı Yönetimi";
            Size = new Size(920, 580);

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
                new DataGridViewTextBoxColumn { DataPropertyName = "KullaniciAdi", HeaderText = "Kullanıcı adı", FillWeight = 80 },
                new DataGridViewTextBoxColumn { DataPropertyName = "AdSoyad", HeaderText = "Ad Soyad", FillWeight = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "RolMetni", HeaderText = "Rol", FillWeight = 55 },
                new DataGridViewTextBoxColumn { DataPropertyName = "YetkiOzeti", HeaderText = "Yetkiler", FillWeight = 140 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Durum", HeaderText = "Durum", FillWeight = 50 }
            );
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv.DataSource = _satirlar;

            btnEkle.Text = "Yeni Kullanıcı";
            btnYetki.Text = "Yetkileri Düzenle";
            btnPasif.Text = "Pasif Yap";
            btnAktif.Text = "Aktifleştir";
            btnSifre.Text = "Şifre Değiştir";
            chkPasifleriGoster.Text = "Pasifleri göster";
            chkPasifleriGoster.AutoSize = true;
            chkPasifleriGoster.CheckedChanged += (_, _) => ListeyiYukle();

            foreach (Button b in new[] { btnEkle, btnYetki, btnPasif, btnAktif, btnSifre })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.FromArgb(30, 121, 159);
                b.ForeColor = Color.White;
                b.FlatAppearance.BorderSize = 0;
                b.Cursor = Cursors.Hand;
                b.Height = 34;
            }

            btnEkle.Click += (_, _) => KullaniciEkle();
            btnYetki.Click += (_, _) => YetkiDuzenle();
            btnPasif.Click += (_, _) => PasifYap();
            btnAktif.Click += (_, _) => Aktiflestir();
            btnSifre.Click += (_, _) => SifreDegistir();

            Controls.Add(dgv);
            Controls.Add(btnEkle);
            Controls.Add(btnYetki);
            Controls.Add(btnPasif);
            Controls.Add(btnAktif);
            Controls.Add(btnSifre);
            Controls.Add(chkPasifleriGoster);

            ArayuzTema.Uygula(this, "Kullanıcı Yönetimi", "Yetkileri kullanıcı bazında işaretleyerek kısıtlayın");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgv,
                altKontroller: [btnEkle, btnYetki, btnPasif, btnAktif, btnSifre, chkPasifleriGoster],
                altYukseklik: 48);

            Load += (_, _) => ListeyiYukle();
        }

        private void ListeyiYukle()
        {
            _satirlar.Clear();
            IEnumerable<Kullanici> kaynak = chkPasifleriGoster.Checked
                ? VeriDeposu.Kullanicilar
                : VeriDeposu.Kullanicilar.Where(k => k.Aktif);

            foreach (Kullanici k in kaynak.OrderBy(k => k.KullaniciAdi))
            {
                _satirlar.Add(new KullaniciSatir(k));
            }
        }

        private Kullanici? SeciliKullanici()
        {
            if (dgv.CurrentRow?.DataBoundItem is KullaniciSatir satir)
            {
                return satir.Kaynak;
            }

            return null;
        }

        private void KullaniciEkle()
        {
            using frmKullaniciEkle dlg = new frmKullaniciEkle();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.KullaniciEkle(
                dlg.KullaniciAdi,
                dlg.Sifre,
                dlg.AdSoyad,
                dlg.Rol,
                dlg.Yetkiler);

            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Hata",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili)
            {
                ListeyiYukle();
            }
        }

        private void YetkiDuzenle()
        {
            Kullanici? k = SeciliKullanici();
            if (k is null)
            {
                MessageBox.Show("Listeden bir kullanıcı seçin.", "Seçim yok");
                return;
            }

            using frmKullaniciEkle dlg = new frmKullaniciEkle(k);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.KullaniciYetkiGuncelle(
                k, dlg.Rol, dlg.Yetkiler, dlg.AdSoyad);

            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Hata",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili)
            {
                ListeyiYukle();
            }
        }

        private void PasifYap()
        {
            Kullanici? k = SeciliKullanici();
            if (k is null)
            {
                MessageBox.Show("Listeden bir kullanıcı seçin.", "Seçim yok");
                return;
            }

            if (!k.Aktif)
            {
                MessageBox.Show("Bu kullanıcı zaten pasif.", "Bilgi");
                return;
            }

            if (MessageBox.Show(
                    $"{k.KullaniciAdi} kullanıcısı pasif yapılsın mı?",
                    "Pasif yap",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.KullaniciPasifYap(k);
            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Hata",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            ListeyiYukle();
        }

        private void Aktiflestir()
        {
            Kullanici? k = SeciliKullanici();
            if (k is null)
            {
                MessageBox.Show("Listeden bir kullanıcı seçin.", "Seçim yok");
                return;
            }

            if (k.Aktif)
            {
                MessageBox.Show("Bu kullanıcı zaten aktif.", "Bilgi");
                return;
            }

            VeriDeposu.KullaniciAktiflestir(k);
            MessageBox.Show("Kullanıcı aktifleştirildi.", "Başarılı");
            ListeyiYukle();
        }

        private void SifreDegistir()
        {
            Kullanici? k = SeciliKullanici();
            if (k is null)
            {
                MessageBox.Show("Listeden bir kullanıcı seçin.", "Seçim yok");
                return;
            }

            using frmSifreDegistir dlg = new frmSifreDegistir(k.KullaniciAdi);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.KullaniciSifreDegistir(k, dlg.YeniSifre);
            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Hata",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private sealed class KullaniciSatir(Kullanici kaynak)
        {
            public Kullanici Kaynak { get; } = kaynak;
            public string KullaniciAdi => Kaynak.KullaniciAdi;
            public string AdSoyad => Kaynak.AdSoyad;
            public string RolMetni => Kaynak.RolMetni;
            public string YetkiOzeti => Kaynak.YetkiOzeti;
            public string Durum => Kaynak.Durum;
        }
    }

    public class frmKullaniciEkle : Form
    {
        private readonly TextBox txtAd = new();
        private readonly TextBox txtKullaniciAdi = new();
        private readonly TextBox txtSifre = new();
        private readonly ComboBox cmbRol = new();
        private readonly CheckBox chkIs = new();
        private readonly CheckBox chkOdemeAl = new();
        private readonly CheckBox chkOdemeIptal = new();
        private readonly CheckBox chkKasa = new();
        private readonly CheckBox chkSilme = new();
        private readonly CheckBox chkDenetim = new();
        private readonly CheckBox chkKullanici = new();
        private readonly Kullanici? _duzenlenen;
        private bool _rolSenkron;

        public string AdSoyad => txtAd.Text.Trim();
        public string KullaniciAdi => txtKullaniciAdi.Text.Trim();
        public string Sifre => txtSifre.Text;
        public KullaniciRol Rol => (KullaniciRol)(cmbRol.SelectedItem ?? KullaniciRol.Personel);

        public KullaniciYetki Yetkiler
        {
            get
            {
                KullaniciYetki y = KullaniciYetki.Yok;
                if (chkIs.Checked) y |= KullaniciYetki.IsIslemleri;
                if (chkOdemeAl.Checked) y |= KullaniciYetki.OdemeAl;
                if (chkOdemeIptal.Checked) y |= KullaniciYetki.OdemeIptal;
                if (chkKasa.Checked) y |= KullaniciYetki.KasaGoruntule;
                if (chkSilme.Checked) y |= KullaniciYetki.Silme;
                if (chkDenetim.Checked) y |= KullaniciYetki.Denetim;
                if (chkKullanici.Checked) y |= KullaniciYetki.KullaniciYonetimi;
                return y;
            }
        }

        public frmKullaniciEkle() : this(null)
        {
        }

        public frmKullaniciEkle(Kullanici? duzenlenen)
        {
            _duzenlenen = duzenlenen;
            bool duzenle = duzenlenen is not null;

            Text = duzenle ? "Yetkileri Düzenle" : "Yeni Kullanıcı";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, duzenle ? 460 : 510);
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.White;

            Label L(string t, int y) => new Label { Text = t, AutoSize = true, Location = new Point(24, y) };

            txtAd.Location = new Point(24, 40);
            txtAd.Size = new Size(370, 28);
            txtKullaniciAdi.Location = new Point(24, 100);
            txtKullaniciAdi.Size = new Size(370, 28);
            txtSifre.Location = new Point(24, 160);
            txtSifre.Size = new Size(370, 28);
            txtSifre.UseSystemPasswordChar = true;

            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Items.AddRange([KullaniciRol.Personel, KullaniciRol.Admin]);
            cmbRol.SelectedItem = KullaniciRol.Personel;
            cmbRol.Location = new Point(24, duzenle ? 160 : 210);
            cmbRol.Size = new Size(180, 28);
            cmbRol.SelectedIndexChanged += (_, _) => RoleGoreYetkileriAyarla();

            int yetkiY = duzenle ? 200 : 250;
            GroupBox grpYetki = new GroupBox
            {
                Text = "Yetkiler",
                Location = new Point(24, yetkiY),
                Size = new Size(370, 190)
            };

            CheckBox Y(string metin, int y, CheckBox chk)
            {
                chk.Text = metin;
                chk.AutoSize = true;
                chk.Location = new Point(16, y);
                return chk;
            }

            grpYetki.Controls.Add(Y("İş / doktor ekle, düzenle, listele", 22, chkIs));
            grpYetki.Controls.Add(Y("Ödeme al", 46, chkOdemeAl));
            grpYetki.Controls.Add(Y("Ödeme iptal", 70, chkOdemeIptal));
            grpYetki.Controls.Add(Y("Kasa bakiyesini görüntüle", 94, chkKasa));
            grpYetki.Controls.Add(Y("Silme (iş sil / doktor kaldır)", 118, chkSilme));
            grpYetki.Controls.Add(Y("Denetim kaydı", 142, chkDenetim));
            grpYetki.Controls.Add(Y("Kullanıcı yönetimi", 166, chkKullanici));

            Button btnKaydet = new Button
            {
                Text = "Kaydet",
                DialogResult = DialogResult.None,
                Size = new Size(110, 34),
                Location = new Point(284, ClientSize.Height - 48),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(30, 121, 159),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
                {
                    MessageBox.Show("Kullanıcı adı zorunludur.");
                    return;
                }

                if (!duzenle && txtSifre.Text.Length < 4)
                {
                    MessageBox.Show("Şifre en az 4 karakter olmalıdır.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            };

            Controls.Add(L("Ad Soyad", 16));
            Controls.Add(txtAd);
            Controls.Add(L("Kullanıcı adı", 76));
            Controls.Add(txtKullaniciAdi);

            if (duzenle)
            {
                Controls.Add(L("Rol", 136));
                txtKullaniciAdi.ReadOnly = true;
                txtKullaniciAdi.BackColor = Color.FromArgb(243, 247, 249);
            }
            else
            {
                Controls.Add(L("Şifre", 136));
                Controls.Add(txtSifre);
                Controls.Add(L("Rol", 190));
            }

            Controls.Add(cmbRol);
            Controls.Add(grpYetki);
            Controls.Add(btnKaydet);
            AcceptButton = btnKaydet;

            if (duzenlenen is not null)
            {
                txtAd.Text = duzenlenen.AdSoyad;
                txtKullaniciAdi.Text = duzenlenen.KullaniciAdi;
                cmbRol.SelectedItem = duzenlenen.Rol;
                YetkileriIsaretle(duzenlenen.Yetkiler);
                if (duzenlenen.Rol == KullaniciRol.Admin)
                {
                    RoleGoreYetkileriAyarla();
                }
            }
            else
            {
                YetkileriIsaretle(Kullanici.PersonelVarsayilanYetkiler);
            }
        }

        private void RoleGoreYetkileriAyarla()
        {
            if (_rolSenkron)
            {
                return;
            }

            _rolSenkron = true;
            try
            {
                bool admin = Rol == KullaniciRol.Admin;
                if (admin)
                {
                    YetkileriIsaretle(KullaniciYetki.Hepsi);
                }

                foreach (CheckBox chk in new[] { chkIs, chkOdemeAl, chkOdemeIptal, chkKasa, chkSilme, chkDenetim, chkKullanici })
                {
                    chk.Enabled = !admin;
                }
            }
            finally
            {
                _rolSenkron = false;
            }
        }

        private void YetkileriIsaretle(KullaniciYetki yetkiler)
        {
            chkIs.Checked = (yetkiler & KullaniciYetki.IsIslemleri) != 0;
            chkOdemeAl.Checked = (yetkiler & KullaniciYetki.OdemeAl) != 0;
            chkOdemeIptal.Checked = (yetkiler & KullaniciYetki.OdemeIptal) != 0;
            chkKasa.Checked = (yetkiler & KullaniciYetki.KasaGoruntule) != 0;
            chkSilme.Checked = (yetkiler & KullaniciYetki.Silme) != 0;
            chkDenetim.Checked = (yetkiler & KullaniciYetki.Denetim) != 0;
            chkKullanici.Checked = (yetkiler & KullaniciYetki.KullaniciYonetimi) != 0;
        }
    }

    public class frmSifreDegistir : Form
    {
        private readonly TextBox txtSifre = new();
        private readonly TextBox txtSifreTekrar = new();

        public string YeniSifre => txtSifre.Text;

        public frmSifreDegistir(string kullaniciAdi)
        {
            Text = $"Şifre Değiştir — {kullaniciAdi}";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(360, 200);
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.White;

            Label L(string t, int y) => new Label { Text = t, AutoSize = true, Location = new Point(24, y) };

            txtSifre.Location = new Point(24, 40);
            txtSifre.Size = new Size(310, 28);
            txtSifre.UseSystemPasswordChar = true;
            txtSifreTekrar.Location = new Point(24, 100);
            txtSifreTekrar.Size = new Size(310, 28);
            txtSifreTekrar.UseSystemPasswordChar = true;

            Button btnKaydet = new Button
            {
                Text = "Kaydet",
                Size = new Size(100, 32),
                Location = new Point(234, 145),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(30, 121, 159),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.Click += (_, _) =>
            {
                if (txtSifre.Text.Length < 4)
                {
                    MessageBox.Show("Şifre en az 4 karakter olmalıdır.");
                    return;
                }

                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler eşleşmiyor.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            };

            Controls.Add(L("Yeni şifre", 16));
            Controls.Add(txtSifre);
            Controls.Add(L("Yeni şifre (tekrar)", 76));
            Controls.Add(txtSifreTekrar);
            Controls.Add(btnKaydet);
            AcceptButton = btnKaydet;
        }
    }
}
