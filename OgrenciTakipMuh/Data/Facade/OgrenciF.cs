using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OgrenciTakipMuh.Facade
{
    public class OgrenciF
    {
        private static string _sql;
        private static string _res;
        public static bool Ekle(Ogrenci ogr)
        {
            HataKont(ogr);
            _res = ogr.Resim == null ? "Null" : "@p13";
            _sql = $@"INSERT INTO Ogrenci VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,{_res},@p14,@p15,@p16,@p17,@p18,@p19,@p20)";
            return Parametre(ogr).Kaydet(_sql);
        }
        public static bool Guncelle(Ogrenci ogr, long id)
        {
            HataKont(ogr);
            _res = ogr.Resim == null ? "Null" : "@p16";

            _sql = $@"UPDATE Ogrenci SET TcKimlikNo=@p1,AdiSoyadi=@p2,Veli1Id=@p3,EmailAdresi=@p4,GeldigiOkul=@p5,Adres=@p6,
                                                DonemId=@p7,GrupId=@p8,SinifId=@p9,KayitTarihi=@p10,Aciklama=@p11,Durum=@p12,
                                                Resim={_res},KayitTutari=@p14,KullaniciId=@p17,IslemTarihi=@p18,OtoSms=@p19,
                                                Veli2Id=@p20 WHERE Id=" + id;

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
            prm.Add("@p3", ogr.Veli1Id);
            prm.Add("@p4", ogr.EmailAdresi);
            prm.Add("@p5", ogr.GeldigiOkul);
            prm.Add("@p6", ogr.Adres);
            prm.Add("@p7", ogr.DonemId);
            prm.Add("@p8", ogr.GrupId);
            prm.Add("@p9", ogr.SinifId);
            prm.Add("@p10", ogr.KayitTarihi);
            prm.Add("@p11", ogr.Aciklama);
            prm.Add("@p12", ogr.Durum);
            prm.Add("@p13", ogr.Resim);
            prm.Add("@p14", ogr.KayitTutari);

            prm.Add("@p15", ogr.TahakkukNo);
            prm.Add("@p16", ogr.TahakkukTutari);

            prm.Add("@p17", ogr.KullaniciId);
            prm.Add("@p18", ogr.IslemTarihi);
            prm.Add("@p19", ogr.OtoSms);
            prm.Add("@p20", ogr.Veli2Id);
            return prm;
        }

        public static List<OgrenciL> Liste(bool aktifPasif,long donemId)
        {
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where Durum='{aktifPasif}' and DonemId={donemId} order by AdiSoyadi").ToList();
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

        public static object VeliOgrenciListe(long id,long donemId)
        {
            return Connections.cnn.Query<OgrenciL>($"SELECT * FROM viewOgrenciListesi where Durum=1 and DonemId={donemId} and ( Veli1Id={id} or Veli2Id={id})").OrderBy(x=>x.AdiSoyadi);
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
            else if (ogr.Veli1Id <= 0)
                throw new Exception("Veli 1 Zorunludur");
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



        public static int TahakkukNoVer()
        {
            string yil = DateTime.Now.Year.ToString();
            string ay = DateTime.Now.Month.ToString();
            if (ay.Length == 1) ay = "0" + ay;

            try
            {
                var a = (int)Connections.cnn.ExecuteScalar($"SELECT MAX(TahakkukNo) FROM Ogrenci Where SubString(cast(TahakkukNo as nvarchar(10)),5,2)={ay} and SubString(cast(TahakkukNo as nvarchar(10)),1,4)={yil} and DonemId={AnaForm.DonemId}");
                return a + 1;
            }
            catch (Exception)
            {
                return (yil + ay + "0001").ToInt32();
            }

        }




    }
}