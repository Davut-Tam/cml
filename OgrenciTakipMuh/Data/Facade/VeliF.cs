using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.Globalization;
using System.Linq;

namespace OgrenciTakipMuh.Data.Facade
{
    public class VeliF 
    {
        private static string _sql;
        public static bool Ekle(Veli veli)
        {
            HataKont(veli);
            _sql = "INSERT INTO Veli VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            return Parametre(veli).Kaydet(_sql);
        }
        public static bool Guncelle(Veli veli, long id)
        {
            HataKont(veli);
            _sql = "UPDATE Veli SET VeliAdiSoyadi=@p1,TcKimlikNo=@p2,Telefon=@p3,Adres=@p4,Aciklama=@p5,KullaniciId=@p6,IslemTarihi=@p7,Durum=@p8,GorevId=@p9 WHERE Id=" + id;
            return Parametre(veli).Guncelle(_sql);


        }
        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Veli WHERE Id=" + id;
            return Repository.Sil(_sql, "Öğrenciler");
        }
        public static VeliL Secim(long id)
        {
            return Connections.cnn.QueryFirst<VeliL>(@"Select v.*, (select count(*) from Ogrenci where Veli1Id=v.Id or Veli2Id=v.Id) as 'OgrenciSayisi',g.GorevAdi from Veli v 
                                                    left join Gorev g on g.Id = v.GorevId WHERE v.Id=" + id);
        }
        public static object Liste(bool durum,long donemId)
        {
            return Connections.cnn.Query<VeliL>($@"Select v.*, (select count(*) from Ogrenci where (Veli1Id=v.Id or Veli2Id=v.Id) and DonemId={donemId}) as 'OgrenciSayisi',g.GorevAdi from Veli v 
                                                    left join Gorev g on g.Id = v.GorevId
                                                    where v.Durum = '{durum}'").OrderBy(x=>x.VeliAdiSoyadi).ToList();
        }
        static void HataKont(Veli veli)
        {
            if (veli.VeliAdiSoyadi.Replace(" ", "") == "")
                throw new Exception("Veli Adı Giriniz");

            if (veli.Telefon != null && veli.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
                throw new Exception("Telefon  Hatalı Lütfen Kontrol Ediniz.");

        }
        static DynamicParameters Parametre(Veli veli)
        {
            var param = new DynamicParameters();
            param.Add("@p0", veli.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(veli.VeliAdiSoyadi.ToLower()));
            param.Add("@p2", veli.TcKimlikNo.Replace(" ", ""));
            param.Add("@p3", veli.Telefon);
            param.Add("@p4", veli.Adres);
            param.Add("@p5", veli.Aciklama);
            param.Add("@p6", veli.KullaniciId);
            param.Add("@p7", veli.IslemTarihi);
            param.Add("@p8", veli.Durum);
            param.Add("@p9", veli.GorevId);
            return param;
        }
    }
}