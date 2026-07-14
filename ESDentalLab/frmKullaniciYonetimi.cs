using System.ComponentModel;

namespace ESDentalLab
{
    public class frmKullaniciYonetimi : Form
    {
        private readonly DataGridView dgv = new();
        private readonly CheckBox chkPasifleriGoster = new();
        private readonly Button btnEkle = new();
        private readonly Button btnPasif = new();
        private readonly Button btnAktif = new();
        private readonly Button btnSifre = new();
        private readonly BindingList<KullaniciSatir> _satirlar = new();

        public frmKullaniciYonetimi()
        {
            Text = "Kullanıcı Yönetimi";
            Size = new Size(820, 560);

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
                new DataGridViewTextBoxColumn { DataPropertyName = "KullaniciAdi", HeaderText = "Kullanıcı adı", FillWeight = 90 },
                new DataGridViewTextBoxColumn { DataPropertyName = "AdSoyad", HeaderText = "Ad Soyad", FillWeight = 120 },
                new DataGridViewTextBoxColumn { DataPropertyName = "RolMetni", HeaderText = "Rol", FillWeight = 70 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Durum", HeaderText = "Durum", FillWeight = 60 }
            );
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv.DataSource = _satirlar;

            btnEkle.Text = "Yeni Kullanıcı";
            btnPasif.Text = "Pasif Yap";
            btnAktif.Text = "Aktifleştir";
            btnSifre.Text = "Şifre Değiştir";
            chkPasifleriGoster.Text = "Pasifleri göster";
            chkPasifleriGoster.AutoSize = true;
            chkPasifleriGoster.CheckedChanged += (_, _) => ListeyiYukle();

            foreach (Button b in new[] { btnEkle, btnPasif, btnAktif, btnSifre })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.FromArgb(30, 121, 159);
                b.ForeColor = Color.White;
                b.FlatAppearance.BorderSize = 0;
                b.Cursor = Cursors.Hand;
                b.Height = 34;
            }

            btnEkle.Click += (_, _) => KullaniciEkle();
            btnPasif.Click += (_, _) => PasifYap();
            btnAktif.Click += (_, _) => Aktiflestir();
            btnSifre.Click += (_, _) => SifreDegistir();

            Controls.Add(dgv);
            Controls.Add(btnEkle);
            Controls.Add(btnPasif);
            Controls.Add(btnAktif);
            Controls.Add(btnSifre);
            Controls.Add(chkPasifleriGoster);

            ArayuzTema.Uygula(this, "Kullanıcı Yönetimi", "Admin yeni kullanıcı ekler, pasif yapar ve şifre günceller");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgv,
                altKontroller: [btnEkle, btnPasif, btnAktif, btnSifre, chkPasifleriGoster],
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
                dlg.Rol);

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
            public string Durum => Kaynak.Durum;
        }
    }

    public class frmKullaniciEkle : Form
    {
        private readonly TextBox txtAd = new();
        private readonly TextBox txtKullaniciAdi = new();
        private readonly TextBox txtSifre = new();
        private readonly ComboBox cmbRol = new();

        public string AdSoyad => txtAd.Text.Trim();
        public string KullaniciAdi => txtKullaniciAdi.Text.Trim();
        public string Sifre => txtSifre.Text;
        public KullaniciRol Rol => (KullaniciRol)(cmbRol.SelectedItem ?? KullaniciRol.Personel);

        public frmKullaniciEkle()
        {
            Text = "Yeni Kullanıcı";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(380, 280);
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.White;

            Label L(string t, int y) => new Label { Text = t, AutoSize = true, Location = new Point(24, y) };

            txtAd.Location = new Point(24, 40);
            txtAd.Size = new Size(330, 28);
            txtKullaniciAdi.Location = new Point(24, 100);
            txtKullaniciAdi.Size = new Size(330, 28);
            txtSifre.Location = new Point(24, 160);
            txtSifre.Size = new Size(330, 28);
            txtSifre.UseSystemPasswordChar = true;

            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Items.AddRange([KullaniciRol.Personel, KullaniciRol.Admin]);
            cmbRol.SelectedItem = KullaniciRol.Personel;
            cmbRol.Location = new Point(24, 210);
            cmbRol.Size = new Size(160, 28);

            Button btnKaydet = new Button
            {
                Text = "Kaydet",
                DialogResult = DialogResult.None,
                Size = new Size(100, 32),
                Location = new Point(254, 208),
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

                if (txtSifre.Text.Length < 4)
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
            Controls.Add(L("Şifre", 136));
            Controls.Add(txtSifre);
            Controls.Add(L("Rol", 190));
            Controls.Add(cmbRol);
            Controls.Add(btnKaydet);
            AcceptButton = btnKaydet;
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
