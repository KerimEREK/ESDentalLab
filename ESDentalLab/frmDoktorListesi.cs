using System.ComponentModel;

namespace ESDentalLab
{
    public partial class frmDoktorListesi : Form
    {
        public frmDoktorListesi()
        {
            InitializeComponent();
            Controls.Remove(lblBaslik);
            ArayuzTema.Uygula(this, "Doktor Listesi", "Doktor bilgilerini yönetin ve bakiye durumlarını görüntüleyin");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgvDoktorlar,
                altKontroller: [btnDuzenle, btnKaldir, btnAktiflestir, chkPasifleriGoster],
                altYukseklik: 48);

            bool silme = VeriDeposu.YetkiVarMi(KullaniciYetki.Silme);
            btnKaldir.Visible = silme;
            btnAktiflestir.Visible = silme;
        }

        private void frmDoktorListesi_Load(object sender, EventArgs e)
        {
            DoktorlariYukle();
        }

        private void chkPasifleriGoster_CheckedChanged(object sender, EventArgs e)
        {
            DoktorlariYukle();
        }

        private void dgvDoktorlar_SelectionChanged(object sender, EventArgs e)
        {
            ButonlariGuncelle();
        }

        private void dgvDoktorlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DoktorDuzenle();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            DoktorDuzenle();
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.Silme))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor kaldırma");
                return;
            }

            if (dgvDoktorlar.CurrentRow?.DataBoundItem is not Doctor secilenDoktor)
            {
                MessageBox.Show("Kaldırmak için listeden bir doktor seçin.", "Doktor seçilmedi");
                return;
            }

            if (!secilenDoktor.Aktif)
            {
                MessageBox.Show("Bu doktor zaten pasif durumda.", "Bilgi");
                return;
            }

            bool kayitVar = VeriDeposu.DoktorunKaydiVarMi(secilenDoktor);
            string onayMesaji = kayitVar
                ? $"{secilenDoktor.AdSoyad} adlı doktora ait iş veya ödeme kayıtları var.\n\nDoktor pasif yapılacak, geçmiş kayıtlar korunacak. Devam edilsin mi?"
                : $"{secilenDoktor.AdSoyad} adlı doktorun kaydı bulunmuyor.\n\nDoktor kalıcı olarak silinecek. Devam edilsin mi?";

            if (MessageBox.Show(onayMesaji, "Doktor kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            (_, string mesaj) = VeriDeposu.DoktorKaldir(secilenDoktor);
            MessageBox.Show(mesaj, "Başarılı");
            DoktorlariYukle();
        }

        private void btnAktiflestir_Click(object sender, EventArgs e)
        {
            if (!VeriDeposu.YetkiVarMi(KullaniciYetki.Silme))
            {
                VeriDeposu.YetkiYokUyarisi("Doktor aktifleştirme");
                return;
            }

            if (dgvDoktorlar.CurrentRow?.DataBoundItem is not Doctor secilenDoktor)
            {
                MessageBox.Show("Aktifleştirmek için listeden bir doktor seçin.", "Doktor seçilmedi");
                return;
            }

            if (secilenDoktor.Aktif)
            {
                MessageBox.Show("Bu doktor zaten aktif durumda.", "Bilgi");
                return;
            }

            VeriDeposu.DoktorAktiflestir(secilenDoktor);
            MessageBox.Show($"{secilenDoktor.AdSoyad} tekrar aktif yapıldı.", "Başarılı");
            DoktorlariYukle();
        }

        private void DoktorDuzenle()
        {
            if (dgvDoktorlar.CurrentRow?.DataBoundItem is not Doctor secilenDoktor)
            {
                MessageBox.Show("Düzenlemek için listeden bir doktor seçin.", "Doktor seçilmedi");
                return;
            }

            using frmDoktorEkle duzenleFormu = new frmDoktorEkle(secilenDoktor);
            if (duzenleFormu.ShowDialog() == DialogResult.OK)
            {
                DoktorlariYukle();
            }
        }

        private void DoktorlariYukle()
        {
            IEnumerable<Doctor> doktorlar = VeriDeposu.Doktorlar;

            if (!chkPasifleriGoster.Checked)
            {
                doktorlar = doktorlar.Where(doktor => doktor.Aktif);
            }

            dgvDoktorlar.DataSource = new BindingList<Doctor>(doktorlar.ToList());
            TabloyuAyarla();
            ButonlariGuncelle();
        }

        private void TabloyuAyarla()
        {
            if (dgvDoktorlar.Columns["Aktif"] is DataGridViewColumn aktifKolon)
            {
                aktifKolon.Visible = false;
            }

            if (dgvDoktorlar.Columns["Durum"] is DataGridViewColumn durumKolon)
            {
                durumKolon.DisplayIndex = 0;
                durumKolon.HeaderText = "Durum";
            }

            if (dgvDoktorlar.Columns["AdSoyad"] is DataGridViewColumn adKolon)
            {
                adKolon.HeaderText = "Ad soyad";
            }

            if (dgvDoktorlar.Columns["Telefon"] is DataGridViewColumn telefonKolon)
            {
                telefonKolon.HeaderText = "Telefon";
            }

            if (dgvDoktorlar.Columns["Klinik"] is DataGridViewColumn klinikKolon)
            {
                klinikKolon.HeaderText = "Klinik";
            }

            if (dgvDoktorlar.Columns["ToplamIsTutari"] is DataGridViewColumn isTutariKolon)
            {
                isTutariKolon.HeaderText = "İş tutarı";
                isTutariKolon.DefaultCellStyle.Format = "N2";
            }

            if (dgvDoktorlar.Columns["ToplamOdeme"] is DataGridViewColumn odemeKolon)
            {
                odemeKolon.HeaderText = "Ödeme";
                odemeKolon.DefaultCellStyle.Format = "N2";
            }

            if (dgvDoktorlar.Columns["Bakiye"] is DataGridViewColumn bakiyeKolon)
            {
                bakiyeKolon.HeaderText = "Bakiye";
                bakiyeKolon.DefaultCellStyle.Format = "N2";
            }

            foreach (DataGridViewRow satir in dgvDoktorlar.Rows)
            {
                if (satir.DataBoundItem is Doctor doktor && !doktor.Aktif)
                {
                    satir.DefaultCellStyle.ForeColor = Color.FromArgb(130, 145, 155);
                }
            }
        }

        private void ButonlariGuncelle()
        {
            bool secili = dgvDoktorlar.CurrentRow?.DataBoundItem is Doctor;
            btnDuzenle.Enabled = secili;

            if (dgvDoktorlar.CurrentRow?.DataBoundItem is not Doctor secilenDoktor)
            {
                btnKaldir.Enabled = false;
                btnAktiflestir.Enabled = false;
                return;
            }

            btnKaldir.Enabled = secilenDoktor.Aktif;
            btnAktiflestir.Enabled = !secilenDoktor.Aktif;
        }
    }
}
