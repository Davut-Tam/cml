using Dapper;
using OgrenciTakipMuh.Data.DataFunctions;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using System;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.Facade
{
    public class FaturaF 
    {

        private static string _sql;
        public static bool Ekle(Fatura frt, List<FaturaDetayL> frtDetayList)
        {

            HataKont(frt);
            HataKont(frtDetayList);


            _sql = "INSERT INTO Fatura VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
            if (Parametre(frt).Kaydet(_sql))
            {
                _sql = "INSERT INTO FaturaDetay VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                foreach (var item in frtDetayList)
                    Parametre(item).Kaydet(_sql);


            }
            return true;




        }
        //   
        public static bool Guncelle(Fatura ftr, long Id, List<FaturaDetayL> frtDetayList)
        {
            HataKont(ftr);
            HataKont(frtDetayList);
            _sql = @"UPDATE Fatura SET BelgeTipi=@p1,BelgeNo=@p2,BelgeTarihi=@p3,BelgeTuru=@p4,FirmaId=@p5,
                BelgeKayitTarihi=@p6,Aciklama=@p7,KullaniciId=@p8,IslemTarihi=@p9,Veli=@p10 WHERE Id=" + Id;


            if (Parametre(ftr).Guncelle(_sql))
            {

                Repository.Sil("DELETE FROM FaturaDetay WHERE FaturaId=" + Id);
                _sql = "INSERT INTO FaturaDetay VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
                foreach (var item in frtDetayList)
                    Parametre(item).Kaydet(_sql);
            }
            return true;
        }

        public static bool Sil(long id)
        {
            // Önce fatura detaydan bu fatra silinecek veya sql den halledilecek
            return Repository.Sil("DELETE FROM Fatura WHERE Id=" + id);

        }

        public static object Liste(string belgeTuru,int ay,int yil)
        {

            return Connections.cnn.Query<FaturaL>($@"Select * From viewFaturaListesi Where BelgeTuru='{belgeTuru}'and Month(BelgeTarihi)={ay} and Year(BelgeTarihi)={yil} order by Id desc");
        }

        public static object DetayListe(long faturaId)
        {
            return Connections.cnn.Query<FaturaDetayL>($@"SELECT ROW_NUMBER() OVER(order by f.Id ) AS Sira,m.MalHizmetAdi,m.MiktarBrim,* FROM FaturaDetay f
                                                        left join MalHizmet m on f.MalHizmetId = m.Id Where FaturaId={faturaId} order by f.Id");
        }

        public static int EnKucukYil()
        {
            try
            {
                return (int)Connections.cnn.ExecuteScalar("SELECT Min(Year(BelgeTarihi)) From Fatura");

            }
            catch (Exception)
            {

                return DateTime.Now.Year;
            }
      
        }
        public static FaturaL Secim(long id)
        {
            return Connections.cnn.QueryFirst<FaturaL>("SELECT * FROM Fatura WHERE Id=" + id);
        }
        static void HataKont(Fatura ftr)
        {
            if (ftr.BelgeTipi.Replace(" ", "") == "")
                throw new Exception("Belge Tipi Seçiniz");

            if (ftr.BelgeNo.Replace(" ", "") == "")
                throw new Exception("Belge No Giriniz");

            if (ftr.BelgeTarihi.Date > DateTime.Now)
                throw new Exception("Belge Tarihi İleri bir Tarih olamaz");


            if (ftr.BelgeTuru.Replace(" ", "") == "")
                throw new Exception("Belge TÜrü Seçiniz");

            if (ftr.FirmaId <= 0)
                throw new Exception("Firma Seçiniz");

            if (ftr.BelgeKayitTarihi.Date > DateTime.Now)
                throw new Exception("İleri bir Tarihe işlem Yapılamaz");



        }

        static void HataKont(List<FaturaDetayL> frtDetayList)
        {
            if (frtDetayList.Count <= 0)
                throw new Exception("Liste Boş");

            foreach (var item in frtDetayList)
            {
                if (item.Id <= 0 || item.FaturaId <= 0)
                    throw new Exception("Id Hatası");

                if (item.MalHizmetId <= 0)
                    throw new Exception("Mal ve Hizmet Seçilmeyen Satır Var");

                if (item.Miktar <= 0)
                    throw new Exception("Miktar Girilmeyen Satır Var");


                if (item.Fiyat <= 0)
                    throw new Exception("Fiyat Girilmeyen Satır Var");
            }


        }
        static DynamicParameters Parametre(Fatura ftr)
        {
            var param = new DynamicParameters();
            param.Add("@p0", ftr.Id);
            param.Add("@p1", ftr.BelgeTipi);
            param.Add("@p2", ftr.BelgeNo);
            param.Add("@p3", ftr.BelgeTarihi);
            param.Add("@p4", ftr.BelgeTuru);
            param.Add("@p5", ftr.FirmaId);
            param.Add("@p6", ftr.BelgeKayitTarihi);
            param.Add("@p7", ftr.Aciklama);
            param.Add("@p8", ftr.KullaniciId);
            param.Add("@p9", ftr.IslemTarihi);
            param.Add("@p10", ftr.Veli);
            return param;
        }

        static DynamicParameters Parametre(FaturaDetay ftrDetay)
        {
            var param = new DynamicParameters();
            param.Add("@p0", ftrDetay.Id);
            param.Add("@p1", ftrDetay.FaturaId);
            param.Add("@p2", ftrDetay.MalHizmetId);
            param.Add("@p3", ftrDetay.Miktar);
            param.Add("@p4", ftrDetay.Fiyat);
            param.Add("@p5", ftrDetay.KdvOrani);
            param.Add("@p6", ftrDetay.IskontoTutari);
            param.Add("@p7", ftrDetay.Aciklama);
            param.Add("@p8", ftrDetay.KullaniciId);
            param.Add("@p9", ftrDetay.IslemTarihi);
            return param;
        }
    }
}
