using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using OgrenciTakipMuh.Enums;
using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.GenelForms;

namespace OgrenciTakipMuh.Raporlar
{
    public partial class RprOdemesiYapilanTaksitler : DevExpress.XtraReports.UI.XtraReport
    {
        public RprOdemesiYapilanTaksitler(long donemId, long grupId, long sinifId, OgrenciRaporTuru ogrenciRaporTuru, DateTime baslamaTarih, DateTime bitisTarih)
        {
            InitializeComponent();

            lblBaslik.Text = ogrenciRaporTuru.ToName() + " ( " + baslamaTarih.ToShortDateString() + " - " + bitisTarih.ToShortDateString() + " )";
            lblGrupAdi.Text = grupId == 0 ? "-Tüm Kayıtlar-" : GrupF.Secim(grupId).GrupAdi;
            lblSinifAdi.Text = sinifId == 0 ? "-Tüm Kayıtlar-" : SinifF.Secim(sinifId).SinifAdi;
            lblKullanici.Text = AnaForm.Kllnci.AdiSoyadi;
            DataSource = OgrenciOdemePlaniF.OdemesiYapilanTaksitler(donemId, grupId, sinifId, baslamaTarih, bitisTarih);

        }

    }
}
