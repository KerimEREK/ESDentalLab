namespace ESDentalLab
{
    public partial class frmAnaMenu : Form
    {
        private Panel pnlMenu = null!;
        private Panel pnlIcerik = null!;
        private Button btnGeri = null!;
        private Button btnCikis = null!;
        private Button btnKullanicilar = null!;
        private Label lblOturum = null!;
        private Panel pnlKasaOzet = null!;
        private Label lblKasaBaslik = null!;
        private Label lblKasaDeger = null!;
        private Button btnKasaGoz = null!;
        private Button btnBakiyeGoz = null!;
        private Form? _aktifSayfa;
        private bool _geriDonuluyor;
        private bool _kasaTutariGorunur = true;
        private bool _bakiyeTutariGorunur = true;
        private decimal _sonKasaBakiyesi;
        private decimal _sonDoktorBakiyesi;

        public frmAnaMenu()
        {
            InitializeComponent();
            ArayuzTema.BaslikLogosuEkle(pnlUst, solaYasla: true, maksimumBoyut: 72);
            lblMarka.Left = 96;
            lblAltBaslik.Left = 100;
            NavigasyonuHazirla();
            OturumBilgisiniGoster();
        }

        private void NavigasyonuHazirla()
        {
            btnGeri = new Button
            {
                Text = "← Ana Menü",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 121, 159),
                Size = new Size(120, 34),
                Location = new Point(ClientSize.Width - 156, 54),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = false,
                Name = "btnGeri"
            };
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.Click += btnGeri_Click;
            pnlUst.Controls.Add(btnGeri);
            btnGeri.BringToFront();

            lblOturum = new Label
            {
                Name = "lblOturum",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(202, 221, 235),
                Location = new Point(ClientSize.Width - 280, 18),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            pnlUst.Controls.Add(lblOturum);

            btnCikis = new Button
            {
                Text = "Çıkış",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(140, 55, 60),
                Size = new Size(72, 28),
                Location = new Point(ClientSize.Width - 100, 14),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Name = "btnCikis"
            };
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.Click += btnCikis_Click;
            pnlUst.Controls.Add(btnCikis);
            btnCikis.BringToFront();

            btnKullanicilar = new Button
            {
                Text = "Kullanıcılar",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Name = "btnKullanicilar",
                Visible = VeriDeposu.AdminMi
            };
            btnKullanicilar.Click += btnKullanicilar_Click;

            Button btnDenetim = new Button
            {
                Text = "Denetim",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Name = "btnDenetim"
            };
            btnDenetim.Click += (_, _) => SayfaAc(new frmDenetim());

            pnlKasaOzet = new Panel
            {
                Name = "pnlKasaOzet",
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(30, 121, 159),
                Size = new Size(210, 58),
                Location = new Point(ClientSize.Width - 382, 42),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            lblKasaBaslik = new Label
            {
                AutoSize = true,
                Text = "Kasa bakiyesi",
                ForeColor = Color.FromArgb(202, 221, 235),
                Font = new Font("Segoe UI", 8F),
                Location = new Point(12, 8),
                Cursor = Cursors.Hand
            };
            lblKasaDeger = new Label
            {
                AutoSize = true,
                Text = "0,00 TL",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(12, 26),
                Cursor = Cursors.Hand
            };
            btnKasaGoz = GozButonuOlustur(Color.FromArgb(30, 121, 159), Color.White);
            btnKasaGoz.Location = new Point(178, 18);
            btnKasaGoz.Click += btnKasaGoz_Click;

            pnlKasaOzet.Controls.Add(lblKasaBaslik);
            pnlKasaOzet.Controls.Add(lblKasaDeger);
            pnlKasaOzet.Controls.Add(btnKasaGoz);
            pnlKasaOzet.Click += pnlKasaOzet_Click;
            lblKasaBaslik.Click += pnlKasaOzet_Click;
            lblKasaDeger.Click += pnlKasaOzet_Click;
            pnlUst.Controls.Add(pnlKasaOzet);
            pnlKasaOzet.BringToFront();
            btnGeri.BringToFront();
            btnKasaGoz.BringToFront();

            pnlMenu = new Panel
            {
                Name = "pnlMenu",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(245, 248, 250),
                Padding = new Padding(24)
            };

            pnlIcerik = new Panel
            {
                Name = "pnlIcerik",
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = Color.FromArgb(243, 247, 249)
            };

            Control[] menuKontrolleri =
            [
                lblHosgeldiniz,
                lblHizliIslemler,
                btnDoktorEkle,
                btnDoktorListesi,
                btnIsEkle,
                btnIsListesi,
                btnOdemeEkle,
                btnOdemeRaporu,
                lblAltBilgi,
                pnlBugunTeslim,
                pnlGeciken,
                pnlUretimde,
                pnlBakiye
            ];

            SuspendLayout();
            foreach (Control kontrol in menuKontrolleri)
            {
                Controls.Remove(kontrol);
            }

            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 8,
                BackColor = Color.FromArgb(245, 248, 250)
            };

            for (int i = 0; i < 4; i++)
            {
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            // Sabit yükseklikler: butonlar tam ekranda "dev" olmasın
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));  // başlık
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));  // özet kartları
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));  // ipucu
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));  // buton satırı 1
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));  // buton satırı 2
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));  // denetim / kullanıcılar
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // boşluk
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));  // alt bilgi

            lblHosgeldiniz.Dock = DockStyle.Fill;
            lblHosgeldiniz.TextAlign = ContentAlignment.MiddleLeft;
            tbl.Controls.Add(lblHosgeldiniz, 0, 0);
            tbl.SetColumnSpan(lblHosgeldiniz, 4);

            foreach (Panel kart in new[] { pnlBugunTeslim, pnlGeciken, pnlUretimde, pnlBakiye })
            {
                kart.Dock = DockStyle.Fill;
                kart.Margin = new Padding(6);
            }

            tbl.Controls.Add(pnlBugunTeslim, 0, 1);
            tbl.Controls.Add(pnlGeciken, 1, 1);
            tbl.Controls.Add(pnlUretimde, 2, 1);
            tbl.Controls.Add(pnlBakiye, 3, 1);

            btnBakiyeGoz = GozButonuOlustur(Color.White, Color.FromArgb(22, 54, 78));
            btnBakiyeGoz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBakiyeGoz.Click += btnBakiyeGoz_Click;
            pnlBakiye.Controls.Add(btnBakiyeGoz);
            btnBakiyeGoz.BringToFront();
            pnlBakiye.Resize += (_, _) =>
            {
                btnBakiyeGoz.Location = new Point(Math.Max(4, pnlBakiye.ClientSize.Width - 34), 18);
            };
            btnBakiyeGoz.Location = new Point(Math.Max(4, pnlBakiye.ClientSize.Width - 34), 18);

            lblHizliIslemler.Dock = DockStyle.Fill;
            lblHizliIslemler.TextAlign = ContentAlignment.MiddleLeft;
            tbl.Controls.Add(lblHizliIslemler, 0, 2);
            tbl.SetColumnSpan(lblHizliIslemler, 4);

            foreach (Button buton in new[] { btnDoktorEkle, btnDoktorListesi, btnIsEkle, btnIsListesi, btnOdemeEkle, btnOdemeRaporu, btnDenetim, btnKullanicilar })
            {
                buton.Dock = DockStyle.Fill;
                buton.Margin = new Padding(6);
                buton.MaximumSize = new Size(0, 76);
                ArayuzTema.ButonuStil(buton, buton == btnIsEkle);
            }

            tbl.Controls.Add(btnDoktorEkle, 0, 3);
            tbl.Controls.Add(btnDoktorListesi, 1, 3);
            tbl.Controls.Add(btnIsEkle, 2, 3);
            tbl.SetColumnSpan(btnIsEkle, 2);

            tbl.Controls.Add(btnIsListesi, 0, 4);
            tbl.Controls.Add(btnOdemeEkle, 1, 4);
            tbl.SetColumnSpan(btnOdemeEkle, 2);
            tbl.Controls.Add(btnOdemeRaporu, 3, 4);

            tbl.Controls.Add(btnDenetim, 0, 5);
            tbl.SetColumnSpan(btnDenetim, 2);

            if (VeriDeposu.AdminMi)
            {
                tbl.Controls.Add(btnKullanicilar, 2, 5);
                tbl.SetColumnSpan(btnKullanicilar, 2);
            }

            lblAltBilgi.Dock = DockStyle.Fill;
            lblAltBilgi.TextAlign = ContentAlignment.MiddleLeft;
            tbl.Controls.Add(lblAltBilgi, 0, 7);
            tbl.SetColumnSpan(lblAltBilgi, 4);

            pnlMenu.Controls.Add(tbl);
            Controls.Add(pnlIcerik);
            Controls.Add(pnlMenu);
            pnlMenu.BringToFront();
            ResumeLayout(true);

            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(920, 680);
        }

        private void frmAnaMenu_Load(object sender, EventArgs e)
        {
            OzetleriGuncelle();
        }

        private void frmAnaMenu_Activated(object sender, EventArgs e)
        {
            if (pnlMenu.Visible)
            {
                OzetleriGuncelle();
            }
        }

        private void OzetleriGuncelle()
        {
            DateTime bugun = DateTime.Today;
            int bugunTeslim = VeriDeposu.Isler.Count(isKaydi =>
                isKaydi.TeslimTarihi.Date == bugun && isKaydi.Durum != "Teslim edildi");
            int geciken = VeriDeposu.Isler.Count(isKaydi =>
                isKaydi.TeslimTarihi.Date < bugun && isKaydi.Durum != "Teslim edildi");
            int uretimde = VeriDeposu.Isler.Count(isKaydi => isKaydi.Durum == "Üretimde");
            decimal toplamBakiye = VeriDeposu.Doktorlar.Sum(doktor => doktor.Bakiye);

            lblBugunTeslimDeger.Text = bugunTeslim.ToString();
            lblGecikenDeger.Text = geciken.ToString();
            lblUretimdeDeger.Text = uretimde.ToString();

            _sonDoktorBakiyesi = toplamBakiye;
            _sonKasaBakiyesi = VeriDeposu.ToplamKasaBakiyesi;
            TutarGosterimleriniGuncelle();
        }

        private static Button GozButonuOlustur(Color arkaPlan, Color yazi)
        {
            Button buton = new Button
            {
                Text = "👁",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Emoji", 9F),
                ForeColor = yazi,
                BackColor = arkaPlan,
                Size = new Size(26, 26),
                TabStop = false
            };
            buton.FlatAppearance.BorderSize = 0;
            buton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, yazi.R, yazi.G, yazi.B);
            return buton;
        }

        private void TutarGosterimleriniGuncelle()
        {
            lblBakiyeDeger.Text = _bakiyeTutariGorunur
                ? $"{_sonDoktorBakiyesi:N2} TL"
                : "——————";
            btnBakiyeGoz.Text = _bakiyeTutariGorunur ? "👁" : "⊘";

            if (lblKasaDeger is not null)
            {
                lblKasaDeger.Text = _kasaTutariGorunur
                    ? $"{_sonKasaBakiyesi:N2} TL"
                    : "——————";
            }

            if (btnKasaGoz is not null)
            {
                btnKasaGoz.Text = _kasaTutariGorunur ? "👁" : "⊘";
            }
        }

        private void btnKasaGoz_Click(object? sender, EventArgs e)
        {
            _kasaTutariGorunur = !_kasaTutariGorunur;
            TutarGosterimleriniGuncelle();
        }

        private void btnBakiyeGoz_Click(object? sender, EventArgs e)
        {
            _bakiyeTutariGorunur = !_bakiyeTutariGorunur;
            TutarGosterimleriniGuncelle();
        }

        private void SayfaAc(Form sayfa)
        {
            MevcutSayfayiKapat();

            sayfa.TopLevel = false;
            sayfa.FormBorderStyle = FormBorderStyle.None;
            sayfa.Dock = DockStyle.Fill;
            sayfa.MinimumSize = Size.Empty;
            sayfa.MaximumSize = Size.Empty;
            sayfa.FormClosed += Sayfa_FormClosed;

            ArayuzTema.GomuluModaAl(sayfa);

            if (ArayuzTema.SayfaBasliginiAl(sayfa) is { } baslikBilgi)
            {
                lblMarka.Text = baslikBilgi.Baslik;
                lblAltBaslik.Text = baslikBilgi.AltBaslik;
            }

            pnlUst.Height = 88;
            _aktifSayfa = sayfa;
            pnlIcerik.Controls.Add(sayfa);
            pnlMenu.Visible = false;
            pnlIcerik.Visible = true;
            pnlIcerik.BringToFront();
            btnGeri.Visible = true;
            sayfa.Show();
        }

        private void Sayfa_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_geriDonuluyor)
            {
                return;
            }

            _aktifSayfa = null;
            pnlIcerik.Controls.Clear();
            pnlIcerik.Visible = false;
            pnlMenu.Visible = true;
            pnlMenu.BringToFront();
            btnGeri.Visible = false;
            lblMarka.Text = "ES DENTAL LAB";
            lblAltBaslik.Text = "Diş laboratuvarı iş ve finans takip sistemi";
            pnlUst.Height = 145;
            OzetleriGuncelle();
        }

        private void MevcutSayfayiKapat()
        {
            if (_aktifSayfa is null)
            {
                return;
            }

            Form sayfa = _aktifSayfa;
            _aktifSayfa = null;
            sayfa.FormClosed -= Sayfa_FormClosed;

            if (!sayfa.IsDisposed)
            {
                _geriDonuluyor = true;
                sayfa.Close();
                sayfa.Dispose();
                _geriDonuluyor = false;
            }

            pnlIcerik.Controls.Clear();
        }

        private void AnaMenuyeDon()
        {
            MevcutSayfayiKapat();
            pnlIcerik.Visible = false;
            pnlMenu.Visible = true;
            pnlMenu.BringToFront();
            btnGeri.Visible = false;
            lblMarka.Text = "ES DENTAL LAB";
            lblAltBaslik.Text = "Diş laboratuvarı iş ve finans takip sistemi";
            OturumBilgisiniGoster();
            pnlUst.Height = 145;
            OzetleriGuncelle();
        }

        private void OturumBilgisiniGoster()
        {
            Kullanici? k = VeriDeposu.GirisYapanKullanici;
            if (k is null)
            {
                lblOturum.Text = "";
                return;
            }

            lblOturum.Text = $"{k.AdSoyad} · {k.RolMetni}";
            lblOturum.Location = new Point(
                Math.Max(200, ClientSize.Width - TextRenderer.MeasureText(lblOturum.Text, lblOturum.Font).Width - 120),
                18);
            btnCikis.Location = new Point(ClientSize.Width - 100, 14);
        }

        private void btnGeri_Click(object? sender, EventArgs e)
        {
            AnaMenuyeDon();
        }

        private void btnCikis_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatıp giriş ekranına dönülsün mü?", "Çıkış",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            VeriDeposu.CikisYap();
            Close();
        }

        private void btnKullanicilar_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.AdminMi)
            {
                MessageBox.Show("Bu işlem yalnızca admin kullanıcılar içindir.", "Yetki yok");
                return;
            }

            SayfaAc(new frmKullaniciYonetimi());
        }

        private void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmDoktorEkle());
        }

        private void btnDoktorListesi_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmDoktorListesi());
        }

        private void btnIsEkle_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmIsEkle());
        }

        private void btnIsListesi_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmIsListesi());
        }

        private void btnOdemeEkle_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmOdemeEkle());
        }

        private void btnOdemeRaporu_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmOdemeRaporu());
        }

        private void pnlBakiye_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmBakiyeIsleri());
        }

        private void pnlBugunTeslim_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmIsListesi(IsListesiOzetFiltresi.BugunTeslim));
        }

        private void pnlGeciken_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmIsListesi(IsListesiOzetFiltresi.Geciken));
        }

        private void pnlUretimde_Click(object sender, EventArgs e)
        {
            SayfaAc(new frmIsListesi(IsListesiOzetFiltresi.Uretimde));
        }

        private void pnlKasaOzet_Click(object? sender, EventArgs e)
        {
            SayfaAc(new frmKasa());
        }
    }
}
