namespace ESDentalLab
{
    public enum KasaTuru
    {
        Nakit,
        Banka
    }

    public class Kasa
    {
        public string Ad { get; set; } = "";
        public KasaTuru Tur { get; set; } = KasaTuru.Nakit;
        public string Aciklama { get; set; } = "";
        public bool Aktif { get; set; } = true;

        public string TurMetni => Tur == KasaTuru.Nakit ? "Nakit" : "Banka";

        public decimal GirisToplami => VeriDeposu.KasaHareketleri
            .Where(hareket => !hareket.IptalEdildi && ReferenceEquals(hareket.Kasa, this) && hareket.Yon == KasaYon.Giris)
            .Sum(hareket => hareket.Tutar);

        public decimal CikisToplami => VeriDeposu.KasaHareketleri
            .Where(hareket => !hareket.IptalEdildi && ReferenceEquals(hareket.Kasa, this) && hareket.Yon == KasaYon.Cikis)
            .Sum(hareket => hareket.Tutar);

        public decimal Bakiye => GirisToplami - CikisToplami;

        public override string ToString()
        {
            return $"{Ad} ({Bakiye:N2} TL)";
        }
    }
}
