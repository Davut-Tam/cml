using System;
using System.Windows.Forms;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh.Forms.ListForms
{

    public partial class DonemEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        public Donem dnm;

        public DonemEditForm()
        {
            InitializeComponent();

            if (DonemListForm.SeciliId > 0)
            {
                dnm = DonemF.Secim(DonemListForm.SeciliId);

                txtDonemAdi.Text = dnm.DonemAdi;
                txtAciklama.Text = dnm.Aciklama;
                txtBaslamaTarihi.EditValue = dnm.BaslamaTarihi;
                txtBitisTarihi.EditValue = dnm.BitisTarihi;
                this.Text += " ( Kayıt Güncelleme )";
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
            Donem dnm = new Donem
            {
                Id = GenelFunctions.IdOlustur(),
                DonemAdi = txtDonemAdi.Text,
                BaslamaTarihi = txtBaslamaTarihi.DateTime,
                BitisTarihi = txtBitisTarihi.DateTime,
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
                    kayitVar = DonemF.Ekle(dnm);
                }
                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = DonemF.Guncelle(dnm, DonemListForm.SeciliId);
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
                kayitVar = DonemF.Sil(DonemListForm.SeciliId);
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