using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.Globalization;
using System.Net;

namespace OgrenciTakipMuh.Data.Facade
{
    public class KullaniciF
    {

        private static string _sql;
        private static string _res;
        public static bool Ekle(Kullanici klnc)
        {
            HataKont(klnc);
            _res = klnc.AnaResim == null ? "Null" : "@p6";
            _sql = $@"INSERT INTO Kullanici VALUES (@p0,@p1,@p2,@p3,@p4,@p5,{_res},@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)";


            return Parametre(klnc).Kaydet(_sql);

        }
        //   
        public static bool Guncelle(Kullanici klnc, long id)
        {
            HataKont(klnc);
            _res = klnc.AnaResim == null ? "Null" : "@p6";
            _sql = $"UPDATE Kullanici SET KullaniciTuru=@p1,AdiSoyadi=@p2,KullaniciAdi=@p3,Sifre=@p4,RolId=@p5,AnaResim={_res},Tema=@p7,TemaParametre=@p8,Aciklama=@p9,IslemTarihi=@p10,KullaniciId=@p13,OtoKapanma=@p14,OtoKapanmaSuresi=@p15 WHERE Id=" + id;
            return Parametre(klnc).Guncelle(_sql);


        }

        public static bool TemaGuncelle(string tema,string parametre,long id)
        {
            var param = new DynamicParameters();
            param.Add("@p7", tema);
            param.Add("@p8", parametre);
            _sql = $"UPDATE Kullanici SET Tema=@p7,TemaParametre=@p8 WHERE Id=" + id;
            return param.Guncelle(_sql);


        }


        public static bool BeniHatirlaGuncelle(long id, bool beniHatirla, string bilgisAyaradi)
        {
            var param = new DynamicParameters();
            param.Add("@p11", beniHatirla);
            param.Add("@p12", bilgisAyaradi);
            _sql = "UPDATE Kullanici SET BeniHatirla=@p11,BilgisayarAdi=@p12  WHERE Id=" + id;
            return param.Guncelle(_sql);

        }


        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Kullanici WHERE Id=" + id;
            return Repository.Sil(_sql);

        }

        public static object Liste()
        {
            return Connections.cnn.Query<KullaniciL>("Select k.*, case k.RolId when 1 then 'Tam Yetki' else  r.RolAdi end as 'RolAdi' From Kullanici k Left Join Rol r on k.RolId=r.Id  order by k.Id");
        }


        public static KullaniciL Secim(long id)
        {
            return Connections.cnn.QueryFirst<KullaniciL>("Select k.*,r.RolAdi From Kullanici k Left Join Rol r on k.RolId=r.Id WHERE k.Id=" + id);
        }


        public static int KullaniciKontrolu()
        {
            return (int)Connections.cnn.ExecuteScalar("Select Count(*) From Kullanici Where KullaniciTuru='Yönetici'");
        }

        public static long SifreKont(string KullaniciAdi, string sifre)
        {
            var Id = Connections.cnn.ExecuteScalar($"Select Id From Kullanici WHERE KullaniciAdi='{KullaniciAdi}' and Sifre='{sifre}'");

            if (Id != null)
                return (long)Id;
            else
                return 0;
        }

        public static long BeniHatirlaKontrolu()
        {
            try
            {
                return (long)Connections.cnn.ExecuteScalar($"Select Id From Kullanici Where BilgisayarAdi='{Dns.GetHostName()}' and BeniHatirla='True'");
            }
            catch (Exception)
            {

                return 0;
            }

        }

        static void HataKont(Kullanici klnc)
        {
            if (klnc.KullaniciTuru.Replace(" ", "") == "")
                throw new Exception("Kullanıcı Türü Belirtiniz");

            if (klnc.AdiSoyadi.Replace(" ", "") == "")
                throw new Exception("Adı Soyadı Giriniz");

            if (klnc.KullaniciAdi.Replace(" ", "") == "")
                throw new Exception("Kullanıcı Adı Giriniz");



            if (klnc.Sifre.Replace(" ", "") == "")
                throw new Exception("Şifre Giriniz");

            if (klnc.RolId <= 0)
                throw new Exception("Rol Tanımlayınız");
        }
        static DynamicParameters Parametre(Kullanici klnc)
        {
            var param = new DynamicParameters();
            param.Add("@p0", klnc.Id);
            param.Add("@p1", klnc.KullaniciTuru);
            param.Add("@p2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(klnc.AdiSoyadi.ToLower()));
            param.Add("@p3", klnc.KullaniciAdi);
            param.Add("@p4", klnc.Sifre);
            param.Add("@p5", klnc.RolId);
            param.Add("@p6", klnc.AnaResim);
            param.Add("@p7", AnaForm.Kllnci.Tema);
            param.Add("@p8", AnaForm.Kllnci.TemaParametre);
            param.Add("@p9", klnc.Aciklama);
            param.Add("@p10", klnc.IslemTarihi);
            param.Add("@p11", null);
            param.Add("@p12", null);
            param.Add("@p13", klnc.KullaniciId);
            param.Add("@p14", klnc.OtoKapanma);
            param.Add("@p15", klnc.OtoKapanmaSuresi);
            return param;
        }
    }
}
