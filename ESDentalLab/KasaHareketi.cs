namespace ESDentalLab
{
    public enum KasaYon
    {
        Giris,
        Cikis
    }

    public class KasaHareketi
    {
        public DateTime Tarih { get; set; }
        public Kasa Kasa { get; set; } = new Kasa();
        public KasaYon Yon { get; set; } = KasaYon.Giris;
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; } = "";
        public Odeme? IliskiliOdeme { get; set; }
        public Guid TahsilatNo { get; set; }
        public bool IptalEdildi { get; set; }

        public string YonMetni => IptalEdildi ? "İptal" : (Yon == KasaYon.Giris ? "Giriş" : "Çıkış");
        public string KasaAdi => Kasa.Ad;
        public decimal GirisTutari => Yon == KasaYon.Giris ? Tutar : 0;
        public decimal CikisTutari => Yon == KasaYon.Cikis ? Tutar : 0;
    }
}
