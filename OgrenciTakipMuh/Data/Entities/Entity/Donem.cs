using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Donem:BaseEntity
    {
        public string DonemAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
    public class DonemL: Donem
    {
        public string KullaniciAdi { get; set; }
        public string GrupSayisi { get; set; }
        public string SinifSayisi { get; set; }
        public string OgrenciSayisi { get; set; }
    }
}
