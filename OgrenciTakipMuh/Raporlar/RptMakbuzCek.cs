using System;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh.Raporlar
{
    public partial class RptMakbuzCek : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMakbuzCek(bool giris,long CekId)
        {
            InitializeComponent();

            VarsayilanAyarlar vrs = VarsayilanAyarlarF.Secim();
            xrPcbLogo.Image = GenelFunctions.ByteToImageConvert(vrs.KurumLogo);
            lblBilgi.Text = $" Kurum Ünvanı:{vrs.KurumUnvan} Adres:{vrs.Adres} Telefon 1:{vrs.Tel1} Telefon 2:{vrs.Tel2} e-mail:{vrs.MailAdres}";


            CekL ckL = CekF.Secim(CekId);
            lblIslem.Text = giris == true ? "Çek Tahsilat Makbuzu" : "Çek Ödeme Makbuzu";
            lblIslemTarihi.Text = giris == true ? (ckL.GirisTarihi).ToShortDateString() : ((DateTime)ckL.CikisTarihi).ToShortDateString();
            lblIslemSaati.Text = giris == true ? (ckL.GirisTarihi).ToShortTimeString() : ((DateTime)ckL.CikisTarihi).ToShortTimeString();

            lblCekNo.Text = ckL.CekNo;
            lblBanka.Text = ckL.CekBanka;
            lblVadeTarihi.Text = ckL.VadeTarihi.ToShortDateString();

            lblIslemEtiket.Text = giris == true ? "Giriş İşlem Türü" : "Çıkış İşlem Türü";
            lblIslemTuru.Text = giris == true ? ckL.GirisIslemAdi : ckL.CikisIslemAdi;

            if (giris)
            {
                if (ckL.GirisIslemId == 1)
                {
                    lblCariEtiket.Text = "Öğrenci Adı";
                    lblCari.Text = ckL.GirisOgrenciAdi;

                }
                else if (ckL.GirisIslemId == 5 )
                {
                    lblCariEtiket.Text = "Firma Ünvanı";
                    lblCari.Text = ckL.GirisFirmaAdi;
                }
                else
                {
                    lblCariEtiket.Visible = false;
                    lblCari.Visible = false;
                }
            }
            else
            {
                if (ckL.CikisIslemId == 2)
                {
                    lblCariEtiket.Text = "Öğrenci Adı";
                    lblCari.Text =  ckL.CikisOgrenciAdi;

                }
                else if (ckL.CikisIslemId == 3)
                {
                    lblCariEtiket.Text = "Personel Adı";
                    lblCari.Text = ckL.CikisPersonelAdi;
                }
                else if (ckL.CikisIslemId == 6)
                {
                    lblCariEtiket.Text = "Firma Ünvanı";
                    lblCari.Text =  ckL.CikisFirmaAdi;
                }
                else
                {
                    lblCariEtiket.Visible = false;
                    lblCari.Visible = false;
                }
            }

    

            lblTutar.Text = ckL.Tutar.ToString("c2");
            lblAciklama.Text = giris == true ? ckL.GirisAciklama : ckL.CikisAciklama;
            lblKayitPersonel.Text = giris == true ? KullaniciF.Secim(ckL.GirisKullaniciId).AdiSoyadi: KullaniciF.Secim(ckL.CikisKullaniciId??0).AdiSoyadi;
            brkd.Text = giris == true ? CekId.ToString() : (CekId + 1).ToString();
        }
    }
}