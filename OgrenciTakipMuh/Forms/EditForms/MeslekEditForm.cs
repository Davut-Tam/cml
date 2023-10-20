using OgrenciTakipMuh.Data.Entities;
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
    public partial class MeslekEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        Gorev grv;

        public MeslekEditForm(long id)
        {
            InitializeComponent();
            Id = id;
            if (Id > 0)
            {
                grv = GorevF.Secim(Id);

                txtGorevAdi.Text = grv.GorevAdi;
                txtAciklama.Text = grv.Aciklama;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Gorev grv = new Gorev
            {
                Id = GenelFunctions.IdOlustur(),
                GorevAdi = txtGorevAdi.Text,
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
                    kayitVar = GorevF.Ekle(grv);
                }
                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = GorevF.Guncelle(grv, Id);
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
                kayitVar = GorevF.Sil(Id);
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