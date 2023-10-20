using OgrenciTakipMuh.Data.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Data.Entities.Entity
{

    public class Cek: BaseKasaBankaCek
    {

        public string Tur { get; set; }
        public string CekNo { get; set; }
        public string CekBanka { get; set; }
        public DateTime VadeTarihi { get; set; }
        public decimal Tutar { get; set; }
        public DateTime GirisTarihi { get; set; }
        public int GirisIslemId { get; set; }
        public long GirisOgrenciId { get; set; }
        public long GirisfirmaId { get; set; }
        public long GirisPersonelId { get; set; }
        public string GirisAciklama { get; set; }
        public long GirisKullaniciId { get; set; }
        public DateTime GirisIslemTarihi { get; set; }
        public DateTime? CikisTarihi { get; set; }
        public int? CikisIslemId { get; set; }
        public long? CikisOgrenciId { get; set; }
        public long? CikisfirmaId { get; set; }
        public long? CikisPersonelId { get; set; }
        public string CikisAciklama { get; set; }
        public long? CikisKullaniciId { get; set; }
        public DateTime? CikisIslemTarihi { get; set; }
        public bool CikisYapildi { get; set; }
        public long CikisHesapId { get; set; }
    

    }
    public class CekL : Cek
    {
        public string GirisIslemAdi { get; set; }
        public string GirisOgrenciAdi { get; set; }
        public string GirisFirmaAdi { get; set; }
        public string GrisPersonelAdi { get; set; }
        public string CikisIslemAdi { get; set; }
        public string CikisOgrenciAdi { get; set; }
        public string CikisFirmaAdi { get; set; }
        public string CikisPersonelAdi { get; set; }
        public int KalanGun { get; set; }
    }

    public class CekGirisCikis
    {
        public decimal Giris { get; set; }
        public decimal Cikis { get; set; }
    }
}
