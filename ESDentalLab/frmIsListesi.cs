using System.ComponentModel;

namespace ESDentalLab
{
    public enum IsListesiOzetFiltresi
    {
        Yok,
        BugunTeslim,
        Geciken,
        Uretimde,
        TeslimEdilen
    }

    public partial class frmIsListesi : Form
    {
        private IsListesiOzetFiltresi _ozetFiltresi;

        public frmIsListesi() : this(IsListesiOzetFiltresi.Yok)
        {
        }

        public frmIsListesi(IsListesiOzetFiltresi ozetFiltresi)
        {
            _ozetFiltresi = ozetFiltresi;
            InitializeComponent();
            string altBaslik = ozetFiltresi switch
            {
                IsListesiOzetFiltresi.BugunTeslim => "Bugün teslim edilecek işleri görüntülüyorsunuz",
                IsListesiOzetFiltresi.Geciken => "Geciken işleri görüntülüyorsunuz",
                IsListesiOzetFiltresi.Uretimde => "Üretimdeki işleri görüntülüyorsunuz",
                IsListesiOzetFiltresi.TeslimEdilen => "Teslim edilen işleri görüntülüyorsunuz",
                _ => "Kayıtları filtreleyin, takip edin ve güncelleyin"
            };
            ArayuzTema.Uygula(this, "İş Listesi", altBaslik);
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgvIsler,
                [
                    lblHastaAra, txtHastaAra,
                    lblDoktorFiltresi, cmbDoktor,
                    lblDurumFiltresi, cmbDurumFiltresi,
                    lblRptFiltresi, cmbRptFiltresi,
                    chkTeslimTarihi, dtpTeslimBaslangic, lblTarihAyirac, dtpTeslimBitis,
                    chkAlinmaTarihi, dtpAlinmaBaslangic, lblAlinmaAyirac, dtpAlinmaBitis
                ],
                [btnHepsiniSec, btnSecimiKaldir, btnPdf, btnYazdir, btnDuzenle, btnSil, btnYenile],
                ustYukseklik: 108,
                altYukseklik: 48);

            btnSil.Visible = VeriDeposu.YetkiVarMi(KullaniciYetki.Silme);
            btnDuzenle.Visible = VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri);

            // Satır 1: arama/filtreler · Satır 2: tarih aralıkları
            if (cmbRptFiltresi.Parent is FlowLayoutPanel filtreAkis)
            {
                filtreAkis.SetFlowBreak(cmbRptFiltresi, true);
            }

            dgvIsler.CurrentCellDirtyStateChanged += (_, _) =>
            {
                if (dgvIsler.IsCurrentCellDirty && dgvIsler.CurrentCell is DataGridViewCheckBoxCell)
                {
                    dgvIsler.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dgvIsler.CellFormatting += dgvIsler_CellFormatting;
        }

        private void dgvIsler_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvIsler.Columns[e.ColumnIndex].Name != "colOdemeDurumu")
            {
                return;
            }

            string durum = e.Value?.ToString() ?? "";
            e.CellStyle.Font = new Font(dgvIsler.Font, FontStyle.Bold);
            e.CellStyle.ForeColor = durum switch
            {
                "Ödendi" => Color.FromArgb(22, 120, 70),
                "Kısmi" => Color.FromArgb(180, 110, 20),
                "Ödenmedi" => Color.FromArgb(180, 40, 40),
                _ => Color.FromArgb(91, 107, 119)
            };
        }

        private void frmIsListesi_Load(object sender, EventArgs e)
        {
            FiltreleriYukle();
            OzetFiltresiniUygula();
            TarihKontrolleriniAyarla();
            IsleriYukle();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            IsleriYukle();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.IsIslemleri))
            {
                VeriDeposu.YetkiYokUyarisi("İş düzenleme");
                return;
            }

            if (dgvIsler.CurrentRow?.DataBoundItem is not Is secilenIs)
            {
                MessageBox.Show("Düzenlemek için listeden bir iş seçin.", "İş seçilmedi");
                return;
            }

            using frmIsDuzenle duzenleFormu = new frmIsDuzenle(secilenIs);

            if (duzenleFormu.ShowDialog() == DialogResult.OK)
            {
                IsleriYukle();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            List<Is> secilenler = SeciliIsleriAl();
            if (secilenler.Count == 0)
            {
                MessageBox.Show("Yazdırmak için soldaki kutudan bir veya daha fazla iş seçin.", "İş seçilmedi");
                return;
            }

            IsFisiYazdirici.OnizlemeGoster(this, secilenler);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            List<Is> secilenler = SeciliIsleriAl();
            if (secilenler.Count == 0)
            {
                MessageBox.Show("PDF için soldaki kutudan bir veya daha fazla iş seçin.", "İş seçilmedi");
                return;
            }

            using SaveFileDialog kaydet = new SaveFileDialog
            {
                Title = "İş fişlerini PDF olarak kaydet",
                Filter = "PDF dosyası (*.pdf)|*.pdf",
                FileName = secilenler.Count == 1
                    ? $"{secilenler[0].IsNumarasi}_is_fisi.pdf"
                    : $"is_fisleri_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                OverwritePrompt = true
            };

            if (kaydet.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            (bool basarili, string mesaj) = IsFisiYazdirici.PdfKaydet(kaydet.FileName, secilenler);
            MessageBox.Show(
                mesaj,
                basarili ? "PDF kaydedildi" : "PDF oluşturulamadı",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili &&
                MessageBox.Show("PDF dosyasını şimdi açmak ister misiniz?", "PDF",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = kaydet.FileName,
                    UseShellExecute = true
                });
            }
        }

        private void btnHepsiniSec_Click(object sender, EventArgs e)
        {
            SecimleriAyarla(true);
        }

        private void btnSecimiKaldir_Click(object sender, EventArgs e)
        {
            SecimleriAyarla(false);
        }

        private void SecimleriAyarla(bool secili)
        {
            foreach (DataGridViewRow satir in dgvIsler.Rows)
            {
                satir.Cells["colSec"].Value = secili;
            }

            dgvIsler.RefreshEdit();
            dgvIsler.Invalidate();
        }

        private List<Is> SeciliIsleriAl()
        {
            List<Is> secilenler = new List<Is>();

            foreach (DataGridViewRow satir in dgvIsler.Rows)
            {
                bool isaretli = satir.Cells["colSec"].Value is true;
                if (isaretli && satir.DataBoundItem is Is isKaydi)
                {
                    secilenler.Add(isKaydi);
                }
            }

            // Hiç kutu işaretli değilse, vurgulanan satırı kullan
            if (secilenler.Count == 0 && dgvIsler.CurrentRow?.DataBoundItem is Is tek)
            {
                secilenler.Add(tek);
            }

            return secilenler;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.Silme))
            {
                VeriDeposu.YetkiYokUyarisi("İş silme");
                return;
            }

            if (dgvIsler.CurrentRow?.DataBoundItem is not Is secilenIs)
            {
                MessageBox.Show("Silmek için listeden bir iş seçin.", "İş seçilmedi");
                return;
            }

            string ozet = $"{secilenIs.HastaAdi} — {secilenIs.IsTuru}";
            if (!string.IsNullOrWhiteSpace(secilenIs.IsNumarasi))
            {
                ozet = $"{secilenIs.IsNumarasi} · {ozet}";
            }

            if (MessageBox.Show(
                    $"Bu iş kaydı silinecek:\n\n{ozet}\n\nDevam edilsin mi?",
                    "İş sil",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            (bool basarili, string mesaj) = VeriDeposu.IsSil(secilenIs);
            MessageBox.Show(
                mesaj,
                basarili ? "Başarılı" : "Silinemedi",
                MessageBoxButtons.OK,
                basarili ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (basarili)
            {
                IsleriYukle();
            }
        }

        private void IsleriYukle()
        {
            IEnumerable<Is> filtrelenmisIsler = VeriDeposu.Isler;

            if (cmbDoktor.SelectedItem is Doctor doktor)
            {
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi =>
                    ReferenceEquals(isKaydi.Doktor, doktor));
            }

            if (cmbDurumFiltresi.SelectedItem is string durum && durum != "Tümü")
            {
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi => isKaydi.Durum == durum);
            }

            if (cmbRptFiltresi.SelectedItem is string rptFiltresi)
            {
                if (rptFiltresi == "RPT olan")
                {
                    filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi => isKaydi.RptMi);
                }
                else if (rptFiltresi == "RPT olmayan")
                {
                    filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi => !isKaydi.RptMi);
                }
            }

            if (chkTeslimTarihi.Checked)
            {
                DateTime baslangic = dtpTeslimBaslangic.Value.Date;
                DateTime bitis = dtpTeslimBitis.Value.Date;
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi =>
                    isKaydi.TeslimTarihi.Date >= baslangic && isKaydi.TeslimTarihi.Date <= bitis);
            }

            if (chkAlinmaTarihi.Checked)
            {
                DateTime baslangic = dtpAlinmaBaslangic.Value.Date;
                DateTime bitis = dtpAlinmaBitis.Value.Date;
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi =>
                    isKaydi.KayitTarihi.Date >= baslangic && isKaydi.KayitTarihi.Date <= bitis);
            }

            string aramaMetni = txtHastaAra.Text.Trim();

            if (!string.IsNullOrEmpty(aramaMetni))
            {
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi =>
                    isKaydi.HastaAdi.Contains(aramaMetni, StringComparison.CurrentCultureIgnoreCase));
            }

            if (_ozetFiltresi is IsListesiOzetFiltresi.BugunTeslim or IsListesiOzetFiltresi.Geciken)
            {
                filtrelenmisIsler = filtrelenmisIsler.Where(isKaydi => isKaydi.Durum != "Teslim edildi");
            }

            dgvIsler.DataSource = new BindingList<Is>(filtrelenmisIsler.ToList());
        }

        private void OzetFiltresiniUygula()
        {
            switch (_ozetFiltresi)
            {
                case IsListesiOzetFiltresi.BugunTeslim:
                    chkTeslimTarihi.Checked = true;
                    dtpTeslimBaslangic.Value = DateTime.Today;
                    dtpTeslimBitis.Value = DateTime.Today;
                    break;
                case IsListesiOzetFiltresi.Geciken:
                    chkTeslimTarihi.Checked = true;
                    dtpTeslimBaslangic.Value = DateTime.Today.AddYears(-10);
                    dtpTeslimBitis.Value = DateTime.Today.AddDays(-1);
                    break;
                case IsListesiOzetFiltresi.Uretimde:
                    cmbDurumFiltresi.SelectedItem = "Üretimde";
                    break;
                case IsListesiOzetFiltresi.TeslimEdilen:
                    cmbDurumFiltresi.SelectedItem = "Teslim edildi";
                    break;
            }
        }

        private void FiltreleriYukle()
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Items.Add("Tümü");

            foreach (Doctor doktor in VeriDeposu.Doktorlar)
            {
                cmbDoktor.Items.Add(doktor);
            }

            cmbDoktor.SelectedIndex = 0;
            cmbDurumFiltresi.SelectedIndex = 0;
            cmbRptFiltresi.SelectedIndex = 0;

            ArayuzTema.ComboboxAramaEtkinlestir(cmbDoktor);
        }

        private void FiltreDegisti(object sender, EventArgs e)
        {
            _ozetFiltresi = IsListesiOzetFiltresi.Yok;
            IsleriYukle();
        }

        private void chkTeslimTarihi_CheckedChanged(object sender, EventArgs e)
        {
            _ozetFiltresi = IsListesiOzetFiltresi.Yok;
            TarihKontrolleriniAyarla();
            IsleriYukle();
        }

        private void chkAlinmaTarihi_CheckedChanged(object sender, EventArgs e)
        {
            _ozetFiltresi = IsListesiOzetFiltresi.Yok;
            TarihKontrolleriniAyarla();
            IsleriYukle();
        }

        private void TarihKontrolleriniAyarla()
        {
            dtpTeslimBaslangic.Enabled = chkTeslimTarihi.Checked;
            dtpTeslimBitis.Enabled = chkTeslimTarihi.Checked;
            dtpAlinmaBaslangic.Enabled = chkAlinmaTarihi.Checked;
            dtpAlinmaBitis.Enabled = chkAlinmaTarihi.Checked;
        }
    }
}
