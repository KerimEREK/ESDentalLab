namespace ESDentalLab
{
    public static class VeriDeposu
    {
        public static List<Doctor> Doktorlar = new List<Doctor>();
        public static List<Is> Isler = new List<Is>();
        public static List<Odeme> Odemeler = new List<Odeme>();
        public static List<Kasa> Kasalar = new List<Kasa>();
        public static List<KasaHareketi> KasaHareketleri = new List<KasaHareketi>();
        public static List<Kullanici> Kullanicilar = new List<Kullanici>();
        public static List<DenetimKaydi> DenetimKayitlari = new List<DenetimKaydi>();
        public static Kullanici? GirisYapanKullanici { get; private set; }

        public static void DenetimEkle(string kategori, string islem, string detay = "")
        {
            Kullanici? k = GirisYapanKullanici;
            DenetimKayitlari.Add(new DenetimKaydi
            {
                Tarih = DateTime.Now,
                KullaniciAdi = k?.KullaniciAdi ?? "sistem",
                AdSoyad = k?.AdSoyad ?? "Sistem",
                Kategori = kategori,
                Islem = islem,
                Detay = detay.Trim()
            });
        }

        public static IEnumerable<DenetimKaydi> DenetimleriListele(
            string? kategori = null,
            string? arama = null,
            DateTime? baslangic = null,
            DateTime? bitis = null)
        {
            IEnumerable<DenetimKaydi> sorgu = DenetimKayitlari;

            if (!string.IsNullOrWhiteSpace(kategori) && kategori != "Tümü")
            {
                sorgu = sorgu.Where(k => k.Kategori == kategori);
            }

            if (baslangic is not null)
            {
                DateTime b = baslangic.Value.Date;
                sorgu = sorgu.Where(k => k.Tarih.Date >= b);
            }

            if (bitis is not null)
            {
                DateTime s = bitis.Value.Date;
                sorgu = sorgu.Where(k => k.Tarih.Date <= s);
            }

            if (!string.IsNullOrWhiteSpace(arama))
            {
                string a = arama.Trim();
                sorgu = sorgu.Where(k =>
                    k.Islem.Contains(a, StringComparison.CurrentCultureIgnoreCase) ||
                    k.Detay.Contains(a, StringComparison.CurrentCultureIgnoreCase) ||
                    k.KullaniciAdi.Contains(a, StringComparison.CurrentCultureIgnoreCase) ||
                    k.AdSoyad.Contains(a, StringComparison.CurrentCultureIgnoreCase) ||
                    k.Kategori.Contains(a, StringComparison.CurrentCultureIgnoreCase));
            }

            return sorgu.OrderByDescending(k => k.Tarih);
        }

        public static List<string> IsTurleri = new List<string>
        {
            "Zirkonyum",
            "Porselen",
            "İmplant üstü",
            "Hareketli protez",
            "Damak",
            "Diğer"
        };

        public static (bool Basarili, string Mesaj) IsTuruEkle(string tur)
        {
            tur = tur.Trim();
            if (string.IsNullOrWhiteSpace(tur))
            {
                return (false, "İş türü adı zorunludur.");
            }

            if (IsTurleri.Any(mevcut =>
                string.Equals(mevcut, tur, StringComparison.CurrentCultureIgnoreCase)))
            {
                return (false, "Bu iş türü zaten listede.");
            }

            IsTurleri.Add(tur);
            DenetimEkle(DenetimKategori.Is, "İş türü eklendi", tur);
            return (true, $"\"{tur}\" iş türü eklendi.");
        }

        public static (bool Basarili, string Mesaj) IsTuruSil(string tur)
        {
            tur = tur.Trim();
            if (string.IsNullOrWhiteSpace(tur))
            {
                return (false, "Silinecek iş türünü seçin veya yazın.");
            }

            string? mevcut = IsTurleri.FirstOrDefault(t =>
                string.Equals(t, tur, StringComparison.CurrentCultureIgnoreCase));
            if (mevcut is null)
            {
                return (false, "Bu iş türü listede yok.");
            }

            bool kullanimda = Isler.Any(isKaydi =>
                string.Equals(isKaydi.IsTuru, mevcut, StringComparison.CurrentCultureIgnoreCase));
            if (kullanimda)
            {
                return (false, $"\"{mevcut}\" türü mevcut iş kayıtlarında kullanıldığı için silinemez.");
            }

            IsTurleri.Remove(mevcut);
            DenetimEkle(DenetimKategori.Is, "İş türü silindi", mevcut);
            return (true, $"\"{mevcut}\" iş türü silindi.");
        }

        public static IEnumerable<Doctor> AktifDoktorlar =>
            Doktorlar.Where(doktor => doktor.Aktif);

        public static IEnumerable<Kasa> AktifKasalar =>
            Kasalar.Where(kasa => kasa.Aktif);

        public static decimal ToplamKasaBakiyesi => AktifKasalar.Sum(kasa => kasa.Bakiye);

        public static Kasa? NakitKasasi =>
            Kasalar.FirstOrDefault(kasa => kasa.Tur == KasaTuru.Nakit && kasa.Aktif);

        public static void VarsayilanKasalarıHazirla()
        {
            if (!Kasalar.Any(kasa => kasa.Tur == KasaTuru.Nakit))
            {
                Kasalar.Add(new Kasa
                {
                    Ad = "Nakit Kasası",
                    Tur = KasaTuru.Nakit,
                    Aciklama = "Laboratuvar nakit kasası",
                    Aktif = true
                });
            }
        }

        public static void VarsayilanKullaniciyiHazirla()
        {
            if (Kullanicilar.Count > 0)
            {
                return;
            }

            Kullanicilar.Add(new Kullanici
            {
                KullaniciAdi = "admin",
                AdSoyad = "Sistem Yöneticisi",
                Rol = KullaniciRol.Admin,
                Aktif = true,
                SifreHash = SifreYardimcisi.HashOlustur("admin")
            });
        }

        public static bool AdminMi =>
            GirisYapanKullanici?.Rol == KullaniciRol.Admin && GirisYapanKullanici.Aktif;

        public static (bool Basarili, string Mesaj) GirisYap(string kullaniciAdi, string sifre)
        {
            kullaniciAdi = kullaniciAdi.Trim();
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                return (false, "Kullanıcı adı ve şifre zorunludur.");
            }

            Kullanici? kullanici = Kullanicilar.FirstOrDefault(k =>
                string.Equals(k.KullaniciAdi, kullaniciAdi, StringComparison.OrdinalIgnoreCase));

            if (kullanici is null || !SifreYardimcisi.Dogrula(sifre, kullanici.SifreHash))
            {
                DenetimKayitlari.Add(new DenetimKaydi
                {
                    Tarih = DateTime.Now,
                    KullaniciAdi = string.IsNullOrWhiteSpace(kullaniciAdi) ? "-" : kullaniciAdi,
                    AdSoyad = "",
                    Kategori = DenetimKategori.Oturum,
                    Islem = "Başarısız giriş",
                    Detay = "Hatalı kullanıcı adı veya şifre"
                });
                return (false, "Kullanıcı adı veya şifre hatalı.");
            }

            if (!kullanici.Aktif)
            {
                DenetimKayitlari.Add(new DenetimKaydi
                {
                    Tarih = DateTime.Now,
                    KullaniciAdi = kullanici.KullaniciAdi,
                    AdSoyad = kullanici.AdSoyad,
                    Kategori = DenetimKategori.Oturum,
                    Islem = "Başarısız giriş",
                    Detay = "Pasif kullanıcı"
                });
                return (false, "Bu kullanıcı pasif. Giriş yapılamaz.");
            }

            GirisYapanKullanici = kullanici;
            DenetimEkle(DenetimKategori.Oturum, "Giriş yapıldı", $"{kullanici.AdSoyad} ({kullanici.RolMetni})");
            return (true, "Giriş başarılı.");
        }

        public static void CikisYap()
        {
            if (GirisYapanKullanici is not null)
            {
                DenetimEkle(DenetimKategori.Oturum, "Çıkış yapıldı", GirisYapanKullanici.AdSoyad);
            }

            GirisYapanKullanici = null;
        }

        public static (bool Basarili, string Mesaj) KullaniciEkle(
            string kullaniciAdi,
            string sifre,
            string adSoyad,
            KullaniciRol rol)
        {
            kullaniciAdi = kullaniciAdi.Trim();
            adSoyad = adSoyad.Trim();

            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                return (false, "Kullanıcı adı zorunludur.");
            }

            if (string.IsNullOrWhiteSpace(sifre) || sifre.Length < 4)
            {
                return (false, "Şifre en az 4 karakter olmalıdır.");
            }

            if (Kullanicilar.Any(k =>
                string.Equals(k.KullaniciAdi, kullaniciAdi, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Bu kullanıcı adı zaten kayıtlı.");
            }

            Kullanicilar.Add(new Kullanici
            {
                KullaniciAdi = kullaniciAdi,
                AdSoyad = string.IsNullOrWhiteSpace(adSoyad) ? kullaniciAdi : adSoyad,
                Rol = rol,
                Aktif = true,
                SifreHash = SifreYardimcisi.HashOlustur(sifre)
            });

            DenetimEkle(DenetimKategori.Kullanici, "Kullanıcı eklendi",
                $"{kullaniciAdi} · {(string.IsNullOrWhiteSpace(adSoyad) ? kullaniciAdi : adSoyad)} · {rol}");
            return (true, "Kullanıcı eklendi.");
        }

        public static (bool Basarili, string Mesaj) KullaniciPasifYap(Kullanici kullanici)
        {
            if (GirisYapanKullanici is not null &&
                ReferenceEquals(GirisYapanKullanici, kullanici))
            {
                return (false, "Oturum açık olan kullanıcıyı pasif yapamazsınız.");
            }

            if (kullanici.Rol == KullaniciRol.Admin &&
                Kullanicilar.Count(k => k.Rol == KullaniciRol.Admin && k.Aktif) <= 1)
            {
                return (false, "En az bir aktif admin kullanıcı kalmalıdır.");
            }

            kullanici.Aktif = false;
            DenetimEkle(DenetimKategori.Kullanici, "Kullanıcı pasif yapıldı", kullanici.KullaniciAdi);
            return (true, "Kullanıcı pasif yapıldı.");
        }

        public static void KullaniciAktiflestir(Kullanici kullanici)
        {
            kullanici.Aktif = true;
            DenetimEkle(DenetimKategori.Kullanici, "Kullanıcı aktifleştirildi", kullanici.KullaniciAdi);
        }

        public static (bool Basarili, string Mesaj) KullaniciSifreDegistir(Kullanici kullanici, string yeniSifre)
        {
            if (string.IsNullOrWhiteSpace(yeniSifre) || yeniSifre.Length < 4)
            {
                return (false, "Şifre en az 4 karakter olmalıdır.");
            }

            kullanici.SifreHash = SifreYardimcisi.HashOlustur(yeniSifre);
            DenetimEkle(DenetimKategori.Kullanici, "Şifre değiştirildi", kullanici.KullaniciAdi);
            return (true, "Şifre güncellendi.");
        }

        public static bool DoktorunKaydiVarMi(Doctor doktor) =>
            Isler.Any(isKaydi => ReferenceEquals(isKaydi.Doktor, doktor)) ||
            Odemeler.Any(odeme => ReferenceEquals(odeme.Doktor, doktor));

        public static bool IsinOdemesiVarMi(Is isKaydi) =>
            Odemeler.Any(odeme => !odeme.IptalEdildi && ReferenceEquals(odeme.IliskiliIs, isKaydi));

        public static IEnumerable<Odeme> TahsilatSatirlari(Guid tahsilatNo) =>
            Odemeler.Where(odeme => odeme.TahsilatNo == tahsilatNo);

        public static TahsilatOzeti? TahsilatOzetiniAl(Guid tahsilatNo)
        {
            List<Odeme> satirlar = TahsilatSatirlari(tahsilatNo)
                .OrderBy(o => o.IliskiliIs?.KayitTarihi ?? o.Tarih)
                .ToList();

            if (satirlar.Count == 0)
            {
                return null;
            }

            Odeme ilk = satirlar[0];
            string dagitim = string.Join(" · ",
                satirlar.Select(o =>
                    o.IliskiliIs is null
                        ? $"{o.Tutar:N2} TL"
                        : $"{o.IliskiliIs.HastaAdi} ({o.Tutar:N2} TL)"));

            return new TahsilatOzeti
            {
                TahsilatNo = tahsilatNo,
                Doktor = ilk.Doktor,
                Tarih = ilk.Tarih,
                Tutar = satirlar.Sum(o => o.Tutar),
                OdemeYontemi = ilk.OdemeYontemi,
                Aciklama = ilk.IptalEdildi
                    ? $"İPTAL: {ilk.IptalNedeni}"
                    : (satirlar.Count == 1 ? ilk.Aciklama : $"{satirlar.Count} işe dağıtıldı"),
                KasaAdi = ilk.Kasa?.Ad ?? "",
                IptalEdildi = ilk.IptalEdildi,
                IsSayisi = satirlar.Count(o => o.IliskiliIs is not null),
                DagitimOzeti = dagitim,
                Satirlar = satirlar
            };
        }

        public static List<TahsilatOzeti> TahsilatlariListele(bool iptalleriGoster)
        {
            IEnumerable<IGrouping<Guid, Odeme>> gruplar = Odemeler.GroupBy(o => o.TahsilatNo);

            List<TahsilatOzeti> sonuc = new List<TahsilatOzeti>();
            foreach (IGrouping<Guid, Odeme> grup in gruplar)
            {
                TahsilatOzeti? ozet = TahsilatOzetiniAl(grup.Key);
                if (ozet is null)
                {
                    continue;
                }

                if (!iptalleriGoster && ozet.IptalEdildi)
                {
                    continue;
                }

                sonuc.Add(ozet);
            }

            return sonuc.OrderByDescending(o => o.Tarih).ToList();
        }

        public static (bool Basarili, string Mesaj) TahsilatIptalEt(Guid tahsilatNo, string neden)
        {
            neden = neden.Trim();
            if (string.IsNullOrWhiteSpace(neden))
            {
                return (false, "İptal gerekçesi zorunludur.");
            }

            List<Odeme> satirlar = TahsilatSatirlari(tahsilatNo).ToList();
            if (satirlar.Count == 0)
            {
                return (false, "Tahsilat bulunamadı.");
            }

            if (satirlar.Any(o => o.IptalEdildi))
            {
                return (false, "Bu tahsilat zaten iptal edilmiş.");
            }

            DateTime simdi = DateTime.Now;
            foreach (Odeme odeme in satirlar)
            {
                odeme.IptalEdildi = true;
                odeme.IptalNedeni = neden;
                odeme.IptalTarihi = simdi;
            }

            foreach (KasaHareketi hareket in KasaHareketleri.Where(h => h.TahsilatNo == tahsilatNo && !h.IptalEdildi))
            {
                hareket.IptalEdildi = true;
                hareket.Aciklama = $"{hareket.Aciklama} | İPTAL: {neden}";
            }

            // Eski kayıtlarda TahsilatNo boş olabilir — IliskiliOdeme üzerinden yedek
            foreach (Odeme odeme in satirlar)
            {
                foreach (KasaHareketi hareket in KasaHareketleri.Where(h =>
                    !h.IptalEdildi && ReferenceEquals(h.IliskiliOdeme, odeme)))
                {
                    hareket.IptalEdildi = true;
                    hareket.TahsilatNo = tahsilatNo;
                    hareket.Aciklama = $"{hareket.Aciklama} | İPTAL: {neden}";
                }
            }

            decimal tutar = satirlar.Sum(o => o.Tutar);
            string doktorAd = satirlar[0].Doktor?.AdSoyad ?? "";
            DenetimEkle(DenetimKategori.Odeme, "Tahsilat iptal edildi",
                $"{doktorAd} · {tutar:N2} TL · {neden}");
            return (true, $"Tahsilat iptal edildi ({tutar:N2} TL).\nGerekçe: {neden}\n\nİş ve doktor bakiyeleri güncellendi. Doğru ödemeyi yeniden girebilirsiniz.");
        }

        public static (bool Basarili, string Mesaj) IsSil(Is isKaydi)
        {
            if (IsinOdemesiVarMi(isKaydi))
            {
                return (false, "Bu işe bağlı ödeme kaydı olduğu için silinemez. Önce ilgili ödemeleri kontrol edin.");
            }

            string ozet = $"{isKaydi.IsNumarasi} · {isKaydi.HastaAdi} · {isKaydi.Doktor?.AdSoyad}";
            if (!Isler.Remove(isKaydi))
            {
                return (false, "İş kaydı bulunamadı.");
            }

            DenetimEkle(DenetimKategori.Is, "İş silindi", ozet);
            return (true, "İş kaydı silindi.");
        }

        public static (bool Basarili, string Mesaj) DoktorKaldir(Doctor doktor)
        {
            if (DoktorunKaydiVarMi(doktor))
            {
                doktor.Aktif = false;
                DenetimEkle(DenetimKategori.Doktor, "Doktor pasif yapıldı", doktor.AdSoyad);
                return (true, "Bu doktora ait iş veya ödeme kayıtları olduğu için kalıcı silinmedi. Doktor pasif yapıldı.");
            }

            string ad = doktor.AdSoyad;
            Doktorlar.Remove(doktor);
            DenetimEkle(DenetimKategori.Doktor, "Doktor silindi", ad);
            return (true, "Doktor kalıcı olarak silindi.");
        }

        public static void DoktorAktiflestir(Doctor doktor)
        {
            doktor.Aktif = true;
            DenetimEkle(DenetimKategori.Doktor, "Doktor aktifleştirildi", doktor.AdSoyad);
        }

        public static KasaHareketi KasaGirisiEkle(Kasa kasa, decimal tutar, string aciklama, DateTime tarih, Odeme? odeme = null, Guid tahsilatNo = default)
        {
            if (tahsilatNo == Guid.Empty && odeme is not null)
            {
                tahsilatNo = odeme.TahsilatNo;
            }

            KasaHareketi hareket = new KasaHareketi
            {
                Kasa = kasa,
                Yon = KasaYon.Giris,
                Tutar = tutar,
                Aciklama = aciklama,
                Tarih = tarih,
                IliskiliOdeme = odeme,
                TahsilatNo = tahsilatNo
            };
            KasaHareketleri.Add(hareket);
            return hareket;
        }

        /// <summary>
        /// Ödemeyi işlere FIFO (en eski kayıt önce) dağıtır.
        /// seciliIsler boş/null ise doktorun tüm açık işlerine; doluysa yalnız seçilenlere yazar.
        /// Tek kasa girişi + iş başına ödeme satırı oluşturur.
        /// </summary>
        public static (bool Basarili, string Mesaj) OdemeFifoDagit(
            Doctor doktor,
            Kasa kasa,
            decimal tutar,
            DateTime tarih,
            string odemeYontemi,
            string aciklama,
            IReadOnlyList<Is>? seciliIsler)
        {
            if (tutar <= 0)
            {
                return (false, "Ödeme tutarı sıfırdan büyük olmalıdır.");
            }

            bool secimVar = seciliIsler is { Count: > 0 };
            List<Is> hedefler = (secimVar
                    ? seciliIsler!
                    : Isler.Where(isKaydi =>
                        ReferenceEquals(isKaydi.Doktor, doktor) && !isKaydi.RptMi && isKaydi.KalanTutar > 0))
                .Where(isKaydi => isKaydi.KalanTutar > 0)
                .OrderBy(isKaydi => isKaydi.KayitTarihi)
                .ThenBy(isKaydi => isKaydi.IsNumarasi, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (hedefler.Count == 0)
            {
                return (false, secimVar
                    ? "Seçili işlerde kalan borç yok."
                    : "Bu doktora ait açık iş yok. İşsiz avans ödemesi henüz desteklenmiyor.");
            }

            decimal acikToplam = hedefler.Sum(isKaydi => isKaydi.KalanTutar);
            if (tutar > acikToplam)
            {
                return (false,
                    $"Tutar açık borç toplamından büyük olamaz.\nAçık borç: {acikToplam:N2} TL");
            }

            string anaAciklama = string.IsNullOrWhiteSpace(aciklama)
                ? (secimVar ? "İş ödemesi" : "FIFO otomatik dağıtım")
                : aciklama.Trim();

            Guid tahsilatNo = Guid.NewGuid();
            decimal kalanDagitim = tutar;
            List<Odeme> olusanOdemeler = new List<Odeme>();

            foreach (Is isKaydi in hedefler)
            {
                if (kalanDagitim <= 0)
                {
                    break;
                }

                decimal buOdeme = Math.Min(isKaydi.KalanTutar, kalanDagitim);
                if (buOdeme <= 0)
                {
                    continue;
                }

                Odeme odeme = new Odeme
                {
                    TahsilatNo = tahsilatNo,
                    Doktor = doktor,
                    IliskiliIs = isKaydi,
                    Kasa = kasa,
                    Tarih = tarih,
                    Tutar = buOdeme,
                    OdemeYontemi = odemeYontemi,
                    Aciklama = $"{anaAciklama} ({isKaydi.IsNumarasi} - {isKaydi.HastaAdi})"
                };
                Odemeler.Add(odeme);
                olusanOdemeler.Add(odeme);
                kalanDagitim -= buOdeme;
            }

            if (olusanOdemeler.Count == 0)
            {
                return (false, "Ödeme dağıtılamadı.");
            }

            KasaGirisiEkle(
                kasa,
                tutar,
                $"{doktor.AdSoyad} - {anaAciklama} ({olusanOdemeler.Count} iş)",
                tarih,
                olusanOdemeler[0],
                tahsilatNo);

            string ozetSatirlari = string.Join("\n",
                olusanOdemeler.Select(o =>
                    $"• {o.IliskiliIs?.IsNumarasi} {o.IliskiliIs?.HastaAdi}: {o.Tutar:N2} TL"));

            string kaynak = secimVar ? "seçili işlere" : "açık işlere (FIFO — en eski önce)";
            DenetimEkle(DenetimKategori.Odeme, "Tahsilat alındı",
                $"{doktor.AdSoyad} · {tutar:N2} TL · {odemeYontemi} · {kasa.Ad} · {olusanOdemeler.Count} iş");
            return (true,
                $"{tutar:N2} TL {kaynak} dağıtıldı.\n{kasa.Ad} bakiyesi: {kasa.Bakiye:N2} TL\n\n{ozetSatirlari}\n\nYanlış mı? Ödeme Raporu’ndan iptal edebilirsiniz.");
        }

        public static (bool Basarili, string Mesaj) KasaCikisiEkle(Kasa kasa, decimal tutar, string aciklama, DateTime tarih)
        {
            if (tutar <= 0)
            {
                return (false, "Çıkış tutarı sıfırdan büyük olmalıdır.");
            }

            if (tutar > kasa.Bakiye)
            {
                return (false, $"Yetersiz bakiye. {kasa.Ad} bakiyesi: {kasa.Bakiye:N2} TL");
            }

            KasaHareketleri.Add(new KasaHareketi
            {
                Kasa = kasa,
                Yon = KasaYon.Cikis,
                Tutar = tutar,
                Aciklama = aciklama,
                Tarih = tarih
            });

            DenetimEkle(DenetimKategori.Kasa, "Kasa çıkışı",
                $"{kasa.Ad} · {tutar:N2} TL · {aciklama}");
            return (true, "Kasa çıkışı kaydedildi.");
        }

        public static (bool Basarili, string Mesaj) BankaHesabiEkle(string ad, string aciklama = "")
        {
            ad = ad.Trim();
            if (string.IsNullOrWhiteSpace(ad))
            {
                return (false, "Hesap adı zorunludur.");
            }

            if (Kasalar.Any(kasa =>
                string.Equals(kasa.Ad.Trim(), ad, StringComparison.CurrentCultureIgnoreCase)))
            {
                return (false, "Bu isimde bir kasa/hesap zaten var.");
            }

            Kasalar.Add(new Kasa
            {
                Ad = ad,
                Tur = KasaTuru.Banka,
                Aciklama = aciklama.Trim(),
                Aktif = true
            });

            DenetimEkle(DenetimKategori.Kasa, "Banka hesabı eklendi", ad);
            return (true, "Banka hesabı eklendi.");
        }
    }
}
