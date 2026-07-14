namespace ESDentalLab
{
    public partial class frmAnaMenu : Form
    {
        private Panel pnlMenu = null!;
        private Panel pnlIcerik = null!;
        private Panel pnlGovde = null!;
        private Panel pnlSol = null!;
        private FlowLayoutPanel flpSolMenu = null!;
        private Button btnGeri = null!;
        private Button btnCikis = null!;
        private Button btnKullanicilar = null!;
        private Button btnDenetim = null!;
        private Button btnAnaSayfa = null!;
        private Button btnKasaMenu = null!;
        private Label lblOturum = null!;
        private Panel pnlKasaOzet = null!;
        private Label lblKasaBaslik = null!;
        private Label lblKasaDeger = null!;
        private Button btnKasaGoz = null!;
        private Button btnBakiyeGoz = null!;
        private Button btnTeslimEdilenler = null!;
        private Button btnGelirGider = null!;
        private Button btnRaporGunluk = null!;
        private Button btnRaporAylik = null!;
        private Button btnRaporDoktor = null!;
        private Button btnAyarlar = null!;
        private DataGridView dgvSonIsler = null!;
        private Label lblSonIslerBaslik = null!;
        private Control? lblBolumIs;
        private Control? lblBolumDoktor;
        private Control? lblBolumFinans;
        private Control? lblBolumRapor;
        private Control? lblBolumSistem;
        private Button btnBildirim = null!;
        private Button btnAyarUst = null!;
        private Panel pnlTabloKart = null!;
        private Form? _aktifSayfa;
        private bool _geriDonuluyor;
        private bool _kasaTutariGorunur = true;
        private decimal _sonKasaBakiyesi;
        private readonly List<Button> _navButonlari = new();

        public frmAnaMenu()
        {
            InitializeComponent();
            NavigasyonuHazirla();
            OturumBilgisiniGoster();
        }

        private void NavigasyonuHazirla()
        {
            // ——— Üst bar (mockup) ———
            pnlUst.Height = 56;
            pnlUst.BackColor = ArayuzTema.Baslik;
            pnlUst.Padding = new Padding(20, 0, 16, 0);

            foreach (Control c in pnlUst.Controls.Find("picTemaLogo", false).ToArray())
            {
                pnlUst.Controls.Remove(c);
            }

            lblMarka.Text = "Kontrol Merkezi";
            lblMarka.Font = new Font("Segoe UI Semibold", 14F);
            lblMarka.ForeColor = Color.White;
            lblMarka.AutoSize = true;
            lblMarka.Location = new Point(24, 16);
            lblMarka.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblAltBaslik.Visible = false;

            btnGeri = new Button
            {
                Text = "← Ana Sayfa",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ArayuzTema.Vurgu,
                Size = new Size(112, 30),
                Location = new Point(ClientSize.Width - 420, 13),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = false,
                Name = "btnGeri"
            };
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.Click += btnGeri_Click;
            pnlUst.Controls.Add(btnGeri);

            lblOturum = new Label
            {
                Name = "lblOturum",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10F),
                ForeColor = Color.White,
                Location = new Point(ClientSize.Width - 220, 18),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Default
            };
            pnlUst.Controls.Add(lblOturum);

            btnBildirim = UstIkonButonu("🔔");
            btnBildirim.Location = new Point(ClientSize.Width - 130, 12);
            btnBildirim.Click += (_, _) => YakindaGoster("Bildirimler");
            pnlUst.Controls.Add(btnBildirim);

            btnAyarUst = UstIkonButonu("⚙");
            btnAyarUst.Location = new Point(ClientSize.Width - 90, 12);
            btnAyarUst.Click += (_, _) => YakindaGoster("Ayarlar");
            pnlUst.Controls.Add(btnAyarUst);

            btnCikis = new Button
            {
                Text = "⎋",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(32, 32),
                Location = new Point(ClientSize.Width - 50, 12),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Name = "btnCikis",
                TabStop = false
            };
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.FlatAppearance.MouseOverBackColor = ArayuzTema.NavHover;
            btnCikis.Click += btnCikis_Click;
            pnlUst.Controls.Add(btnCikis);

            // Kasa özeti üstte yok; mockupta yalnızca kartta
            pnlKasaOzet = new Panel { Name = "pnlKasaOzet", Visible = false, Size = Size.Empty };
            lblKasaBaslik = new Label { Visible = false };
            lblKasaDeger = new Label { Visible = false };
            btnKasaGoz = new Button { Visible = false };

            btnGeri.BringToFront();
            btnCikis.BringToFront();
            btnBildirim.BringToFront();
            btnAyarUst.BringToFront();
            lblOturum.BringToFront();

            // ——— Sol menü ———
            pnlSol = new Panel
            {
                Name = "pnlSol",
                Dock = DockStyle.Fill,
                BackColor = ArayuzTema.Sidebar,
                Padding = new Padding(0, 4, 0, 4),
                Margin = Padding.Empty
            };

            flpSolMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(8, 2, 8, 2),
                BackColor = ArayuzTema.Sidebar
            };

            Label lblSolMarka = new Label
            {
                Text = "🦷  ES DENTAL LAB",
                AutoSize = false,
                Width = 200,
                Height = 36,
                Margin = new Padding(4, 6, 4, 10),
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };
            flpSolMenu.Controls.Add(lblSolMarka);

            btnAnaSayfa = NavButonuOlustur("🏠  Ana Sayfa", true);
            btnAnaSayfa.Click += (_, _) => AnaMenuyeDon();

            btnIsEkle.Text = "➜  Yeni İş";
            btnIsListesi.Text = "➜  İş Listesi";
            btnTeslimEdilenler = NavButonuOlustur("➜  Teslim Edilenler", false);
            btnTeslimEdilenler.Click += btnTeslimEdilenler_Click;

            btnDoktorEkle.Text = "➜  Doktor Ekle";
            btnDoktorListesi.Text = "➜  Doktor Listesi";

            btnOdemeEkle.Text = "➜  Tahsilatlar";
            btnOdemeRaporu.Text = "➜  Ödemeler";
            btnKasaMenu = NavButonuOlustur("➜  Kasa", false);
            btnKasaMenu.Click += pnlKasaOzet_Click;
            btnGelirGider = NavButonuOlustur("➜  Gelir-Gider", false);
            btnGelirGider.Click += (_, _) => YakindaGoster("Gelir-Gider");

            btnRaporGunluk = NavButonuOlustur("➜  Günlük", false);
            btnRaporGunluk.Click += btnRaporGunluk_Click;
            btnRaporAylik = NavButonuOlustur("➜  Aylık", false);
            btnRaporAylik.Click += btnRaporAylik_Click;
            btnRaporDoktor = NavButonuOlustur("➜  Doktor Bazlı", false);
            btnRaporDoktor.Click += btnRaporDoktor_Click;

            btnKullanicilar = NavButonuOlustur("➜  Kullanıcılar", false);
            btnKullanicilar.Name = "btnKullanicilar";
            btnKullanicilar.Click += btnKullanicilar_Click;
            btnDenetim = NavButonuOlustur("➜  Denetim", false);
            btnDenetim.Name = "btnDenetim";
            btnDenetim.Click += btnDenetim_Click;
            btnAyarlar = NavButonuOlustur("➜  Ayarlar", false);
            btnAyarlar.Click += (_, _) => YakindaGoster("Ayarlar");

            NavButonunuStil(btnIsEkle);
            NavButonunuStil(btnIsListesi);
            NavButonunuStil(btnDoktorEkle);
            NavButonunuStil(btnDoktorListesi);
            NavButonunuStil(btnOdemeEkle);
            NavButonunuStil(btnOdemeRaporu);

            lblBolumIs = BolumBasligi("🦷  İŞ YÖNETİMİ", ustCizgi: false);
            lblBolumDoktor = BolumBasligi("👨‍⚕️  DOKTORLAR");
            lblBolumFinans = BolumBasligi("💰  FİNANS");
            lblBolumRapor = BolumBasligi("📊  RAPORLAR");
            lblBolumSistem = BolumBasligi("⚙  SİSTEM");

            flpSolMenu.Controls.Add(btnAnaSayfa);
            flpSolMenu.Controls.Add(lblBolumIs);
            flpSolMenu.Controls.Add(btnIsEkle);
            flpSolMenu.Controls.Add(btnIsListesi);
            flpSolMenu.Controls.Add(btnTeslimEdilenler);
            flpSolMenu.Controls.Add(lblBolumDoktor);
            flpSolMenu.Controls.Add(btnDoktorEkle);
            flpSolMenu.Controls.Add(btnDoktorListesi);
            flpSolMenu.Controls.Add(lblBolumFinans);
            flpSolMenu.Controls.Add(btnOdemeEkle);
            flpSolMenu.Controls.Add(btnOdemeRaporu);
            flpSolMenu.Controls.Add(btnKasaMenu);
            flpSolMenu.Controls.Add(btnGelirGider);
            flpSolMenu.Controls.Add(lblBolumRapor);
            flpSolMenu.Controls.Add(btnRaporGunluk);
            flpSolMenu.Controls.Add(btnRaporAylik);
            flpSolMenu.Controls.Add(btnRaporDoktor);
            flpSolMenu.Controls.Add(lblBolumSistem);
            flpSolMenu.Controls.Add(btnKullanicilar);
            flpSolMenu.Controls.Add(btnDenetim);
            flpSolMenu.Controls.Add(btnAyarlar);

            pnlSol.Controls.Add(flpSolMenu);

            // ——— Sağ gövde: dashboard + içerik ———
            pnlGovde = new Panel
            {
                Name = "pnlGovde",
                Dock = DockStyle.Fill,
                BackColor = ArayuzTema.IcerikZemin
            };

            pnlMenu = new Panel
            {
                Name = "pnlMenu",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = ArayuzTema.IcerikZemin,
                Padding = new Padding(24, 16, 24, 16)
            };

            pnlIcerik = new Panel
            {
                Name = "pnlIcerik",
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = ArayuzTema.IcerikZemin
            };

            Control[] eski =
            [
                lblHosgeldiniz, lblHizliIslemler,
                btnDoktorEkle, btnDoktorListesi, btnIsEkle, btnIsListesi,
                btnOdemeEkle, btnOdemeRaporu, lblAltBilgi,
                pnlBugunTeslim, pnlGeciken, pnlUretimde, pnlBakiye
            ];
            SuspendLayout();
            foreach (Control kontrol in eski)
            {
                Controls.Remove(kontrol);
            }

            // Kart başlıkları (mockup)
            lblBugunTeslimBaslik.Text = "📦  Teslim";
            lblUretimdeBaslik.Text = "🦷  Üretimde";
            lblGecikenBaslik.Text = "⚠  Geciken";
            lblBakiyeBaslik.Text = "₺  Kasa";
            lblBugunTeslimBaslik.ForeColor = ArayuzTema.SolukMetin;
            lblUretimdeBaslik.ForeColor = ArayuzTema.SolukMetin;
            lblGecikenBaslik.ForeColor = ArayuzTema.SolukMetin;
            lblBakiyeBaslik.ForeColor = ArayuzTema.SolukMetin;
            lblBugunTeslimDeger.ForeColor = ArayuzTema.Vurgu;
            lblUretimdeDeger.ForeColor = ArayuzTema.Vurgu;
            lblGecikenDeger.ForeColor = ArayuzTema.Tehlike;
            lblBakiyeDeger.ForeColor = ArayuzTema.Metin;

            pnlBakiye.Click -= pnlBakiye_Click;
            pnlBakiye.Click += pnlKasaKart_Click;
            lblBakiyeBaslik.Click -= pnlBakiye_Click;
            lblBakiyeBaslik.Click += pnlKasaKart_Click;
            lblBakiyeDeger.Click -= pnlBakiye_Click;
            lblBakiyeDeger.Click += pnlKasaKart_Click;

            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 3,
                BackColor = ArayuzTema.IcerikZemin
            };
            for (int i = 0; i < 4; i++)
            {
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 110));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            foreach (Panel kart in new[] { pnlBugunTeslim, pnlUretimde, pnlGeciken, pnlBakiye })
            {
                kart.Dock = DockStyle.Fill;
                kart.Margin = new Padding(8);
                ArayuzTema.YuvarlakKartUygula(kart, 12);
                KartIcerikYerlestir(kart);
            }

            tbl.Controls.Add(pnlBugunTeslim, 0, 0);
            tbl.Controls.Add(pnlUretimde, 1, 0);
            tbl.Controls.Add(pnlGeciken, 2, 0);
            tbl.Controls.Add(pnlBakiye, 3, 0);

            btnBakiyeGoz = GozButonuOlustur(Color.White, ArayuzTema.Baslik);
            btnBakiyeGoz.Size = new Size(22, 22);
            btnBakiyeGoz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBakiyeGoz.Click += btnBakiyeGoz_Click;
            pnlBakiye.Controls.Add(btnBakiyeGoz);
            btnBakiyeGoz.BringToFront();
            pnlBakiye.Resize += (_, _) =>
            {
                btnBakiyeGoz.Location = new Point(Math.Max(4, pnlBakiye.ClientSize.Width - 30), 12);
            };
            btnBakiyeGoz.Location = new Point(Math.Max(4, pnlBakiye.ClientSize.Width - 30), 12);

            lblSonIslerBaslik = new Label
            {
                Text = "Son Eklenen İşler",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = ArayuzTema.Metin,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            tbl.Controls.Add(lblSonIslerBaslik, 0, 1);
            tbl.SetColumnSpan(lblSonIslerBaslik, 4);

            pnlTabloKart = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(12, 8, 12, 12),
                BackColor = Color.White
            };
            ArayuzTema.YuvarlakKartUygula(pnlTabloKart, 12);

            dgvSonIsler = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 38,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(236, 240, 239),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                RowTemplate = { Height = 40 }
            };
            dgvSonIsler.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvSonIsler.ColumnHeadersDefaultCellStyle.ForeColor = ArayuzTema.Metin;
            dgvSonIsler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F);
            dgvSonIsler.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvSonIsler.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvSonIsler.DefaultCellStyle.ForeColor = ArayuzTema.Metin;
            dgvSonIsler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 242);
            dgvSonIsler.DefaultCellStyle.SelectionForeColor = ArayuzTema.Metin;
            dgvSonIsler.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvSonIsler.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvSonIsler.CellPainting += dgvSonIsler_CellPainting;
            dgvSonIsler.CellDoubleClick += dgvSonIsler_CellDoubleClick;

            dgvSonIsler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHasta", HeaderText = "Hasta", FillWeight = 22 });
            dgvSonIsler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDoktor", HeaderText = "Doktor", FillWeight = 22 });
            dgvSonIsler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTur", HeaderText = "Tür", FillWeight = 18 });
            dgvSonIsler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTeslim", HeaderText = "Teslim", FillWeight = 18 });
            dgvSonIsler.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDurum", HeaderText = "Durum", FillWeight = 20 });

            pnlTabloKart.Controls.Add(dgvSonIsler);
            tbl.Controls.Add(pnlTabloKart, 0, 2);
            tbl.SetColumnSpan(pnlTabloKart, 4);

            pnlMenu.Controls.Add(tbl);
            pnlGovde.Controls.Add(pnlIcerik);
            pnlGovde.Controls.Add(pnlMenu);
            pnlMenu.BringToFront();

            if (pnlUst.Parent is not null)
            {
                pnlUst.Parent.Controls.Remove(pnlUst);
            }

            Panel pnlSag = new Panel
            {
                Name = "pnlSag",
                Dock = DockStyle.Fill,
                BackColor = ArayuzTema.IcerikZemin,
                Margin = Padding.Empty
            };
            pnlGovde.Dock = DockStyle.Fill;
            pnlUst.Dock = DockStyle.Top;
            pnlUst.Margin = Padding.Empty;
            pnlSag.Controls.Add(pnlGovde);
            pnlSag.Controls.Add(pnlUst);

            Control[] formKontrolleri = Controls.Cast<Control>().ToArray();
            foreach (Control kontrol in formKontrolleri)
            {
                Controls.Remove(kontrol);
            }

            TableLayoutPanel pnlKabuk = new TableLayoutPanel
            {
                Name = "pnlKabuk",
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = ArayuzTema.Sidebar
            };
            pnlKabuk.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 228F));
            pnlKabuk.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlKabuk.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlKabuk.Controls.Add(pnlSol, 0, 0);
            pnlKabuk.Controls.Add(pnlSag, 1, 0);

            Controls.Add(pnlKabuk);

            YetkiyeGoreMenuAyarla();
            NavSecimiGuncelle(btnAnaSayfa);
            pnlUst.Resize += (_, _) => OturumBilgisiniGoster();

            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(1100, 680);
            ResumeLayout(true);
        }

        private static void KartIcerikYerlestir(Panel kart)
        {
            foreach (Control c in kart.Controls)
            {
                if (c is Label { Name: var n } lbl)
                {
                    if (n.EndsWith("Baslik", StringComparison.Ordinal))
                    {
                        lbl.AutoSize = false;
                        lbl.Location = new Point(18, 16);
                        lbl.Size = new Size(Math.Max(80, kart.Width - 48), 22);
                        lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        lbl.Font = new Font("Segoe UI", 9.5F);
                    }
                    else if (n.EndsWith("Deger", StringComparison.Ordinal))
                    {
                        lbl.AutoSize = false;
                        lbl.Location = new Point(18, 44);
                        lbl.Size = new Size(Math.Max(80, kart.Width - 48), 40);
                        lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        lbl.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
                    }
                }
            }
        }

        private static Button UstIkonButonu(string ikon)
        {
            Button b = new Button
            {
                Text = ikon,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Emoji", 11F),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(32, 32),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TabStop = false
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = ArayuzTema.NavHover;
            return b;
        }

        private static Control BolumBasligi(string metin, bool ustCizgi = true)
        {
            Panel panel = new Panel
            {
                Width = 200,
                Height = ustCizgi ? 30 : 22,
                Margin = new Padding(2, ustCizgi ? 6 : 4, 2, 0),
                BackColor = ArayuzTema.Sidebar
            };

            if (ustCizgi)
            {
                panel.Controls.Add(new Panel
                {
                    Height = 1,
                    Width = 188,
                    Location = new Point(6, 4),
                    BackColor = ArayuzTema.Ayirici
                });
            }

            panel.Controls.Add(new Label
            {
                Text = metin,
                AutoSize = false,
                Width = 190,
                Height = 18,
                Location = new Point(4, ustCizgi ? 10 : 2),
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = ArayuzTema.SolukMetin,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            });

            return panel;
        }

        private Button NavButonuOlustur(string metin, bool birincil)
        {
            Button b = new Button
            {
                Text = metin,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, birincil ? FontStyle.Bold : FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(birincil ? 10 : 18, 0, 6, 0),
                Width = 200,
                Height = birincil ? 34 : 30,
                Margin = new Padding(2, 1, 2, 1),
                Tag = "nav"
            };
            b.FlatAppearance.BorderSize = 0;
            if (birincil)
            {
                b.BackColor = ArayuzTema.Vurgu;
                b.ForeColor = Color.White;
            }
            else
            {
                b.BackColor = ArayuzTema.Sidebar;
                b.ForeColor = ArayuzTema.NavMetin;
                b.FlatAppearance.MouseOverBackColor = ArayuzTema.NavHover;
            }

            _navButonlari.Add(b);
            return b;
        }

        private void NavButonunuStil(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Cursor = Cursors.Hand;
            b.Font = new Font("Segoe UI", 9F);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(18, 0, 6, 0);
            b.Width = 200;
            b.Height = 30;
            b.Margin = new Padding(2, 1, 2, 1);
            b.MaximumSize = new Size(210, 30);
            b.MinimumSize = new Size(180, 30);
            b.BackColor = ArayuzTema.Sidebar;
            b.ForeColor = ArayuzTema.NavMetin;
            b.FlatAppearance.MouseOverBackColor = ArayuzTema.NavHover;
            b.UseVisualStyleBackColor = false;
            b.Tag = "nav";
            _navButonlari.Add(b);
        }

        private void NavSecimiGuncelle(Button? aktif)
        {
            foreach (Button b in _navButonlari)
            {
                bool secili = aktif is not null && ReferenceEquals(b, aktif);
                bool ana = ReferenceEquals(b, btnAnaSayfa);
                if (secili)
                {
                    b.BackColor = ArayuzTema.Vurgu;
                    b.ForeColor = Color.White;
                }
                else
                {
                    b.BackColor = ArayuzTema.Sidebar;
                    b.ForeColor = ArayuzTema.NavMetin;
                    if (ana)
                    {
                        b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }
            }
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

            lblBugunTeslimDeger.Text = bugunTeslim.ToString();
            lblGecikenDeger.Text = geciken.ToString();
            lblUretimdeDeger.Text = uretimde.ToString();

            _sonKasaBakiyesi = VeriDeposu.ToplamKasaBakiyesi;
            TutarGosterimleriniGuncelle();
            SonIsleriGuncelle();
        }

        private void SonIsleriGuncelle()
        {
            if (dgvSonIsler is null)
            {
                return;
            }

            dgvSonIsler.Rows.Clear();
            foreach (Is isKaydi in VeriDeposu.Isler
                         .OrderByDescending(i => i.KayitTarihi)
                         .Take(12))
            {
                dgvSonIsler.Rows.Add(
                    isKaydi.HastaAdi,
                    isKaydi.Doktor?.AdSoyad ?? "",
                    isKaydi.IsTuru,
                    isKaydi.TeslimTarihi.ToString("d MMMM", new System.Globalization.CultureInfo("tr-TR")),
                    isKaydi.Durum);
            }
        }

        private void dgvSonIsler_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvSonIsler.Columns[e.ColumnIndex].Name != "colDurum")
            {
                return;
            }

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            string durum = e.FormattedValue?.ToString() ?? e.Value?.ToString() ?? "";
            ArayuzTema.DurumRozetiCiz(
                e.Graphics!,
                e.CellBounds,
                durum,
                new Font("Segoe UI Semibold", 8.5F));
        }

        private void dgvSonIsler_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                return;
            }

            SayfaAcNav(new frmIsListesi(), btnIsListesi);
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
            string kasaMetni = _kasaTutariGorunur
                ? $"{_sonKasaBakiyesi:N2} TL"
                : "——————";

            if (lblBakiyeDeger is not null)
            {
                lblBakiyeDeger.Text = kasaMetni;
            }

            if (btnBakiyeGoz is not null)
            {
                btnBakiyeGoz.Text = _kasaTutariGorunur ? "👁" : "⊘";
            }

            if (lblKasaDeger is not null)
            {
                lblKasaDeger.Text = kasaMetni;
            }

            if (btnKasaGoz is not null)
            {
                btnKasaGoz.Text = _kasaTutariGorunur ? "👁" : "⊘";
            }
        }

        private void YetkiyeGoreMenuAyarla()
        {
            bool isYetki = VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri);
            bool odemeAl = VeriDeposu.YetkiVarMi(KullaniciYetki.OdemeAl);
            bool odemeIptal = VeriDeposu.YetkiVarMi(KullaniciYetki.OdemeIptal);
            bool kasa = VeriDeposu.YetkiVarMi(KullaniciYetki.KasaGoruntule);
            bool denetim = VeriDeposu.YetkiVarMi(KullaniciYetki.Denetim);
            bool kullanici = VeriDeposu.YetkiVarMi(KullaniciYetki.KullaniciYonetimi);
            bool finans = odemeAl || odemeIptal || kasa;

            btnDoktorEkle.Visible = isYetki;
            btnDoktorListesi.Visible = isYetki;
            btnIsEkle.Visible = isYetki;
            btnIsListesi.Visible = isYetki;
            btnTeslimEdilenler.Visible = isYetki;
            btnOdemeEkle.Visible = odemeAl;
            btnOdemeRaporu.Visible = odemeAl || odemeIptal;
            btnDenetim.Visible = denetim;
            btnKullanicilar.Visible = kullanici;
            btnKasaMenu.Visible = kasa;
            btnGelirGider.Visible = finans;
            btnRaporGunluk.Visible = isYetki;
            btnRaporAylik.Visible = isYetki;
            btnRaporDoktor.Visible = isYetki;
            btnAyarlar.Visible = kullanici || denetim;

            if (lblBolumIs is not null) lblBolumIs.Visible = isYetki;
            if (lblBolumDoktor is not null) lblBolumDoktor.Visible = isYetki;
            if (lblBolumFinans is not null) lblBolumFinans.Visible = finans;
            if (lblBolumRapor is not null) lblBolumRapor.Visible = isYetki;
            if (lblBolumSistem is not null) lblBolumSistem.Visible = kullanici || denetim;

            if (pnlKasaOzet is not null)
            {
                pnlKasaOzet.Visible = false;
            }

            if (pnlBakiye is not null)
            {
                pnlBakiye.Visible = kasa;
            }

            if (!kasa)
            {
                _kasaTutariGorunur = false;
                if (lblKasaDeger is not null)
                {
                    lblKasaDeger.Text = "Yetki yok";
                }

                if (lblBakiyeDeger is not null)
                {
                    lblBakiyeDeger.Text = "Yetki yok";
                }

                if (btnKasaGoz is not null)
                {
                    btnKasaGoz.Visible = false;
                }

                if (btnBakiyeGoz is not null)
                {
                    btnBakiyeGoz.Visible = false;
                }
            }
        }

        private void btnKasaGoz_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.KasaGoruntule))
            {
                VeriDeposu.YetkiYokUyarisi("Kasa görüntüleme");
                return;
            }

            _kasaTutariGorunur = !_kasaTutariGorunur;
            TutarGosterimleriniGuncelle();
        }

        private void btnBakiyeGoz_Click(object? sender, EventArgs e)
        {
            btnKasaGoz_Click(sender, e);
        }

        private static void YakindaGoster(string ozellik)
        {
            MessageBox.Show(
                $"{ozellik} bölümü yakında eklenecek.",
                "Yakında",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnTeslimEdilenler_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(IsListesiOzetFiltresi.TeslimEdilen), btnTeslimEdilenler);
        }

        private void btnRaporGunluk_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(IsListesiOzetFiltresi.BugunTeslim), btnRaporGunluk);
        }

        private void btnRaporAylik_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(), btnRaporAylik);
        }

        private void btnRaporDoktor_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor listesi");
                return;
            }

            SayfaAcNav(new frmDoktorListesi(), btnRaporDoktor);
        }

        private void SayfaAcNav(Form sayfa, Button? nav)
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
            }
            else
            {
                lblMarka.Text = sayfa.Text;
            }

            _aktifSayfa = sayfa;
            pnlIcerik.Controls.Add(sayfa);
            pnlMenu.Visible = false;
            pnlIcerik.Visible = true;
            pnlIcerik.BringToFront();
            btnGeri.Visible = true;
            if (nav is not null)
            {
                NavSecimiGuncelle(nav);
            }

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
            lblMarka.Text = "Kontrol Merkezi";
            NavSecimiGuncelle(btnAnaSayfa);
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
            lblMarka.Text = "Kontrol Merkezi";
            OturumBilgisiniGoster();
            NavSecimiGuncelle(btnAnaSayfa);
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

            string ad = k.AdSoyad.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? k.AdSoyad;
            lblOturum.Text = ad;
            int sagKenar = 160;
            lblOturum.Location = new Point(
                Math.Max(200, pnlUst.ClientSize.Width - TextRenderer.MeasureText(lblOturum.Text, lblOturum.Font).Width - sagKenar),
                18);
            btnBildirim.Location = new Point(pnlUst.ClientSize.Width - 130, 12);
            btnAyarUst.Location = new Point(pnlUst.ClientSize.Width - 90, 12);
            btnCikis.Location = new Point(pnlUst.ClientSize.Width - 50, 12);
            btnGeri.Location = new Point(pnlUst.ClientSize.Width - 280, 13);
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
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.KullaniciYonetimi))
            {
                VeriDeposu.YetkiYokUyarisi("Kullanıcı yönetimi");
                return;
            }

            SayfaAcNav(new frmKullaniciYonetimi(), btnKullanicilar);
        }

        private void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor / iş işlemleri");
                return;
            }

            SayfaAcNav(new frmDoktorEkle(), btnDoktorEkle);
        }

        private void btnDoktorListesi_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor / iş işlemleri");
                return;
            }

            SayfaAcNav(new frmDoktorListesi(), btnDoktorListesi);
        }

        private void btnIsEkle_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor / iş işlemleri");
                return;
            }

            SayfaAcNav(new frmIsEkle(), btnIsEkle);
        }

        private void btnIsListesi_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor / iş işlemleri");
                return;
            }

            SayfaAcNav(new frmIsListesi(), btnIsListesi);
        }

        private void btnOdemeEkle_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.OdemeAl))
            {
                VeriDeposu.YetkiYokUyarisi("Ödeme alma");
                return;
            }

            SayfaAcNav(new frmOdemeEkle(), btnOdemeEkle);
        }

        private void btnOdemeRaporu_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.OdemeAl) &&
                !VeriDeposu.YetkiVarMi(KullaniciYetki.OdemeIptal))
            {
                VeriDeposu.YetkiYokUyarisi("Ödeme raporu");
                return;
            }

            SayfaAcNav(new frmOdemeRaporu(), btnOdemeRaporu);
        }

        private void pnlKasaKart_Click(object? sender, EventArgs e)
        {
            pnlKasaOzet_Click(sender, e);
        }

        private void pnlBakiye_Click(object sender, EventArgs e)
        {
            pnlKasaOzet_Click(sender, e);
        }

        private void btnDenetim_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.Denetim))
            {
                VeriDeposu.YetkiYokUyarisi("Denetim kaydı");
                return;
            }

            SayfaAcNav(new frmDenetim(), btnDenetim);
        }

        private void pnlBugunTeslim_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(IsListesiOzetFiltresi.BugunTeslim), btnIsListesi);
        }

        private void pnlGeciken_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(IsListesiOzetFiltresi.Geciken), btnIsListesi);
        }

        private void pnlUretimde_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş listesi");
                return;
            }

            SayfaAcNav(new frmIsListesi(IsListesiOzetFiltresi.Uretimde), btnIsListesi);
        }

        private void pnlKasaOzet_Click(object? sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.KasaGoruntule))
            {
                VeriDeposu.YetkiYokUyarisi("Kasa görüntüleme");
                return;
            }

            SayfaAcNav(new frmKasa(), btnKasaMenu);
        }
    }
}
