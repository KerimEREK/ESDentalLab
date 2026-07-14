using System.Security.Cryptography;
using System.Text;

namespace ESDentalLab
{
    public enum KullaniciRol
    {
        Admin,
        Personel
    }

    public class Kullanici
    {
        public string KullaniciAdi { get; set; } = "";
        public string SifreHash { get; set; } = "";
        public string AdSoyad { get; set; } = "";
        public KullaniciRol Rol { get; set; } = KullaniciRol.Personel;
        public bool Aktif { get; set; } = true;

        public string RolMetni => Rol == KullaniciRol.Admin ? "Admin" : "Personel";
        public string Durum => Aktif ? "Aktif" : "Pasif";

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
