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
    public partial class SinifEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        private bool _dvm;
        public bool kayitVar;
        public SinifL snf;
        private long _donemId;
        private long _sinifId;

        public SinifEditForm(long sinifId = 0, long donemId=0)
        {
            InitializeComponent();
            _donemId = donemId;
            _sinifId = sinifId;
            txtDonem.Text  = DonemF.Secim(_donemId).DonemAdi;
            txtGrupAdi.AddItems(dnmId: _donemId);


            if (_sinifId > 0)
            {
                snf = SinifF.Secim(_sinifId);

                txtSinifAdi.Text = snf.SinifAdi;
                txtAciklama.Text = snf.Aciklama;
                txtGrupAdi.Text = snf.GrupAdi;
                txtGrupAdi.Tag = snf.GrupId;
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
            _dvm = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Sinif snf = new Sinif
            {
                Id = GenelFunctions.IdOlustur(),
                SinifAdi = txtSinifAdi.Text,
                GrupId = Convert.ToInt64(txtGrupAdi.Tag),
                Aciklama = txtAciklama.Text,
                DonemId = _donemId,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now
            };

            


            try
            {
                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    kayitVar = SinifF.Ekle(snf);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = SinifF.Guncelle(snf, _sinifId);
                }
            }
            catch (Exception ex)
            {
                kayitVar = false;
                Messages.HataMesaji(ex.Message);
            }

            if (kayitVar)
                this.Close();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                kayitVar = SinifF.Sil(_sinifId);
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
                kayitVar = false;
            }
           if(kayitVar)
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            kayitVar = false;
            this.Close();
        }

        private void txtGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            txtGrupAdi.Tag = txtGrupAdi.ItemsId(_donemId) ;
        }
    }
}