using System.Reflection;

namespace ESDentalLab
{
    public static class ArayuzTema
    {
        public const int BaslikYuksekligi = 82;
        private static Image? _logoOnbellek;

        public static Image? LogoResmi()
        {
            if (_logoOnbellek is not null)
            {
                return _logoOnbellek;
            }

            Assembly asm = Assembly.GetExecutingAssembly();
            string? kaynakAdi = asm.GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith("logo.png", StringComparison.OrdinalIgnoreCase));

            if (kaynakAdi is not null)
            {
                using Stream? akis = asm.GetManifestResourceStream(kaynakAdi);
                if (akis is not null)
                {
                    _logoOnbellek = new Bitmap(akis);
                    return _logoOnbellek;
                }
            }

            string yol = Path.Combine(AppContext.BaseDirectory, "Resources", "logo.png");
            if (File.Exists(yol))
            {
                _logoOnbellek = Image.FromFile(yol);
            }

            return _logoOnbellek;
        }

        /// <summary>
        /// Mavi başlık paneline köşe logo ekler (varsayılan sağ üst).
        /// </summary>
        public static void BaslikLogosuEkle(Control baslikPanel, bool solaYasla = false, int maksimumBoyut = 64)
        {
            if (baslikPanel.Controls.Find("picTemaLogo", false).Length > 0)
            {
                return;
            }

            Image? logo = LogoResmi();
            if (logo is null)
            {
                return;
            }

            PictureBox pic = new PictureBox
            {
                Name = "picTemaLogo",
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Image = logo,
                TabStop = false
            };

            void Yerles()
            {
                int boy = Math.Clamp(baslikPanel.ClientSize.Height - 16, 40, maksimumBoyut);
                pic.Size = new Size(boy, boy);
                int y = Math.Max(4, (baslikPanel.ClientSize.Height - pic.Height) / 2);
                pic.Location = solaYasla
                    ? new Point(12, y)
                    : new Point(Math.Max(12, baslikPanel.ClientSize.Width - pic.Width - 14), y);
            }

            pic.Anchor = solaYasla
                ? AnchorStyles.Top | AnchorStyles.Left
                : AnchorStyles.Top | AnchorStyles.Right;

            Yerles();
            baslikPanel.Controls.Add(pic);
            pic.BringToFront();
            baslikPanel.Resize += (_, _) => Yerles();
        }

        public static void Uygula(Form form, string baslik, string altBaslik)
        {
            Control[] mevcutKontroller = form.Controls.Cast<Control>().ToArray();

            form.SuspendLayout();
            form.BackColor = Color.FromArgb(243, 247, 249);
            form.Controls.Clear();

            if (form.TopLevel)
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.MaximizeBox = true;
            }
            else
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }

            TableLayoutPanel kok = new TableLayoutPanel
            {
                Name = "pnlTemaKok",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.FromArgb(243, 247, 249),
                Tag = new[] { baslik, altBaslik }
            };
            kok.RowStyles.Add(new RowStyle(SizeType.Absolute, BaslikYuksekligi));
            kok.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            kok.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            Panel ustPanel = new Panel
            {
                Name = "pnlTemaBaslik",
                BackColor = Color.FromArgb(22, 54, 78),
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };

            Label lblBaslik = new Label
            {
                Name = "lblTemaBaslik",
                AutoSize = true,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(24, 14),
                Text = baslik
            };

            Label lblAltBaslik = new Label
            {
                Name = "lblTemaAltBaslik",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(202, 221, 235),
                Location = new Point(26, 48),
                Text = altBaslik
            };

            ustPanel.Controls.Add(lblBaslik);
            ustPanel.Controls.Add(lblAltBaslik);
            BaslikLogosuEkle(ustPanel);

            Panel icerikPanel = new Panel
            {
                Name = "pnlTemaIcerik",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(243, 247, 249),
                Padding = new Padding(12, 8, 12, 8),
                Margin = Padding.Empty
            };

            foreach (Control kontrol in mevcutKontroller)
            {
                StilUygula(kontrol);
                icerikPanel.Controls.Add(kontrol);
            }

            kok.Controls.Add(ustPanel, 0, 0);
            kok.Controls.Add(icerikPanel, 0, 1);
            form.Controls.Add(kok);

            form.ResumeLayout(true);
            form.PerformLayout();
        }

        /// <summary>
        /// Ana menü içinde açılan sayfalarda ikinci mavi başlığı kaldırır.
        /// </summary>
        public static void GomuluModaAl(Form form)
        {
            if (form.Controls.Find("pnlTemaKok", true).FirstOrDefault() is not TableLayoutPanel kok)
            {
                return;
            }

            kok.SuspendLayout();
            kok.RowStyles[0].SizeType = SizeType.Absolute;
            kok.RowStyles[0].Height = 0;

            if (kok.GetControlFromPosition(0, 0) is Control baslikPanel)
            {
                baslikPanel.Visible = false;
            }

            kok.ResumeLayout(true);
        }

        public static (string Baslik, string AltBaslik)? SayfaBasliginiAl(Form form)
        {
            if (form.Controls.Find("pnlTemaKok", true).FirstOrDefault()?.Tag is string[] bilgi && bilgi.Length == 2)
            {
                return (bilgi[0], bilgi[1]);
            }

            if (form.Controls.Find("lblTemaBaslik", true).FirstOrDefault() is Label lbl)
            {
                string alt = form.Controls.Find("lblTemaAltBaslik", true).FirstOrDefault() is Label lblAlt
                    ? lblAlt.Text
                    : "";
                return (lbl.Text, alt);
            }

            return null;
        }

        public static void ListeFormunuEsnekYap(
            Form form,
            DataGridView tablo,
            Control[]? ustKontroller = null,
            Control[]? altKontroller = null,
            int ustYukseklik = 0,
            int altYukseklik = 50)
        {
            if (form.Controls.Find("pnlTemaIcerik", true).FirstOrDefault() is not Panel host)
            {
                return;
            }

            host.SuspendLayout();
            host.AutoScroll = false;
            host.Controls.Clear();
            host.Padding = new Padding(8, 4, 8, 4);

            TableLayoutPanel duzen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.FromArgb(243, 247, 249)
            };
            duzen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            if (ustKontroller is { Length: > 0 })
            {
                FlowLayoutPanel akis = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    WrapContents = true,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    FlowDirection = FlowDirection.LeftToRight,
                    Padding = new Padding(0, 2, 0, 6)
                };

                foreach (Control kontrol in ustKontroller)
                {
                    kontrol.Margin = new Padding(0, 4, 10, 4);
                    akis.Controls.Add(kontrol);
                }

                int yukseklik = ustYukseklik > 0 ? ustYukseklik : Math.Max(akis.PreferredSize.Height + 12, 70);
                duzen.RowStyles.Add(new RowStyle(SizeType.Absolute, yukseklik));
                duzen.Controls.Add(akis, 0, 0);
            }
            else
            {
                duzen.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
            }

            duzen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablo.Dock = DockStyle.Fill;
            duzen.Controls.Add(tablo, 0, 1);

            if (altKontroller is { Length: > 0 })
            {
                FlowLayoutPanel akis = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Padding = new Padding(0, 4, 0, 0)
                };

                foreach (Control kontrol in altKontroller)
                {
                    kontrol.Margin = new Padding(0, 0, 8, 0);
                    kontrol.Anchor = AnchorStyles.Left;

                    if (kontrol is Button buton)
                    {
                        buton.AutoSize = false;
                        buton.Size = new Size(Math.Max(120, TextRenderer.MeasureText(buton.Text, buton.Font).Width + 28), 34);
                        buton.MaximumSize = new Size(180, 34);
                        buton.MinimumSize = new Size(100, 34);
                    }
                    else if (kontrol is Label etiket)
                    {
                        etiket.AutoSize = true;
                        etiket.Margin = new Padding(12, 8, 0, 0);
                    }

                    akis.Controls.Add(kontrol);
                }

                duzen.RowStyles.Add(new RowStyle(SizeType.Absolute, altYukseklik));
                duzen.Controls.Add(akis, 0, 2);
            }
            else
            {
                duzen.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
            }

            host.Controls.Add(duzen);
            host.ResumeLayout(true);
            host.PerformLayout();
        }

        public static void ButonuStil(Button buton, bool birincil = true)
        {
            buton.FlatStyle = FlatStyle.Flat;
            buton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buton.Cursor = Cursors.Hand;
            buton.Margin = new Padding(8);
            buton.Size = new Size(220, 72);
            buton.MaximumSize = new Size(0, 76);

            if (birincil)
            {
                buton.BackColor = Color.FromArgb(30, 121, 159);
                buton.ForeColor = Color.White;
                buton.FlatAppearance.BorderSize = 0;
            }
            else
            {
                buton.BackColor = Color.White;
                buton.ForeColor = Color.FromArgb(22, 54, 78);
                buton.FlatAppearance.BorderColor = Color.FromArgb(214, 224, 232);
            }
        }

        private sealed class ComboboxAramaDurumu
        {
            public List<object> Kaynak { get; init; } = new();
            public bool SerbestMetin { get; init; }
            public bool Guncelleniyor { get; set; }
        }

        /// <summary>
        /// Yazarak arama: metin içinde geçenleri listeler (ör. "mehm" → Dr. Mehmet).
        /// DataSource veya Items doldurulduktan sonra çağırın.
        /// </summary>
        public static void ComboboxAramaEtkinlestir(ComboBox cmb, bool serbestMetinIzin = false)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDown;
            cmb.AutoCompleteMode = AutoCompleteMode.None;
            cmb.AutoCompleteSource = AutoCompleteSource.None;

            // DataSource bağlıysa Items üzerinden çalışmak için çöz
            object? secili = cmb.SelectedItem;
            List<object> kaynak;
            if (cmb.DataSource is not null)
            {
                kaynak = cmb.Items.Cast<object>().ToList();
                cmb.DataSource = null;
                cmb.Items.Clear();
                cmb.Items.AddRange(kaynak.ToArray());
                if (secili is not null)
                {
                    cmb.SelectedItem = secili;
                }
            }
            else
            {
                kaynak = cmb.Items.Cast<object>().ToList();
            }

            ComboboxAramaDurumu durum = new ComboboxAramaDurumu
            {
                Kaynak = kaynak,
                SerbestMetin = serbestMetinIzin
            };
            cmb.Tag = durum;

            cmb.TextUpdate -= ComboboxArama_TextUpdate;
            cmb.Leave -= ComboboxArama_Leave;
            cmb.DropDown -= ComboboxArama_DropDown;
            cmb.TextUpdate += ComboboxArama_TextUpdate;
            cmb.Leave += ComboboxArama_Leave;
            cmb.DropDown += ComboboxArama_DropDown;
        }

        private static void ComboboxArama_DropDown(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cmb || cmb.Tag is not ComboboxAramaDurumu durum)
            {
                return;
            }

            if (durum.Guncelleniyor || !string.IsNullOrWhiteSpace(cmb.Text))
            {
                return;
            }

            ListeyiYenile(cmb, durum, "");
        }

        private static void ComboboxArama_TextUpdate(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cmb || cmb.Tag is not ComboboxAramaDurumu durum || durum.Guncelleniyor)
            {
                return;
            }

            string yazi = cmb.Text;
            int imlec = cmb.SelectionStart;
            ListeyiYenile(cmb, durum, yazi);

            cmb.Text = yazi;
            cmb.SelectionStart = Math.Min(imlec, cmb.Text.Length);
            cmb.SelectionLength = 0;

            if (!cmb.DroppedDown && cmb.Items.Count > 0)
            {
                cmb.DroppedDown = true;
                // WinForms: açılınca imleç bazen kaybolur
                Cursor.Current = Cursors.Default;
            }
        }

        private static void ComboboxArama_Leave(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cmb || cmb.Tag is not ComboboxAramaDurumu durum)
            {
                return;
            }

            string yazilan = cmb.Text.Trim();
            // Serbest metinde yalnızca tam eşleşme; aksi halde yeni türler mevcut türe kilitlenir
            object? eslesen = durum.SerbestMetin
                ? TamEslesmeBul(cmb, durum.Kaynak, yazilan)
                : EnIyiEslesmeyiBul(cmb, durum.Kaynak, yazilan);

            ListeyiYenile(cmb, durum, "");

            if (eslesen is not null)
            {
                cmb.SelectedItem = eslesen;
                return;
            }

            if (durum.SerbestMetin)
            {
                cmb.Text = yazilan;
                return;
            }

            // Liste dışı: ilk kayda veya boş
            if (durum.Kaynak.Count > 0)
            {
                cmb.SelectedItem = durum.Kaynak[0];
            }
            else
            {
                cmb.Text = "";
            }
        }

        /// <summary>
        /// Arama combo kaynağını günceller (ör. iş türü eklendi/silindi sonrası).
        /// </summary>
        public static void ComboboxAramaKaynaginiYenile(ComboBox cmb, IEnumerable<object> yeniKaynak, string? seciliMetin = null)
        {
            string metin = seciliMetin ?? cmb.Text;
            List<object> kaynak = yeniKaynak.ToList();

            if (cmb.Tag is ComboboxAramaDurumu durum)
            {
                durum.Kaynak.Clear();
                durum.Kaynak.AddRange(kaynak);
                ListeyiYenile(cmb, durum, "");
            }
            else
            {
                cmb.DataSource = null;
                cmb.Items.Clear();
                cmb.Items.AddRange(kaynak.ToArray());
            }

            if (!string.IsNullOrWhiteSpace(metin))
            {
                object? eslesen = kaynak.FirstOrDefault(item =>
                    string.Equals(cmb.GetItemText(item), metin.Trim(), StringComparison.CurrentCultureIgnoreCase));
                if (eslesen is not null)
                {
                    cmb.SelectedItem = eslesen;
                }
                else
                {
                    cmb.Text = metin.Trim();
                }
            }
        }

        private static void ListeyiYenile(ComboBox cmb, ComboboxAramaDurumu durum, string filtre)
        {
            durum.Guncelleniyor = true;
            try
            {
                IEnumerable<object> sonuc = string.IsNullOrWhiteSpace(filtre)
                    ? durum.Kaynak
                    : durum.Kaynak.Where(item =>
                        cmb.GetItemText(item).Contains(filtre.Trim(), StringComparison.CurrentCultureIgnoreCase));

                cmb.BeginUpdate();
                cmb.Items.Clear();
                foreach (object item in sonuc)
                {
                    cmb.Items.Add(item);
                }
                cmb.EndUpdate();
            }
            finally
            {
                durum.Guncelleniyor = false;
            }
        }

        private static object? TamEslesmeBul(ComboBox cmb, List<object> kaynak, string yazilan)
        {
            if (string.IsNullOrWhiteSpace(yazilan))
            {
                return null;
            }

            return kaynak.FirstOrDefault(item =>
                string.Equals(cmb.GetItemText(item), yazilan, StringComparison.CurrentCultureIgnoreCase));
        }

        private static object? EnIyiEslesmeyiBul(ComboBox cmb, List<object> kaynak, string yazilan)
        {
            if (string.IsNullOrWhiteSpace(yazilan))
            {
                return null;
            }

            object? tam = TamEslesmeBul(cmb, kaynak, yazilan);
            if (tam is not null)
            {
                return tam;
            }

            // Başlangıç (Dr. Mehmet / Mehmet)
            object? baslayan = kaynak.FirstOrDefault(item =>
            {
                string metin = cmb.GetItemText(item);
                return metin.StartsWith(yazilan, StringComparison.CurrentCultureIgnoreCase) ||
                       metin.Contains(" " + yazilan, StringComparison.CurrentCultureIgnoreCase);
            });
            if (baslayan is not null)
            {
                return baslayan;
            }

            // İçinde geçen
            return kaynak.FirstOrDefault(item =>
                cmb.GetItemText(item).Contains(yazilan, StringComparison.CurrentCultureIgnoreCase));
        }

        private static void StilUygula(Control kontrol)
        {
            if (kontrol is Button buton)
            {
                buton.FlatStyle = FlatStyle.Flat;
                buton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                // Kompakt +/- butonları tema genişletmesinden muaf
                if (buton.Text is "+" or "−" or "-")
                {
                    buton.Size = new Size(28, 28);
                    buton.MaximumSize = new Size(32, 32);
                    buton.MinimumSize = new Size(28, 28);
                    buton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    buton.Padding = Padding.Empty;
                    buton.Margin = Padding.Empty;
                    if (buton.Text is "+" )
                    {
                        buton.BackColor = Color.FromArgb(30, 121, 159);
                        buton.ForeColor = Color.White;
                        buton.FlatAppearance.BorderSize = 0;
                    }
                    else
                    {
                        buton.BackColor = Color.FromArgb(235, 241, 245);
                        buton.ForeColor = Color.FromArgb(51, 70, 84);
                        buton.FlatAppearance.BorderColor = Color.FromArgb(205, 216, 224);
                        buton.FlatAppearance.BorderSize = 1;
                    }
                }
                else
                {
                    buton.Size = new Size(Math.Max(buton.Width, 110), 34);
                    buton.MaximumSize = new Size(200, 34);

                    if (buton.Text is "İptal" or "Çıkış")
                    {
                        buton.BackColor = Color.FromArgb(235, 241, 245);
                        buton.ForeColor = Color.FromArgb(51, 70, 84);
                        buton.FlatAppearance.BorderColor = Color.FromArgb(205, 216, 224);
                    }
                    else
                    {
                        buton.BackColor = Color.FromArgb(30, 121, 159);
                        buton.ForeColor = Color.White;
                        buton.FlatAppearance.BorderSize = 0;
                    }
                }
            }
            else if (kontrol is DataGridView tablo)
            {
                tablo.BackgroundColor = Color.White;
                tablo.BorderStyle = BorderStyle.None;
                tablo.EnableHeadersVisualStyles = false;
                tablo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 54, 78);
                tablo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                tablo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                tablo.ColumnHeadersHeight = 34;
                tablo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 249, 251);
            }
        }
    }
}
