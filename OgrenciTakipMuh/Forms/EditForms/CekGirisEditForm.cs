using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class CekGirisEditForm : BaseEditForm
    {
        private long _OgrenciOdemePlaniId;
        private long _OgrenciId;
        private long _Id;

        private long _FirmaId;
        public bool _YeniKayit;
        public bool kayitVar;
        public bool _cikisYapilmis;

        private long _ogrenciFormundanAcilmaOgrenciId;

        List<OgrenciCariOdemeL> _secimListesi;
        //private List<Cek> _list;

        public CekGirisEditForm(bool ogrenciFormundanAcilma = false, long OgrenciFormundanAcilmaOgrenciId = 0)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            txtCekIslemAdi.AddItems();
            txtCekIslemAdi.AddItems(islemTuru: "Giriş");
            txtVadeTarihi.Properties.MinValue = DateTime.Now;
            txtIslemTarihi.DateTime = DateTime.Now;

            if (ogrenciFormundanAcilma)
            {
                _YeniKayit = true;
                btnSil.Enabled = false;
                txtIslemTarihi.DateTime = DateTime.Now;
                _ogrenciFormundanAcilmaOgrenciId = OgrenciFormundanAcilmaOgrenciId;
                var ogrenci = OgrenciF.Secim(OgrenciFormundanAcilmaOgrenciId);
                Text = "Çek / Senet Öğrenci Tahsilatı - " + ogrenci.AdiSoyadi.ToUpper();
                txtCekIslemAdi.Text = "Öğrenci Tahsilatı";
                txtCekIslemAdi.Enabled  = false;
                lblBilgi.Text = _ogrenciFormundanAcilmaOgrenciId == 0 ? "" : "Not: Yapacağınız Tahsilatın Güncelleme ve Silme işlemlerini Çek İşlemlerinden Yapabilirsiniz...";

            }
            else
            {
                if (CekListForm.SeciliId <= 0)// yeni kayıt
                {
                    _YeniKayit = true;
                    btnSil.Enabled = false;
                   
                    _cikisYapilmis = false;
                }
                else// kayıt güncelleme veya çıkış yapılacak
                {
                    _YeniKayit = false;
                    btnKaydet.Text = "Güncelle";
                    CekL ck = CekF.Secim(CekListForm.SeciliId);
                    _cikisYapilmis = ck.CikisYapildi;
                    txtCekIslemAdi.Text = ck.GirisIslemAdi;
                    //txtCekIslemAdi.Tag = txtCekIslemAdi.ComboboxIdBul("CekIslemler", "IslemAdi");
                    if (ck.GirisIslemId == 1)
                    {
                        _OgrenciId = ck.GirisOgrenciId;
                        _OgrenciOdemePlaniId = ck.OgrenciOdemePlaniId;
                        txtCariSecim.Text = ck.GirisOgrenciAdi;
                        lblIslemAdi.Enabled = true;
                        lblIslemAdi.Text = "Tahakkuk";

                    }

                    if (ck.GirisIslemId == 5)
                    {
                        _FirmaId = ck.GirisfirmaId;
                        txtCariSecim.Text = ck.GirisFirmaAdi;
                        lblIslemAdi.Enabled = true;
                        lblIslemAdi.Text = "Firma Adı";
                    }

                    txtTur.Text = ck.Tur;
                    txtCekNo.Text = ck.CekNo;
                    txtIslemTarihi.DateTime = ck.GirisTarihi;
                    txtVadeTarihi.DateTime = ck.VadeTarihi;
                    txtIslemTutari.Value = ck.Tutar;
                    txtBanka.Text = ck.CekBanka;
                    txtAciklama.Text = ck.GirisAciklama;

                }
            }

            

        }

 
        void Temizle()
        {
            txtCariSecim.Text = "";
            txtCariSecim.Tag = -1;
            txtIslemTarihi.DateTime = DateTime.Now;
            txtTur.SelectedIndex = -1;
            txtIslemTutari.Text = "";
            txtCekNo.Text = "";
            txtBanka.Text = "";
            txtAciklama.Text = "";
            txtVadeTarihi.Text = "";
        }
   

        private void TxtCariSecim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtCekIslemAdi.Text == "") return;

            switch (txtCekIslemAdi.Tag.ToInt32())
            {
                case 1:
                    OgrenciTaksitSecimListForm fr1 = new OgrenciTaksitSecimListForm(true, _ogrenciFormundanAcilmaOgrenciId);
                    if (!fr1.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Öğrenci Listesini Görme Yetkiniz Bulunmamaktadır");
                        fr1.Dispose();
                        return;
                    }
                    fr1.ShowDialog();

                    _secimListesi = fr1.SecimListesi;
                    if (_secimListesi == null) return;
                    if (_secimListesi.Count == 1)
                    {
                        txtCariSecim.Text = _secimListesi[0].AdiSoyadi + $" {_secimListesi[0].TaksitNo} Nolu Taksit"; ;
                        _OgrenciOdemePlaniId = _secimListesi[0].OdemePlaniId;
                        _OgrenciId = _secimListesi[0].OgrenciId;
                        txtIslemTutari.EditValue = _secimListesi[0].Kalan;
                        txtAciklama.Text = _secimListesi[0].TaksitNo != 0 ? _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " " + _secimListesi[0].TaksitNo + " Nolu Taksit Ödemesi" : _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " Eğitim Ücreti Ödemesi";

                    }
                    else if (_secimListesi.Count > 1)
                    {
                        string taksitler = "";
                        decimal toplam = 0;
                        foreach (var item in _secimListesi)
                        {
                            taksitler += item.TaksitNo + " ,";
                            toplam += item.Kalan;
                        }
                        txtCariSecim.Text = _secimListesi[0].AdiSoyadi + $" ({taksitler.Remove(taksitler.Length - 1, 1)}) Nolu Taksitler";
                        _OgrenciOdemePlaniId = _secimListesi[0].OdemePlaniId;
                        _OgrenciId = _secimListesi[0].OgrenciId;
                        txtIslemTutari.EditValue = toplam;
                        txtAciklama.Text = _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + $" ({taksitler.Remove(taksitler.Length - 1, 1)}) Nolu Taksitler Ödemesi";
                    }




                    fr1.Dispose();
                    break;

                case 5:
                    FirmaListForm fr5 = new FirmaListForm(true);
                    if (!fr5.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Firma Listesini Görme Yetkiniz Bulunmamaktadır.");
                        fr5.Dispose();
                        return;
                    }
                    fr5.ShowDialog();
                    txtCariSecim.Text = fr5.FirmaAdi;
                    _FirmaId = fr5.FirmaId;
                    txtAciklama.Text = fr5.Aciklama+ "Firma Tahsilatı";
                    fr5.Dispose();
                    break;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj;
            if (_YeniKayit) mesaj = "Yeni Kayıt Yapılacak Onaylıyor musunuz"; else mesaj = "Kayıt Güncellenecek Onaylıyor musunuz";

            if (Messages.SoruEvetSeciliEvetHayir(mesaj, "Kaydetme") == DialogResult.No)
                return;
            try
            {

                if (_YeniKayit)
                    kayitVar = txtCekIslemAdi.Tag.ToInt32() == 1 ? CekF.Ekle(CekEntities(_secimListesi), txtIslemTutari.Value) : CekF.Ekle(CekEntity());

                else
                    kayitVar = CekF.Guncelle(CekEntity(), CekListForm.SeciliId);


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


            if (txtCekIslemAdi.Tag.ToInt32() != 1 && txtCekIslemAdi.Tag.ToInt32() != 2)
            {
                _OgrenciId = 0;
                _OgrenciOdemePlaniId = 0;
            }
            if (txtCekIslemAdi.Tag.ToInt32() != 5 && txtCekIslemAdi.Tag.ToInt32() != 6) _FirmaId = 0;

            if (txtCekIslemAdi.Tag.ToInt32() == 11) _FirmaId = 0;
            if (_YeniKayit) _Id = GenelFunctions.IdOlustur();


            Cek ck = new Cek
            {
                Id = _Id,
                Tur = txtTur.Text,
                CekNo = txtCekNo.Text,
                CekBanka = txtBanka.Text,
                VadeTarihi = txtVadeTarihi.DateTime,
                Tutar = txtIslemTutari.Value,

                GirisTarihi = txtIslemTarihi.DateTime,
                GirisIslemId = txtCekIslemAdi.Tag.ToInt32(),
                OgrenciOdemePlaniId = _OgrenciOdemePlaniId,
                GirisOgrenciId = _OgrenciId,
                GirisPersonelId = 0,
                GirisfirmaId = _FirmaId,
                GirisAciklama = txtAciklama.Text,
                GirisKullaniciId = AnaForm.KullanicilId,
                GirisIslemTarihi = DateTime.Now,
                CikisYapildi = _cikisYapilmis

            };
            return ck;


        }
        private List<Cek> CekEntities(List<OgrenciCariOdemeL> _secimListesi)
        {
            if (_secimListesi == null) return null;


            var list = new List<Cek>();
            _Id = GenelFunctions.IdOlustur();
            foreach (var item in _secimListesi)
            {
                Cek ck = new Cek
                {
                    Id = _Id++,
                    Tur = txtTur.Text,
                    CekNo = txtCekNo.Text,
                    CekBanka = txtBanka.Text,
                    VadeTarihi = txtVadeTarihi.DateTime,
                    Tutar = item.Kalan,

                    GirisTarihi = txtIslemTarihi.DateTime,
                    GirisIslemId = txtCekIslemAdi.Tag.ToInt32(),
                    OgrenciOdemePlaniId = item.OdemePlaniId,
                    GirisOgrenciId = item.OgrenciId,
                    Aciklama = _secimListesi.Count == 1 ? txtAciklama.Text : item.AdiSoyadi + " (TC:" + item.TcKimlikNo + ") " + item.DonemAdi + " " + item.TaksitNo + " Nolu Taksit Ödemesi",
                    GirisKullaniciId = AnaForm.KullanicilId,
                    GirisIslemTarihi = DateTime.Now
                };
                list.Add(ck);
            }

            return list;

        }
        private void TxtTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTur.Text == "Çek")
            {
                txtBanka.Enabled = true;
                lblCektutari.Text = "Çek Tutarı";
                lblCekNo.Text = "Çek No";
            }
            else
            {
                txtBanka.Text = "";
                txtBanka.Enabled = false;
                lblCektutari.Text = "Senet Tutarı";
                lblCekNo.Text = "Senet No";
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                if (kayitVar = CekF.Sil(CekListForm.SeciliId) == true)
                    Close();
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

 


        private void txtCariSecim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _OgrenciId = _OgrenciOdemePlaniId = _FirmaId  = 0;
            }
        }

        private void txtCekIslemAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIslemAdi.Enabled = true;
            txtCekIslemAdi.Tag = txtCekIslemAdi.ItemsId();
            Temizle();
            switch (txtCekIslemAdi.Tag.ToInt32())
            {
                case 1:
                    lblIslemAdi.Text = "Taksit No";
                    break;

                case 5:
                    lblIslemAdi.Text = "Firma Adı";
                    break;

                case 11:
                    lblIslemAdi.Text = "";
                    lblIslemAdi.Enabled = false;
                    lblIslemAdi.Text = "...";
                    txtTur.Text = "Çek";
                    break;

            }
        }
    }
}
