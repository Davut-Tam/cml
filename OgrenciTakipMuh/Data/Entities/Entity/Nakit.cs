using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Nakit:BaseKasaBankaCek
    {
        public DateTime? Tarih { get; set; }
        public string GirisCikis { get; set; }
        public int IslemId { get; set; }
        public decimal Tutar { get; set; }
        public decimal Bakiye { get; set; }
        public long HesapId { get; set; }
        public long? BankaIslemId { get; set; }
        public long? CekIslemId { get; set; }
      
    }

    public class NakitL : Nakit
    {
        public string OgrenciAdi { get; set; }
        public string IslemAdi { get; set; }
        public string FirmaAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string HesapAdi { get; set; }
      
    }

    public class NakitGirisCikis 
    {
        public decimal Giris { get; set; }
        public decimal Cikis { get; set; }
    }
}