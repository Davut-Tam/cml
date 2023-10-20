using OgrenciTakipMuh.Data.Entities.BaseEntities;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class BankaHesap:BaseEntity
    {
        public string HesapAdi { get; set; }
        public string BankaAdi { get; set; }
        public string SubeAdi { get; set; }
        public string IbanNo { get; set; }

    }
    public class BankaHesapL: BankaHesap
    {
        public decimal Bakiye { get; set; }
    }
}
