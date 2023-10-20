
using OgrenciTakipMuh.Data.Entities.BaseEntities;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Sinif:BaseEntity
    {
        public string SinifAdi { get; set; }
        public long DonemId { get; set; }
        public long GrupId { get; set; }
    }
    public class SinifL:Sinif
    {
        public string GrupAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public int OgrenciSayisi { get; set; }
    }
}