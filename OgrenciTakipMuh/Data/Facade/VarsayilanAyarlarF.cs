using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;

namespace OgrenciTakipMuh.Data.Facade
{


    public class VarsayilanAyarlarF 
    {
        private static string _sql;
        private static string _res;
        public static VarsayilanAyarlar Secim()
        {
            return Connections.cnn.QueryFirstOrDefault<VarsayilanAyarlar>("SELECT * from VarsayilanAyarlar Where Id=1");
        }

        public static int KayitSayisiKontrol()
        {
            return (int)Connections.cnn.ExecuteScalar("SELECT Count(*) from VarsayilanAyarlar");
        }

        public static bool Guncelle(VarsayilanAyarlar Ayr)
        {
            HataKont(Ayr);

            if (KayitSayisiKontrol() == 0)
                Connections.cnn.Execute("Insert Into VarsayilanAyarlar (Id) Values (1)");



            _res = Ayr.KurumLogo == null ? "Null" : "@p9";

            _sql = $@"UPDATE VarsayilanAyarlar SET DonemId=@p1,BankaHesapId=@p2,KurumUnvan=@p3,VergiNo=@p4,VergiDairesi=@p5,Tel1=@p6,Tel2=@p7,
                        Adres=@p8,KurumLogo={_res},MailAdres=@p10,KayitSesi=@p11,YedeklemeSaati=@p12,OtomatikYedekleme=@p13, YedeklemeYolu=@p14,
                        OtoYedeklemeMail=@p15,OtoYedeklemeMailAdres=@p16,SmsGonderme=@p17,SmsKullaniciAdi=@p18,SmsSifre=@p19,SmsBaslik=@p20,OtoSms=@p21,
                        BirinciSmsSuresi=@p22,IkinciSmsSuresi=@p23,OtoSmsMesaj=@p24
                        WHERE Id=1";

            return Parametre(Ayr).Guncelle(_sql);
        }

        static void HataKont(VarsayilanAyarlar Ayr)
        {
            if (Ayr.OtomatikYedekleme == true && Ayr.YedeklemeYolu.Replace(" ", "") == "")
                throw new Exception("Yedekleme Yolu Seçiniz");

        }

        static DynamicParameters Parametre(VarsayilanAyarlar Ayr)
        {
            var param = new DynamicParameters();

            param.Add("@p1", Ayr.DonemId);
            param.Add("@p2", Ayr.BankaHesapId);
            param.Add("@p3", Ayr.KurumUnvan);
            param.Add("@p4", Ayr.VergiNo);
            param.Add("@p5", Ayr.VergiDairesi);
            param.Add("@p6", Ayr.Tel1);
            param.Add("@p7", Ayr.Tel2);
            param.Add("@p8", Ayr.Adres);
            param.Add("@p9", Ayr.KurumLogo);
            param.Add("@p10", Ayr.MailAdres);
            param.Add("@p11", Ayr.KayitSesi);
            param.Add("@p12", Ayr.YedeklemeSaati);
            param.Add("@p13", Ayr.OtomatikYedekleme);
            param.Add("@p14", Ayr.YedeklemeYolu);
            param.Add("@p15", Ayr.OtoYedeklemeMail);
            param.Add("@p16", Ayr.OtoYedeklemeMailAdres);
            param.Add("@p17", Ayr.SmsGonderme);
            param.Add("@p18", Ayr.SmsKullaniciAdi);
            param.Add("@p19", Ayr.SmsSifre);
            param.Add("@p20", Ayr.SmsBaslik);
            param.Add("@p21", Ayr.OtoSms);
            param.Add("@p22", Ayr.BirinciSmsSuresi);
            param.Add("@p23", Ayr.IkinciSmsSuresi);
            param.Add("@p24", Ayr.OtoSmsMesaj);

            return param;
        }
    }
}