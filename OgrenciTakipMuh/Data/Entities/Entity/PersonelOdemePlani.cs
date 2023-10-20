using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
  public  class PersonelOdemePlani: BaseEntity
    {
        public int? TahakkukNo { get; set; }
        public long PersonelId { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public decimal Maas { get; set; }
        public string Tur { get; set; }
        public bool OtomatikMaas { get; set; }

    }

   public  class PersonelOdemePlaniL : PersonelOdemePlani
    {
        public string TahakkukSekli { get; set; }
        public string TahakkukAdi { get; set; }
        public DateTime Tarih { get; set; }
        public string OdemeKanali { get; set; }
        public decimal Tutar { get; set; }
        public decimal Bakiye { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string GirisCikis { get; set; } // sadece Yürüyen Bakiyede kullanılacak

    }
}
