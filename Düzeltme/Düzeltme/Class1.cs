using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Düzeltme
{
    public class Veli : BaseEntity
    {
        public string VeliAdiSoyadi { get; set; }
        public string TcKimlikNo { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Adres { get; set; }
        public long GorevId { get; set; }
    }

    public class VeliL : Veli
    {
        public string OgrenciAdi { get; set; }
        public int OgrenciSayisi { get; set; }
    }
    public class BaseEntity
    {
        public long Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public long? KullaniciId { get; set; }
        public DateTime? IslemTarihi { get; set; }
    }


    public class Ogrenci : BaseEntity
    {
        public string TcKimlikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public long VeliId { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string EmailAdresi { get; set; }
        public string GeldigiOkul { get; set; }
        public string Adres { get; set; }
        public long DonemId { get; set; }
        public long GrupId { get; set; }
        public long SinifId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public byte[] Resim { get; set; }

        // tHkkuk
        public decimal KayitTutari { get; set; }
        public int TahakkukNo { get; set; }
        public decimal TahakkukTutari { get; set; }
    }
    public class OgrenciL : Ogrenci
    {
        public string VeliAdiSoyadi { get; set; }
        public string VeliTel1 { get; set; }
        public string VeliTel2 { get; set; }
        public string DonemAdi { get; set; }
        public string GrupAdi { get; set; }
        public string SinifAdi { get; set; }
        public string KullaniciAdi { get; set; }

        public decimal TahsilatTutari { get; set; }
        public decimal GeriIadeTutari { get; set; }
        public decimal KalanBakiye { get; set; }


    }

    public static class Connections
    {
        // SQL Server Bağlantı
        public static SqlConnection cnn = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MuhData; User ID = sa; Password=123456;");
    }

    public class OgrenciF : OgrenciL
    {
        private static string _sql;
        private static string _res;
        public static bool Ekle(Ogrenci ogr)
        {
            HataKont(ogr);
            _res = ogr.Resim == null ? "Null" : "@p17";
            _sql = $@"INSERT INTO Ogrenci VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,{_res},@p18,@p19,@p20,@p21,@p22)";
            return Parametre(ogr).Kaydet(_sql);
        }
        public static bool Guncelle(Ogrenci ogr, long id)
        {
            HataKont(ogr);
            _res = ogr.Resim == null ? "Null" : "@p17";

            _sql = $@"UPDATE Ogrenci SET TcKimlikNo=@p1,AdiSoyadi=@p2,BabaAdi=@p3,AnaAdi=@p4,VeliId=@p5,Tel1=@p6,
                                                Tel2=@p7,EmailAdresi=@p8,GeldigiOkul=@p9,Adres=@p10,DonemId=@p11,GrupId=@p12,SinifId=@p13,
                                                KayitTarihi=@p14,Aciklama=@p15,Durum=@p16,Resim={_res},KayitTutari=@p18,                                                
                                                KullaniciId=@p21,IslemTarihi=@p22 WHERE Id=" + id;

            return Parametre(ogr).Guncelle(_sql);

        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Ogrenci WHERE Id=" + id;
            return Repository.Sil(_sql, "Ödeme Planı");
        }
        static DynamicParameters Parametre(Ogrenci ogr)
        {
            var prm = new DynamicParameters();

            prm.Add("@p0", ogr.Id);
            prm.Add("@p1", ogr.TcKimlikNo.Replace(" ", ""));
            prm.Add("@p2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ogr.AdiSoyadi.ToLower()));
            prm.Add("@p3", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ogr.BabaAdi.ToLower()));
            prm.Add("@p4", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ogr.AnaAdi.ToLower()));
            prm.Add("@p5", ogr.VeliId);
            prm.Add("@p6", ogr.Tel1);
            prm.Add("@p7", ogr.Tel2);
            prm.Add("@p8", ogr.EmailAdresi);
            prm.Add("@p9", ogr.GeldigiOkul);
            prm.Add("@p10", ogr.Adres);
            prm.Add("@p11", ogr.DonemId);
            prm.Add("@p12", ogr.GrupId);
            prm.Add("@p13", ogr.SinifId);
            prm.Add("@p14", ogr.KayitTarihi);
            prm.Add("@p15", ogr.Aciklama);
            prm.Add("@p16", ogr.Durum);
            prm.Add("@p17", ogr.Resim);
            prm.Add("@p18", ogr.KayitTutari);

            prm.Add("@p19", ogr.TahakkukNo);
            prm.Add("@p20", ogr.TahakkukTutari);

            prm.Add("@p21", ogr.KullaniciId);
            prm.Add("@p22", ogr.IslemTarihi);
            return prm;
        }

        public static IEnumerable<OgrenciL> Liste(bool aktifPasif)
        {
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where Durum='{aktifPasif}' order by AdiSoyadi");
        }



        public static object HicOdemeYapmayanOgrenciListesi(long donemId, long grupId, long SinifId)
        {
            var grup = grupId != 0 ? $" AND GrupId={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND SinifId={ SinifId}" : "";
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where DonemId={donemId} AND Durum=1  and KayitTutari>0 and TahsilatTutari=0 {grup}{sinif} ORDER BY GrupAdi,SinifAdi,AdiSoyadi");
        }

        public static object OdemesiTamamlananlar(long donemId, long grupId, long SinifId)
        {
            var grup = grupId != 0 ? $" AND GrupId={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND SinifId={ SinifId}" : "";
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where DonemId={donemId} AND Durum=1   AND TahakkukTutari>0 AND KalanBakiye<=0 {grup}{sinif} ORDER BY GrupAdi,SinifAdi,AdiSoyadi");
        }

        public static object TahakkukYapilmayanlar(long donemId, long grupId, long SinifId)
        {
            var grup = grupId != 0 ? $" AND GrupId={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND SinifId={ SinifId}" : "";
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where  DonemId={donemId} AND Durum=1  and TahakkukTutari=0 {grup}{sinif} ORDER BY GrupAdi,SinifAdi,AdiSoyadi");
        }


        public static object OdemesiTamamlanmayanlar(long donemId, long grupId, long SinifId)
        {
            var grup = grupId != 0 ? $" AND GrupId={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND SinifId={ SinifId}" : "";
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where DonemId={donemId} AND Durum=1  AND TahakkukTutari>0 AND KalanBakiye>0 {grup}{sinif} ORDER BY GrupAdi,SinifAdi,AdiSoyadi");
        }





        public static int OdemesiTamamlananlarSayisi(long donemId)
        {
            return (int)Connections.cnn.ExecuteScalar($"SELECT Count(*) FROM viewOgrenciListesi where  DonemId={donemId}  AND Durum=1 AND KalanBakiye<=0");
        }

        public static int HicOdemeYapmayanlarinSayisi(long donemId)
        {
            return (int)Connections.cnn.ExecuteScalar($"SELECT Count(*) FROM viewOgrenciListesi where  DonemId={donemId} AND Durum=1 AND  KayitTutari>0 and TahsilatTutari=0");
        }
        public static object VeliOgrenciListe(long id)
        {
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where Durum=1 and VeliId={id} order by Id desc");
        }
        public static OgrenciL Secim(long id)
        {
            return Connections.cnn.QueryFirstOrDefault<OgrenciL>($"SELECT * FROM viewOgrenciListesi where Id={id}");
        }
        public static void HataKont(Ogrenci ogr)
        {
            if (ogr.AdiSoyadi.Replace(" ", "") == "")
                throw new Exception("Öğrenci Adı Giriniz");
            else if (ogr.TcKimlikNo == "")
                throw new Exception("Tc Giriniz");
            else if (ogr.TcKimlikNo.Replace(" ", "").Length != 11)
                throw new Exception("Tc Hatalı!");
            else if (ogr.VeliId <= 0)
                throw new Exception("Öğrenciye Veli Tanımlayınız");
            else if (ogr.GrupId <= 0)
                throw new Exception("Grup Giriniz");
            else if (ogr.SinifId <= 0)
                throw new Exception("Sınıf Seçiniz");
            else if (ogr.KayitTutari < 0)
                throw new Exception("Kayıt Tutarı Hatalı (Eksi Değer)");
            else if (ogr.KayitTarihi == null && ogr.KayitTarihi.Date > DateTime.Today.Date)
                throw new Exception("Tarih Hatalı");
        }
    }



    public class OgrenciTahakkukF : Ogrenci
    {

        public static bool TahakkukOlustur(long ogrenciId, decimal kayitTutari, int tahakkukNo)
        {
            //HataKont(thk);

            var prm = new DynamicParameters();
            prm.Add("@p0", tahakkukNo);
            prm.Add("@p1", kayitTutari);

            if (Connections.cnn.Execute($"UPDATE Ogrenci Set TahakkukNo=@p0,TahakkukTutari=@p1 Where Id={ogrenciId}", prm) > 0)
                return true;
            else
                return false;
        }



        public static bool Sil(long id)
        {

            if (Connections.cnn.Execute("DELETE FROM OgrenciTahakkuk WHERE Id=" + id) > 0)
                return true;
            else
                return false;


        }



 

        public class VeliF : VeliL
        {
            private static string _sql;
            public static bool Ekle(Veli veli)
            {
                HataKont(veli);
                _sql = "INSERT INTO Veli VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
                return Parametre(veli).Kaydet(_sql);
            }
            public static bool Guncelle(Veli veli, long id)
            {
                HataKont(veli);
                _sql = "UPDATE Veli SET VeliAdiSoyadi=@p1,TcKimlikNo=@p2,Tel1=@p3,Tel2=@p4,Adres=@p5,Aciklama=@p6,KullaniciId=@p7,IslemTarihi=@p8,Durum=@p9 WHERE Id=" + id;
                return Parametre(veli).Guncelle(_sql);


            }
            public static bool Sil(long id)
            {
                _sql = "DELETE FROM Veli WHERE Id=" + id;
                return Repository.Sil(_sql, "Öğrenciler");
            }
            public static VeliL Secim(long id)
            {
                return Connections.cnn.QueryFirst<VeliL>("Select *, (select count(*) from Ogrenci where VeliId=v.Id) as 'OgrenciSayisi' from Veli v WHERE Id=" + id);
            }
            public static IEnumerable<VeliL> Liste()
            {
                return Connections.cnn.Query<VeliL>($"Select *, (select count(*) from Ogrenci where VeliId=v.Id) as 'OgrenciSayisi' from Veli v  order by VeliAdiSoyadi");
            }
            static void HataKont(Veli veli)
            {
                if (veli.VeliAdiSoyadi.Replace(" ", "") == "")
                    throw new Exception("Veli Adı Giriniz");
            }
            static DynamicParameters Parametre(Veli veli)
            {
                var param = new DynamicParameters();
                param.Add("@p0", veli.Id);
                param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(veli.VeliAdiSoyadi.ToLower()));
                param.Add("@p2", veli.TcKimlikNo);
                param.Add("@p3", veli.Tel1);
                param.Add("@p4", veli.Tel2);
                param.Add("@p5", veli.Adres);
                param.Add("@p6", veli.Aciklama);
                param.Add("@p7", veli.KullaniciId);
                param.Add("@p8", veli.IslemTarihi);
                param.Add("@p9", veli.Durum);
                param.Add("@p10", veli.GorevId);
                return param;
            }
        }

      
    }
    public static class Repository
    {

        public static bool Kaydet(this DynamicParameters prm, string sql)
        {
            try
            {
                if (Connections.cnn.Execute(sql, prm) > 0)

                    return true;

                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new Exception("Mükerrer Kayıt Hatası");
                else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");

            }


        }

        public static bool Guncelle(this DynamicParameters prm, string sql)
        {
            try
            {
                if (Connections.cnn.Execute(sql, prm) > 0)

                    return true;

                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new Exception("Mükerrer Kayıt Hatası");
                else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");
            }


        }

        public static bool Sil(string sql, params string[] prm)
        {

            try
            {
                if (Connections.cnn.Execute(sql) > 0)

                    return true;

                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {

                    throw new Exception("Bu Kaydın Başka Tablolarda Bağlı işlemleri olduğundan öncelikle bu Kayıtların Silinmesi Gerekiyor.");
                }

                else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");
            }


        }





    }
}
