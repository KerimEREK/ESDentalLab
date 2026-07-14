using System.Security.Cryptography;
using System.Text;

namespace ESDentalLab
{
    public enum KullaniciRol
    {
        Admin,
        Personel
    }

    [Flags]
    public enum KullaniciYetki
    {
        Yok = 0,
        IsIslemleri = 1 << 0,       // iş ekle / düzenle / liste (+ doktora işlemleri)
        OdemeAl = 1 << 1,
        OdemeIptal = 1 << 2,
        KasaGoruntule = 1 << 3,
        Silme = 1 << 4,             // iş sil, doktor kaldır/pasif
        Denetim = 1 << 5,
        KullaniciYonetimi = 1 << 6,

        Hepsi = IsIslemleri | OdemeAl | OdemeIptal | KasaGoruntule | Silme | Denetim | KullaniciYonetimi
    }

    public class Kullanici
    {
        public string KullaniciAdi { get; set; } = "";
        public string SifreHash { get; set; } = "";
        public string AdSoyad { get; set; } = "";
        public KullaniciRol Rol { get; set; } = KullaniciRol.Personel;
        public KullaniciYetki Yetkiler { get; set; } = KullaniciYetki.IsIslemleri;
        public bool Aktif { get; set; } = true;

        public string RolMetni => Rol == KullaniciRol.Admin ? "Admin" : "Personel";
        public string Durum => Aktif ? "Aktif" : "Pasif";

        public string YetkiOzeti
        {
            get
            {
                if (Rol == KullaniciRol.Admin)
                {
                    return "Tümü";
                }

                List<string> parcalar = new();
                if (YetkiVarMi(KullaniciYetki.IsIslemleri)) parcalar.Add("İş");
                if (YetkiVarMi(KullaniciYetki.OdemeAl)) parcalar.Add("Ödeme");
                if (YetkiVarMi(KullaniciYetki.OdemeIptal)) parcalar.Add("İptal");
                if (YetkiVarMi(KullaniciYetki.KasaGoruntule)) parcalar.Add("Kasa");
                if (YetkiVarMi(KullaniciYetki.Silme)) parcalar.Add("Silme");
                if (YetkiVarMi(KullaniciYetki.Denetim)) parcalar.Add("Denetim");
                if (YetkiVarMi(KullaniciYetki.KullaniciYonetimi)) parcalar.Add("Kullanıcı");
                return parcalar.Count == 0 ? "Yok" : string.Join(", ", parcalar);
            }
        }

        public bool YetkiVarMi(KullaniciYetki yetki)
        {
            if (!Aktif)
            {
                return false;
            }

            if (Rol == KullaniciRol.Admin)
            {
                return true;
            }

            return (Yetkiler & yetki) == yetki;
        }

        public static KullaniciYetki PersonelVarsayilanYetkiler => KullaniciYetki.IsIslemleri;

        public override string ToString() => KullaniciAdi;
    }

    public static class SifreYardimcisi
    {
        private const int Iterasyon = 100_000;

        public static string HashOlustur(string sifre)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(sifre),
                salt,
                Iterasyon,
                HashAlgorithmName.SHA256,
                32);

            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public static bool Dogrula(string sifre, string sakliHash)
        {
            string[] parcalar = sakliHash.Split('.', 2);
            if (parcalar.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(parcalar[0]);
            byte[] beklenen = Convert.FromBase64String(parcalar[1]);
            byte[] gelen = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(sifre),
                salt,
                Iterasyon,
                HashAlgorithmName.SHA256,
                32);

            return CryptographicOperations.FixedTimeEquals(beklenen, gelen);
        }
    }
}
