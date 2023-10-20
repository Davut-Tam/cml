using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.Facade
{
    public class PersonelOdemePlaniF 
    {
        private static string _sql;
        public static bool Ekle(PersonelOdemePlani prsO)
        {
            HataKont(prsO);
            _sql = "INSERT INTO PersonelOdemePlani VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            return Parametre(prsO).Kaydet(_sql);


        }
        public static bool Sil(long id)
        {
            return Repository.Sil($"Delete PersonelOdemePlani Where Id={id}");

        }
        public static bool Guncelle(PersonelOdemePlani prsO, long id)
        {
            _sql = @"Update PersonelOdemePlani Set TahakkukNo=@p1,PersonelId=@p2,SonOdemeTarihi=@p3,Maas=@p4,Aciklama=@p5,IslemTarihi=@p6,KullaniciId=@p7,
                   Tur=@p8,OtomatikMaas=@p9 Where Id=" + id;
            return Parametre(prsO).Guncelle(_sql);
        }

        public static int TahakkukNoBul(long personelId)
        {
            try
            {
                return (int)Connections.cnn.ExecuteScalar($"Select Max(TahakkukNo) From PersonelOdemePlani Where PersonelId=" + personelId) + 1;
            }
            catch (Exception)
            {

                return 1;
            }

        }

        public static PersonelOdemePlani Secim(long id)
        {
            return Connections.cnn.QueryFirst<PersonelOdemePlani>($"SELECT * From PersonelOdemePlani Where Id={id}");
        }

        public static object MaasOdemeGunuListesi(bool bugun)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@p1", DateTime.Now.Date);
            if(bugun)
            return Connections.cnn.Query<PersonelL>($@"SELECT ıd, TcKimlikNo,AdiSoyadi,GorevAdi,Maas,KalanBakiye,SonMaasTahakkukTarihi from viewPersonelListesi
                                                       where Convert(Date,SonMaasTahakkukTarihi,103)=@p1 and KalanBakiye>0  and Durum ='True' order by Id desc", prm);
            else
                return Connections.cnn.Query<PersonelL>($@"SELECT ıd, TcKimlikNo,AdiSoyadi,GorevAdi,Maas,KalanBakiye,SonMaasTahakkukTarihi from viewPersonelListesi
                                                       where Convert(Date,SonMaasTahakkukTarihi,103)<@p1 and KalanBakiye>0 and Durum ='True' order by Id desc", prm);
        }

 

        public static int BuGunkOdenecekMaasSayisi()
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@p1", DateTime.Now.Date);
            return (int)Connections.cnn.ExecuteScalar($@"SELECT count(*) from viewPersonelListesi
                                                       where Convert(Date,SonMaasTahakkukTarihi,103)=@p1 and KalanBakiye>0  and Durum ='True'", prm);
        }



        public static object CariHareket(long personelId)// tamam
        {
            var list = Connections.cnn.Query<PersonelOdemePlaniL>($@"SET language turkish SELECT * From viewPersCariHareket
                                                                Where personelId={personelId} order by Tarih desc");

            decimal bakiye = PersonelBakiye(personelId);
            foreach (var item in list)
            {
                (item).Bakiye = bakiye;
                if (item.GirisCikis != "Çıkış") bakiye -= item.Tutar; else bakiye += item.Tutar;

            }
            return list;
        }

        public static decimal PersonelBakiye(long personelId)
        {
            return (decimal)Connections.cnn.ExecuteScalar($@"select
                                                            (select COALESCE(SUM(Maas), 0)   FROM PersonelOdemePlani      where personelId = {personelId}) +
                                                            (select COALESCE(SUM(Tutar), 0)  FROM viewPersTumIadeListesi  where personelId = {personelId}) -
                                                            (select COALESCE(SUM(Tutar), 0)  FROM viewPersTumOdemeListesi where personelId = {personelId})");
        }
        public static object OdemePlaniListesi(long personelId)// tamam
        {
            return Connections.cnn.Query<PersonelOdemePlaniL>($@"SET language turkish select *,
                                                                CASE OtomatikMaas WHEN 1 THEN 'Otomatik' ELSE 'Manuel' END AS TahakkukSekli,
                                                                datename(month, SonOdemeTarihi) + ' ' + CONVERT(CHAR(4), YEAR(SonOdemeTarihi)) + ' ' + Tur AS TahakkukAdi
                                                                from PersonelOdemePlani
                                                                Where personelId={personelId} order by SonOdemeTarihi desc");


        }

        public static bool MaasKontrol(long personelId, int ay, int yil)
        {
            var dr = Connections.cnn.ExecuteReader($"Select * From PersonelOdemePlani Where Tur='Maaş' and PersonelId={ personelId} and Year(SonOdemeTarihi)={yil} and Month(SonOdemeTarihi)={ay}");

            if (dr.Read())
            {
                dr.Close();
                return true;
            }

            else
            {
                dr.Close();
                return false;
            }
        }


        public static void OtomatikMaasIslemi()
        {
            DateTime TahkTarh;
            long _Id = GenelFunctions.IdOlustur();
            _sql = "INSERT INTO PersonelOdemePlani VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            List<Personel> personeller = (List<Personel>)Connections.cnn.Query<Personel>($"SELECT * FROM Personel where Durum='True' and OtomatikMaas='True'");

            foreach (var prs in personeller)
            {
                try { try { try { TahkTarh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu); } catch (Exception) { TahkTarh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 1); } } catch (Exception) { TahkTarh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 2); } } catch (Exception) { TahkTarh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 3); }

                if (DateTime.Now.Date >= TahkTarh)
                {
                    PersonelOdemePlani prsO = new PersonelOdemePlani
                    {
                        Id = _Id,
                        TahakkukNo = TahakkukNoBul(prs.Id),
                        PersonelId = prs.Id,
                        SonOdemeTarihi = TahkTarh,
                        Maas = prs.Maas,
                        Aciklama = prs.AdiSoyadi + " Otomatik maas",
                        KullaniciId = AnaForm.KullanicilId,
                        IslemTarihi = DateTime.Now,
                        Tur = "Maaş",
                        OtomatikMaas = true,
                       
                    };
                    if (!MaasKontrol(prsO.PersonelId, TahkTarh.Month, TahkTarh.Year))
                        Parametre(prsO).Kaydet(_sql);
                    _Id++;
                }

            }


        }

        public static void HataKont(PersonelOdemePlani prsO)
        {

            if (prsO.Maas <= 0)
                throw new Exception("Maaş Tutarı Hatalı");
            if (prsO.PersonelId <= 0)
                throw new Exception("Personel Kayıt Hatası");
            if (prsO.Tur == "Maaş")
                if (MaasKontrol(prsO.PersonelId, prsO.SonOdemeTarihi.Month, prsO.SonOdemeTarihi.Year))
                    throw new Exception("Aynı Aya Birden Fazla Maaş Girilemez");


        }

        static DynamicParameters Parametre(PersonelOdemePlani prsO)
        {
            var prm = new DynamicParameters();
            prm.Add("@p0", prsO.Id);
            prm.Add("@p1", prsO.TahakkukNo);
            prm.Add("@p2", prsO.PersonelId);
            prm.Add("@p3", prsO.SonOdemeTarihi);
            prm.Add("@p4", prsO.Maas);
            prm.Add("@p5", prsO.Aciklama);
            prm.Add("@p6", prsO.IslemTarihi);
            prm.Add("@p7", prsO.KullaniciId);
            prm.Add("@p8", prsO.Tur);
            prm.Add("@p9", prsO.OtomatikMaas);

            return prm;
        }


    }
}
