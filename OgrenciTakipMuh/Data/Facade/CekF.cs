using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.Facade
{
    public class CekF 
    {
        private static string _sql;


        public static bool Ekle(Cek ck)
        {

            HataKont(ck);
            _sql = @"INSERT INTO Cek (Id,Tur,CekNo,CekBanka,VadeTarihi,Tutar,GirisTarihi,GirisIslemId,GirisOgrenciId,OgrenciOdemePlaniId,GirisfirmaId,GirisPersonelId,
                    GirisAciklama,GirisKullaniciId,GirisIslemTarihi,CikisYapildi) VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)";
            return GirisParametre(ck).Kaydet(_sql);

        }

        public static bool Ekle(List<Cek> ceklist, decimal tutar)
        {
            decimal listetoplami = 0;

            if (ceklist == null) throw new Exception("Taksit Seçiniz");



            foreach (var item in ceklist)
                listetoplami += item.Tutar;
            

            if (tutar > listetoplami) throw new Exception("Girilen Tutar Seçilen Taksitlerden Büyük olamaz Tekrar Taksit Seçiniz.");

            _sql = @"INSERT INTO Cek (Id,Tur,CekNo,CekBanka,VadeTarihi,Tutar,GirisTarihi,GirisIslemId,GirisOgrenciId,OgrenciOdemePlaniId,GirisfirmaId,GirisPersonelId,
                    GirisAciklama,GirisKullaniciId,GirisIslemTarihi,CikisYapildi) VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)";

            var odemeplanilist = new List<OgrenciCariOdemeL>();
            foreach (var item in ceklist)
            {
                if (tutar <= 0) continue;

                if (tutar <= item.Tutar)
                    item.Tutar = tutar;

                if (GirisParametre(item).Kaydet(_sql))
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

        public static bool Guncelle(Cek ck, long id)
        {
            HataKont(ck);

            Cek EskiCek = Secim(id);
            Cek YeniCek = ck;

            if (EskiCek.CikisYapildi)
            {
                #region Nakitten Güncelleme İşlemleri
                if (EskiCek.CikisIslemId == 8)
                {
                    Nakit nkt = new Nakit
                    {
                        Tarih = EskiCek.CikisTarihi,
                        GirisCikis = "Giriş",
                        IslemId = 12,
                        Tutar = YeniCek.Tutar,
                        OgrenciOdemePlaniId = 0,
                        OgrenciId = 0,
                        PersonelId = 0,
                        FirmaId = 0,
                        HesapId = 0,
                        Aciklama = $"{YeniCek.Tur} No: {YeniCek.CekNo} Vade Tarihi: {YeniCek.VadeTarihi} Evrağın Nakite Çevrilerek Nakit Kasaya Aktarılması ",
                        KullaniciId = EskiCek.CikisKullaniciId,
                        IslemTarihi = EskiCek.CikisIslemTarihi,
                        CekIslemId = EskiCek.Id,

                    };
                    if (!NakitF.Guncelle(nkt, NakitF.CekIslemIdyeGoreIdBul(id)))
                        throw new Exception("Nakit Kasayadaki işlem Güncellenemediği için işlem Başarısız");
                }
                #endregion

                #region Bankadan Güncelleme İşlemleri
                if (EskiCek.CikisIslemId == 9)
                {

                    Banka bnk = new Banka
                    {

                        Tarih = EskiCek.CikisTarihi,
                        HesapId = EskiCek.CikisHesapId,
                        GirisCikis = "Giriş",
                        IslemId = 15,
                        Tutar = YeniCek.Tutar,
                        OgrenciOdemePlaniId = 0,
                        OgrenciId = 0,
                        PersonelId = 0,
                        FirmaId = 0,
                        Aciklama = $"{YeniCek.Tur} No: {YeniCek.CekNo} Vade Tarihi: {YeniCek.VadeTarihi.Date} Evrağın Nakite Çevrilerek Bankaya Aktarılması",
                        KullaniciId = EskiCek.CikisKullaniciId,
                        IslemTarihi = EskiCek.CikisTarihi,
                        NakitIslemId = 0,
                        CekIslemId = EskiCek.Id

                    };

                    if (!BankaF.Guncelle(bnk, BankaF.CekIslemIdyeGoreIdBul(id)))
                        throw new Exception("Bankadaki Kayıt Güncellenemediği için işlem Başarısız");
                }

                #endregion
            }

            HataKont(ck);
            _sql = @"UPDATE Cek SET Tur=@p1,CekNo=@p2,CekBanka=@p3,VadeTarihi=@p4,Tutar=@p5,GirisTarihi=@p6,
                GirisIslemId=@p7,GirisOgrenciId=@p8,OgrenciOdemePlaniId=@p9,
                GirisfirmaId=@p10,GirisPersonelId=@p11,GirisAciklama=@p12,GirisKullaniciId=@p13,GirisIslemTarihi=@p14,CikisYapildi=@p15 Where Id=" + id;
            return GirisParametre(ck).Guncelle(_sql);

        }

        public static bool Sil(long id)
        {
            if (Secim(id).CikisYapildi)
                throw new Exception("Bu Çeki Silebilmeniz İçin Önce Evrağın Çıkışını Silmeniz gerekiyor.");


            return Repository.Sil("DELETE FROM Cek WHERE Id=" + id);

        }

        public static bool CikisGuncelleVeSil(Cek ck, long id, bool guncelle)
        {
            if (guncelle)
                HataKont(ck);
            Cek Eski = Secim(id);
            Cek Yeni = ck;

            #region Nakitten Güncelleme İşlemleri
            if (Eski.CikisIslemId == 8 && Yeni.CikisIslemId == 8 && guncelle == true)
            {
                Nakit nkt = new Nakit
                {
                    Tarih = Yeni.CikisTarihi,
                    GirisCikis = "Giriş",
                    IslemId = 12,
                    Tutar = Yeni.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    HesapId = 0,
                    Aciklama = $"{Eski.Tur} No: {Eski.CekNo} Vade Tarihi: {Eski.VadeTarihi.ToShortDateString()} Evrağın Nakite Çevrilerek Bankaya Aktarılması",
                    KullaniciId = Yeni.CikisKullaniciId,
                    IslemTarihi = Yeni.CikisIslemTarihi,
                    CekIslemId = Yeni.Id,

                };
                if (!NakitF.Guncelle(nkt, NakitF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Nakit Kasayadaki işlem Güncellenemediği için işlem Başarısız");
            }
            if (Eski.CikisIslemId != 8 && Yeni.CikisIslemId == 8 && guncelle == true)
            {
                Nakit nkt = new Nakit
                {
                    Id = GenelFunctions.IdOlustur(),
                    Tarih = Yeni.CikisTarihi,
                    GirisCikis = "Giriş",
                    IslemId = 12,
                    Tutar = Eski.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    HesapId = 0,
                    Aciklama = $"{Eski.Tur} No: {Eski.CekNo} Vade Tarihi: {Eski.VadeTarihi.ToShortDateString()} Evrağın Nakite Çevrilerek Bankaya Aktarılması",
                    KullaniciId = Yeni.CikisKullaniciId,
                    IslemTarihi = Yeni.CikisIslemTarihi,
                    CekIslemId = Yeni.Id,

                };
                if (!NakitF.Ekle(nkt))
                    throw new Exception("Nakit Kasaya Giriş Yapılamadığı için işlem Başarısız");
            }
            if (Eski.CikisIslemId == 8 && Yeni.CikisIslemId != 8 && guncelle == true)
            {
                if (!NakitF.Sil(NakitF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Nakit Kasadaki işlem silinemediği için işlem Başarısız");
            }
            #endregion

            #region Nakitten Silme İşlemi
            if (Eski.CikisIslemId == 8 && guncelle == false)
            {
                if (!NakitF.Sil(NakitF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Nakit Kasadaki işlem silinemediği için işlem Başarısız");
            }
            #endregion


            #region Bankadan Güncelleme İşlemleri
            if (Eski.CikisIslemId == 9 && Yeni.CikisIslemId == 9 && guncelle == true)
            {

                Banka bnk = new Banka
                {
                    Tarih = Yeni.CikisTarihi,
                    HesapId = Yeni.CikisHesapId,
                    GirisCikis = "Giriş",
                    IslemId = 15,
                    Tutar = Yeni.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    Aciklama = $"{Eski.Tur} No: {Eski.CekNo} Vade Tarihi: {Eski.VadeTarihi.ToShortDateString()} Evrağın Nakite Çevrilerek Bankaya Aktarılması",
                    KullaniciId = Yeni.CikisKullaniciId,
                    IslemTarihi = Yeni.CikisTarihi,
                    NakitIslemId = 0,
                    VirmanHesapId = 0,
                    CekIslemId = Yeni.Id

                };

                if (!BankaF.Guncelle(bnk, BankaF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Bankadaki Kayıt Güncellenemediği için işlem Başarısız");
            }
            if (Eski.CikisIslemId != 9 && Yeni.CikisIslemId == 9 && guncelle == true)
            {
                Banka bnk = new Banka
                {
                    Id = GenelFunctions.IdOlustur(),
                    Tarih = Yeni.CikisTarihi,
                    HesapId = Yeni.CikisHesapId,
                    GirisCikis = "Giriş",
                    IslemId = 15,
                    Tutar = Yeni.Tutar,
                    OgrenciOdemePlaniId = 0,
                    OgrenciId = 0,
                    PersonelId = 0,
                    FirmaId = 0,
                    Aciklama = $"{Eski.Tur} No: {Eski.CekNo} Vade Tarihi: {Eski.VadeTarihi.ToShortDateString()} Evrağın Nakite Çevrilerek Bankaya Aktarılması",
                    KullaniciId = Yeni.CikisKullaniciId,
                    IslemTarihi = Yeni.CikisTarihi,
                    NakitIslemId = 0,
                    VirmanHesapId = 0,
                    CekIslemId = Yeni.Id

                };

                if (!BankaF.Ekle(bnk))
                    throw new Exception("Bankaya Kayıt Eklenemediği için işlem Başarısız");
            }
            if (Eski.CikisIslemId == 9 && Yeni.CikisIslemId != 9 && guncelle == true)
            {
                if (!BankaF.Sil(BankaF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Bankadaki işlem silinemediği için işlem Başarısız");
            }
            #endregion

            #region Bankadan Kayıt Silme
            if (Eski.CikisIslemId == 9 && guncelle == false)
            {
                if (!BankaF.Sil(BankaF.CekIslemIdyeGoreIdBul(id)))
                    throw new Exception("Bankadaki işlem silinemediği için işlem Başarısız");
            }
            #endregion


            _sql = @"UPDATE Cek SET CikisTarihi=@p16,CikisIslemId=@p17,CikisOgrenciId=@p18,CikisfirmaId=@p19,CikisPersonelId=@p20,CikisHesapId=@p21,CikisKullaniciId=@p22,
                CikisAciklama=@p23,CikisIslemTarihi=@p24,CikisYapildi=@p15 Where Id=" + id;
            return CikisParametre(ck).Guncelle(_sql);

        }

        public static CekL Secim(long id)
        {
            return Connections.cnn.QueryFirst<CekL>($"SELECT * FROM viewCekHareketListesi where  Id={id}");
        }
        public static object Liste(bool CikisiYapilanCekler = false)
        {

            return Connections.cnn.Query<CekL>($"SELECT * FROM viewCekHareketListesi Where CikisYapildi='{CikisiYapilanCekler}' order by Id desc");

        }

        public static object VadesiBugunOlanCekListesi(bool VadesiBugun)
        {
            var param = new DynamicParameters();
            param.Add("@t1", DateTime.Now.Date);

            if (VadesiBugun)
                return Connections.cnn.Query<CekL>($"SELECT * FROM viewCekHareketListesi Where Convert(Date,VadeTarihi,103)=@t1 order by Id desc", param);
            else
                return Connections.cnn.Query<CekL>($"SELECT * FROM viewCekHareketListesi Where  Convert(Date,VadeTarihi,103)<@t1 order by Id desc", param);

        }

        public static int VadesiBugunOlanCekSayisi()
        {
            var param = new DynamicParameters();
            param.Add("@t1", DateTime.Now.Date);

            return (int)Connections.cnn.ExecuteScalar($"SELECT Count(*) FROM Cek Where Convert(Date,VadeTarihi,103)=@t1", param);

        }

        public static decimal GenelBakiye()
        {
            return (decimal)Connections.cnn.ExecuteScalar("select coalesce(sum(Tutar),0) from Cek where CikisYapildi=0");
        }

        public static CekGirisCikis TarihArasiBakiye(DateTime trh1, DateTime trh2)
        {
            var param = new DynamicParameters();
            param.Add("@t1", trh1);
            param.Add("@t2", trh2);
            return Connections.cnn.QueryFirstOrDefault<CekGirisCikis>($@"select 
                                                                 (select coalesce(sum(Tutar),0) from Cek where convert(date,GirisTarihi, 103)>=convert(date,@t1, 103) and convert(date,GirisTarihi, 103)<=convert(date,@t2, 103)) as Giris,
                                                                 (select coalesce(sum(Tutar),0) from Cek where convert(date,CikisTarihi, 103)>=convert(date,@t1, 103) and convert(date,CikisTarihi, 103)<=convert(date,@t2, 103)) as Cikis", param);
        }


        static void HataKont(Cek ck)
        {
            if (ck.GirisIslemId <= 0)
                throw new Exception("İşlem Seçiniz");
            if (ck.Tur == "")
                throw new Exception("Evrak Türünü Seçiniz.");
            if (ck.GirisTarihi > DateTime.Now)
                throw new Exception("İleri Tarihe Veri Girilemez.");
            if (ck.Tutar <= 0)
                throw new Exception("Tutar Giriniz.");

            if (ck.CekNo.Replace(" ", "") == "")
                throw new Exception("Evrak No Giriniz.");
            if (ck.VadeTarihi < ck.GirisTarihi)
                throw new Exception("Vade Tarihi İşlem Tarihinden küçük olamaz.");
            if (ck.Tur == "Çek" && ck.CekBanka.Replace(" ", "") == "")
                throw new Exception("Banka Adı Giriniz.");


            if (ck.GirisAciklama.Replace(" ", "") == "")
                throw new Exception("Açıklama Giriniz.");

            if (ck.GirisIslemId == 1 && (ck.GirisOgrenciId == 0 || ck.OgrenciOdemePlaniId == 0))
                throw new Exception("Öğrenci Ödenecek Tahakkuku seçiniz.");

            if (ck.CikisIslemId == 2 && ck.CikisOgrenciId == 0 )
                throw new Exception("İade yapılacak Öğrenci seçiniz.");

            if ((ck.CikisIslemId == 3 ) && ck.PersonelId == 0)
                throw new Exception("Personel Seçiniz.");
            if (ck.GirisIslemId == 5  && ck.GirisfirmaId == 0)
                throw new Exception("Firma Seçiniz");
            if (ck.CikisIslemId == 6 && ck.CikisfirmaId == 0)
                throw new Exception("Firma Seçiniz");

            if (ck.CikisIslemId == 9 && ck.CikisHesapId == 0)
                throw new Exception("Hesap Seçiniz");



        }
        static DynamicParameters GirisParametre(Cek ck)
        {
            var param = new DynamicParameters();
            param.Add("@p0", ck.Id);
            param.Add("@p1", ck.Tur);
            param.Add("@p2", ck.CekNo);
            param.Add("@p3", ck.CekBanka);
            param.Add("@p4", ck.VadeTarihi);
            param.Add("@p5", ck.Tutar);

            param.Add("@p6", ck.GirisTarihi);
            param.Add("@p7", ck.GirisIslemId);
            param.Add("@p8", ck.GirisOgrenciId);
            param.Add("@p9", ck.OgrenciOdemePlaniId);
            param.Add("@p10", ck.GirisfirmaId);
            param.Add("@p11", ck.GirisPersonelId);
            param.Add("@p12", ck.GirisAciklama);
            param.Add("@p13", ck.GirisKullaniciId);
            param.Add("@p14", ck.GirisIslemTarihi);
            param.Add("@p15", ck.CikisYapildi);
            return param;
        }

        static DynamicParameters CikisParametre(Cek ck)
        {
            var param = new DynamicParameters();
            param.Add("@p15", ck.CikisYapildi);
            param.Add("@p16", ck.CikisTarihi);
            param.Add("@p17", ck.CikisIslemId);
            param.Add("@p18", ck.CikisOgrenciId);
            param.Add("@p19", ck.CikisfirmaId);
            param.Add("@p20", ck.CikisPersonelId);
            param.Add("@p21", ck.CikisHesapId);
            param.Add("@p22", ck.CikisKullaniciId);
            param.Add("@p23", ck.CikisAciklama);
            param.Add("@p24", ck.CikisIslemTarihi);

            return param;
        }
    }
}
