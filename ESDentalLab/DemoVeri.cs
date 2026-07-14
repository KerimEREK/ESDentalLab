namespace ESDentalLab
{
    public static class DemoVeri
    {
        public static void Yukle()
        {
            VeriDeposu.VarsayilanKasalarıHazirla();

            if (VeriDeposu.Doktorlar.Count > 0 || VeriDeposu.Isler.Count > 0)
            {
                return;
            }

            if (!VeriDeposu.Kasalar.Any(kasa => kasa.Tur == KasaTuru.Banka))
            {
                VeriDeposu.Kasalar.Add(new Kasa
                {
                    Ad = "Ziraat Bankası",
                    Tur = KasaTuru.Banka,
                    Aciklama = "Demo banka hesabı",
                    Aktif = true
                });
            }

            Doctor doktor1 = new Doctor
            {
                AdSoyad = "Dr. Ayşe Yılmaz",
                Telefon = "0532 111 22 33",
                Klinik = "Yılmaz Diş Kliniği",
                Aktif = true
            };

            Doctor doktor2 = new Doctor
            {
                AdSoyad = "Dr. Mehmet Kaya",
                Telefon = "0533 444 55 66",
                Klinik = "Kaya Oral Sağlık",
                Aktif = true
            };

            Doctor doktor3 = new Doctor
            {
                AdSoyad = "Dr. Elif Demir",
                Telefon = "0535 777 88 99",
                Klinik = "Demir Dental",
                Aktif = true
            };

            VeriDeposu.Doktorlar.AddRange([doktor1, doktor2, doktor3]);

            DateTime bugun = DateTime.Today;

            VeriDeposu.Isler.AddRange(
            [
                new Is
                {
                    IsNumarasi = $"IS-{bugun:yyyyMMdd}-0001",
                    KayitTarihi = bugun.AddDays(-3).AddHours(10),
                    Doktor = doktor1,
                    HastaAdi = "Ali Veli",
                    IsTuru = "Zirkonyum",
                    DisNumarasi = "11-21",
                    TeslimTarihi = bugun,
                    Durum = "Teslime hazır",
                    Aciklama = "Anterior zirkonyum köprü",
                    Fiyat = 8500,
                    RptMi = false
                },
                new Is
                {
                    IsNumarasi = $"IS-{bugun:yyyyMMdd}-0002",
                    KayitTarihi = bugun.AddDays(-5).AddHours(14),
                    Doktor = doktor1,
                    HastaAdi = "Fatma Çelik",
                    IsTuru = "Porselen",
                    DisNumarasi = "36",
                    TeslimTarihi = bugun.AddDays(-2),
                    Durum = "Üretimde",
                    Aciklama = "Geciken porselen kron",
                    Fiyat = 4200,
                    RptMi = false
                },
                new Is
                {
                    IsNumarasi = $"IS-{bugun:yyyyMMdd}-0003",
                    KayitTarihi = bugun.AddDays(-1).AddHours(9),
                    Doktor = doktor2,
                    HastaAdi = "Can Öztürk",
                    IsTuru = "İmplant üstü",
                    DisNumarasi = "46",
                    TeslimTarihi = bugun.AddDays(4),
                    Durum = "Üretimde",
                    Aciklama = "Implant üstü abutment",
                    Fiyat = 6500,
                    RptMi = false
                },
                new Is
                {
                    IsNumarasi = $"IS-{bugun:yyyyMMdd}-0004",
                    KayitTarihi = bugun.AddHours(11),
                    Doktor = doktor2,
                    HastaAdi = "Zeynep Arslan",
                    IsTuru = "Hareketli protez",
                    DisNumarasi = "Üst çene",
                    TeslimTarihi = bugun.AddDays(10),
                    Durum = "Alındı",
                    Aciklama = "Tam protez",
                    Fiyat = 12000,
                    RptMi = false
                },
                new Is
                {
                    IsNumarasi = $"IS-{bugun:yyyyMMdd}-0005",
                    KayitTarihi = bugun.AddDays(-2).AddHours(16),
                    Doktor = doktor3,
                    HastaAdi = "Hasan Şahin",
                    IsTuru = "Damak",
                    DisNumarasi = "-",
                    TeslimTarihi = bugun,
                    Durum = "Kontrolde",
                    Aciklama = "RPT iş - bakiyeye dahil değil",
                    Fiyat = 0,
                    RptMi = true
                }
            ]);

            Kasa banka = VeriDeposu.Kasalar.First(kasa => kasa.Tur == KasaTuru.Banka);
            Is? kismiIs = VeriDeposu.Isler.FirstOrDefault(i =>
                ReferenceEquals(i.Doktor, doktor1) && !i.RptMi);
            Guid tahsilatNo = Guid.NewGuid();
            Odeme demoOdeme = new Odeme
            {
                TahsilatNo = tahsilatNo,
                Doktor = doktor1,
                IliskiliIs = kismiIs,
                Tarih = bugun.AddDays(-1),
                Tutar = 3000,
                OdemeYontemi = "Havale / EFT",
                Aciklama = "Kısmi ödeme",
                Kasa = banka
            };
            VeriDeposu.Odemeler.Add(demoOdeme);
            VeriDeposu.KasaGirisiEkle(banka, 3000, "Dr. Ayşe Yılmaz - kısmi ödeme", bugun.AddDays(-1), demoOdeme, tahsilatNo);

            VeriDeposu.DenetimKayitlari.Add(new DenetimKaydi
            {
                Tarih = bugun.AddHours(-2),
                KullaniciAdi = "sistem",
                AdSoyad = "Sistem",
                Kategori = DenetimKategori.Sistem,
                Islem = "Demo veri yüklendi",
                Detay = $"{VeriDeposu.Doktorlar.Count} doktor, {VeriDeposu.Isler.Count} iş"
            });
        }
    }
}
