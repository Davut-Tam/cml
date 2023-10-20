using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    class BankaHesapF
    {
        private static string _sql;
        public static bool Ekle(BankaHesap hsp)
        {
            HataKont(hsp);
            _sql = "INSERT INTO BankaHesap VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            return Parametre(hsp).Kaydet(_sql);
  
        }
        //   
        public static bool Guncelle(BankaHesap hsp, long id)
        {
            HataKont(hsp);
            _sql = "UPDATE BankaHesap SET BankaAdi=@p1,SubeAdi=@p2,IbanNo=@p3,Durum=@p4,Aciklama=@p5,KullaniciId=@p6,IslemTarihi=@p7,HesapAdi=@p8 WHERE Id=" + id;
            return Parametre(hsp).Guncelle(_sql);
        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM BankaHesap WHERE Id=" + id;
            return Repository.Sil(_sql,"Bankalar");
        }

        public static object Liste(bool durum)
        {
            return Connections.cnn.Query<BankaHesapL>($@"SELECT bh.Id,bh.HesapAdi,bh.BankaAdi,bh.SubeAdi,bh.IbanNo,bh.IslemTarihi,bh.KullaniciId,
                                                    (select coalesce(sum(tutar), 0) from Banka where GirisCikis = 'Giriş' and HesapId = bh.Id) -
                                                    (select coalesce(sum(tutar), 0) from Banka where GirisCikis = 'Çıkış' and HesapId = bh.Id) as Bakiye,
                                                    bh.Aciklama FROM BankaHesap bh where bh.Durum ='{durum}' order by bh.Id");
        }


        public static BankaHesap Secim(long id)
        {
            return Connections.cnn.QueryFirst<BankaHesap>("SELECT * FROM BankaHesap WHERE Id=" + id);
        }
        static void HataKont(BankaHesap hsp)
        {
            if (hsp.HesapAdi.Replace(" ", "") == "")
                throw new Exception("Hesap Adı Giriniz");
            if (hsp.BankaAdi.Replace(" ", "") == "")
                throw new Exception("Banka Adı Giriniz");
            if (hsp.SubeAdi.Replace(" ", "") == "")
                throw new Exception("Şube Adı Giriniz");
            if (hsp.IbanNo.Replace(" ", "") == "")
                throw new Exception("Iban no Giriniz");
            if (hsp.IbanNo.Replace(" ", "").Length != 26)
                throw new Exception("Iban no Hatalı");
        }
        static DynamicParameters Parametre(BankaHesap hsp)
        {
            var param = new DynamicParameters();
            param.Add("@p0", hsp.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(hsp.BankaAdi.ToLower()));
            param.Add("@p2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(hsp.SubeAdi.ToLower())); 
            param.Add("@p3", hsp.IbanNo);
            param.Add("@p4", hsp.Durum);
            param.Add("@p5", hsp.Aciklama);
            param.Add("@p6", hsp.KullaniciId);
            param.Add("@p7", hsp.IslemTarihi);
            param.Add("@p8", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(hsp.HesapAdi.ToLower()));
            return param;
        }
    }
}