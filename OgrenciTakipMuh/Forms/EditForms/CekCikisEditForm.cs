using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class CekCikisEditForm : BaseEditForm
    {


        private long _OgrenciId;
        private long _PersonelId;
        private long _CikisHesapId;
        public bool _CikisYapildi;
        private long _FirmaId;
        public bool _YeniKayit;
        public bool kayitVar;
        public CekCikisEditForm()
        {
            InitializeComponent();
           
            txtIslemTarihi.DateTime = DateTime.Now;
            txtCekIslemAdi.AddItems(islemTuru:"Çıkış");
            CekBilgileri();
        }

        void CekBilgileri()
        {

            CekL ck = CekF.Secim(CekListForm.SeciliId);
            txtTur.Text = ck.Tur;
            txtCekNo.Text = ck.CekNo;
            txtVadeTarihi.DateTime = ck.VadeTarihi;
            txtIslemTutari.Value = ck.Tutar;
            txtBanka.Text = ck.CekBanka;
            if (ck.CikisYapildi)
            {
                _YeniKayit = false;
                btnKaydet.Text = "Güncelle";
                txtCekIslemAdi.Text = ck.CikisIslemAdi;
                //txtCekIslemAdi.Tag = txtCekIslemAdi.ComboboxIdBul("CekIslemler", "IslemAdi");

                
                if (ck.CikisIslemId == 2)// Öğrenci
                {
                    _OgrenciId = ck.CikisOgrenciId??0;
                    txtCariSecim.Text = ck.CikisOgrenciAdi;
                    lblIslemAdi.Enabled = true;
                    lblIslemAdi.Text = "Öğrenci Adı";

                }

                else if (ck.CikisIslemId == 3)// Personel
                {
                    _PersonelId = ck.CikisPersonelId??0;
                    txtCariSecim.Text = ck.CikisPersonelAdi;
                    lblIslemAdi.Enabled = true;
                    lblIslemAdi.Text = "Personel Adı";
                }


                else if (ck.CikisIslemId == 6)// Firma
                {
                    _FirmaId = ck.CikisfirmaId ?? 0;
                    txtCariSecim.Text = ck.CikisFirmaAdi;
                    lblIslemAdi.Enabled = true;
                    lblIslemAdi.Text = "Firma Adı";
                }



                else if (ck.CikisIslemId == 9)// Hesap
                {
                    BankaHesap bnkhsp = BankaHesapF.Secim(ck.CikisHesapId);
                    _CikisHesapId = ck.CikisHesapId;
                    txtCariSecim.Text = bnkhsp.BankaAdi + " " + bnkhsp.SubeAdi + " / " + bnkhsp.IbanNo; 
                    lblIslemAdi.Enabled = true;
                    lblIslemAdi.Text = "Hesap Adı";
                }


               else// Diğer
                {
                    txtCariSecim.Text = "...";
                    lblIslemAdi.Enabled = false;
                    lblIslemAdi.Text = "";
                }



            }
            else
            {
                _YeniKayit = true;
            }

        }

        private void txtIslemAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIslemAdi.Enabled = true;
            txtCekIslemAdi.Tag = txtCekIslemAdi.ItemsId();
            txtCariSecim.Text = "";

            switch (txtCekIslemAdi.Tag.ToInt32())
            {
                case 2:
                    lblIslemAdi.Text = "Öğrenci Adı";
                    break;
                case 3:
                    lblIslemAdi.Text = "Personel Adı";
                    break;
                case 6:
                    lblIslemAdi.Text = "Firma Adı";
                    break;

                case 9:
                    lblIslemAdi.Text = "Hesap Adı";
                    break;

                default:
                    lblIslemAdi.Enabled = false;
                    lblIslemAdi.Text = "...";
                    break;

            }
        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Çıkış Kaydı Silinecek Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                _YeniKayit = false;
                if (kayitVar = CekF.CikisGuncelleVeSil(CekEntity(), CekListForm.SeciliId, false))
                    Close();
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }


        }



        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj;
            if (_YeniKayit) mesaj = "Yeni Kayıt Yapılacak Onaylıyor musunuz"; else mesaj = "Kayıt Güncellenecek Onaylıyor musunuz";

            if (Messages.SoruEvetSeciliEvetHayir(mesaj, "Kaydetme") == DialogResult.No)
                return;
            try
            {
                _YeniKayit = true;
                kayitVar = CekF.CikisGuncelleVeSil(CekEntity(), CekListForm.SeciliId, true);
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }

            if (kayitVar)
                this.Close();
        }




        Cek CekEntity()
        {
 

            if (_YeniKayit)
            {
                if (txtCekIslemAdi.Tag.ToInt32() != 2) _OgrenciId = 0;
                if (txtCekIslemAdi.Tag.ToInt32() != 3) _PersonelId = 0;
                if (txtCekIslemAdi.Tag.ToInt32() != 6) _FirmaId = 0;
                if (txtCekIslemAdi.Tag.ToInt32() != 9)
                {
                    _CikisHesapId = 0;
                }

                Cek ck = new Cek();
                ck = CekF.Secim(CekListForm.SeciliId);
                ck.CikisTarihi = txtIslemTarihi.DateTime;
                ck.CikisIslemId = txtCekIslemAdi.Tag.ToInt32();
                ck.CikisOgrenciId = _OgrenciId;
                ck.CikisfirmaId = _FirmaId;
                ck.CikisPersonelId = _PersonelId;
                ck.CikisKullaniciId = AnaForm.KullanicilId;
                ck.CikisAciklama = txtAciklama.Text;
                ck.CikisIslemTarihi=  DateTime.Now;
                ck.CikisYapildi = true;
                ck.CikisHesapId = _CikisHesapId;
                return ck;

            }
            else
            {
                Cek ck = new Cek();
                ck = CekF.Secim(CekListForm.SeciliId);
                ck.CikisTarihi = null;
                ck.CikisIslemId = null;
                ck.CikisOgrenciId = null;
                ck.CikisfirmaId = null;
                ck.CikisPersonelId = null;
                ck.CikisKullaniciId = null;
                ck.CikisAciklama = null;
                ck.CikisIslemTarihi = null;
                ck.CikisYapildi = false;

                return ck;

            }


        }

        private void txtCariSecim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtCekIslemAdi.Text == "") return;

            switch (txtCekIslemAdi.Tag.ToInt32())
            {


                case 2:
                    OgrenciListForm fr2 = new OgrenciListForm(true);
                    if (!fr2.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Öğrenci Listesini Görme Yetkiniz Bulunmamaktadır");
                        fr2.Dispose();
                        return;
                    }
                    fr2.ShowDialog();
                    txtCariSecim.Text = fr2.ogrenciAdi;
                    _OgrenciId = fr2.OgrenciId;
                    txtAciklama.Text = fr2.Aciklama;
                    fr2.Dispose();
                    break;

               
                case 3:
                    PersonelListForm fr3 = new PersonelListForm(true);
                    if (!fr3.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Personel Listesini Görme Yetkiniz Bulunmamaktadır.");
                        fr3.Dispose();
                        return;
                    }
                    fr3.ShowDialog();
                    txtCariSecim.Text = fr3.PersonelAdi;
                    _PersonelId = fr3.personelId;
                    txtAciklama.Text = fr3.Aciklama;
                    fr3.Dispose();
                    break;


                case 6:
                    FirmaListForm fr6 = new FirmaListForm(true);
                    if (!fr6.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Firma Listesini Görme Yetkiniz Bulunmamaktadır.");
                        fr6.Dispose();
                        return;
                    }
                    fr6.ShowDialog();
                    txtCariSecim.Text = fr6.FirmaAdi;
                    _FirmaId = fr6.FirmaId;
                    txtAciklama.Text = fr6.Aciklama+"Firma Ödemesi";
                    fr6.Dispose();
                    break;


                case 9:
                    BankaHesapListForm fr9 = new BankaHesapListForm(true);
                    if (!fr9.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Hesap Listesini Görme Yetkiniz Bulunmamaktadır.");
                        fr9.Dispose();
                        return;
                    }
                    fr9.ShowDialog();
                    txtCariSecim.Text = fr9.SeciliHesap;
                    _CikisHesapId = fr9.SeciliHesapId;
                    txtAciklama.Text = fr9.SeciliHesap + " Nolu Hesaba Aktarma";
                    fr9.Dispose();

                    break;

            }
        }

        private void txtCariSecim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _OgrenciId = _PersonelId = _FirmaId = _CikisHesapId= 0;
            }
        }
    }



}
