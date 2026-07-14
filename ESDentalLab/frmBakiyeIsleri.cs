using System.ComponentModel;

namespace ESDentalLab
{
    public partial class frmBakiyeIsleri : Form
    {
        public frmBakiyeIsleri()
        {
            InitializeComponent();
            ArayuzTema.Uygula(this, "Bakiye İşleri", "Tüm işleri görüntüleyin ve seçili iş için ödeme ekleyin");
            ArayuzTema.ListeFormunuEsnekYap(
                this,
                dgvIsler,
                altKontroller: [btnYenile, btnOdemeEkle, lblOzet],
                altYukseklik: 48);
        }

        private void frmBakiyeIsleri_Load(object sender, EventArgs e)
        {
            IsleriYukle();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            IsleriYukle();
        }

        private void btnOdemeEkle_Click(object sender, EventArgs e)
        {
            OdemeFormunuAc();
        }

        private void dgvIsler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OdemeFormunuAc();
            }
        }

        private void dgvIsler_SelectionChanged(object sender, EventArgs e)
        {
            btnOdemeEkle.Enabled = dgvIsler.CurrentRow?.DataBoundItem is Is;
        }

        private void OdemeFormunuAc()
        {
            if (dgvIsler.CurrentRow?.DataBoundItem is not Is secilenIs)
            {
                MessageBox.Show("Ödeme eklemek için listeden bir iş seçin.", "İş seçilmedi");
                return;
            }

            if (secilenIs.RptMi)
            {
                MessageBox.Show("RPT işler bakiyeye dahil edilmez. Yine de ödeme eklemek istiyorsanız Doktor Ödemesi menüsünü kullanın.",
                    "RPT iş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (secilenIs.Fiyat <= 0)
            {
                MessageBox.Show("Bu işin fiyatı girilmemiş. Önce iş fiyatını güncelleyin.", "Fiyat yok");
                return;
            }

            using frmOdemeEkle odemeFormu = new frmOdemeEkle(secilenIs);

            if (odemeFormu.ShowDialog() == DialogResult.OK)
            {
                IsleriYukle();
            }
        }

        private void IsleriYukle()
        {
            List<Is> isler = VeriDeposu.Isler
                .OrderByDescending(isKaydi => isKaydi.KayitTarihi)
                .ToList();

            dgvIsler.DataSource = new BindingList<Is>(isler);

            decimal toplamFiyat = isler.Where(isKaydi => !isKaydi.RptMi).Sum(isKaydi => isKaydi.Fiyat);
            decimal toplamBakiye = VeriDeposu.Doktorlar.Sum(doktor => doktor.Bakiye);
            lblOzet.Text = $"Toplam iş fiyatı: {toplamFiyat:N2} TL    |    Güncel bakiye: {toplamBakiye:N2} TL";
        }
    }
}
