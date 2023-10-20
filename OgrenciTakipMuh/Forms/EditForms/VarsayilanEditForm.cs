using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using DevExpress.Utils;
using DevExpress.XtraLayout.Utils;
using OgrenciTakipMuh.Controls.Components;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class VarsayilanEditForm : BaseEditForm
    {

        AnaForm frm;
        public VarsayilanEditForm()
        {
            InitializeComponent();
            EventLoad();
            VarsayilanBilgiler();
            TglOtomatikYedekleme_Toggled(null, null);
            txtOtoSmsMesaj.EnterMoveNextControl = false;
            txtOtoSmsMesaj.ToolTipController = new ToolTipController { AutoPopDelay = 20000 }; ;
        }

        void VarsayilanBilgiler()
        {

            if (VarsayilanAyarlarF.KayitSayisiKontrol() == 0)
            {
                btnKaydet.Text = "Kaydet";
                Text += " ( Yeni Kayıt )";
                txtSaat.EditValue = new DateTime(2020, 01, 01, 0, 0, 0);
                return;

            }
            VarsayilanAyarlar ayr = VarsayilanAyarlarF.Secim();
            if (ayr.DonemId != 0)
            {
                txtVarsayilanDonem.Text = DonemF.Secim(ayr.DonemId).DonemAdi;
                txtVarsayilanDonem.Tag = ayr.DonemId;
            }

            if (ayr.BankaHesapId != 0)
            {
                txtvarsayilanBankaHesap.Text = BankaHesapF.Secim(ayr.BankaHesapId).BankaAdi + " " + BankaHesapF.Secim(ayr.BankaHesapId).SubeAdi + " / " + BankaHesapF.Secim(ayr.BankaHesapId).IbanNo;
                txtvarsayilanBankaHesap.Tag = ayr.BankaHesapId;
            }

            txtKurumUnvan.Text = ayr.KurumUnvan;
            txtVergiNo.Text = ayr.VergiNo;
            txtVergiDairesi.Text = ayr.VergiDairesi;
            txtTel1.Text = ayr.Tel1;
            txtTel2.Text = ayr.Tel2;
            txtAdres.Text = ayr.Adres;
            myPictureEdit1.EditValue = ayr.KurumLogo;

            txtMailAdres.Text = ayr.MailAdres;

            tglKayitSesleri.IsOn = ayr.KayitSesi;

            txtYedeklemeYolu.Text = ayr.YedeklemeYolu;
            tglOtomatikYedekleme.IsOn = ayr.OtomatikYedekleme;
            txtSaat.EditValue = ayr.YedeklemeSaati;
            tglMailYedekleme.IsOn = ayr.OtoYedeklemeMail;
            txtYedeklenecekMailAdres.Text = ayr.OtoYedeklemeMailAdres;

            txtSmsBaslik.Text = ayr.SmsBaslik;
            txtSmsKullaniciAdi.Text = ayr.SmsKullaniciAdi;
            txtSmsSifre.Text = ayr.SmsSifre;
            tglSmsGonderme.IsOn = ayr.SmsGonderme;
            chbOtoSms.Checked = ayr.OtoSms;
            txtSure1.Value = ayr.BirinciSmsSuresi;
            txtSure2.Value = ayr.IkinciSmsSuresi;
            txtOtoSmsMesaj.EditValue = ayr.OtoSmsMesaj;
            TglSmsGonderme_Toggled(null, null);

        }
        void EventLoad()
        {
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;

            txtVarsayilanDonem.ButtonClick += TxtVarsayilanDonem_ButtonClick;
            txtvarsayilanBankaHesap.ButtonClick += TxtvarsayilanBankaHesap_ButtonClick;

            myPictureEdit1.Enter += MyPictureEdit1_Enter;
            txtYedeklemeYolu.ButtonClick += TxtYedeklemeYolu_ButtonClick;

            tglOtomatikYedekleme.Toggled += TglOtomatikYedekleme_Toggled;
            tglSmsGonderme.Toggled += TglSmsGonderme_Toggled;
            chbOtoSms.CheckedChanged += ChbOtoSms_CheckedChanged;
        }

        private void ChbOtoSms_CheckedChanged(object sender, EventArgs e)
        {
            layoutSure1.Enabled = layoutSure2.Enabled = layoutOtoSmsMesaj.Enabled = chbOtoSms.Checked && tglSmsGonderme.IsOn;
        }

        private void TglSmsGonderme_Toggled(object sender, EventArgs e)
        {
            layoutSmsBaslik.Enabled = layoutSmsKullaniciAdi.Enabled = layoutSmsSifre.Enabled = layoutOtoSms.Enabled = layoutSure1.Enabled = layoutSure2.Enabled = layoutOtoSmsMesaj.Enabled = tglSmsGonderme.IsOn;
            ChbOtoSms_CheckedChanged(null, null);
        }

        private void TglOtomatikYedekleme_Toggled(object sender, EventArgs e)
        {
            lytNot.Visibility = lytYedeklemeSaati.Visibility = lytMailYdekleme.Visibility = tglOtomatikYedekleme.IsOn ? LayoutVisibility.Always : LayoutVisibility.Never;
            if (!tglOtomatikYedekleme.IsOn) tglMailYedekleme.IsOn = false;

            lytOtoYedeklemeMailAdres.Visibility = tglMailYedekleme.IsOn ? LayoutVisibility.Always : LayoutVisibility.Never;
        }
        private void TglMailYedekleme_Toggled(object sender, EventArgs e)
        {
            lytOtoYedeklemeMailAdres.Visibility = tglMailYedekleme.IsOn ? LayoutVisibility.Always : LayoutVisibility.Never;
        }
        private void TxtYedeklemeYolu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtYedeklemeYolu.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void MyPictureEdit1_Enter(object sender, EventArgs e)
        {
            ((MyPictureEdit)sender).Sec(popupMenu1);
        }

        private void TxtvarsayilanBankaHesap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BankaHesapListForm fr = new BankaHesapListForm(true);
            fr.ShowDialog();
            txtvarsayilanBankaHesap.Tag = fr.SeciliHesapId;
            txtvarsayilanBankaHesap.Text = fr.SeciliHesap;
            fr.Dispose();
        }

        private void TxtVarsayilanDonem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DonemListForm fr = new DonemListForm(true);
            fr.ShowDialog();
            txtVarsayilanDonem.Tag = fr.donemId;
            txtVarsayilanDonem.Text = fr.SeciliDonemAdi;
            fr.Dispose();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            try
            {

                VarsayilanAyarlar ayr = new VarsayilanAyarlar()
                {
                    DonemId = Convert.ToInt64(txtVarsayilanDonem.Tag),
                    BankaHesapId = Convert.ToInt64(txtvarsayilanBankaHesap.Tag),
                    KurumUnvan = txtKurumUnvan.Text,
                    VergiNo = txtVergiNo.Text,
                    VergiDairesi = txtVergiDairesi.Text,
                    Tel1 = txtTel1.Text,
                    Tel2 = txtTel2.Text,
                    Adres = txtAdres.Text,
                    KurumLogo = (byte[])myPictureEdit1.EditValue,
                    MailAdres = txtMailAdres.Text,
                    KayitSesi = tglKayitSesleri.IsOn,
                    YedeklemeYolu = txtYedeklemeYolu.Text,
                    YedeklemeSaati = saat,
                    OtomatikYedekleme = tglOtomatikYedekleme.IsOn,
                    OtoYedeklemeMail = tglMailYedekleme.IsOn,
                    OtoYedeklemeMailAdres = txtYedeklenecekMailAdres.Text,
                    SmsBaslik = txtSmsBaslik.Text,
                    SmsKullaniciAdi = txtSmsKullaniciAdi.Text,
                    SmsSifre = txtSmsSifre.Text,
                    SmsGonderme = tglSmsGonderme.IsOn,
                    OtoSms = chbOtoSms.Checked,
                    BirinciSmsSuresi = (int)txtSure1.Value,
                    IkinciSmsSuresi = (int)txtSure2.Value,
                    OtoSmsMesaj = txtOtoSmsMesaj.Text,

                };

                if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                    return;
                if (VarsayilanAyarlarF.Guncelle(ayr))
                {
                    frm = Application.OpenForms["AnaForm"] as AnaForm;
                    frm.GenelAyarlar();
                    Close();
                }

            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }

        }

        TimeSpan saat;
        private void TxtSaat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime tarihsaat = (DateTime)txtSaat.EditValue;
                saat = new TimeSpan(tarihsaat.Hour, tarihsaat.Minute, tarihsaat.Second);
            }
            catch (Exception)
            {

                saat = (TimeSpan)txtSaat.EditValue;
            }


        }


    }
}
