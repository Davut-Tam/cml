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
    public class BankaF 
    {
        private static string _sql;


        public static bool Ekle(Banka bnk)
        {
            HataKont(bnk);

            // nakite aktarma işlemi
            if (bnk.IslemId == 10)
            {
                Nakit nkt = new Nakit
                {
                    Id = GenelFunctions.IdOlustur(),
                    Tarih = bnk.Tarih,
                    GirisCikis = "Giriş",
                    IslemId = 11,
                    Tutar = bnk.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    HesapId = bnk.HesapId,
                    Aciklama = BankaHesapF.Secim(bnk.HesapId).BankaAdi + " " + BankaHesapF.Secim(bnk.HesapId).SubeAdi + " / " + BankaHesapF.Secim(bnk.HesapId).IbanNo + " Nolu Hesaptan Gelen Tutar",
                    KullaniciId = bnk.KullaniciId,
                    IslemTarihi = bnk.IslemTarihi,
                    BankaIslemId = bnk.Id,
                    CekIslemId = null
                };
                NakitF.Ekle(nkt);
            }


            _sql = "INSERT INTO Banka VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
            if (bnk.IslemId == 8)// virman ise 
                ParametreVirman(bnk).Kaydet(_sql);


            return Parametre(bnk).Kaydet(_sql);

        }

        public static bool Ekle(List<Banka> nktlist, decimal tutar)
        {
            decimal listetoplami = 0;


            if (nktlist == null) throw new Exception("Taksit Seçiniz");

            foreach (var item in nktlist)
                listetoplami += item.Tutar;

            

            if (tutar > listetoplami) throw new Exception("Girilen Tutar Seçilen Taksitlerden Büyük olamaz Tekrar Taksit Seçiniz.");

            _sql = "INSERT INTO Banka VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
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
            // Nakitte kayıt varsa sil
            if (Secim(id).IslemId == 10)
            {
                _sql = "DELETE FROM Nakit WHERE BankaIslemId=" + id;
                Repository.Sil(_sql);
            }


            // Hesaplar arası virmansa  sil
            if (Secim(id).IslemId == 8)
            {
                _sql = "DELETE FROM Banka WHERE Id=" + (id + 1);
                Repository.Sil(_sql);
            }

            _sql = "DELETE FROM Banka WHERE Id=" + id;
            return Repository.Sil(_sql);

        }

        public static bool Guncelle(Banka bnk, long id)
        {
            HataKont(bnk);

            #region Nakite Aktarma İşlemleri Kontrolü
            // Nakitten kayıt varsa
            if (Secim(id).IslemId == 10 && bnk.IslemId == 10)// önceki kayıt ve yeni  nakit aktarma ise
            {
                Nakit nkt = new Nakit
                {

                    Tarih = bnk.Tarih,
                    GirisCikis = "Giriş",
                    IslemId = 11,
                    Tutar = bnk.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    HesapId = 0,
                    Aciklama = BankaHesapF.Secim(bnk.HesapId).BankaAdi + " " + BankaHesapF.Secim(bnk.HesapId).SubeAdi + " / " + BankaHesapF.Secim(bnk.HesapId).IbanNo + " Nolu Hesaptan Gelen Tutar",
                    KullaniciId = bnk.OgrenciId,
                    IslemTarihi = bnk.IslemTarihi,
                    BankaIslemId = bnk.Id,
                    CekIslemId = null
                };

                NakitF.Guncelle(nkt, NakitF.BankaIslemIdyeGoreIdBul(bnk.Id));
            }
            else if (Secim(id).IslemId != 10 && bnk.IslemId == 10)// 
            {
                Nakit nkt = new Nakit
                {

                    Tarih = bnk.Tarih,
                    GirisCikis = "Giriş",
                    IslemId = 11,
                    Tutar = bnk.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    HesapId = 0,
                    Aciklama = BankaHesapF.Secim(bnk.HesapId).BankaAdi + " " + BankaHesapF.Secim(bnk.HesapId).SubeAdi + " / " + BankaHesapF.Secim(bnk.HesapId).IbanNo + " Nolu Hesaptan Gelen Tutar",
                    KullaniciId = bnk.OgrenciId,
                    IslemTarihi = bnk.IslemTarihi,
                    BankaIslemId = bnk.Id,
                    CekIslemId = null
                };

                NakitF.Ekle(nkt);
            }
            else if (Secim(id).IslemId == 10 && bnk.IslemId != 10)
                Repository.Sil("DELETE FROM Nakit WHERE BankaIslemId=" + id);
            #endregion

            #region Virman İşlemleri Kontrolü
            if (Secim(id).IslemId == 8 && bnk.IslemId == 8)
            {
                // eski ve yeni işlem virmansa
                _sql = @"UPDATE Banka SET Tarih=@p1,HesapId=@p2,GirisCikis=@p3,IslemId=@p4,Tutar=@p5,OgrenciOdemePlaniId=@p6,OgrenciId=@p7,
                                                PersonelId=@p8,FirmaId=@p9,Aciklama=@p10,KullaniciId=@p11,IslemTarihi=@p12,NakitIslemId=@p13 WHERE Id=" + (id + 1);
                ParametreVirman(bnk).Guncelle(_sql);

            }
            else if (Secim(id).IslemId != 8 && bnk.IslemId == 8)
            {
                _sql = "INSERT INTO Banka VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
                ParametreVirman(bnk).Kaydet(_sql);
            }



            else if (Secim(id).IslemId == 8 && bnk.IslemId != 8)
            {
                Repository.Sil("DELETE FROM Banka WHERE Id=" + (id + 1));
            }


            #endregion
            _sql = @"UPDATE Banka SET Tarih=@p1,HesapId=@p2,GirisCikis=@p3,IslemId=@p4,Tutar=@p5,OgrenciOdemePlaniId=@p6,OgrenciId=@p7,
                                                PersonelId=@p8,FirmaId=@p9,Aciklama=@p10,KullaniciId=@p11,IslemTarihi=@p12,NakitIslemId=@p13 WHERE Id=" + id;

            return Parametre(bnk).Guncelle(_sql);
        }

        public static BankaL Secim(long id)
        {
            return Connections.cnn.QueryFirst<BankaL>($"SELECT * FROM viewBankaHareketListesi where  Id={id}");
        }
        public static long NakitIdyeGoreIdBul(long id)
        {
            return (long)Connections.cnn.ExecuteScalar($"SELECT Id FROM Banka where  NakitIslemId={id}");
        }
        public static long CekIslemIdyeGoreIdBul(long id)
        {
            return (long)Connections.cnn.ExecuteScalar($"SELECT Id FROM Banka where  CekIslemId={id}");
        }


        public static object Liste(long hesapId)
        {
            var list = Connections.cnn.Query<BankaL>($"SELECT * FROM viewBankaHareketListesi");
            list = ((List<BankaL>)list).Where(x => x.HesapId == hesapId).OrderByDescending(x => x.Tarih).ToList();


            decimal bakiye = GenelBakiye(hesapId);
            foreach (var item in list)
            {
                item.Bakiye = bakiye;
                if (item.GirisCikis == "Giriş") bakiye -= item.Tutar; else bakiye += item.Tutar;

            }
            return list;

        }

        public static decimal GenelBakiye(long hesapId)
        {
            return (decimal)Connections.cnn.ExecuteScalar($"select (select coalesce(sum(Tutar),0) from Banka where HesapId={hesapId} and GirisCikis='Giriş') - (select coalesce(sum(Tutar),0) from Banka where HesapId={hesapId} and  GirisCikis='Çıkış')");
        }

        public static BankaGirisCikis TarihArasiBakiye(long hesapId, DateTime trh1, DateTime trh2)
        {
            var param = new DynamicParameters();
            param.Add("@t1", trh1);
            param.Add("@t2", trh2);
            return Connections.cnn.QueryFirst<BankaGirisCikis>($@"select 
                                                                 (select coalesce(sum(Tutar),0) from Banka where HesapId={hesapId} and  GirisCikis='Giriş' and convert(date,Tarih, 103)>=convert(date,@t1, 103) and convert(date,Tarih, 103)<=convert(date,@t2, 103)) as Giris,
                                                                 (select coalesce(sum(Tutar),0) from Banka where HesapId={hesapId} and  GirisCikis='Çıkış' and convert(date,Tarih, 103)>=convert(date,@t1, 103) and convert(date,Tarih, 103)<=convert(date,@t2, 103)) as Cikis", param);
        }


        static void HataKont(Banka bnk)
        {
            if (bnk.IslemId <= 0)
                throw new Exception("İşlem Seçiniz");
            if (bnk.Tarih >= DateTime.Now)
                throw new Exception("İleri Tarihe Veri Girilemez.");
            if (bnk.IslemId == 1 && (bnk.OgrenciId == 0 || bnk.OgrenciOdemePlaniId == 0))
                throw new Exception("Öğrenci Ödenecek Tahakkuku seçiniz.");
            if ((bnk.IslemId == 3 || bnk.IslemId == 4) && bnk.PersonelId == 0)
                throw new Exception("Personel Seçiniz");
            if ((bnk.IslemId == 5 || bnk.IslemId == 6) && bnk.FirmaId == 0)
                throw new Exception("Firma Seçiniz.");
            if (bnk.Tutar <= 0)
                throw new Exception("Tutar Giriniz.");
            if (bnk.Aciklama.Replace(" ", "") == "")
                throw new Exception("Açıklama Giriniz.");



        }
        static DynamicParameters Parametre(Banka bnk)
        {
            var param = new DynamicParameters();
            param.Add("@p0", bnk.Id);
            param.Add("@p1", bnk.Tarih);
            param.Add("@p2", bnk.HesapId);
            param.Add("@p3", bnk.GirisCikis);
            param.Add("@p4", bnk.IslemId);
            param.Add("@p5", bnk.Tutar);
            param.Add("@p6", bnk.OgrenciOdemePlaniId);
            param.Add("@p7", bnk.OgrenciId);
            param.Add("@p8", bnk.PersonelId);
            param.Add("@p9", bnk.FirmaId);
            param.Add("@p10", bnk.Aciklama);
            param.Add("@p11", bnk.KullaniciId);
            param.Add("@p12", bnk.IslemTarihi);
            param.Add("@p13", bnk.NakitIslemId);
            param.Add("@p14", bnk.CekIslemId);
            return param;
        }
        static DynamicParameters ParametreVirman(Banka bnk)
        {
            var param = new DynamicParameters();
            param.Add("@p0", bnk.Id + 1);
            param.Add("@p1", bnk.Tarih);
            param.Add("@p2", bnk.VirmanHesapId);
            param.Add("@p3", "Giriş");
            param.Add("@p4", 9);
            param.Add("@p5", bnk.Tutar);
            param.Add("@p6", 0);
            param.Add("@p7", 0);
            param.Add("@p8", 0);
            param.Add("@p9", 0);
            param.Add("@p10", BankaHesapF.Secim(bnk.HesapId).BankaAdi + " " + BankaHesapF.Secim(bnk.HesapId).SubeAdi + " / " + BankaHesapF.Secim(bnk.HesapId).IbanNo + " Nolu Hesaptan Gelen Tutar");
            param.Add("@p11", bnk.KullaniciId);
            param.Add("@p12", bnk.IslemTarihi);
            param.Add("@p13", 0);
            param.Add("@p14", null);
            return param;
        }


    }
}
