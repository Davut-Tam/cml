using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
   public class MalHizmet:BaseEntity
    {
        public string MalHizmetAdi { get; set; }
        public string MiktarBrim { get; set; }

    }
}
