using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using OgrenciTakipMuh.Data.Entities;
using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Ogrenci:BaseEntity
    {
        public string TcKimlikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public long Veli1Id { get; set; }
        public long Veli2Id { get; set; }
        public string EmailAdresi { get; set; }
        public string GeldigiOkul { get; set; }
        public string Adres { get; set; }
        public long DonemId { get; set; }
        public long GrupId { get; set; }
        public long SinifId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public byte[] Resim { get; set; }

        // tHkkuk
        public decimal KayitTutari { get; set; }
        public int TahakkukNo { get; set; }
        public decimal TahakkukTutari { get; set; }
        public bool OtoSms { get; set; } 
    }
    public class OgrenciL : Ogrenci
    {
        public string Veli1AdiSoyadi { get; set; }
        public string Veli2AdiSoyadi { get; set; }
        public string Veli1Telefon { get; set; }
        public string Veli2Telefon { get; set; }
        public string Veli1MeslekAdi { get; set; }
        public string Veli2MeslekAdi { get; set; }
        public string DonemAdi { get; set; }
        public string GrupAdi { get; set; }
        public string SinifAdi { get; set; }
        public string KullaniciAdi { get; set; }

        public decimal TahsilatTutari { get; set; }
        public decimal GeriIadeTutari { get; set; }
        public decimal KalanBakiye { get; set; }
        public string SmsBilgilendirmeString { get { return OtoSms ? "Evet" : "Hayır"; } }

    }
}
