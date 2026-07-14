namespace ESDentalLab
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
            ArayuzTema.Uygula(this, "Kasa İşlemleri", "Giriş-çıkış hareketleri, banka hesabı ve para çıkışı");
            DuzeniAyarla();
        }

        private void DuzeniAyarla()
        {
            if (Controls.Find("pnlTemaIcerik", true).FirstOrDefault() is not Panel host)
            {
                return;
            }

            host.Controls.Clear();
            host.AutoScroll = false;
            host.Padding = new Padding(10);

            TableLayoutPanel kok = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            kok.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            kok.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            kok.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));

            FlowLayoutPanel ust = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 6, 0, 0)
            };
            ust.Controls.Add(lblKasaFiltre);
            ust.Controls.Add(cmbKasaFiltre);
            ust.Controls.Add(btnYenile);
            ust.Controls.Add(btnBankaEkle);
            ust.Controls.Add(lblToplamBakiye);

            dgvHareketler.Dock = DockStyle.Fill;

            Panel alt = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 8, 0, 0) };
            lblCikisBaslik.Location = new Point(0, 4);
            lblCikisKasa.Location = new Point(0, 36);
            cmbCikisKasa.Location = new Point(90, 33);
            lblCikisTutar.Location = new Point(330, 36);
            nudCikisTutar.Location = new Point(380, 33);
            lblCikisAciklama.Location = new Point(0, 72);
            txtCikisAciklama.Location = new Point(90, 69);
            btnCikisKaydet.Location = new Point(90, 108);

            alt.Controls.Add(lblCikisBaslik);
            alt.Controls.Add(lblCikisKasa);
            alt.Controls.Add(cmbCikisKasa);
            alt.Controls.Add(lblCikisTutar);
            alt.Controls.Add(nudCikisTutar);
            alt.Controls.Add(lblCikisAciklama);
            alt.Controls.Add(txtCikisAciklama);
            alt.Controls.Add(btnCikisKaydet);

            kok.Controls.Add(ust, 0, 0);
            kok.Controls.Add(dgvHareketler, 0, 1);
            kok.Controls.Add(alt, 0, 2);
            host.Controls.Add(kok);
        }

        private void frmKasa_Load(object sender, EventArgs e)
        {
            KasalarıYukle();
            HareketleriYukle();
        }

        private void KasalarıYukle()
        {
            List<Kasa> kasalar = VeriDeposu.AktifKasalar.ToList();

            cmbKasaFiltre.SelectedIndexChanged -= cmbKasaFiltre_SelectedIndexChanged;
            cmbKasaFiltre.Items.Clear();
            cmbKasaFiltre.Items.Add("Tümü");
            foreach (Kasa kasa in kasalar)
            {
                cmbKasaFiltre.Items.Add(kasa);
            }

            cmbKasaFiltre.SelectedIndex = 0;
            cmbKasaFiltre.SelectedIndexChanged += cmbKasaFiltre_SelectedIndexChanged;

            cmbCikisKasa.DataSource = null;
            cmbCikisKasa.DataSource = kasalar.ToList();

            BakiyeleriGuncelle();
        }

        private void BakiyeleriGuncelle()
        {
            lblToplamBakiye.Text = $"Toplam kasa: {VeriDeposu.ToplamKasaBakiyesi:N2} TL";
        }

        private void HareketleriYukle()
        {
            IEnumerable<KasaHareketi> hareketler = VeriDeposu.KasaHareketleri;

            if (cmbKasaFiltre.SelectedItem is Kasa kasa)
            {
                hareketler = hareketler.Where(h => ReferenceEquals(h.Kasa, kasa));
            }

            List<KasaHareketi> liste = hareketler
                .OrderByDescending(h => h.Tarih)
                .ThenByDescending(h => h.Yon)
                .ToList();

            dgvHareketler.DataSource = null;
            dgvHareketler.AutoGenerateColumns = false;
            dgvHareketler.Columns.Clear();
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tarih",
                HeaderText = "Tarih",
                DefaultCellStyle = { Format = "dd.MM.yyyy" },
                FillWeight = 14
            });
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "KasaAdi",
                HeaderText = "Kasa",
                FillWeight = 18
            });
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "YonMetni",
                HeaderText = "Yön",
                FillWeight = 10
            });
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GirisTutari",
                HeaderText = "Giriş",
                DefaultCellStyle = { Format = "N2" },
                FillWeight = 14
            });
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CikisTutari",
                HeaderText = "Çıkış",
                DefaultCellStyle = { Format = "N2" },
                FillWeight = 14
            });
            dgvHareketler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Aciklama",
                HeaderText = "Açıklama",
                FillWeight = 30
            });

            dgvHareketler.DataSource = liste;
            dgvHareketler.CellFormatting -= DgvHareketler_CellFormatting;
            dgvHareketler.CellFormatting += DgvHareketler_CellFormatting;
            BakiyeleriGuncelle();
        }

        private void DgvHareketler_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHareketler.Rows[e.RowIndex].DataBoundItem is not KasaHareketi hareket)
            {
                return;
            }

            if (hareket.IptalEdildi)
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgvHareketler.Font, FontStyle.Strikeout);
            }
        }

        private void cmbKasaFiltre_SelectedIndexChanged(object? sender, EventArgs e)
        {
            HareketleriYukle();
        }

        private void btnYenile_Click(object? sender, EventArgs e)
        {
            KasalarıYukle();
            HareketleriYukle();
        }

        private void btnBankaEkle_Click(object? sender, EventArgs e)
        {
            using Form dialog = new Form
            {
                Text = "Banka Hesabı Ekle",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(360, 150),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label { Text = "Hesap adı", Location = new Point(20, 24), AutoSize = true };
            TextBox txt = new TextBox { Location = new Point(20, 48), Width = 310 };
            Button btnTamam = new Button
            {
                Text = "Kaydet",
                DialogResult = DialogResult.OK,
                Location = new Point(140, 95),
                Size = new Size(90, 30)
            };
            Button btnVazgec = new Button
            {
                Text = "İptal",
                DialogResult = DialogResult.Cancel,
                Location = new Point(240, 95),
                Size = new Size(90, 30)
            };

            dialog.Controls.AddRange([lbl, txt, btnTamam, btnVazgec]);
            dialog.AcceptButton = btnTamam;
            dialog.CancelButton = btnVazgec;

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.BankaHesabiEkle(txt.Text);
            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Uyarı");
            if (basarili)
            {
                KasalarıYukle();
                HareketleriYukle();
            }
        }

        private void btnCikisKaydet_Click(object? sender, EventArgs e)
        {
            if (cmbCikisKasa.SelectedItem is not Kasa kasa)
            {
                MessageBox.Show("Çıkış için bir kasa seçin.", "Eksik bilgi");
                return;
            }

            string aciklama = txtCikisAciklama.Text.Trim();
            if (string.IsNullOrWhiteSpace(aciklama))
            {
                MessageBox.Show("Çıkış açıklaması zorunludur (ör. Mutfak harcaması).", "Eksik bilgi");
                txtCikisAciklama.Focus();
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.KasaCikisiEkle(
                kasa,
                nudCikisTutar.Value,
                aciklama,
                DateTime.Today);

            MessageBox.Show(mesaj, basarili ? "Başarılı" : "Uyarı");
            if (!basarili)
            {
                return;
            }

            nudCikisTutar.Value = 0;
            txtCikisAciklama.Clear();
            KasalarıYukle();
            HareketleriYukle();
        }
    }
}
