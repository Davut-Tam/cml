using OgrenciTakipMuh.Data.Entities.BaseEntities;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;


namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class OgrenciCariOdemeL : BaseEntity
    {
        public long OdemePlaniId { get; set; }
        public long OgrenciId { get; set; }
        public string TcKimlikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public int TaksitNo { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public decimal Odenecek { get; set; }
        public decimal Odenen { get; set; }
        public decimal Kalan { get; set; }
        public int TahakkukNo { get; set; }
        public string OdemeSekliAdi { get; set; }
        public string DonemAdi { get; set; }
        public string Veli1AdiSoyadi { get; set; }
        public string Veli2AdiSoyadi { get; set; }
        public string Veli1Telefon { get; set; }
        public string Veli2Telefon { get; set; }
        public string GrupAdi { get; set; }
        public string SinifAdi { get; set; }
        public bool OtoSms { get; set; }
        public DateTime? BirinciHatirlatma { get; set; }
        public DateTime? IkinciHatirlatma { get; set; }

    
        
        
        // Ayarlardan girilen güne göre yeniden hessaplanacak
        public DateTime BirinciHatirlatmaGunu { get { return SonOdemeTarihi.IsgunuHesapla(); }  }
        public DateTime IkinciHatirlatmaGunu { get { return SonOdemeTarihi.AddDays(AnaForm.GenAyr.IkinciSmsSuresi); } }

    }
    public class OgrenciOdemeListesiR
    {
        public string TcKimlikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public int TaksitNo { get; set; }
        public string GrupAdi { get; set; }
        public string SinifAdi { get; set; }
        public DateTime? Tarih { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public string OdemeKanali { get; set; }
        public decimal OdenecekTutar { get; set; }

    }

}

