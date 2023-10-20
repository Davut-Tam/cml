using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;

namespace OgrenciTakipMuh.Data.Facade
{
    public  class SinifF 
    {
        private static string _sql;
        public static bool Ekle(Sinif snf)
        {
            
            HataKont(snf);
            _sql = "INSERT INTO Sinif VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
           return Parametre(snf).Kaydet(_sql);


        }

        public static bool Guncelle(Sinif snf, long id)
        {
            HataKont(snf);
            _sql = "UPDATE Sinif SET SinifAdi = @p1, GrupId = @p2, DonemId = @p3, Aciklama = @p4, KullaniciId = @p5, IslemTarihi = @p6 WHERE Id = " + id;
            return Parametre(snf).Kaydet(_sql);

        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Sinif WHERE Id=" + id;
            return Repository.Sil(_sql,"Öğrenci Listesi");
        }

        public static object Liste(long donemId)
        {
          return Connections.cnn.Query<SinifL>($"select s.*,g.GrupAdi,(select count(*) from Ogrenci where SinifId=s.Id) as 'OgrenciSayisi' from Sinif s left join Grup g on s.GrupId=g.Id WHERE s.DonemId={donemId} order by s.GrupId");
        }

        public static object Liste(long donemId,long grupId)
        {
            return Connections.cnn.Query<SinifL>($"select s.*,g.GrupAdi,(select count(*) from Ogrenci where SinifId=s.Id) as 'OgrenciSayisi' from Sinif s left join Grup g on s.GrupId=g.Id WHERE s.DonemId={donemId} and s.GrupId={grupId} order by s.GrupId");
        }

        public static SinifL Secim(long id)
        { 
            return Connections.cnn.QueryFirst<SinifL>("SELECT *,g.GrupAdi FROM Sinif f Left Join Grup g on f.GrupId=g.Id WHERE f.Id=" + id);
        }
        static void HataKont(Sinif snf)
        {
            if (snf.SinifAdi.Replace(" ", "") == "")
                throw new System.Exception("Sınıf Giriniz");
            if (snf.GrupId <=0)
                throw new Exception("Grup Seçiniz");
        }

       
        static DynamicParameters Parametre(Sinif snf)
        {
            var param = new DynamicParameters();
            param.Add("@p0", snf.Id);
            param.Add("@p1", snf.SinifAdi);
            param.Add("@p2", snf.GrupId);
            param.Add("@p3", snf.DonemId);
            param.Add("@p4", snf.Aciklama);
            param.Add("@p5", snf.KullaniciId);
            param.Add("@p6", snf.IslemTarihi);
            return param;
        }
    }
 
}
