using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    class FirmaF
    {
        private static string _sql;
        public static bool Ekle(Firma firma)
        {
            HataKont(firma);
            _sql = "INSERT INTO Firma VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
            return Parametre(firma).Kaydet(_sql);
        }
        public static bool Guncelle(Firma firma, long id)
        {
            HataKont(firma);
            _sql = "UPDATE Firma SET FirmaAdi=@p1,VergiTcKimlikNo=@p2,VergiDairesi=@p3,Tur=@p4,Telefon=@p5,BankaAdi=@p6,IbanNo=@p7,Durum=@p8,Adres=@p9,Aciklama=@p10,KullaniciId=@p11,IslemTarihi=@p12 WHERE Id=" + id;
            return Parametre(firma).Guncelle(_sql);

        }
        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Firma WHERE Id=" + id;
            return Repository.Sil(_sql, "Faturalar");
        }
        public static FirmaL Secim(long id)
        {
            return Connections.cnn.QueryFirstOrDefault<FirmaL>(@"Select f.*,
                                                     COALESCE((select ToplamCiro from viewFirmaCiroListesi where FirmaId = f.Id and BelgeTuru = 'Alış'), 0) as ToplamAlis,
                                                     COALESCE((select ToplamCiro from viewFirmaCiroListesi where FirmaId = f.Id and BelgeTuru = 'Satış'),0) as ToplamSatis,
                                                     coalesce(Ft.ToplamCikan, 0) as ToplamOdeme,coalesce(Ft.ToplamGiren, 0) as ToplamTahsilat
                                                     from Firma f
                                                     left
                                                     join FirmaTumOdemeListesiGroupBy Ft on ft.firmaId = f.Id where f.Id=" + id);
        }
        public static object Liste(bool durum)
        {
            return Connections.cnn.Query<FirmaL>($@"Select f.*,
                                                     COALESCE((select ToplamCiro from viewFirmaCiroListesi where FirmaId=f.Id and BelgeTuru='Alış'),0) as ToplamAlis,
                                                     COALESCE((select ToplamCiro from viewFirmaCiroListesi where FirmaId=f.Id and BelgeTuru='Satış'),0) as ToplamSatis,
                                                     coalesce(Ft.ToplamCikan,0) as ToplamOdeme,coalesce(Ft.ToplamGiren,0) as ToplamTahsilat
                                                     from Firma f
                                                     left join FirmaTumOdemeListesiGroupBy Ft on ft.firmaId=f.Id where  f.Durum='{durum}' order by f.Id desc");
        }
        static void HataKont(Firma firma)
        {
            if (firma.FirmaAdi.Replace(" ", "") == "")
                throw new Exception("Firma Adı Giriniz");
            if (firma.Telefon != null && firma.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
                throw new Exception("Telefon 1 Hatalı Lütfen Kontrol Ediniz.");

            if (firma.Tur=="Gerçek Kişi" && firma.VergiTcKimlikNo.Length!=11 )
                throw new Exception("Tc Kimlik No Hatalı");

            if (firma.Tur == "Tüzel Kişi" && firma.VergiTcKimlikNo.Length != 10)
                throw new Exception("Vergi No Hatalı");

        }
        static DynamicParameters Parametre(Firma firma)
        {
            var param = new DynamicParameters();
            param.Add("@p0", firma.Id);
            param.Add("@p1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firma.FirmaAdi.ToLower()));
            param.Add("@p2", firma.VergiTcKimlikNo);
            param.Add("@p3", firma.VergiDairesi);
            param.Add("@p4", firma.Tur);
            param.Add("@p5", firma.Telefon);
            param.Add("@p6", firma.BankaAdi);
            param.Add("@p7", firma.IbanNo);
            param.Add("@p8", firma.Durum);
            param.Add("@p9", firma.Adres);
            param.Add("@p10", firma.Aciklama);
            param.Add("@p11", firma.KullaniciId);
            param.Add("@p12", firma.IslemTarihi);
            return param;
        }


    }
}