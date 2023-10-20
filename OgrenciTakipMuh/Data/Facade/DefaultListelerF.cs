using Dapper;
using OgrenciTakipMuh.Data.Tools;


namespace OgrenciTakipMuh.Data.Facade
{
    public class DefaultListelerF
    {
        public static void MenuListesiKontrol()
        {
            string[] menuler = new[]
            {
              "Öğrenci İşlemleri",
              "Öğrenci Kayit Yenileme İşlemleri",
              "Öğrenci Veli İşlemleri",
              "Öğrenci Ödenmeyen Tahakkukları Görebilme Yetkisi",
              "Öğrenci Dönem İşlemleri",
              "Öğrenci Grup İşlemleri",
              "Öğrenci Sınıf  İşlemleri",
              "Personel İşlemleri",
              "Personel Görev Listesi",
              "Firma İşlemleri",
              "Firma Cari Hareket İşlemleri",
              "Gelen (Alış) Fatura İşlemleri",
              "Giden (Satış) Fatura İşlemleri",
              "Mal ve Hizmet İşlemleri",
              "Nakit İşlemler",
              "Banka İşlemleri",
              "Banka Hesap İşlemleri",
              "Çek / Senet İşlemleri",
              "Personel Tahakkuk İşlemleri",
              "Öğrenci Hatırlatmaları Görebilme Yetkisi",
              "Personel Hatırlatmaları Görebilme Yetkisi",
              "Çek / Senet Hatırlatmaları Görebilme Yetkisi",
              "Öğrenci Raporları Görebilme Yetkisi",
              "Sms İşlemleri",
              "Öğrenci Tutarları Görebilme Yetkisi"
            };

            if (KayitSayisi("MenuListesi") == menuler.Length) return;

            Connections.cnn.Execute($"Delete From MenuListesi");
            for (int i = 0; i < menuler.Length; i++)
                Connections.cnn.Execute($"Insert Into MenuListesi  Values ({i + 1},'{menuler[i]}')");



        }



        private static int KayitSayisi(string alan)
        {
            try
            {
                return (int)Connections.cnn.ExecuteScalar($"SELECT Count(*) from {alan}");
            }
            catch (System.Exception)
            {

                return 0;
            }

        }
    }
}
