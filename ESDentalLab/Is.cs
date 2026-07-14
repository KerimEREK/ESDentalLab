using System;
using System.Collections.Generic;
using System.Text;

namespace ESDentalLab
{
    public class Is
    {
        public string IsNumarasi { get; set; } = "";
        public DateTime KayitTarihi { get; set; }
        public Doctor Doktor { get; set; } = new Doctor();
        public string HastaAdi { get; set; } = "";
        public string IsTuru { get; set; } = "";
        public string DisNumarasi { get; set; } = "";
        public DateTime TeslimTarihi { get; set; }
        public string Durum { get; set; } = "Alındı";
        public string Aciklama { get; set; } = "";
        public decimal Fiyat { get; set; }
        public bool RptMi { get; set; }

        public decimal OdendiTutari => VeriDeposu.Odemeler
            .Where(odeme => !odeme.IptalEdildi && ReferenceEquals(odeme.IliskiliIs, this))
            .Sum(odeme => odeme.Tutar);

        public decimal KalanTutar => RptMi ? 0 : Math.Max(0, Fiyat - OdendiTutari);

        /// <summary>
        /// Doktor ödemesi (iş seçimli veya FIFO) sonrası liste durumu.
        /// </summary>
        public string OdemeDurumu
        {
            get
            {
                if (RptMi)
                {
                    return "—";
                }

                if (Fiyat <= 0)
                {
                    return "—";
                }

                if (KalanTutar <= 0)
                {
                    return "Ödendi";
                }

                if (OdendiTutari > 0)
                {
                    return "Kısmi";
                }

                return "Ödenmedi";
            }
        }
    }
}
