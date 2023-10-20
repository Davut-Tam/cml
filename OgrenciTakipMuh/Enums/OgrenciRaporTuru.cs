using System.ComponentModel;

namespace OgrenciTakipMuh.Enums
{
    public enum OgrenciRaporTuru : byte
    {
        [Description("Hiç Ödeme Yapmayanlar")] HicOdemeYapmayanlar = 0,
        [Description("Tahakkuk Yapılmayanlar")] TahakkukYapilmayanlar = 1,
        [Description("Ödemesi Tamamlananlar")] OdemesiTamamlananlar = 2,
        [Description("Ödemesi Tamamlanmayanlar")] OdemesiTamamlanmayanlar = 3,
        [Description("Ödeme Yapmayanlar")] OdemeYapmayanlar = 4,
        [Description("Ödeme Yapanlar")] OdemeYapanlar = 5,

    }
}
