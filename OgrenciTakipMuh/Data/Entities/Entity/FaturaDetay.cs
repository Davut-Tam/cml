using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class FaturaDetay : BaseEntity
    {



        public long FaturaId { get; set; }
        public long MalHizmetId { get; set; }
        public decimal Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public int KdvOrani { get; set; }
        public decimal IskontoTutari { get; set; }

        public decimal Tutar
        {
            get { return (Miktar * Fiyat); }
            set { }
        }

    }

    public class FaturaDetayL : FaturaDetay
    {
        public int Sira { get; set; }
        public string MalHizmetAdi { get; set; }
        public string MiktarBrim { get; set; }

    }


}
