using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Globalization;

namespace OgrenciTakipMuh.Data.Facade
{
    class PersonelF 
    {

        private static string _sql;
        private static string _res;

        public static bool Ekle(Personel prs)
        {
            HataKont(prs);
            _res = prs.Resim == null ? "Null" : "@p7";
            _sql = $@"INSERT INTO Personel VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,{_res},@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)";


            return Parametre(prs).Kaydet(_sql);
        }



        public static bool Guncelle(Personel prs, long id)
        {
            HataKont(prs);
            _res = prs.Resim == null ? "Null" : "@p7";
            _sql = $@"UPDATE Personel SET TcKimlikNo=@p1,AdiSoyadi=@p2,GorevId=@p3,BaslamaTarihi=@p4,Maas=@p5,MaasOdemeGunu=@p6,
                                                Resim={_res},EmailAdresi=@p8,Telefon=@p9,Adres=@p10,BankaAdi=@p11,IbanNo=@p12,
                                                Aciklama=@p13,IslemTarihi=@p14,KullaniciId=@p15,Durum=@p16,OtomatikMaas=@p17                                                
                                                WHERE Id=" + id;

            return Parametre(prs).Guncelle(_sql);

        }

        public static bool Sil(long id)
        {
            _sql = "DELETE FROM Personel WHERE Id=" + id;
            return Repository.Sil(_sql, "Maaş Tahakkuk Planı");
        }
        static DynamicParameters Parametre(Personel prs)
        {
            var prm = new DynamicParameters();

            prm.Add("@p0", prs.Id);
            prm.Add("@p1", prs.TcKimlikNo.Replace(" ", ""));
            prm.Add("@p2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prs.AdiSoyadi.ToLower()));
            prm.Add("@p3", prs.GorevId);
            prm.Add("@p4", prs.BaslamaTarihi);
            prm.Add("@p5", prs.Maas);
            prm.Add("@p6", prs.MaasOdemeGunu);
            prm.Add("@p7", prs.Resim);
            prm.Add("@p8", prs.EmailAdresi);
            prm.Add("@p9", prs.Telefon);
            prm.Add("@p10", prs.Adres);
            prm.Add("@p11", prs.BankaAdi);
            prm.Add("@p12", prs.IbanNo);
            prm.Add("@p13", prs.Aciklama);
            prm.Add("@p14", prs.IslemTarihi);
            prm.Add("@p15", prs.KullaniciId);
            prm.Add("@p16", prs.Durum);
            prm.Add("@p17", prs.OtomatikMaas);


            return prm;
        }

        public static object Liste(bool aktifPasif)
        {
            return Connections.cnn.Query<PersonelL>($"SELECT * FROM viewPersonelListesi where Durum='{aktifPasif}' order by AdiSoyadi");
        }



        public static PersonelL Secim(long id)
        {
            return Connections.cnn.QueryFirst<PersonelL>($"SELECT * FROM viewPersonelListesi where Id={id}");
        }




        public static void HataKont(Personel prs)
        {
            if (prs.AdiSoyadi.Replace(" ", "") == "")
                throw new Exception("Personel Adı Giriniz");

            if (prs.Telefon != null && prs.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
                throw new Exception("Telefon 1 Hatalı Lütfen Kontrol Ediniz.");


            else if (prs.TcKimlikNo == "")
                throw new Exception("Tc Giriniz");

            else if (prs.TcKimlikNo.Replace(" ", "").Length != 11)
                throw new Exception("Tc Hatalı!");

            else if (prs.GorevId <= 0)
                throw new Exception("Görev Tanımlayınız");

            else if (prs.BaslamaTarihi >= DateTime.Now)
                throw new Exception("İleri Tarihe İşlem Yapılamaz");

            else if (prs.Maas <= 0)
                throw new Exception("Maaş Giriniz");

            else if (prs.MaasOdemeGunu <= 0)
                throw new Exception("Maaş Ödeme Günü Giriniz");
        }
    }




}
