

using OgrenciTakipMuh.Data.Entities.BaseEntities;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
   public class Grup:BaseEntity
    {
        public string GrupAdi { get; set; }
        public long DonemId { get; set; }

    }
    public class GrupL : Grup
    {
        public string KullaniciAdi { get; set; }
        public string SinifSayisi { get; set; }
        public string OgrenciSayisi { get; set; }
    }
}