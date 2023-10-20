using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class MalHizmetEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        MalHizmet MlHizmet;

        public MalHizmetEditForm()
        {
            InitializeComponent();
            EventLoad();
            txtMiktarBrim.AddItems();

            if (MalHizmetListForm.SeciliId > 0)
            {
                MlHizmet = MalHizmetF.Secim(MalHizmetListForm.SeciliId);

                txtMalHizmetAdi.Text = MlHizmet.MalHizmetAdi;
                txtMiktarBrim.Text = MlHizmet.MiktarBrim;
                txtAciklama.Text = MlHizmet.Aciklama;
                btnKaydet.Text = "Güncelle";
                _yeniKayit = false;
            }
            else
            {
                btnSil.Enabled = false;
                this.Text += " ( Yeni Kayıt )";
                _yeniKayit = true;

            }
        }

        void EventLoad()
        {
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            btnSil.Click += BtnSil_Click;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                kayitVar = MalHizmetF.Sil(MalHizmetListForm.SeciliId);
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
;
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            kayitVar = false;
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            MalHizmet MlHizmet = new MalHizmet
            {
                Id = GenelFunctions.IdOlustur(),
                MalHizmetAdi = txtMalHizmetAdi.Text,
                MiktarBrim = txtMiktarBrim.Text,
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
                    kayitVar = MalHizmetF.Ekle(MlHizmet);
                }
                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = MalHizmetF.Guncelle(MlHizmet, MalHizmetListForm.SeciliId);
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


  

    }
}
