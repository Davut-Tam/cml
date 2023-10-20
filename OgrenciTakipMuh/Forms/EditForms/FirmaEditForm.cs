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
    public partial class FirmaEditForm : BaseEditForm
    {
        public FirmaL frmL;
        public Firma frm;
        public bool YeniKayit;
        public bool KayitVar;



        public FirmaEditForm()
        {
            InitializeComponent();
            EventLoad();

            if (FirmaListForm.SeciliId > 0)
            {

                YeniKayit = false;

                frmL = FirmaF.Secim(FirmaListForm.SeciliId);
                txtFirmaAdi.Text = frmL.FirmaAdi;
                txtVergiTcKimlikNo.Text = frmL.VergiTcKimlikNo;
                txtVergiDairesi.Text = frmL.VergiDairesi;
                txtFirmaTuru.Text = frmL.Tur;

                txtTel1.Text = frmL.Telefon;

                txtBankaAdi.Text = frmL.BankaAdi;
                txtIbanNo.Text = frmL.IbanNo;


                txtAdres.Text = frmL.Adres;
                txtAciklama.Text = frmL.Aciklama;
                tglDurum.IsOn = frmL.Durum;
                btnSil.Enabled = true;
                this.Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                this.Text += " ( Yeni Kayıt )";
                YeniKayit = true;
            }
           
        }

        void EventLoad()
        {
            btnKaydet.Click += BtnKaydet_Click;
            btnSil.Click += BtnSil_Click;
            btnIptal.Click += BtnIptal_Click;
            txtFirmaTuru.TextChanged += TxtFirmaTuru_TextChanged;
        }

        private void TxtFirmaTuru_TextChanged(object sender, EventArgs e)
        {
            if(txtFirmaTuru.Text=="Gerçek Kişi")
            {
                lblVergiTcNo.Text = "Tc Kimlik No";
                txtVergiTcKimlikNo.Properties.MaxLength = 11;
            }
            else
            {
                lblVergiTcNo.Text = "Vergi No";
                txtVergiTcKimlikNo.Properties.MaxLength = 10;
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            KayitVar = false;
            Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                KayitVar = FirmaF.Sil(FirmaListForm.SeciliId);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
                KayitVar = false;
            }

            if (KayitVar)
                this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Firma frm = new Firma
            {
                Id = GenelFunctions.IdOlustur(),
                FirmaAdi = txtFirmaAdi.Text,
                VergiTcKimlikNo = txtVergiTcKimlikNo.Text,
                VergiDairesi = txtVergiDairesi.Text,
                Tur=txtFirmaTuru.Text,
                Telefon = txtTel1.EditValue == null ? null : txtTel1.Text == "" ? null : txtTel1.Text,
                BankaAdi = txtBankaAdi.Text,
                IbanNo = txtIbanNo.Text,
                Durum = tglDurum.IsOn,
                Adres = txtAdres.Text,
                Aciklama = txtAciklama.Text,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now,

            };


            try
            {
                if (YeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    KayitVar = FirmaF.Ekle(frm);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    KayitVar = FirmaF.Guncelle(frm, FirmaListForm.SeciliId);


                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);

            }

            if (KayitVar)
                Close();
        }
    }
}
