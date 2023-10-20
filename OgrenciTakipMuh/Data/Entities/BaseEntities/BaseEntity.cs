using System;

namespace OgrenciTakipMuh.Data.Entities.BaseEntities
{
   public class BaseEntity
    {
        public long Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public long? KullaniciId { get; set; }
        public DateTime? IslemTarihi { get; set; }
    }
}
