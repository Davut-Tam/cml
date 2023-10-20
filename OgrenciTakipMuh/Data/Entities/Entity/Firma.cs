using OgrenciTakipMuh.Data.Entities.BaseEntities;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Firma : BaseEntity
    {
        public string FirmaAdi { get; set; }
        public string VergiTcKimlikNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Tur { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string BankaAdi { get; set; }
        public string IbanNo { get; set; }

    }

    public class FirmaL : Firma
    {
        public decimal ToplamSatis { get; set; }
        public decimal ToplamAlis { get; set; }
        public decimal ToplamOdeme { get; set; }
        public decimal ToplamTahsilat { get; set; }

        public decimal Bakiye
        {
            //get { return   (ToplamAlis - ToplamOdeme)+ (ToplamSatis - ToplamTahsilat); }
            get { return (ToplamSatis - ToplamTahsilat) - (ToplamAlis - ToplamOdeme); }
            set { }
        }


    }
}
