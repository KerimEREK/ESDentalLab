namespace ESDentalLab
{
    public partial class frmOdemeEkle : Form
    {
        private readonly Is? _iliskiliIs;
        private bool _secimGuncelleniyor;

        public frmOdemeEkle() : this(null)
        {
        }

        public frmOdemeEkle(Is? iliskiliIs)
        {
            _iliskiliIs = iliskiliIs;
            InitializeComponent();
            ArayuzTema.Uygula(this, "Doktor Ödemesi", "Fazla tutar doktora alacak yazılır; laboratuvar borçlu olabilir");
            FormDuzeniniAyarla();
            // Tema başlığı + Kaydet/İptal için dialog yüksekliği
            if (TopLevel)
            {
                ClientSize = new Size(Math.Max(ClientSize.Width, 1000), Math.Max(ClientSize.Height, 580));
                MinimumSize = new Size(920, 520);
            }
        }

        private void FormDuzeniniAyarla()
        {
            if (Controls.Find("pnlTemaIcerik", true).FirstOrDefault() is not Panel host)
            {
                return;
            }

            Control[] kontroller = host.Controls.Cast<Control>().ToArray();
            host.Controls.Clear();
            host.AutoScroll = false;
            host.Padding = new Padding(8);

            Panel sol = new Panel
            {
                Dock = DockStyle.Left,
                Width = 390,
                Padding = new Padding(4)
            };

            Panel sag = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 0, 4, 4)
            };

            foreach (Control kontrol in kontroller)
            {
                if (kontrol == dgvIsler || kontrol == lblIsListesi || kontrol == lblSecimOzet || kontrol == lblBakiye)
                {
                    continue;
                }

                sol.Controls.Add(kontrol);
            }

            TableLayoutPanel sagDuzen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            sagDuzen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sagDuzen.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            sagDuzen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sagDuzen.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));

            Panel baslikPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            lblIsListesi.AutoSize = true;
            lblIsListesi.Dock = DockStyle.None;
            lblIsListesi.TextAlign = ContentAlignment.MiddleLeft;
            lblIsListesi.Location = new Point(0, 8);
            lblIsListesi.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblBakiye.AutoSize = true;
            lblBakiye.Dock = DockStyle.None;
            lblBakiye.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBakiye.ForeColor = Color.FromArgb(180, 40, 40);
            lblBakiye.TextAlign = ContentAlignment.MiddleRight;
            lblBakiye.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBakiye.Margin = Padding.Empty;
            lblBakiye.Padding = Padding.Empty;

            void BakiyeKonumunuAyarla()
            {
                lblBakiye.Location = new Point(
                    Math.Max(0, baslikPanel.ClientSize.Width - lblBakiye.Width - 4),
                    6);
            }

            baslikPanel.Resize += (_, _) => BakiyeKonumunuAyarla();
            lblBakiye.SizeChanged += (_, _) => BakiyeKonumunuAyarla();

            dgvIsler.Dock = DockStyle.Fill;
            lblSecimOzet.AutoSize = false;
            lblSecimOzet.Dock = DockStyle.Fill;
            lblSecimOzet.TextAlign = ContentAlignment.MiddleLeft;

            baslikPanel.Controls.Add(lblIsListesi);
            baslikPanel.Controls.Add(lblBakiye);
            BakiyeKonumunuAyarla();

            sagDuzen.Controls.Add(baslikPanel, 0, 0);
            sagDuzen.Controls.Add(dgvIsler, 0, 1);
            sagDuzen.Controls.Add(lblSecimOzet, 0, 2);

            sag.Controls.Add(sagDuzen);
            host.Controls.Add(sag);
            host.Controls.Add(sol);
        }

        private void frmOdemeEkle_Load(object sender, EventArgs e)
        {
            List<Doctor> doktorlar = VeriDeposu.AktifDoktorlar.ToList();

            if (_iliskiliIs?.Doktor is Doctor iliskiliDoktor &&
                !doktorlar.Any(doktor => ReferenceEquals(doktor, iliskiliDoktor)))
            {
                doktorlar.Insert(0, iliskiliDoktor);
            }

            cmbDoktor.SelectedIndexChanged -= cmbDoktor_SelectedIndexChanged;
            cmbDoktor.DataSource = doktorlar;
            dtpTarih.Value = DateTime.Today;
            cmbOdemeYontemi.SelectedIndex = 0;
            KasalarıYukle();
            OdemeYontemineGoreKasaSec();
            cmbDoktor.SelectedIndexChanged += cmbDoktor_SelectedIndexChanged;

            if (_iliskiliIs is not null)
            {
                cmbDoktor.SelectedItem = _iliskiliIs.Doktor;
                cmbDoktor.Enabled = false;
            }

            ArayuzTema.ComboboxAramaEtkinlestir(cmbDoktor);

            DoktorIsleriniYukle();

            if (_iliskiliIs is not null)
            {
                IsSatiriniSec(_iliskiliIs);
            }
        }

        private void KasalarıYukle()
        {
            cmbKasa.DataSource = null;
            cmbKasa.DataSource = VeriDeposu.AktifKasalar.ToList();
        }

        private void cmbOdemeYontemi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            OdemeYontemineGoreKasaSec();
        }

        private void OdemeYontemineGoreKasaSec()
        {
            if (cmbKasa.Items.Count == 0)
            {
                return;
            }

            string yontem = cmbOdemeYontemi.Text;
            Kasa? hedef = yontem.Contains("Nakit", StringComparison.CurrentCultureIgnoreCase)
                ? VeriDeposu.NakitKasasi
                : VeriDeposu.AktifKasalar.FirstOrDefault(kasa => kasa.Tur == KasaTuru.Banka)
                  ?? VeriDeposu.NakitKasasi;

            if (hedef is not null)
            {
                cmbKasa.SelectedItem = hedef;
            }
            else if (cmbKasa.Items.Count > 0)
            {
                cmbKasa.SelectedIndex = 0;
            }
        }

        private void cmbDoktor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            DoktorIsleriniYukle();
        }

        private void DoktorIsleriniYukle()
        {
            if (cmbDoktor.SelectedItem is not Doctor doktor)
            {
                dgvIsler.DataSource = null;
                BakiyeyiGoster(0);
                SecimiGuncelle();
                return;
            }

            BakiyeyiGoster(doktor.Bakiye);

            List<Is> isler = VeriDeposu.Isler
                .Where(isKaydi => ReferenceEquals(isKaydi.Doktor, doktor) && !isKaydi.RptMi && isKaydi.KalanTutar > 0)
                .OrderByDescending(isKaydi => isKaydi.KayitTarihi)
                .ToList();

            dgvIsler.DataSource = null;
            dgvIsler.Rows.Clear();
            dgvIsler.Columns.Clear();
            dgvIsler.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn secKolonu = new DataGridViewCheckBoxColumn
            {
                Name = "colSec",
                HeaderText = "Seç",
                Width = 45,
                FillWeight = 10F
            };
            DataGridViewTextBoxColumn hastaKolonu = new DataGridViewTextBoxColumn
            {
                Name = "colHasta",
                HeaderText = "Hasta",
                FillWeight = 28F,
                ReadOnly = true
            };
            DataGridViewTextBoxColumn turKolonu = new DataGridViewTextBoxColumn
            {
                Name = "colIsTuru",
                HeaderText = "İş türü",
                FillWeight = 20F,
                ReadOnly = true
            };
            DataGridViewTextBoxColumn fiyatKolonu = new DataGridViewTextBoxColumn
            {
                Name = "colFiyat",
                HeaderText = "Fiyat",
                FillWeight = 14F,
                ReadOnly = true,
                DefaultCellStyle = { Format = "N2" }
            };
            DataGridViewTextBoxColumn odendiKolonu = new DataGridViewTextBoxColumn
            {
                Name = "colOdendi",
                HeaderText = "Ödenen",
                FillWeight = 14F,
                ReadOnly = true,
                DefaultCellStyle = { Format = "N2" }
            };
            DataGridViewTextBoxColumn kalanKolonu = new DataGridViewTextBoxColumn
            {
                Name = "colKalan",
                HeaderText = "Kalan",
                FillWeight = 14F,
                ReadOnly = true,
                DefaultCellStyle = { Format = "N2" }
            };

            dgvIsler.Columns.AddRange(secKolonu, hastaKolonu, turKolonu, fiyatKolonu, odendiKolonu, kalanKolonu);

            foreach (Is isKaydi in isler)
            {
                int indeks = dgvIsler.Rows.Add(
                    false,
                    isKaydi.HastaAdi,
                    isKaydi.IsTuru,
                    isKaydi.Fiyat,
                    isKaydi.OdendiTutari,
                    isKaydi.KalanTutar);
                dgvIsler.Rows[indeks].Tag = isKaydi;
            }

            SecimiGuncelle();
        }

        private void BakiyeyiGoster(decimal bakiye)
        {
            lblBakiye.AutoSize = true;
            string isaret = bakiye > 0 ? "+" : "";
            lblBakiye.Text = $"Doktor bakiyesi: {isaret}{bakiye:N2} TL";
            lblBakiye.ForeColor = bakiye < 0
                ? Color.FromArgb(30, 121, 159)
                : Color.FromArgb(180, 40, 40);

            if (lblBakiye.Parent is Control parent)
            {
                lblBakiye.Location = new Point(
                    Math.Max(0, parent.ClientSize.Width - lblBakiye.PreferredWidth - 4),
                    6);
            }
        }

        private void IsSatiriniSec(Is hedef)
        {
            foreach (DataGridViewRow satir in dgvIsler.Rows)
            {
                if (satir.Tag is Is isKaydi && ReferenceEquals(isKaydi, hedef))
                {
                    satir.Cells["colSec"].Value = true;
                    break;
                }
            }

            SecimiGuncelle();
        }

        private List<Is> SeciliIsleriAl()
        {
            List<Is> secilenler = new List<Is>();

            foreach (DataGridViewRow satir in dgvIsler.Rows)
            {
                bool secili = satir.Cells["colSec"].Value is true;
                if (secili && satir.Tag is Is isKaydi)
                {
                    secilenler.Add(isKaydi);
                }
            }

            return secilenler;
        }

        private void SecimiGuncelle()
        {
            if (_secimGuncelleniyor)
            {
                return;
            }

            _secimGuncelleniyor = true;
            try
            {
                List<Is> secilenler = SeciliIsleriAl();
                decimal toplamKalan = secilenler.Sum(isKaydi => isKaydi.KalanTutar);

                if (secilenler.Count == 0)
                {
                    decimal acikToplam = cmbDoktor.SelectedItem is Doctor d
                        ? VeriDeposu.Isler
                            .Where(isKaydi => ReferenceEquals(isKaydi.Doktor, d) && !isKaydi.RptMi && isKaydi.KalanTutar > 0)
                            .Sum(isKaydi => isKaydi.KalanTutar)
                        : 0;
                    lblSecimOzet.Text = acikToplam > 0
                        ? $"Seçim yok → önce açık işlere (FIFO) · açık: {acikToplam:N2} TL · fazlası doktora alacak"
                        : "Açık borç yok · tutarın tamamı doktora alacak (avans) yazılır";
                }
                else
                {
                    lblSecimOzet.Text =
                        $"{secilenler.Count} iş seçili · kalan: {toplamKalan:N2} TL · fazlası doktora alacak yazılır";
                    nudTutar.Value = Math.Min(toplamKalan, nudTutar.Maximum);
                    txtAciklama.Text = secilenler.Count == 1
                        ? $"{secilenler[0].IsNumarasi} - {secilenler[0].HastaAdi} iş ödemesi"
                        : $"{secilenler.Count} iş ödemesi: {string.Join(", ", secilenler.Select(isKaydi => isKaydi.IsNumarasi))}";
                }
            }
            finally
            {
                _secimGuncelleniyor = false;
            }
        }

        private void dgvIsler_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvIsler.IsCurrentCellDirty)
            {
                dgvIsler.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvIsler_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvIsler.Columns[e.ColumnIndex].Name == "colSec")
            {
                SecimiGuncelle();
            }
        }

        private void dgvIsler_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvIsler.Columns[e.ColumnIndex].Name == "colSec")
            {
                dgvIsler.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbDoktor.SelectedItem is not Doctor doktor)
            {
                MessageBox.Show("Lütfen bir doktor seçin.", "Eksik bilgi");
                return;
            }

            if (cmbKasa.SelectedItem is not Kasa kasa)
            {
                MessageBox.Show("Lütfen ödemenin işleneceği kasayı seçin.", "Eksik bilgi");
                return;
            }

            if (nudTutar.Value <= 0)
            {
                MessageBox.Show("Ödeme tutarı sıfırdan büyük olmalıdır.", "Eksik bilgi");
                return;
            }

            List<Is> secilenler = SeciliIsleriAl();
            DateTime tarih = dtpTarih.Value.Date;
            string yontem = cmbOdemeYontemi.Text;
            string aciklama = txtAciklama.Text.Trim();

            (bool basarili, string mesaj) = VeriDeposu.OdemeFifoDagit(
                doktor,
                kasa,
                nudTutar.Value,
                tarih,
                yontem,
                aciklama,
                secilenler.Count > 0 ? secilenler : null);

            MessageBox.Show(
                mesaj,
                basarili ? "Başarılı" : "Ödeme kaydedilemedi",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (!basarili)
            {
                return;
            }

            if (_iliskiliIs is not null)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            nudTutar.Value = 0;
            txtAciklama.Clear();
            KasalarıYukle();
            OdemeYontemineGoreKasaSec();
            DoktorIsleriniYukle();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
