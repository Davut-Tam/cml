using System;
using System.Windows.Forms;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class GrupEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        public Grup grp;
        private long _donemId;
        private long _grupId;

        public GrupEditForm(long grupId=0,long donemId=0)
        {
            InitializeComponent();
            _grupId = grupId;
            _donemId = donemId;
            txtDonem.Text = DonemF.Secim(_donemId).DonemAdi;
            if (grupId > 0)
            {
                grp = GrupF.Secim(grupId);

                txtGrupAdi.Text = grp.GrupAdi;
                txtAciklama.Text = grp.Aciklama;
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
            Grup grp = new Grup
            {
                Id = GenelFunctions.IdOlustur(),
                GrupAdi = txtGrupAdi.Text,
                DonemId = _donemId,
                Aciklama = txtAciklama.Text,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi =DateTime.Now
            };

            try
            {
                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    kayitVar = GrupF.Ekle(grp);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = GrupF.Guncelle(grp, _grupId);
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
                kayitVar = GrupF.Sil(_grupId);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
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
    }
}