using System.Drawing.Printing;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace ESDentalLab
{
    public static class IsFisiYazdirici
    {
        // A5: 148 × 210 mm → 583 × 827 (1/100 inch)
        private static readonly PaperSize A5Kagit = new PaperSize("A5", 583, 827)
        {
            RawKind = (int)PaperKind.A5
        };

        private static bool _fontHazir;

        public static void OnizlemeGoster(IWin32Window sahip, Is isKaydi) =>
            OnizlemeGoster(sahip, new[] { isKaydi });

        public static void OnizlemeGoster(IWin32Window sahip, IReadOnlyList<Is> isler)
        {
            if (isler.Count == 0)
            {
                MessageBox.Show("Yazdırmak için en az bir iş seçin.", "İş seçilmedi");
                return;
            }

            int sayfaNo = 0;
            PrintDocument yazdirmaBelgesi = new PrintDocument();
            yazdirmaBelgesi.DocumentName = isler.Count == 1
                ? $"{isler[0].IsNumarasi} İş Fişi"
                : $"İş Fişleri ({isler.Count} adet)";
            A5AyariUygula(yazdirmaBelgesi);
            yazdirmaBelgesi.PrintPage += (_, e) =>
            {
                FisCiz(e, isler[sayfaNo]);
                sayfaNo++;
                e.HasMorePages = sayfaNo < isler.Count;
            };

            using PrintPreviewDialog onizleme = new PrintPreviewDialog
            {
                Document = yazdirmaBelgesi,
                Width = 720,
                Height = 900,
                StartPosition = FormStartPosition.CenterParent,
                UseAntiAlias = true
            };

            onizleme.ShowDialog(sahip);
        }

        public static (bool Basarili, string Mesaj) PdfKaydet(string dosyaYolu, IReadOnlyList<Is> isler)
        {
            if (isler.Count == 0)
            {
                return (false, "PDF için en az bir iş seçin.");
            }

            try
            {
                FontlariHazirla();

                using PdfDocument belge = new PdfDocument();
                belge.Info.Title = isler.Count == 1
                    ? $"{isler[0].IsNumarasi} İş Fişi"
                    : $"İş Fişleri ({isler.Count})";
                belge.Info.Author = "ES Dental Lab";

                foreach (Is isKaydi in isler)
                {
                    PdfPage sayfa = belge.AddPage();
                    sayfa.Width = XUnit.FromMillimeter(148);
                    sayfa.Height = XUnit.FromMillimeter(210);
                    using XGraphics grafik = XGraphics.FromPdfPage(sayfa);
                    FisCizPdf(grafik, isKaydi, sayfa.Width.Point, sayfa.Height.Point);
                }

                belge.Save(dosyaYolu);
                return (true, $"{isler.Count} iş fişi PDF olarak kaydedildi.\n{dosyaYolu}");
            }
            catch (Exception ex)
            {
                return (false, $"PDF oluşturulamadı:\n{ex.Message}");
            }
        }

        private static void FontlariHazirla()
        {
            if (_fontHazir)
            {
                return;
            }

            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            _fontHazir = true;
        }

        private static void A5AyariUygula(PrintDocument belge)
        {
            PaperSize? yazicidaA5 = belge.PrinterSettings.PaperSizes
                .Cast<PaperSize>()
                .FirstOrDefault(p => p.Kind == PaperKind.A5);

            belge.DefaultPageSettings.PaperSize = yazicidaA5 ?? A5Kagit;
            belge.DefaultPageSettings.Landscape = false;
            belge.DefaultPageSettings.Margins = new Margins(36, 36, 36, 36);
        }

        private static void FisCiz(PrintPageEventArgs e, Is isKaydi)
        {
            Graphics? grafik = e.Graphics;
            if (grafik is null)
            {
                return;
            }

            int sol = e.MarginBounds.Left;
            int ust = e.MarginBounds.Top;
            int genislik = e.MarginBounds.Width;
            int y = ust;

            using Font markaFont = new Font("Segoe UI", 14, FontStyle.Bold);
            using Font baslikFont = new Font("Segoe UI", 10, FontStyle.Bold);
            using Font normalFont = new Font("Segoe UI", 9);
            using Font kucukFont = new Font("Segoe UI", 8);
            using Brush koyuFirca = new SolidBrush(Color.FromArgb(22, 54, 78));
            using Pen cizgi = new Pen(Color.FromArgb(160, 175, 185));

            grafik.DrawString("ES DENTAL LAB", markaFont, koyuFirca, sol, y);
            y += 28;
            grafik.DrawString("İŞ FİŞİ", baslikFont, Brushes.Black, sol, y);
            SizeF noBoyut = grafik.MeasureString(isKaydi.IsNumarasi, baslikFont);
            grafik.DrawString(isKaydi.IsNumarasi, baslikFont, koyuFirca, sol + genislik - noBoyut.Width, y);
            y += 22;
            grafik.DrawLine(cizgi, sol, y, sol + genislik, y);
            y += 14;

            BilgiSatiri(grafik, "Kayıt tarihi", isKaydi.KayitTarihi.ToString("dd.MM.yyyy HH:mm"), sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Hasta adı", isKaydi.HastaAdi, sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Doktor", isKaydi.Doktor.AdSoyad, sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Klinik", isKaydi.Doktor.Klinik, sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "İş türü", isKaydi.IsTuru, sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Diş numarası", isKaydi.DisNumarasi, sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Teslim tarihi", isKaydi.TeslimTarihi.ToString("dd.MM.yyyy"), sol, ref y, baslikFont, normalFont);
            BilgiSatiri(grafik, "Durum", isKaydi.Durum, sol, ref y, baslikFont, normalFont);

            y += 6;
            grafik.DrawLine(cizgi, sol, y, sol + genislik, y);
            y += 10;
            grafik.DrawString("Açıklama", baslikFont, Brushes.Black, sol, y);
            y += 18;
            int aciklamaYukseklik = 70;
            RectangleF aciklamaAlani = new RectangleF(sol, y, genislik, aciklamaYukseklik);
            grafik.DrawRectangle(cizgi, aciklamaAlani.X, aciklamaAlani.Y, aciklamaAlani.Width, aciklamaAlani.Height);
            grafik.DrawString(string.IsNullOrWhiteSpace(isKaydi.Aciklama) ? "-" : isKaydi.Aciklama,
                normalFont, Brushes.Black, aciklamaAlani);
            y += aciklamaYukseklik + 28;

            int imzaGenislik = Math.Min(160, genislik / 2 - 10);
            grafik.DrawLine(cizgi, sol, y, sol + imzaGenislik, y);
            grafik.DrawLine(cizgi, sol + genislik - imzaGenislik, y, sol + genislik, y);
            y += 5;
            grafik.DrawString("Teslim eden", kucukFont, Brushes.Black, sol, y);
            grafik.DrawString("Teslim alan çalışan", kucukFont, Brushes.Black, sol + genislik - imzaGenislik, y);
        }

        private static void FisCizPdf(XGraphics grafik, Is isKaydi, double sayfaGenislik, double sayfaYukseklik)
        {
            const double margin = 28;
            double sol = margin;
            double genislik = sayfaGenislik - margin * 2;
            double y = margin;

            XColor koyu = XColor.FromArgb(22, 54, 78);
            XPen cizgi = new XPen(XColor.FromArgb(160, 175, 185), 0.7);
            XFont markaFont = new XFont("Segoe UI", 14, XFontStyleEx.Bold);
            XFont baslikFont = new XFont("Segoe UI", 10, XFontStyleEx.Bold);
            XFont normalFont = new XFont("Segoe UI", 9, XFontStyleEx.Regular);
            XFont kucukFont = new XFont("Segoe UI", 8, XFontStyleEx.Regular);

            grafik.DrawString("ES DENTAL LAB", markaFont, new XSolidBrush(koyu), sol, y);
            y += 26;
            grafik.DrawString("İŞ FİŞİ", baslikFont, XBrushes.Black, sol, y);
            XSize noBoyut = grafik.MeasureString(isKaydi.IsNumarasi, baslikFont);
            grafik.DrawString(isKaydi.IsNumarasi, baslikFont, new XSolidBrush(koyu), sol + genislik - noBoyut.Width, y);
            y += 20;
            grafik.DrawLine(cizgi, sol, y, sol + genislik, y);
            y += 12;

            PdfBilgiSatiri(grafik, "Kayıt tarihi", isKaydi.KayitTarihi.ToString("dd.MM.yyyy HH:mm"), sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Hasta adı", isKaydi.HastaAdi, sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Doktor", isKaydi.Doktor.AdSoyad, sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Klinik", isKaydi.Doktor.Klinik, sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "İş türü", isKaydi.IsTuru, sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Diş numarası", isKaydi.DisNumarasi, sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Teslim tarihi", isKaydi.TeslimTarihi.ToString("dd.MM.yyyy"), sol, ref y, baslikFont, normalFont);
            PdfBilgiSatiri(grafik, "Durum", isKaydi.Durum, sol, ref y, baslikFont, normalFont);

            y += 6;
            grafik.DrawLine(cizgi, sol, y, sol + genislik, y);
            y += 10;
            grafik.DrawString("Açıklama", baslikFont, XBrushes.Black, sol, y);
            y += 16;
            double aciklamaYukseklik = 70;
            XRect aciklamaAlani = new XRect(sol, y, genislik, aciklamaYukseklik);
            grafik.DrawRectangle(cizgi, aciklamaAlani);
            grafik.DrawString(
                string.IsNullOrWhiteSpace(isKaydi.Aciklama) ? "-" : isKaydi.Aciklama,
                normalFont,
                XBrushes.Black,
                aciklamaAlani,
                XStringFormats.TopLeft);
            y += aciklamaYukseklik + 26;

            double imzaGenislik = Math.Min(160, genislik / 2 - 10);
            grafik.DrawLine(cizgi, sol, y, sol + imzaGenislik, y);
            grafik.DrawLine(cizgi, sol + genislik - imzaGenislik, y, sol + genislik, y);
            y += 5;
            grafik.DrawString("Teslim eden", kucukFont, XBrushes.Black, sol, y);
            grafik.DrawString("Teslim alan çalışan", kucukFont, XBrushes.Black, sol + genislik - imzaGenislik, y);
        }

        private static void BilgiSatiri(Graphics grafik, string etiket, string deger, int sol, ref int y,
            Font baslikFont, Font normalFont)
        {
            grafik.DrawString($"{etiket}:", baslikFont, Brushes.Black, sol, y);
            grafik.DrawString(string.IsNullOrWhiteSpace(deger) ? "-" : deger, normalFont, Brushes.Black, sol + 110, y + 1);
            y += 20;
        }

        private static void PdfBilgiSatiri(XGraphics grafik, string etiket, string deger, double sol, ref double y,
            XFont baslikFont, XFont normalFont)
        {
            grafik.DrawString($"{etiket}:", baslikFont, XBrushes.Black, sol, y);
            grafik.DrawString(string.IsNullOrWhiteSpace(deger) ? "-" : deger, normalFont, XBrushes.Black, sol + 100, y + 1);
            y += 18;
        }
    }
}
