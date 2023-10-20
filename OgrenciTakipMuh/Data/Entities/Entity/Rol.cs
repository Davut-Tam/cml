using OgrenciTakipMuh.Data.Entities.BaseEntities;
using OgrenciTakipMuh.Forms.GenelForms;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Rol : BaseEntity

    {
        public string RolAdi { get; set; }

    }

    public class RolDetay
    {

        public long Id { get; set; }
        public long RolId { get; set; }
        public int MenuId { get; set; }
        public byte Gorebilir { get; set; } 
        public byte Ekleyebilir { get; set; }
        public byte Guncelleyebilir { get; set; }
        public byte Silebilir { get; set; }
        public string MenuAdi { get; set; }
    }
}
