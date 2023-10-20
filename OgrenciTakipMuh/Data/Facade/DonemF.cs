using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    public class DonemF
    {
        private static string _sql;
        public static bool Ekle(Donem dnm)
        {
            HataKont(dnm);
            _sql = "INSERT INTO Donem VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
            return Parametre(dnm).Kaydet(_sql);

        }

        public static bool Guncelle(Donem dnm, long id)
        {
            HataKont(dnm);
            _sql = "UPDATE Donem SET DonemAdi=@p1,BaslamaTarihi=@p2,BitisTarihi=@p3,Aciklama=@p4,KullaniciId=@p5,IslemTarihi=@p6 WHERE Id=" + id;
            return Parametre(dnm).Guncelle(_sql);

        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Donem WHERE Id=" + id;
            return Repository.Sil(_sql,"Gruplar","Sınıflar","Öğrenciler","Veliler");
        }

        public static object Liste()
        {
            return Connections.cnn.Query<DonemL>(@"select *,
                                                 (select count(*) from Ogrenci where DonemId = d.Id) as OgrenciSayisi,
                                                 (select count(*) from Sinif where DonemId = d.Id) as SinifSayisi,
                                                 (select count(*) from Grup where DonemId = d.Id) as GrupSayisi
                                                 from donem d order by DonemAdi");
        }
        public static object Liste(long kayitdisiDonemId)
        {
            return Connections.cnn.Query<DonemL>($@"select *,
                                                 (select count(*) from Ogrenci where DonemId = d.Id) as OgrenciSayisi,
                                                 (select count(*) from Sinif where DonemId = d.Id) as SinifSayisi,
                                                 (select count(*) from Grup where DonemId = d.Id) as GrupSayisi
                                                 from donem d where Id<> {kayitdisiDonemId} order by DonemAdi");
        }

        public static Donem Secim(long id)
        {
            return Connections.cnn.QueryFirstOrDefault<DonemL>("SELECT * FROM Donem WHERE Id=" + id);
        }

        static void HataKont(Donem dnm)
        {
            if (dnm.DonemAdi.Replace(" ", "") == "")
                throw new Exception("Dönem Adı Giriniz");
            if (dnm.BaslamaTarihi>=dnm.BitisTarihi)
                throw new Exception("Tarihler Hatalı");
        }
        static DynamicParameters Parametre(Donem dnm)
        {
            var param = new DynamicParameters();
            param.Add("@p0", dnm.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dnm.DonemAdi.ToLower()));
            param.Add("@p2", dnm.BaslamaTarihi);
            param.Add("@p3", dnm.BitisTarihi);
            param.Add("@p4", dnm.Aciklama);
            param.Add("@p5", dnm.KullaniciId);
            param.Add("@p6", dnm.IslemTarihi);
            return param;
        }
    }
}