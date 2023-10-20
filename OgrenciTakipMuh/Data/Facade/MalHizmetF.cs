using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    public class MalHizmetF
    {
        private static string _sql;
        public static bool Ekle(MalHizmet mhz)
        {
            HataKont(mhz);
            _sql = "INSERT INTO MalHizmet VALUES (@p0,@p1,@p2,@p3,@p4,@p5)";
            return Parametre(mhz).Kaydet(_sql);

        }
        //   
        public static bool Guncelle(MalHizmet mhz, long id)
        {
            HataKont(mhz);
            _sql = "UPDATE MalHizmet SET MalHizmetAdi=@p1,MiktarBrim=@p2,Aciklama=@p3,KullaniciId=@p4,IslemTarihi=@p5 WHERE Id=" + id;
            return Parametre(mhz).Guncelle(_sql);
        }

        public static bool Sil(long id)
        {

            return Repository.Sil("DELETE FROM MalHizmet WHERE Id=" + id);
        }

        public static object Liste()
        {
            return Connections.cnn.Query<MalHizmet>($@"select * From MalHizmet order by Id desc");
        }


        public static MalHizmet Secim(long id)
        {
            return Connections.cnn.QueryFirst<MalHizmet>("SELECT * FROM MalHizmet WHERE Id=" + id);
        }
        static void HataKont(MalHizmet mhz)
        {
            if (mhz.MalHizmetAdi.Replace(" ", "") == "")
                throw new Exception("Mal / Hizmet Adı Giriniz");

            if (mhz.MiktarBrim.Replace(" ", "") == "")
                throw new Exception("Miktar Brimi Giriniz");
        }
        static DynamicParameters Parametre(MalHizmet mhz)
        {
            var param = new DynamicParameters();
            param.Add("@p0", mhz.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mhz.MalHizmetAdi.ToLower())); 
            param.Add("@p2", mhz.MiktarBrim);
            param.Add("@p3", mhz.Aciklama);
            param.Add("@p4", mhz.KullaniciId);
            param.Add("@p5", mhz.IslemTarihi);
            return param;
        }
    }
}
