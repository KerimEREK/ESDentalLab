namespace ESDentalLab
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            VeriDeposu.VarsayilanKasalarıHazirla();
            VeriDeposu.VarsayilanKullaniciyiHazirla();
            DemoVeri.Yukle();

            while (true)
            {
                using frmGiris giris = new frmGiris();
                if (giris.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Application.Run(new frmAnaMenu());

                // Hâlâ girişliyse pencere kapatılmıştır → uygulamadan çık
                if (VeriDeposu.GirisYapanKullanici is not null)
                {
                    return;
                }

                // Çıkış yapılmış → tekrar giriş ekranı
            }
        }
    }
}
