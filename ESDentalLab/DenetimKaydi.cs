namespace ESDentalLab
{
    public class DenetimKaydi
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string KullaniciAdi { get; set; } = "";
        public string AdSoyad { get; set; } = "";
        public string Kategori { get; set; } = "";
        public string Islem { get; set; } = "";
        public string Detay { get; set; } = "";
    }

    public static class DenetimKategori
    {
        public const string Oturum = "Oturum";
        public const string Is = "İş";
        public const string Odeme = "Ödeme";
        public const string Doktor = "Doktor";
        public const string Kasa = "Kasa";
        public const string Kullanici = "Kullanıcı";
        public const string Sistem = "Sistem";
    }
}
