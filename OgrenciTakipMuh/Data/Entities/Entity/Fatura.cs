using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Fatura:BaseEntity
    {
        public string BelgeTipi { get; set; }
        public string BelgeNo { get; set; }
        public DateTime BelgeTarihi { get; set; }
        public string BelgeTuru { get; set; }
        public long FirmaId { get; set; }
        public DateTime BelgeKayitTarihi { get; set; }
        public bool Veli { get; set; }


    }

    public class FaturaL : Fatura
    {
        public decimal Matrah { get; set; }
        public decimal Iskonto { get; set; }
        public decimal Kdv { get; set; }
        public decimal Odenecek { get; set; }

        public string FirmaAdi { get; set; }
        public string VergiTcKimlikNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Adres { get; set; }
        public string Tel1 { get; set; }


    }
}
