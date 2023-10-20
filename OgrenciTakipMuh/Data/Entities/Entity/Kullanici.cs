using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
   public class Kullanici:BaseEntity
    {
        public string KullaniciTuru { get; set; }
        public string AdiSoyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public long RolId { get; set; }
        public byte[] AnaResim { get; set; }
        public string Tema { get; set; }
        public string TemaParametre { get; set; }

        public bool OtoKapanma { get; set; }

        public int OtoKapanmaSuresi { get; set; }
    }

    public class KullaniciL : Kullanici
    {
        public string RolAdi { get; set; }
  
    }


}
