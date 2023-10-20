using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using DevExpress.Skins;
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
    public partial class KullaniciEditForm : BaseEditForm
    {
        private long _seciliId;
        public Kullanici klnc;
        public KullaniciL klncL;
        public bool YeniKayit;
        public bool KayitVar;
        public bool IlkYoneticiTanimi;
        AnaForm frm;


        public KullaniciEditForm(long seciliId)
        {
            InitializeComponent();
            _seciliId = seciliId;
            EventLoad();


            if (_seciliId > 0)
            {
                YeniKayit = false;

                klncL = KullaniciF.Secim(_seciliId);
                txtAdiSoyadi.Text = klncL.AdiSoyadi;
                txtKullaniciTuru.Text = klncL.KullaniciTuru;
                txtKullaniciAdi.Text = klncL.KullaniciAdi;
                txtSifre.Text = klncL.Sifre;
                txtRolAdi.Tag = klncL.RolId;
                if(klncL.RolId==1) txtRolAdi.Text = "Tam Yetki"; else txtRolAdi.Text = klncL.RolAdi;
                txtAciklama.Text = klncL.Aciklama;
                myPictureEdit1.EditValue = klncL.AnaResim;
                this.Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
                tglOtomatikKapanma.IsOn = txtOtoKapanmaSuresi.Enabled = klncL.OtoKapanma;
                txtOtoKapanmaSuresi.EditValue = klncL.OtoKapanmaSuresi;


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
            myPictureEdit1.Enter += MyPictureEdit_Enter;
            txtRolAdi.ButtonClick += TxtRolAdi_ButtonClick;
            txtKullaniciTuru.TextChanged += TxtKullaniciTuru_TextChanged;
        }

        private void TxtKullaniciTuru_TextChanged(object sender, EventArgs e)
        {
            if (txtKullaniciTuru.Text == "Yönetici")
            {
                txtRolAdi.Text = "Tam Yetki";
                txtRolAdi.Tag = 1;
                txtRolAdi.Enabled = false;
            }
            else
            {
                txtRolAdi.Text = "";
                txtRolAdi.Tag = 0;
                txtRolAdi.Enabled = true;
            }
        }

        private void TxtRolAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            RolListForm fr = new RolListForm(true);
            fr.ShowDialog();
            txtRolAdi.Text = fr.RolAdi;
            txtRolAdi.Tag = fr.rolId;


        }


        private void MyPictureEdit_Enter(object sender, EventArgs e)
        {
            ((MyPictureEdit)sender).Sec(popupMenu1);
        }



        private void BtnIptal_Click(object sender, EventArgs e)
        {
            KayitVar = false;
            this.Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                KayitVar = KullaniciF.Sil(_seciliId);
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
            Kullanici klnc = new Kullanici
            {
                Id = GenelFunctions.IdOlustur(),
                KullaniciTuru = txtKullaniciTuru.Text,
                AdiSoyadi = txtAdiSoyadi.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text,
                RolId = Convert.ToInt64(txtRolAdi.Tag),
                AnaResim = (byte[])myPictureEdit1.EditValue,
                Aciklama = txtAciklama.Text,
                IslemTarihi = DateTime.Now,
                KullaniciId=AnaForm.KullanicilId,
                OtoKapanma=tglOtomatikKapanma.IsOn,
                OtoKapanmaSuresi=(int)txtOtoKapanmaSuresi.Value

                
            };


            try
            {
                if (YeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    KayitVar = KullaniciF.Ekle(klnc);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    KayitVar = KullaniciF.Guncelle(klnc, _seciliId);

                }

                if (!IlkYoneticiTanimi)
                {
                    frm = Application.OpenForms["AnaForm"] as AnaForm;
                    if (_seciliId == AnaForm.KullanicilId)
                        frm.KullaniciAyarlari();
                }


            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);

            }


            if (KayitVar)
                Close();
        }

        private void tglOtomatikKapanma_Toggled(object sender, EventArgs e)
        {
            txtOtoKapanmaSuresi.Enabled = tglOtomatikKapanma.IsOn;
        }


    }
}
