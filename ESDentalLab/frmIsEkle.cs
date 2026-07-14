using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ESDentalLab
{
    public partial class frmIsEkle : Form
    {
        public frmIsEkle()
        {
            InitializeComponent();
            ArayuzTema.Uygula(this, "Yeni İş Kaydı", "Laboratuvar iş detaylarını eksiksiz kaydedin");
        }

        private void frmIsEkle_Load(object sender, EventArgs e)
        {
            cmbDoktor.DataSource = VeriDeposu.AktifDoktorlar.ToList();
            cmbIsTuru.DataSource = VeriDeposu.IsTurleri.ToList();
            cmbDurum.SelectedIndex = 0;
            dtpTeslimTarihi.Value = DateTime.Today.AddDays(7);

            ArayuzTema.ComboboxAramaEtkinlestir(cmbDoktor);
            ArayuzTema.ComboboxAramaEtkinlestir(cmbIsTuru, serbestMetinIzin: true);
            chkRptMi.CheckedChanged += chkRptMi_CheckedChanged;
            RptAlanlariniAyarla();
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
                IsTuruListesiniYenile("");
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

            string isTuru = cmbIsTuru.Text.Trim();
            VeriDeposu.IsTuruEkle(isTuru);
            IsTuruListesiniYenile(isTuru);

            bool rpt = chkRptMi.Checked;
            Is yeniIs = new Is
            {
                IsNumarasi = $"IS-{DateTime.Today:yyyyMMdd}-{VeriDeposu.Isler.Count + 1:D4}",
                KayitTarihi = DateTime.Now,
                Doktor = doktor,
                HastaAdi = txtHastaAdi.Text.Trim(),
                IsTuru = isTuru,
                DisNumarasi = txtDisNumarasi.Text.Trim(),
                TeslimTarihi = dtpTeslimTarihi.Value.Date,
                Durum = cmbDurum.Text,
                Aciklama = txtAciklama.Text.Trim(),
                Fiyat = rpt ? 0 : nudFiyat.Value,
                RptMi = rpt
            };
            VeriDeposu.Isler.Add(yeniIs);
            VeriDeposu.DenetimEkle(DenetimKategori.Is, "İş eklendi",
                $"{yeniIs.IsNumarasi} · {yeniIs.HastaAdi} · {doktor.AdSoyad} · {yeniIs.Fiyat:N2} TL{(rpt ? " · RPT" : "")}");

            Is kaydedilenIs = yeniIs;

            if (MessageBox.Show("İş kaydı eklendi. İş fişini şimdi görüntülemek ister misiniz?", "Başarılı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsFisiYazdirici.OnizlemeGoster(this, kaydedilenIs);
            }
            txtHastaAdi.Clear();
            txtDisNumarasi.Clear();
            txtAciklama.Clear();
            nudFiyat.Value = 0;
            chkRptMi.Checked = false;
            cmbIsTuru.SelectedIndex = -1;
            cmbDurum.SelectedIndex = 0;
            txtHastaAdi.Focus();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
