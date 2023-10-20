using AbcYazilim.OgrenciTakip.UI.Win.Functions;
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
    public partial class PersonelEditForm : BaseEditForm
    {
       
        public Personel prs;
        public PersonelL prsL;
        public bool YeniKayit;
        public bool KayitVar;



        public PersonelEditForm()
        {
            InitializeComponent();
            EventLoad();

            if (PersonelListForm.SeciliId > 0)
            {

                YeniKayit = false;

                prsL = PersonelF.Secim(PersonelListForm.SeciliId);
                txtTcKimlikNo.Text = prsL.TcKimlikNo;
                txtAdiSoyadi.Text = prsL.AdiSoyadi;
                txtGorevAdi.Tag = prsL.GorevId;
                txtGorevAdi.Text = prsL.GorevAdi;


                txtTelefon.Text = prsL.Telefon;
                txtBankaAdi.Text = prsL.BankaAdi;
                txtIbanNo.Text = prsL.IbanNo;

                txtEmail.Text = prsL.EmailAdresi;
                txtAdres.Text = prsL.Adres;
                txtAciklama.Text = prsL.Aciklama;

                txtBaslamaTarihi.EditValue = prsL.BaslamaTarihi;
                txtMaasTutari.Value = prsL.Maas;
                txtMaasOdemeGunu.Value = prsL.MaasOdemeGunu;
                txtOtomatikMaas.Text = prsL.OtomatikMaas == true ? "Otomatik" : "Manuel";


                tglDurum.IsOn = prsL.Durum;
                pcrResim.EditValue = prsL.Resim;
                btnSil.Enabled = true;
                Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                Text += " ( Yeni Kayıt )";
                YeniKayit = true;
                loyoutTahakkukButon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                txtBaslamaTarihi.EditValue = DateTime.Now;
            }
        }

        void EventLoad()
        {
            btnKaydet.Click += BtnKaydet_Click;
            btnSil.Click += BtnSil_Click;
            btnIptal.Click += BtnIptal_Click;
            btnTahakkuk.Click += BtnTahakkuk_Click;
            txtGorevAdi.ButtonClick += TxtGorevAdi_ButtonClick;
            pcrResim.Enter += PcrResim_Enter;
        }

        private void PcrResim_Enter(object sender, EventArgs e)
        {
            ((MyPictureEdit)sender).Sec(popupMenu1);
        }

        private void TxtGorevAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MeslekListForm fr = new MeslekListForm() { Text = "Meslek Seç" };
            fr.SecimFormuOlarakAcilma = true;
            fr.ShowDialog();
            if (fr.SeciliId <= 0) { fr.Dispose(); return; }
            var gorev = GorevF.Secim(fr.SeciliId);
            txtGorevAdi.Text = gorev.GorevAdi;
            txtGorevAdi.Tag = gorev.Id;
            fr.Dispose();
        }

        private void BtnTahakkuk_Click(object sender, EventArgs e)
        {
            if (AnaForm.KullaniciTuru == "Kullanıcı")
                if (RolF.Kontroller(20).Gorebilir != 1) { Messages.YetkinizYokMesaji(); return; }
            Close();
            PersonelTahakkukEditForm fr = new PersonelTahakkukEditForm(PersonelListForm.SeciliId);
            fr.ShowDialog();
            KayitVar = fr.KayitVar;
            fr.Dispose();
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
                KayitVar = PersonelF.Sil(PersonelListForm.SeciliId);
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
            Personel prs = new Personel
            {
                Id = GenelFunctions.IdOlustur(),
                TcKimlikNo = txtTcKimlikNo.Text,
                AdiSoyadi = txtAdiSoyadi.Text,
                GorevId = Convert.ToInt64(txtGorevAdi.Tag),
                Telefon = txtTelefon.EditValue == null ? null : txtTelefon.Text == "" ? null : txtTelefon.Text,
                BankaAdi = txtBankaAdi.Text,
                IbanNo = txtIbanNo.Text,

                BaslamaTarihi = txtBaslamaTarihi.DateTime,
                Maas = txtMaasTutari.Value,
                MaasOdemeGunu = (int)txtMaasOdemeGunu.Value,


                EmailAdresi = txtEmail.Text,
                Adres = txtAdres.Text,
                Aciklama = txtAciklama.Text,


                Durum = tglDurum.IsOn,
                Resim = (byte[])pcrResim.EditValue,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now,
                OtomatikMaas = txtOtomatikMaas.Text == "Otomatik"
            };


            try
            {
                if (YeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                        KayitVar = PersonelF.Ekle(prs);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    KayitVar = PersonelF.Guncelle(prs, PersonelListForm.SeciliId);

                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);

            }

            if (KayitVar)
            {
                Id = prs.Id;
                this.Close();
            }
               
            
              
        }

    }
}