namespace ESDentalLab
{
    public class Odeme
    {
        public Guid TahsilatNo { get; set; } = Guid.NewGuid();
        public Doctor Doktor { get; set; } = new Doctor();
        public Is? IliskiliIs { get; set; }
        public Kasa? Kasa { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
        public string OdemeYontemi { get; set; } = "Nakit";
        public string Aciklama { get; set; } = "";
        public bool IptalEdildi { get; set; }
        public string IptalNedeni { get; set; } = "";
        public DateTime? IptalTarihi { get; set; }

        public string Durum => IptalEdildi ? "İptal" : "Aktif";
    }

    /// <summary>
    /// Aynı tahsilat numarasına bağlı ödeme satırlarının özeti (liste ekranı).
    /// </summary>
    public class TahsilatOzeti
    {
        public Guid TahsilatNo { get; set; }
        public Doctor Doktor { get; set; } = new Doctor();
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
        public string OdemeYontemi { get; set; } = "";
        public string Aciklama { get; set; } = "";
        public string KasaAdi { get; set; } = "";
        public bool IptalEdildi { get; set; }
        public string Durum => IptalEdildi ? "İptal" : "Aktif";
        public int IsSayisi { get; set; }
        public string DagitimOzeti { get; set; } = "";
        public List<Odeme> Satirlar { get; set; } = new();
    }
}
