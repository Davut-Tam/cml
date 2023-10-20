using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    public class GrupF 
    {
        private static string _sql;
        public static bool Ekle(Grup grp)
        {
            HataKont(grp);
            _sql = "INSERT INTO Grup VALUES (@p0,@p1,@p2,@p3,@p4,@p5)";
            return Parametre(grp).Kaydet(_sql);

        }
        //   
        public static bool Guncelle(Grup grp, long id)
        {
            HataKont(grp);
            _sql = "UPDATE Grup SET GrupAdi=@p1,DonemId=@p2,Aciklama=@p3,KullaniciId=@p4,IslemTarihi=@p5 WHERE Id=" + id;
            return Parametre(grp).Guncelle(_sql);
        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Grup WHERE Id=" + id;
            return Repository.Sil(_sql,"Sınıf Listesi","Öğrenci Listesi");

        }

        public static object Liste(long donemId)
        {
            return Connections.cnn.Query<GrupL>($@"select g.*,
                                                (select count(*) from Sinif where GrupId = g.Id) as SinifSayisi,
                                                (select count(*) from Ogrenci where GrupId = g.Id) as OgrenciSayisi
                                                from Grup g where g.DonemId={donemId} order by g.Id");
        }


        public static Grup Secim(long id)
        {       
           return Connections.cnn.QueryFirst<Grup>("SELECT * FROM Grup WHERE Id=" + id);
        }
        static void HataKont(Grup dnm)
        {
            if (dnm.GrupAdi.Replace(" ", "") == "")
                throw new Exception("Grup Adı Giriniz");
        }
        static DynamicParameters Parametre(Grup grp)
        {
            var param = new DynamicParameters();
            param.Add("@p0", grp.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(grp.GrupAdi.ToLower()));
            param.Add("@p2", grp.DonemId);
            param.Add("@p3", grp.Aciklama);
            param.Add("@p4", grp.KullaniciId);
            param.Add("@p5", grp.IslemTarihi);
            return param;
        }
    }
}