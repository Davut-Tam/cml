using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciTakipMuh.Data.Facade
{
    public class NakitF 
    {
        private static string _sql;
        public static bool Ekle(Nakit nkt)
        {
            _sql = "";
            HataKont(nkt);

            if (nkt.IslemId == 7)
            {
                Banka bnk = new Banka
                {
                    Id = GenelFunctions.IdOlustur(),
                    Tarih = nkt.Tarih,
                    HesapId = nkt.HesapId,
                    GirisCikis = "Giriş",
                    IslemId = 7,
                    Tutar = nkt.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    Aciklama = "Nakit kasadan Gelen Tutar",
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = nkt.IslemTarihi,
                    NakitIslemId = nkt.Id,
                };

                BankaF.Ekle(bnk);
            }

            _sql = "INSERT INTO Nakit VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
            return Parametre(nkt).Kaydet(_sql);

        }
        public static bool Ekle(List<Nakit> nktlist, decimal tutar)
        {
            decimal listetoplami = 0;


            if (nktlist == null) throw new Exception("Taksit Seçiniz");

            foreach (var item in nktlist)
                listetoplami += item.Tutar;


            if (tutar > listetoplami) throw new Exception("Girilen Tutar Seçilen Taksitlerden Büyük olamaz Tekrar Taksit Seçiniz.");

            _sql = "INSERT INTO Nakit VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";

            var odemeplanilist = new List<OgrenciCariOdemeL>();
            foreach (var item in nktlist)
            {
                if (tutar <= 0) continue;
                if (tutar <= item.Tutar)
                    item.Tutar = tutar;

                if (Parametre(item).Kaydet(_sql))
                    odemeplanilist.Add(OgrenciOdemePlaniF.Secim(item.OgrenciOdemePlaniId));
                tutar -= item.Tutar;
            }

            if (AnaForm.GenAyr.SmsGonderme)
            {
                if (Messages.SoruHayirSeciliEvetHayir("İşlem Başarılı.\nTahsilat Bilgisi Öğrenci Velisine Sms olarak Gönderisin mi?", "Sms Bilgilendirme") != System.Windows.Forms.DialogResult.Yes) return true;
                using (var frm = new TaksitHatirlatmaSmsForm(null, odemeplanilist))
                    frm.ShowDialog();
            }






            return true;
        }

        public static bool Sil(long id)
        {
            _sql = "";
            // bankada kayıt varsa sil
            if (Secim(id).IslemId == 7)
            {
                _sql = "DELETE FROM Banka WHERE NakitId=" + id;
                Repository.Sil(_sql);
            }

            _sql = "DELETE FROM Nakit WHERE Id=" + id;
            return Repository.Sil(_sql);
        }

        public static bool Guncelle(Nakit nkt, long id)
        {
            _sql = "";
            HataKont(nkt);

            // bankada kayıt varsa
            if (Secim(id).IslemId == 7 && nkt.IslemId == 7)// önceki kayıt ve yeni  banka aktarma ise
            {
                Banka bnk = new Banka
                {
                    Tarih = nkt.Tarih,
                    HesapId = nkt.HesapId,
                    GirisCikis = "Giriş",
                    IslemId = 7,
                    Tutar = nkt.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    Aciklama = "Nakit kasadan Gelen Tutar",
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = nkt.IslemTarihi,
                    NakitIslemId = nkt.Id,
                };

                BankaF.Guncelle(bnk, BankaF.NakitIdyeGoreIdBul(nkt.Id));
            }
            else if (Secim(id).IslemId != 7 && nkt.IslemId == 7)
            {
                Banka bnk = new Banka
                {
                    Id = GenelFunctions.IdOlustur(),
                    Tarih = nkt.Tarih,
                    HesapId = nkt.HesapId,
                    GirisCikis = "Giriş",
                    IslemId = 7,
                    Tutar = nkt.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    Aciklama = "Nakit kasadan Gelen Tutar",
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = nkt.IslemTarihi,
                    NakitIslemId = nkt.Id,
                };

                BankaF.Ekle(bnk);
            }
            else if (Secim(id).IslemId == 7 && nkt.IslemId != 7)
            {
                _sql = "DELETE FROM Banka WHERE NakitId=" + id;
                Repository.Sil(_sql);
            }

            _sql = @"UPDATE Nakit SET Tarih=@p1,GirisCikis=@p2,IslemId=@p3,Tutar=@p4,OgrenciOdemePlaniId=@p5,OgrenciId=@p6,
                   PersonelId=@p7,FirmaId=@p8,HesapId=@p9,Aciklama=@p10,KullaniciId=@p11,IslemTarihi=@p12,BankaIslemId=@p13,CekIslemId=@p14 WHERE Id=" + id;

            return Parametre(nkt).Guncelle(_sql);


        }

        public static NakitL Secim(long id)
        {
            return Connections.cnn.QueryFirst<NakitL>($"SELECT * FROM viewNakitHareketListesi where  Id={id}");
        }

        public static long BankaIslemIdyeGoreIdBul(long id)
        {
            return (long)Connections.cnn.ExecuteScalar($"SELECT Id FROM Nakit where BankaIslemId={id}");
        }

        public static long CekIslemIdyeGoreIdBul(long id)
        {
            return (long)Connections.cnn.ExecuteScalar($"SELECT Id FROM Nakit where CekIslemId={id}");
        }

        public static object Liste()
        {

            var list = Connections.cnn.Query<NakitL>($"SELECT * FROM viewNakitHareketListesi");
            list = list.OrderByDescending(x => x.Tarih).ToList();

            decimal bakiye = GenelBakiye();
            foreach (var item in list)
            {
                item.Bakiye = bakiye;
                if (item.GirisCikis == "Giriş") bakiye -= item.Tutar; else bakiye += item.Tutar;

            }
            return list;


        }

        public static decimal GenelBakiye()
        {
            return (decimal)Connections.cnn.ExecuteScalar($"select (select coalesce(sum(Tutar),0) from Nakit where GirisCikis='Giriş') - (select coalesce(sum(Tutar),0) from Nakit where GirisCikis='Çıkış')");
        }

        public static NakitGirisCikis TarihArasiBakiye(DateTime trh1, DateTime trh2)
        {
            var param = new DynamicParameters();
            param.Add("@t1", trh1);
            param.Add("@t2", trh2);
            return Connections.cnn.QueryFirst<NakitGirisCikis>($@"select 
                                                                 (select coalesce(sum(Tutar),0) from Nakit where GirisCikis='Giriş' and convert(date,Tarih, 103)>=convert(date,@t1, 103) and convert(date,Tarih, 103)<=convert(date,@t2, 103)) as Giris,
                                                                 (select coalesce(sum(Tutar),0) from Nakit where GirisCikis='Çıkış' and convert(date,Tarih, 103)>=convert(date,@t1, 103) and convert(date,Tarih, 103)<=convert(date,@t2, 103)) as Cikis", param);
        }


        static void HataKont(Nakit nkt)
        {
            if (nkt.IslemId <= 0)
                throw new Exception("İşlem Seçiniz");
            if (nkt.Tarih >= DateTime.Now)
                throw new Exception("İleri Tarihe Veri Girilemez.");
            if (nkt.Tutar <= 0)
                throw new Exception("Tutar Giriniz.");
            if (nkt.Aciklama.Replace(" ", "") == "")
                throw new Exception("Açıklama Giriniz.");

            if (nkt.IslemId == 1 && (nkt.OgrenciId == 0 || nkt.OgrenciOdemePlaniId == 0))
                throw new Exception("Öğrenci Ödenecek Tahakkuku seçiniz.");
            if ((nkt.IslemId == 3 || nkt.IslemId == 4) && nkt.PersonelId == 0)
                throw new Exception("Personel Seçiniz");
            if ((nkt.IslemId == 5 || nkt.IslemId == 6) && nkt.FirmaId == 0)
                throw new Exception("Firma Seçiniz");
        }
        static DynamicParameters Parametre(Nakit nkt)
        {
            var param = new DynamicParameters();
            param.Add("@p0", nkt.Id);
            param.Add("@p1", nkt.Tarih);
            param.Add("@p2", nkt.GirisCikis);
            param.Add("@p3", nkt.IslemId);
            param.Add("@p4", nkt.Tutar);
            param.Add("@p5", nkt.OgrenciOdemePlaniId);
            param.Add("@p6", nkt.OgrenciId);
            param.Add("@p7", nkt.PersonelId);
            param.Add("@p8", nkt.FirmaId);
            param.Add("@p9", nkt.HesapId);
            param.Add("@p10", nkt.Aciklama);
            param.Add("@p11", nkt.KullaniciId);
            param.Add("@p12", nkt.IslemTarihi);
            param.Add("@p13", nkt.BankaIslemId);
            param.Add("@p14", nkt.CekIslemId);

            return param;
        }

    }
}
