
using OgrenciTakipMuh.Properties;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Tools;
using System;
using System.Linq;

namespace OgrenciTakipMuh.Raporlar
{
    public partial class RprOgrenciOdemePlani : DevExpress.XtraReports.UI.XtraReport
    {

        public RprOgrenciOdemePlani(long OgrenciId)
        {
            InitializeComponent();
            var donemId = OgrenciF.Secim(OgrenciId).DonemId;
            DataSourceOdemePlani.DataSource = OgrenciOdemePlaniF.OdemePlani(OgrenciId, donemId);
            if (OgrenciOdemePlaniF.OdemeListesiVarmi(OgrenciId))
            {
                lblOdemeVarmi.Visible = false;
                DetailReportOdemeListesi.Visible = true;
                DataSourceOdemeListesi.DataSource = OgrenciOdemePlaniF.OdemeListesi(OgrenciId);
            }
           

            OgrenciL ogrL = OgrenciF.Secim(OgrenciId);
            VarsayilanAyarlar vrs = VarsayilanAyarlarF.Secim();
            xrPcbLogo.Image = GenelFunctions.ByteToImageConvert(vrs.KurumLogo);
            xrPcbOgr.Image = GenelFunctions.ByteToImageConvert(ogrL.Resim);
            //if (xrPcbOgr.Image==null) xrPcbOgr.Image = Resources.BosOgrenciResmi;

            lblOgrenciAdi.Text = ogrL.AdiSoyadi;
            lblGrup.Text = ogrL.GrupAdi;
            lblSinif.Text = ogrL.SinifAdi;
            lblDonem.Text = ogrL.DonemAdi;

            lblTahTutari.Text = ogrL.TahakkukTutari.ToString("n2");
            lblOdemeTutari.Text = ogrL.TahsilatTutari.ToString("n2");
            lblGeriOdeme.Text = ogrL.GeriIadeTutari.ToString("n2");
            lblKalanBakiye.Text = ogrL.KalanBakiye.ToString("n2");


            lblBilgi.Text = $"Kurum Ünvanı: {vrs.KurumUnvan}  Adres: {vrs.Adres}  Telefon 1: {vrs.Tel1}  Telefon 2: {vrs.Tel2}  e-mail:{vrs.MailAdres}  ";
            BankaHesap bnk = BankaHesapF.Secim(vrs.BankaHesapId);
            lblBankaBilgileri.Text = $"Banka Bilgilerimiz : {bnk.BankaAdi} {bnk.SubeAdi}  /  {bnk.IbanNo}";
            lbltarih.Text += DateTime.Now.ToShortDateString();
            brkd.Text = OgrenciId.ToString();

            

        }


    }
}