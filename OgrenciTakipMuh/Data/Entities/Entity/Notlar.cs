using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
   public class Notlar : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public long OgrenciId { get; set; }
    }
}
