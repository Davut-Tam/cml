using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Personel:BaseEntity
    {

        public string TcKimlikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public long GorevId { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public decimal Maas { get; set; }
        public int MaasOdemeGunu { get; set; }
        public byte[] Resim { get; set; }
        public string EmailAdresi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string BankaAdi { get; set; }
        public string IbanNo { get; set; }
        public bool OtomatikMaas { get; set; }
        
    }

    public class PersonelL : Personel
    {
        public string GorevAdi { get; set; }
        public string TahakkukSekli { get; set; }
        public decimal HakedilenMaas { get; set; }
        public decimal OdenenMaas { get; set; }
        public decimal ToplamIade { get; set; }
        public decimal KalanBakiye { get; set; }
        public DateTime? SonMaasTahakkukTarihi { get; set; }

    }
   

}
