using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;


namespace OgrenciTakipMuh.Data.Entities.Entity
{
  public  class OgrenciOdemePlani:BaseEntity
    {
        public int TahakkukNo { get; set; }
        public long OgrenciId { get; set; }
        public long DonemId { get; set; }
        public long OdemeSekliId { get; set; }
        public int TaksitNo { get; set; }
        public decimal OdenecekTutar { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public DateTime? BirinciHatirlatma { get; set; }
        public DateTime? IkinciHatirlatma { get; set; }



    }

    public class OgrenciOdemePlaniL: OgrenciOdemePlani
    {
        public string OdemeSekliAdi { get; set; }      
        public bool Odendi { get; set; }

        public string OdemeKanali { get; set; }
    
        public decimal Odenecek { get; set; }
        public decimal Odenen { get; set; }
        public decimal Kalan { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime? Tarih { get; set; }
        public decimal Tutar { get; set; }

    }
}
