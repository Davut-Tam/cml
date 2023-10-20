using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    public class GorevF
    {
        private static string _sql;
        public static bool Ekle(Gorev grv)
        {
            HataKont(grv);
            _sql = "INSERT INTO Gorev VALUES (@p0,@p1,@p2,@p3,@p4)";
            return Parametre(grv).Kaydet(_sql);

        }
        //   
        public static bool Guncelle(Gorev grv, long id)
        {
            HataKont(grv);
            _sql = "UPDATE Gorev SET GorevAdi=@p1,Aciklama=@p2,KullaniciId=@p3,IslemTarihi=@p4 WHERE Id=" + id;
            return Parametre(grv).Guncelle(_sql);
        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Gorev WHERE Id=" + id;
            return Repository.Sil(_sql, "Personel Listesi");

        }

        public static object Liste()
        {
            return Connections.cnn.Query<Gorev>("select * From Gorev order by GorevAdi");
        }


        public static Gorev Secim(long id)
        {
            return Connections.cnn.QueryFirst<Gorev>("SELECT * FROM Gorev WHERE Id=" + id);
        }
        static void HataKont(Gorev grv)
        {
            if (grv.GorevAdi.Replace(" ", "") == "")
                throw new Exception("Görev Adı Giriniz");
        }
        static DynamicParameters Parametre(Gorev grv)
        {
            var param = new DynamicParameters();
            param.Add("@p0", grv.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(grv.GorevAdi.ToLower())); 
            param.Add("@p2", grv.Aciklama);
            param.Add("@p3", grv.KullaniciId);
            param.Add("@p4", grv.IslemTarihi);
            return param;
        }

    }
}