using Dapper;
using Ionic.Zip;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.IO;

namespace OgrenciTakipMuh.Data.Facade
{
    public class YedeklemeKayitlariF
    {
        private static string _sql;
        public static  string yedeklemeyolu;
        private static bool Ekle(string dizin, string aciklama)
        {
            var paramSil = new DynamicParameters();
            paramSil.Add("@p1", DateTime.Now.AddDays(-50));
            Connections.cnn.Execute("DELETE FROM YedeklemeKayitlari WHERE IslemTarihi<@p1", paramSil);

            var paramEkle = new DynamicParameters();
            paramEkle.Add("@p0", GenelFunctions.IdOlustur());
            paramEkle.Add("@p1", dizin);
            paramEkle.Add("@p2", DateTime.Now);
            paramEkle.Add("@p3", AnaForm.KullanicilId);
            paramEkle.Add("@p4", aciklama);

            _sql = "INSERT INTO YedeklemeKayitlari VALUES (@p0,@p1,@p2,@p3,@p4)";
            return paramEkle.Kaydet(_sql);

        }

        public static bool YedekAl(string dizin, string aciklama)
        {
            try
            {
                string yedeklemeTarih = DateTime.Now.ToString().Replace(":", ".");
                yedeklemeyolu = dizin + @"\Veritabanı Yedek (MuhData)\" + yedeklemeTarih + @"\";
                if (!Directory.Exists(yedeklemeyolu)) // klasör var mı
                    Directory.CreateDirectory(yedeklemeyolu);// klasör ekle

                if (Connections.cnn.Execute($@"BACKUP DATABASE MuhData TO DISK = '{yedeklemeyolu}MuhData.bak'") == -1 && YedeklemeZamaniGuncelle(DateTime.Now) && Ekle(yedeklemeyolu + "MuhData.bak", aciklama) == true)
                {
                    ZipFile zf = new ZipFile($@"{yedeklemeyolu}MuhData.zip");
                    zf.AddFile($@"{yedeklemeyolu}MuhData.bak", yedeklemeTarih);
                    zf.Save();
                    File.Delete($@"{yedeklemeyolu}MuhData.bak");
                    return true;
                }
                    
                else
                    return false;
            }
            catch (Exception)
            {

                Messages.UyariMesaji("Yedekleme Başarısız");
                return false;
            }

        }
        //   

        private static bool YedeklemeZamaniGuncelle(DateTime tarih)
        {
            var param = new DynamicParameters();
            param.Add("@p17", tarih);
            _sql = @"UPDATE VarsayilanAyarlar SET SonYedeklemeTarihi=@p17 WHERE Id=1";
            return param.Guncelle(_sql);
        }
        public static object Liste()
        {
            return Connections.cnn.Query<YedeklemeKayitlari>("Select y.*,k.AdiSoyadi From YedeklemeKayitlari y left join Kullanici k on y.KullaniciId=k.Id order by y.Id desc");
        }


    }
}
