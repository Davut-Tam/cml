using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Enums;
using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.GenelForms;
using System.Drawing;

namespace OgrenciTakipMuh.Raporlar
{
    public partial class RprOgrenciRaporlari : DevExpress.XtraReports.UI.XtraReport
    {
        public RprOgrenciRaporlari(long donemId, long grupId, long sinifId, OgrenciRaporTuru ogrenciRaporTuru)
        {
            InitializeComponent();
            lblBaslik.Text = ogrenciRaporTuru.ToName();
            lblGrupAdi.Text = grupId == 0 ? "-Tüm Kayıtlar-" : GrupF.Secim(grupId).GrupAdi;
            lblSinifAdi.Text = sinifId == 0 ? "-Tüm Kayıtlar-" : SinifF.Secim(sinifId).SinifAdi;
            lblKullanici.Text = AnaForm.Kllnci.AdiSoyadi;

            switch (ogrenciRaporTuru)
            {
                case OgrenciRaporTuru.HicOdemeYapmayanlar:
                    DataSource =  OgrenciF.HicOdemeYapmayanOgrenciListesi(donemId,grupId,sinifId);
                    lblBaslik.BackColor = xrTableRow1.BackColor = xrTableRow3.BackColor = Color.FromArgb(255, 128, 128);
                    break;
                case OgrenciRaporTuru.TahakkukYapilmayanlar:
                    DataSource =  OgrenciF.TahakkukYapilmayanlar(donemId, grupId, sinifId);
                    lblBaslik.BackColor = xrTableRow1.BackColor = xrTableRow3.BackColor = Color.SkyBlue;
                    break;
                  
                case OgrenciRaporTuru.OdemesiTamamlananlar:
                    DataSource =  OgrenciF.OdemesiTamamlananlar(donemId, grupId, sinifId);
                    lblBaslik.BackColor = xrTableRow1.BackColor = xrTableRow3.BackColor = Color.LimeGreen;
                    break;

                case OgrenciRaporTuru.OdemesiTamamlanmayanlar:
                    DataSource = OgrenciF.OdemesiTamamlanmayanlar(donemId, grupId, sinifId);
                    lblBaslik.BackColor = xrTableRow1.BackColor = xrTableRow3.BackColor = Color.Yellow;
                    break;

            }
           
           
        }

    }
}
