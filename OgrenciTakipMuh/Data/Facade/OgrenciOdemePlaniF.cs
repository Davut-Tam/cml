using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciTakipMuh.Data.Facade
{
    public class OgrenciOdemePlaniF 
    {
        private static string _sql;

        public static bool OdemePlaniOlustur(List<OgrenciOdemePlaniL> currentOdemePlani)
        {
            //HataKont(currentOdemePlani);
            _sql = "INSERT INTO OgrenciOdemePlani VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";


            long ogreciId = currentOdemePlani[currentOdemePlani.Count - 1].OgrenciId;
            int tahakkukno = currentOdemePlani[currentOdemePlani.Count - 1].TahakkukNo;

            decimal toplam = 0;
            foreach (var item in currentOdemePlani)
            {
                Parametre(item).Kaydet(_sql);
                toplam += item.OdenecekTutar;
            }
            return OgrenciTahakkukF.TahakkukOlustur(ogreciId, toplam, tahakkukno);



        }
        public static bool OdemePlaniSil(List<OgrenciOdemePlaniL> oldOdemePlani, List<OgrenciOdemePlaniL> currentOdemePlani)
        {
            long ogreciId = oldOdemePlani[oldOdemePlani.Count - 1].OgrenciId;
            int tahakkukno = oldOdemePlani[oldOdemePlani.Count - 1].TahakkukNo;

            // eski ödeme planının ödenmeyenlerini tamamen silme
            foreach (var item in oldOdemePlani)
            {
                if (!item.Odendi)
                {
                    _sql = $"Delete OgrenciOdemePlani Where Id={item.Id}";
                    Repository.Sil(_sql);
                }


            }

            decimal toplam = 0;
            foreach (var item in oldOdemePlani)
            {
                if (item.Odendi)
                    toplam += item.OdenecekTutar;
            }

            if (toplam == 0) tahakkukno = 0;
            return OgrenciTahakkukF.TahakkukOlustur(ogreciId, toplam, tahakkukno);



        }
        public static bool OdemePlaniGuncelle(List<OgrenciOdemePlaniL> oldOdemePlani, List<OgrenciOdemePlaniL> currentOdemePlani)
        {


            long ogreciId = oldOdemePlani[oldOdemePlani.Count - 1].OgrenciId;
            int tahakkukno = oldOdemePlani[oldOdemePlani.Count - 1].TahakkukNo;

            // eski ödeme planının ödenmeyenlerini tamamen silme
            foreach (var item in oldOdemePlani)
            {
                if (!item.Odendi)
                    Repository.Sil($"Delete OgrenciOdemePlani Where Id={item.Id}");

            }

            _sql = "INSERT INTO OgrenciOdemePlani VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
            decimal toplam = 0;
            foreach (var item in currentOdemePlani)
            {
                if (!item.Odendi)
                    Parametre(item).Kaydet(_sql);
                toplam += item.OdenecekTutar;
            }
            if (toplam == 0) tahakkukno = 0;
            return OgrenciTahakkukF.TahakkukOlustur(ogreciId, toplam, tahakkukno);


        }


        public static bool BirinciSmsKayit(long id)
        {
            _sql = $"UPDATE OgrenciOdemePlani SET BirinciHatirlatma=GetDate() WHERE Id={id}";
            return Connections.cnn.Execute(_sql) > 0;

        }

        public static bool IkinciSmsKayit(List<long> ids)
        {
            var sqlId = "";
            foreach (var item in ids) sqlId+= $"Id={item} OR ";


            sqlId = sqlId.Substring(0, sqlId.Length - 3);

            _sql = $"UPDATE OgrenciOdemePlani SET IkinciHatirlatma=GetDate() WHERE {sqlId}";
            return Connections.cnn.Execute(_sql) > 0;

        }


        // tahakkuk formu odeme planı hazırlama ve rapor  görüntüleme tablolarında kullanıdı
        public static object OdemePlani(long ogrenciId, long donemId)
        {
            return Connections.cnn.Query<OgrenciOdemePlaniL>($@"SELECT op.*, s.OdemeSekliAdi,
                                                             case when w.Toplam >= op.OdenecekTutar then 1 else 0 end as Odendi
                                                             FROM OgrenciOdemePlani op
                                                             Left Join OdemeSekli s on op.OdemeSekliId = s.Id
                                                             Left Join viewOgrenciTahsilatToplamiOdemePlaniIdyeGore w on w.OgrenciOdemePlaniId = op.Id Where op.OgrenciId={ogrenciId} and op.DonemId={donemId} order by op.SonOdemeTarihi");
        }

        public static object OdemeListesi(long ogrenciId)
        {
            return Connections.cnn.Query<OgrenciOdemePlaniL>($@"SELECT w.*,op.TaksitNo 
                                                             FROM viewOgrenciTahsilatNakitBankaCek w left join OgrenciOdemePlani op on w.OgrenciOdemePlaniId=op.Id Where w.OgrenciId={ogrenciId} Order By w.Tarih");
        }

        public static bool OdemePlaniVarmi(long ogrenciId, long donemId)
        {
            var a = (int)Connections.cnn.ExecuteScalar($@"SELECT count(*) FROM OgrenciOdemePlani Where OgrenciId={ogrenciId} and DonemId={donemId}");

            return a > 0;
        }

        public static bool OdemeListesiVarmi(long ogrenciId)
        {
            var a = Connections.cnn.ExecuteScalar($@"SELECT count(*)FROM viewOgrenciTahsilatNakitBankaCek Where OgrenciId={ogrenciId}");
            return ((int)a) > 0;

        }

        public static object OdemesiYapilmayanTaksitler(long donemid, long grupId, long SinifId, DateTime trh1, DateTime trh2)
        {

            var grup = grupId != 0 ? $" AND g.Id={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND s.Id={ SinifId}" : "";
            var prm = new DynamicParameters();
            prm.Add("@p0", trh1);
            prm.Add("@p1", trh2);

            var sql = $@"select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,g.GrupAdi,s.SinifAdi,v.VeliAdiSoyadi as Veli1AdiSoyadi,v.Telefon as Veli1Telefon,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,op.KullaniciId,op.IslemTarihi 
                                                            from OgrenciOdemePlani op
                                                            left join   [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            left join Ogrenci o  on o.Id=op.OgrenciId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            inner join Grup g  on g.Id=o.GrupId
                                                            inner join Sinif s  on s.Id=o.SinifId
                                                            inner join Veli v  on v.Id=o.Veli1Id
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and o.DonemId={donemid}{grup}{sinif} and  o.Durum=1 and
                                                            op.SonOdemeTarihi>=@p0 and   op.SonOdemeTarihi<=@p1 
                                                            ORDER BY g.GrupAdi,s.SinifAdi,o.AdiSoyadi";

            return Connections.cnn.Query<OgrenciCariOdemeL>(sql, prm);
        }

        public static object OdemesiYapilanTaksitler(long donemid, long grupId, long SinifId, DateTime trh1, DateTime trh2)
        {

            var grup = grupId != 0 ? $" AND o.GrupId={ grupId}" : "";
            var sinif = SinifId != 0 ? $" AND o.SinifId={ SinifId}" : "";
            var prm = new DynamicParameters();
            prm.Add("@p0", trh1);
            prm.Add("@p1", trh2);

            var sql = $@"SELECT w.*,op.TaksitNo,op.OdenecekTutar,o.AdiSoyadi,o.TcKimlikNo,o.SinifAdi,o.GrupAdi,o.DonemId
                                                             FROM viewOgrenciTahsilatNakitBankaCek w
                                                             left join OgrenciOdemePlani op on w.OgrenciOdemePlaniId=op.Id 
                                                             left join viewOgrenciListesi o on w.ogrenciId=o.Id 
                                                             where o.DonemId={donemid}{grup}{sinif} and
                                                             w.Tarih>=@p0 and  w.Tarih<=@p1 
                                                             ORDER BY w.Tarih";

            return Connections.cnn.Query<OgrenciOdemeListesiR>(sql, prm);
        }

        public static OgrenciCariOdemeL Secim(long odemePlaniId)
        {
            return Connections.cnn.QueryFirstOrDefault<OgrenciCariOdemeL>($@"Select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,os.OdemeSekliAdi,
                                                            op.KullaniciId,op.IslemTarihi,op.BirinciHatirlatma,op.IkinciHatirlatma,o.Veli1AdiSoyadi,o.Veli2AdiSoyadi,o.Veli1Telefon,o.Veli2Telefon,o.GrupAdi,o.SinifAdi,o.OtoSms
                                                            from OgrenciOdemePlani op
                                                            left join [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            left join viewOgrenciListesi o on o.Id=op.OgrenciId
                                                            left join OdemeSekli os  on os.Id=op.OdemeSekliId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            where  o.Durum=1 and op.Id={odemePlaniId}");
        }


        public static object OdenmeyenTaksitlerListesiTumu(long donemId)
        {
            return Connections.cnn.Query<OgrenciCariOdemeL>($@"Select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,os.OdemeSekliAdi,
                                                            op.KullaniciId,op.IslemTarihi,op.BirinciHatirlatma,op.IkinciHatirlatma,o.Veli1AdiSoyadi,o.Veli2AdiSoyadi,o.Veli1Telefon,o.Veli2Telefon,o.GrupAdi,o.SinifAdi,o.OtoSms
                                                            from OgrenciOdemePlani op
                                                            left join [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            left join viewOgrenciListesi o on o.Id=op.OgrenciId
                                                            left join OdemeSekli os  on os.Id=op.OdemeSekliId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and  o.Durum=1 and op.DonemId={donemId} order by op.SonOdemeTarihi desc");
        }
        public static object OdenmeyenTaksitlerSmsGondermeListesi()
        {
            return Connections.cnn.Query<OgrenciCariOdemeL>($@"Select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,os.OdemeSekliAdi,
                                                            op.KullaniciId,op.IslemTarihi,op.BirinciHatirlatma,op.IkinciHatirlatma,o.Veli1AdiSoyadi,o.Veli2AdiSoyadi,o.Veli1Telefon,o.Veli2Telefon,o.GrupAdi,o.SinifAdi,o.OtoSms
                                                            from OgrenciOdemePlani op
                                                            left join [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            left join viewOgrenciListesi o on o.Id=op.OgrenciId
                                                            left join OdemeSekli os  on os.Id=op.OdemeSekliId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and  o.Durum=1");//SonOdemeTarihi>= '2022/08/01 00:00:00'
        }

        public static object OdenmeyenTaksitlerListesiTumuOgrenciyeGore(long ogrenciId)
        {
            return Connections.cnn.Query<OgrenciCariOdemeL>($@"select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,os.OdemeSekliAdi,
                                                            op.KullaniciId,op.IslemTarihi,op.BirinciHatirlatma,op.IkinciHatirlatma,o.Veli1AdiSoyadi,o.Veli2AdiSoyadi,o.Veli1Telefon,o.Veli2Telefon,o.GrupAdi,o.SinifAdi,o.OtoSms
                                                            from OgrenciOdemePlani op
                                                            left join   [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            left join viewOgrenciListesi o on o.Id=op.OgrenciId
                                                            left join OdemeSekli os  on os.Id=op.OdemeSekliId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and op.OgrenciId={ogrenciId} order by op.SonOdemeTarihi");
        }

        public static List<OgrenciCariOdemeL> OdenmeyenTaksitlerListesiTumu()
        {

         
                return Connections.cnn.Query<OgrenciCariOdemeL>($@"select op.OgrenciId,d.DonemAdi,op.Id as OdemePlaniId,op.SonOdemeTarihi,o.TcKimlikNo,o.AdiSoyadi,op.TaksitNo,op.TahakkukNo,
                                                            op.OdenecekTutar as Odenecek,coalesce( w.Toplam,0) as Odenen,op.OdenecekTutar-coalesce( w.Toplam,0) as kalan,op.Aciklama,os.OdemeSekliAdi,
                                                            op.KullaniciId,op.IslemTarihi,op.BirinciHatirlatma,op.IkinciHatirlatma,o.Veli1AdiSoyadi,o.Veli2AdiSoyadi,o.Veli1Telefon,o.Veli2Telefon,o.GrupAdi,o.SinifAdi,o.OtoSms
                                                            from OgrenciOdemePlani op
                                                            left join   [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                             left join viewOgrenciListesi o on o.Id=op.OgrenciId
                                                            left join OdemeSekli os  on os.Id=op.OdemeSekliId
                                                            left join Donem d  on d.Id=op.DonemId
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and o.Durum=1").ToList();
  

        }

        public static int BuGunOdenecekTaksitSayisi()
        {
            var prm = new DynamicParameters();
            prm.Add("@p1", DateTime.Now.Date);
            return (int)Connections.cnn.ExecuteScalar($@"select count(*)  from OgrenciOdemePlani op
                                                            left join   [dbo].[viewOgrenciTahsilatToplamiOdemePlaniIdyeGore] w on w.ogrenciOdemePlaniId=op.Id
                                                            where op.OdenecekTutar>coalesce( w.Toplam,0) and Convert(Date,op.SonOdemeTarihi,103)=@p1", prm);

        }

        public static void HataKont(List<OgrenciOdemePlaniL> currentOdemePlani)
        {
            if (currentOdemePlani.Count <= 0)
                throw new Exception("Ödeme Planı Boş");

            foreach (var item in currentOdemePlani)
            {
                if (item.Id <= 0)
                    throw new Exception("Id Hatası");

                else if (item.OgrenciId <= 0)
                    throw new Exception("Öğrenci Id Hatası");

                else if (item.DonemId <= 0)
                    throw new Exception("Dönem Hatası");

                else if (item.OdenecekTutar <= 0)
                    throw new Exception("Taksit Tutarı Belirtilmemiş kayıt var");

            }

        }

        static DynamicParameters Parametre(OgrenciOdemePlani OdemePlani)
        {
            var prm = new DynamicParameters();
            prm.Add("@p0", OdemePlani.Id);
            prm.Add("@p1", OdemePlani.TahakkukNo);
            prm.Add("@p2", OdemePlani.OgrenciId);
            prm.Add("@p3", OdemePlani.DonemId);
            prm.Add("@p4", OdemePlani.OdemeSekliId);
            prm.Add("@p5", OdemePlani.TaksitNo);
            prm.Add("@p6", OdemePlani.OdenecekTutar);
            prm.Add("@p7", OdemePlani.SonOdemeTarihi);
            prm.Add("@p8", OdemePlani.KullaniciId);
            prm.Add("@p9", OdemePlani.IslemTarihi);
            prm.Add("@p10", OdemePlani.Aciklama);
            prm.Add("@p11", OdemePlani.BirinciHatirlatma);
            prm.Add("@p12", OdemePlani.IkinciHatirlatma);
            return prm;
        }
    }
}
