using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
   public class VarsayilanAyarlar
    {
        public long DonemId { get; set; }
        public long BankaHesapId { get; set; }
        public string KurumUnvan { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Adres { get; set; }
        public byte[] KurumLogo { get; set; }
        public string MailAdres { get; set; }
        public bool KayitSesi { get; set; }
        public TimeSpan? YedeklemeSaati { get; set; }
        public DateTime SonYedeklemeTarihi { get; set; }
        public bool OtomatikYedekleme { get; set; }
        public string YedeklemeYolu { get; set; }
        public bool OtoYedeklemeMail { get; set; }
        public string OtoYedeklemeMailAdres { get; set; }

        public bool  SmsGonderme { get; set; }
        public string SmsKullaniciAdi { get; set; }
        public string SmsSifre { get; set; }
        public string SmsBaslik { get; set; }
        public bool OtoSms { get; set; }
        public int BirinciSmsSuresi { get; set; }
        public int IkinciSmsSuresi { get; set; }
        public string OtoSmsMesaj { get; set; }
    }
}