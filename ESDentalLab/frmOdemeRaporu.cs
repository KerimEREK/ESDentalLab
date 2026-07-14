using System.ComponentModel;

namespace ESDentalLab
{
    public partial class frmOdemeRaporu : Form
    {
        public frmOdemeRaporu()
        {
            InitializeComponent();
            ArayuzTema.Uygula(this, "Ödeme Raporları", "Tahsilatları inceleyin, detaya bakın veya iptal edin");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgvOdemeler,
                [
                    lblDoktor, cmbDoktor,
                    lblOdemeYontemi, cmbOdemeYontemi,
                    chkTarihFiltrele, dtpBaslangic, lblTarihAyirac, dtpBitis,
                    chkIptalleriGoster, btnFiltrele
                ],
                [btnDetay, btnIptal, lblToplam],
                ustYukseklik: 70,
                altYukseklik: 48);

            dgvOdemeler.CellFormatting += dgvOdemeler_CellFormatting;
            dgvOdemeler.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DetayGoster();
                }
            };
        }

        private void frmOdemeRaporu_Load(object sender, EventArgs e)
        {
            cmbDoktor.Items.Add("Tümü");
            cmbDoktor.Items.AddRange(VeriDeposu.Doktorlar.Cast<object>().ToArray());
            cmbDoktor.SelectedIndex = 0;

            cmbOdemeYontemi.SelectedIndex = 0;
            dtpBaslangic.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpBitis.Value = DateTime.Today;
            TarihKontrolleriniAyarla();
            ArayuzTema.ComboboxAramaEtkinlestir(cmbDoktor);
            RaporuYukle();
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        private void chkTarihFiltrele_CheckedChanged(object sender, EventArgs e)
        {
            TarihKontrolleriniAyarla();
        }

        private void chkIptalleriGoster_CheckedChanged(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        private void TarihKontrolleriniAyarla()
        {
            dtpBaslangic.Enabled = chkTarihFiltrele.Checked;
            dtpBitis.Enabled = chkTarihFiltrele.Checked;
        }

        private void RaporuYukle()
        {
            IEnumerable<TahsilatOzeti> tahsilatlar = VeriDeposu.TahsilatlariListele(chkIptalleriGoster.Checked);

            if (cmbDoktor.SelectedItem is Doctor doktor)
            {
                tahsilatlar = tahsilatlar.Where(t => ReferenceEquals(t.Doktor, doktor));
            }

            if (cmbOdemeYontemi.SelectedItem is string yontem && yontem != "Tümü")
            {
                tahsilatlar = tahsilatlar.Where(t => t.OdemeYontemi == yontem);
            }

            if (chkTarihFiltrele.Checked)
            {
                DateTime baslangic = dtpBaslangic.Value.Date;
                DateTime bitis = dtpBitis.Value.Date;
                tahsilatlar = tahsilatlar.Where(t => t.Tarih.Date >= baslangic && t.Tarih.Date <= bitis);
            }

            List<TahsilatOzeti> raporKayitlari = tahsilatlar.ToList();
            dgvOdemeler.DataSource = new BindingList<TahsilatOzeti>(raporKayitlari);
            colAciklama.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOdemeler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            decimal aktifToplam = raporKayitlari.Where(t => !t.IptalEdildi).Sum(t => t.Tutar);
            lblToplam.Text = chkIptalleriGoster.Checked
                ? $"Aktif toplam: {aktifToplam:N2} TL  ·  Listelenen: {raporKayitlari.Count}"
                : $"Toplam ödeme: {aktifToplam:N2} TL";
        }

        private TahsilatOzeti? SeciliTahsilat()
        {
            return dgvOdemeler.CurrentRow?.DataBoundItem as TahsilatOzeti;
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            DetayGoster();
        }

        private void DetayGoster()
        {
            TahsilatOzeti? tahsilat = SeciliTahsilat();
            if (tahsilat is null)
            {
                MessageBox.Show("Detay için listeden bir tahsilat seçin.", "Seçim yok");
                return;
            }

            string satirlar = string.Join("\n",
                tahsilat.Satirlar.Select(o =>
                    o.IliskiliIs is null
                        ? $"• (İş bağlı değil) {o.Tutar:N2} TL — {o.Aciklama}"
                        : $"• {o.IliskiliIs.IsNumarasi} — {o.IliskiliIs.HastaAdi} / {o.IliskiliIs.IsTuru}: {o.Tutar:N2} TL"));

            string iptalBilgi = tahsilat.IptalEdildi
                ? $"\n\nDurum: İPTAL\nGerekçe: {tahsilat.Satirlar[0].IptalNedeni}\nTarih: {tahsilat.Satirlar[0].IptalTarihi:g}"
                : "\n\nDurum: Aktif";

            MessageBox.Show(
                $"Doktor: {tahsilat.Doktor.AdSoyad}\n" +
                $"Tarih: {tahsilat.Tarih:d}\n" +
                $"Yöntem: {tahsilat.OdemeYontemi}\n" +
                $"Kasa: {tahsilat.KasaAdi}\n" +
                $"Toplam: {tahsilat.Tutar:N2} TL\n\n" +
                $"Dağılım ({tahsilat.IsSayisi} iş):\n{satirlar}{iptalBilgi}",
                "Tahsilat detayı");
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            TahsilatOzeti? tahsilat = SeciliTahsilat();
            if (tahsilat is null)
            {
                MessageBox.Show("İptal için listeden bir tahsilat seçin.", "Seçim yok");
                return;
            }

            if (tahsilat.IptalEdildi)
            {
                MessageBox.Show("Bu tahsilat zaten iptal edilmiş.", "Bilgi");
                return;
            }

            using frmTahsilatIptal dlg = new frmTahsilatIptal(tahsilat);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.TahsilatIptalEt(tahsilat.TahsilatNo, dlg.Gerekce);
            MessageBox.Show(
                mesaj,
                basarili ? "İptal edildi" : "İptal edilemedi",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili)
            {
                RaporuYukle();
            }
        }

        private void dgvOdemeler_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOdemeler.Rows[e.RowIndex].DataBoundItem is not TahsilatOzeti tahsilat)
            {
                return;
            }

            if (tahsilat.IptalEdildi)
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgvOdemeler.Font, FontStyle.Strikeout);
            }
        }
    }

    public class frmTahsilatIptal : Form
    {
        private readonly TextBox txtGerekce = new();

        public string Gerekce => txtGerekce.Text.Trim();

        public frmTahsilatIptal(TahsilatOzeti tahsilat)
        {
            Text = "Tahsilat iptal";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, 230);
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.White;

            Label lbl = new Label
            {
                AutoSize = false,
                Size = new Size(380, 60),
                Location = new Point(20, 16),
                Text = $"{tahsilat.Doktor.AdSoyad}\n{tahsilat.Tarih:d} · {tahsilat.Tutar:N2} TL\n\nBu tahsilat iptal edilecek; iş ve kasa bakiyeleri geri alınır. Doğru ödemeyi sonra yeniden girin."
            };

            Label lblGerekce = new Label
            {
                Text = "İptal gerekçesi",
                AutoSize = true,
                Location = new Point(20, 90)
            };

            txtGerekce.Location = new Point(20, 112);
            txtGerekce.Size = new Size(380, 50);
            txtGerekce.Multiline = true;

            Button btnTamam = new Button
            {
                Text = "İptal et",
                Size = new Size(110, 34),
                Location = new Point(190, 180),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(140, 55, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnTamam.FlatAppearance.BorderSize = 0;
            btnTamam.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtGerekce.Text))
                {
                    MessageBox.Show("Kısa bir gerekçe yazın.", "Eksik bilgi");
                    return;
                }

                if (MessageBox.Show(
                        "Tahsilat kalıcı olarak iptal işareti alacak (silinmez). Devam?",
                        "Onay",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            };

            Button btnVazgec = new Button
            {
                Text = "Vazgeç",
                Size = new Size(90, 34),
                Location = new Point(310, 180),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(lbl);
            Controls.Add(lblGerekce);
            Controls.Add(txtGerekce);
            Controls.Add(btnTamam);
            Controls.Add(btnVazgec);
            CancelButton = btnVazgec;
        }
    }
}
