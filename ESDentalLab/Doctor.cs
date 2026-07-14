using System;
using System.Collections.Generic;
using System.Text;

namespace ESDentalLab
{
    public class Doctor
    {
        public string AdSoyad { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Klinik { get; set; } = "";
        public bool Aktif { get; set; } = true;

        public string Durum => Aktif ? "Aktif" : "Pasif";

        public decimal ToplamIsTutari => VeriDeposu.Isler
            .Where(isKaydi => ReferenceEquals(isKaydi.Doktor, this) && !isKaydi.RptMi)
            .Sum(isKaydi => isKaydi.Fiyat);

        public decimal ToplamOdeme => VeriDeposu.Odemeler
            .Where(odeme => !odeme.IptalEdildi && ReferenceEquals(odeme.Doktor, this))
            .Sum(odeme => odeme.Tutar);

        public decimal Bakiye => ToplamIsTutari - ToplamOdeme;

        public override string ToString()
        {
            return Aktif ? AdSoyad : $"{AdSoyad} (Pasif)";
        }
    }



}
