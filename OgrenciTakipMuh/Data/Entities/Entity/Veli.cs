using OgrenciTakipMuh.Data.Entities.BaseEntities;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Veli:BaseEntity
    {
        public string VeliAdiSoyadi { get; set; }
        public string TcKimlikNo { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public long GorevId { get; set; }
    }

    public class VeliL : Veli
    {
        public string OgrenciAdi { get; set; }
        public int OgrenciSayisi { get; set; }
        public string GorevAdi { get; set; }
    }
}