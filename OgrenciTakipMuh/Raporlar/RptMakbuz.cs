using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using System;

namespace OgrenciTakipMuh.Raporlar
{
    public partial class RptMakbuz : DevExpress.XtraReports.UI.XtraReport
    {
 
        public RptMakbuz(byte kanal,long IslemId)
        {
            InitializeComponent();
     
            VarsayilanAyarlar vrs = VarsayilanAyarlarF.Secim();
            xrPcbLogo.Image = GenelFunctions.ByteToImageConvert(vrs.KurumLogo);
            lblBilgi.Text = $" Kurum Ünvanı:{vrs.KurumUnvan} Adres:{vrs.Adres} Telefon 1:{vrs.Tel1} Telefon 2:{vrs.Tel2} e-mail:{vrs.MailAdres}";


            switch (kanal)
            {
                case 1:
                    NakitBilgileri(IslemId);
                    break;
                case 2:
                    BankaBilgileri(IslemId);
                    break;
            }
            brkd.Text = IslemId.ToString();

        }

        void NakitBilgileri(long IslemId)
        {
            NakitL nktL = NakitF.Secim(IslemId);
            lblIslem.Text= nktL.GirisCikis== "Giriş" ? "Tahsilat Makbuzu" : "Ödeme Makbuzu";
            lblIslemTarihi.Text = ((DateTime)nktL.Tarih).ToShortDateString();
            lblIslemSaati.Text = ((DateTime)nktL.Tarih).ToShortTimeString();

            lblKanal.Text = "Nakit Kasa";
            lblIslemTuru.Text = nktL.IslemAdi;
            if(nktL.IslemId==1 || nktL.IslemId == 2)
            {
                lblCariEtiket.Text = "Öğrenci Adı";
                lblCari.Text = nktL.OgrenciAdi;

            }
            else if(nktL.IslemId == 3 || nktL.IslemId == 4)
            {
                lblCariEtiket.Text = "Personel Adı";
                lblCari.Text = nktL.PersonelAdi;
            }
            else if (nktL.IslemId == 5 || nktL.IslemId == 6)
            {
                lblCariEtiket.Text = "Firma Ünvanı";
                lblCari.Text = nktL.FirmaAdi;
            }
            else
            {
                lblCariEtiket.Visible = false;
                lblCari.Visible = false;
            }

            lblTutar.Text = nktL.Tutar.ToString("c2");
            lblAciklama.Text = nktL.Aciklama;
            lblKayitPersonel.Text = KullaniciF.Secim(nktL.KullaniciId??0).AdiSoyadi;

          
        }

        void BankaBilgileri(long IslemId)
        {
            BankaL bnkL = BankaF.Secim(IslemId);
            lblIslem.Text = bnkL.GirisCikis == "Giriş" ? "Tahsilat Makbuzu" : "Ödeme Makbuzu";
            lblIslemTarihi.Text = ((DateTime)bnkL.Tarih).ToShortDateString();
            lblIslemSaati.Text = ((DateTime)bnkL.Tarih).ToShortTimeString();

            lblKanal.Text = "Banka / "+ BankaHesapF.Secim(bnkL.HesapId).IbanNo;
            lblIslemTuru.Text = bnkL.IslemAdi;
            if (bnkL.IslemId == 1 || bnkL.IslemId == 2)
            {
                lblCariEtiket.Text = "Öğrenci Adı";
                lblCari.Text = bnkL.OgrenciAdi;

            }
            else if (bnkL.IslemId == 3 || bnkL.IslemId == 4)
            {
                lblCariEtiket.Text = "Personel Adı";
                lblCari.Text = bnkL.PersonelAdi;
            }
            else if (bnkL.IslemId == 5 || bnkL.IslemId == 6)
            {
                lblCariEtiket.Text = "Firma Ünvanı";
                lblCari.Text = bnkL.FirmaAdi;
            }
            else
            {
                lblCariEtiket.Visible = false;
                lblCari.Visible = false;
            }

            lblTutar.Text = bnkL.Tutar.ToString("c2");
            lblAciklama.Text = bnkL.Aciklama;
            lblKayitPersonel.Text = KullaniciF.Secim(bnkL.KullaniciId ?? 0).AdiSoyadi;
        }
    }
}