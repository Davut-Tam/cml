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
    public partial class BankaHesapEditForm : BaseEditForm
    {
     

        private bool _yeniKayit;
        public bool kayitVar;
        public BankaHesap hsp;

        public BankaHesapEditForm()
        {
            InitializeComponent();

            if (BankaHesapListForm.SeciliId > 0)
            {
                hsp = BankaHesapF.Secim(BankaHesapListForm.SeciliId);
                txtHesapAdi.Text = hsp.HesapAdi;
                txtBankaAdi.Text = hsp.BankaAdi;
                txtSubeAdi.Text = hsp.SubeAdi;
                txtIbanNo.Text = hsp.IbanNo;
                tglDurum.IsOn = hsp.Durum;
                txtAciklama.Text = hsp.Aciklama;            
                this.Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
                _yeniKayit = false;
            }
            else
            {
                btnSil.Enabled = false;
                this.Text += " ( Yeni Kayıt )";
                _yeniKayit = true;
                txtHesapAdi.Focus();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            BankaHesap hsp = new BankaHesap
            {
                Id = GenelFunctions.IdOlustur(),
                HesapAdi = txtHesapAdi.Text,
                BankaAdi = txtBankaAdi.Text,
                SubeAdi = txtSubeAdi.Text,
                IbanNo = txtIbanNo.Text,
                Durum = tglDurum.IsOn,
                Aciklama = txtAciklama.Text,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now
            };

            try
            {
                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    kayitVar = BankaHesapF.Ekle(hsp);
                }
                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = BankaHesapF.Guncelle(hsp, BankaHesapListForm.SeciliId);
                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                kayitVar = false;
            }

            if (kayitVar)
                this.Close();
    

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                kayitVar = BankaHesapF.Sil(DonemListForm.SeciliId);
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            kayitVar = false;
            this.Close();
        }
    }
}
