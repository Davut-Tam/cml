using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Banka: BaseKasaBankaCek
    {
        public DateTime? Tarih { get; set; }
        public string GirisCikis { get; set; }
        public long HesapId { get; set; }
        public int IslemId { get; set; }
        public decimal Tutar { get; set; }
        public decimal Bakiye { get; set; }
        public long NakitIslemId { get; set; }
        public long VirmanHesapId { get; set; }
        public long? CekIslemId { get; set; }


    }

    public class BankaL : Banka
    {
        public string OgrenciAdi { get; set; }
        public string IslemAdi { get; set; }
        public string FirmaAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string HesapAdi { get; set; }
    }

    public class BankaGirisCikis
    {
        public decimal Giris { get; set; }
        public decimal Cikis { get; set; }
    }

}
