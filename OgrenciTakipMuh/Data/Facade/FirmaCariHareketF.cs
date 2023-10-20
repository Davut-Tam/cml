using Dapper;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;

namespace OgrenciTakipMuh.Data.Facade
{
    class FirmaCariHareketF
    {

        public static object Liste(long firmaId)
        {
           var list= Connections.cnn.Query<FirmaCariHareket>($@"Select * From viewFirmaCariHareket Where FirmaId='{firmaId}' order by Tarih desc");

            decimal bakiye = FirmaF.Secim(firmaId).Bakiye;

            foreach (var item in list)
            {
                item.Bakiye += bakiye;
                if (item.IslemTuru == "Satış" || item.IslemTuru == "Ödeme")
                    bakiye -= item.Tutar;
                else
                    bakiye += item.Tutar;
            }
            return list;
        }


    }
}
