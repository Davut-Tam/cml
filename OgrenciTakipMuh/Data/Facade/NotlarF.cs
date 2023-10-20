using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.Facade
{
    public class NotlarF
    {
        private static string _sql;
        public static bool Ekle(Notlar nt)
        {
            _sql = "INSERT INTO Notlar VALUES (@p0,@p1,@p2,@p3,@p4,@p5)";
            return Parametre(nt).Kaydet(_sql);
        }

        public static bool Guncelle(List<Notlar> notList)
        {

            Connections.cnn.Execute("Delete From Notlar Where OgrenciId=" + notList[0].OgrenciId);

            foreach (var item in notList)
                if (item.Aciklama.Replace(" ", "") != "")
                    Ekle(item);

            return true;
        }


        public static object Liste(long ogrenciId)
        {
            return Connections.cnn.Query<Notlar>($@"SELECT  * FROM Notlar Where OgrenciId={ogrenciId} ORDER BY Tarih");
        }

        static DynamicParameters Parametre(Notlar nt)
        {
            var param = new DynamicParameters();
            param.Add("@p0", nt.Id);
            param.Add("@p1", nt.Tarih);
            param.Add("@p2", nt.OgrenciId);
            param.Add("@p3", nt.Aciklama);
            param.Add("@p4", nt.KullaniciId);
            param.Add("@p5", nt.IslemTarihi);
            return param;
        }
    }
}
