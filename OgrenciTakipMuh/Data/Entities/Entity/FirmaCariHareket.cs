using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    class FirmaCariHareket : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public string IslemTuru { get; set; }
        public decimal Tutar { get; set; }
        public decimal Bakiye { get; set; }

    }
}
