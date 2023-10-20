using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    public class RolF
    {

        private static string _sql;


        public static bool Ekle(List<RolDetay> rolDetay, Rol rol)
        {
            HataKont(rol);
            _sql = "INSERT INTO RolDetay VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
            long YeniId = GenelFunctions.IdOlustur();
            foreach (var item in rolDetay)
            {
                item.Id = YeniId;
                item.RolId = rol.Id;
                Parametre(item).Kaydet(_sql);
                YeniId++;
            }

            _sql = "INSERT INTO Rol VALUES (@p0,@p1,@p2,@p3,@p4)";
            return Parametre(rol).Kaydet(_sql);
        }

        public static bool Guncelle(List<RolDetay> rolDetay, Rol rol, long id)
        {
            HataKont(rol);


            foreach (var item in rolDetay)
            {
                _sql = @"UPDATE RolDetay SET MenuId=@p2,Gorebilir=@p3,Ekleyebilir=@p4,Guncelleyebilir=@p5,Silebilir=@p6  WHERE Id=" + item.Id;
                Parametre(item).Guncelle(_sql);
            }

            _sql = @"UPDATE Rol SET RolAdi=@p1,Aciklama=@p2,IslemTarihi=@p3,KullaniciId=@p4  WHERE Id=" + id;
            return Parametre(rol).Guncelle(_sql);


        }

        public static bool Sil(long id)
        {
            if (RolKullailmismi(id))
                throw new Exception("Bu Rol Kullanıcılarda Tanımlı olduğu için silinemez. Önce Kullanıcılardan Bu Rolün Silinmesi Gerekiyor");
            if (Repository.Sil("DELETE FROM Rol WHERE Id=" + id))
                return Repository.Sil("DELETE From RolDetay  WHERE RolId=" + id);
            else
                return false;
        }

        public static object Liste()
        {
            return Connections.cnn.Query<Rol>(@"Select * From Rol order by Id");
        }

 
        public static RolDetay Kontroller(object menuId)
        {
            return Connections.cnn.QueryFirstOrDefault<RolDetay>($@"Select Gorebilir,Ekleyebilir,Guncelleyebilir,Silebilir From RolDetay Where RolId={AnaForm.RolId} and MenuId='{menuId}'");
        }

        public static object RolDetayBosListe()
        {
            return Connections.cnn.Query<RolDetay>(@"select Id as MenuId,MenuAdi,0 as Gorebilir,2 as Ekleyebilir,2 as Guncelleyebilir,2 as Silebilir from MenuListesi order by MenuAdi");
        }

        public static object RolDetayListesi(long rolId)
        {
            return Connections.cnn.Query<RolDetay>($@"select rd.Id,m.Id as MenuId,m.MenuAdi,rd.Gorebilir,rd.Ekleyebilir,rd.Guncelleyebilir,rd.Silebilir from MenuListesi m
                                                    left join RolDetay rd on rd.MenuId=m.Id Where rd.RolId='{rolId}' order by m.MenuAdi ");
        }

        public static Rol Secim(long id)
        {
           return Connections.cnn.QueryFirstOrDefault<Rol>("SELECT * FROM Rol WHERE Id=" + id);
        }

        public static bool RolKullailmismi(long id)
        {
            var a= Connections.cnn.QueryFirstOrDefault("SELECT * FROM Kullanici WHERE RolId=" + id);
            if (a == null)
                return false;
            else
                return true;
        }

        static void HataKont(Rol rol)
        {
            if (rol.RolAdi.Replace(" ", "") == "")
                throw new Exception("Rol Adı Giriniz");
        }
        static DynamicParameters Parametre(Rol rol)
        {
            var param = new DynamicParameters();
            param.Add("@p0", rol.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rol.RolAdi.ToLower()));
            param.Add("@p2", rol.Aciklama);
            param.Add("@p3", rol.IslemTarihi);
            param.Add("@p4", rol.KullaniciId);

            return param;
        }

        static DynamicParameters Parametre(RolDetay rolDetay)
        {

            var param = new DynamicParameters();
            param.Add("@p0", rolDetay.Id);
            param.Add("@p1", rolDetay.RolId);
            param.Add("@p2", rolDetay.MenuId);
            param.Add("@p3", rolDetay.Gorebilir);
            param.Add("@p4", rolDetay.Ekleyebilir);
            param.Add("@p5", rolDetay.Guncelleyebilir);
            param.Add("@p6", rolDetay.Silebilir);

            return param;
        }
    }
}
