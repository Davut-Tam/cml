using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class NakitEditForm : BaseEditForm
    {

        #region Değişkenler
        private long _Id;
        private long _OgrenciId;
        private long _OgrenciOdemePlaniId;
        private long _HesapId;
        private long _Personel;
        private long _FirmaId;
        private bool _dvm;

        private string _girisCikis;
        private bool _YeniKayit;
        public bool kayitVar;

        private long _ogrenciFormundanAcilmaOgrenciId;
        private bool _ogrenciFormundanAcilma;
        List<OgrenciCariOdemeL> _secimListesi;

        #endregion

        public NakitEditForm(bool ogrenciFormundanAcilma = false, long OgrenciFormundanAcilmaOgrenciId = 0)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            IslemAdiDoldur("Giriş");
            _dvm = true;

            if (ogrenciFormundanAcilma)
            {
                _YeniKayit = true;
                _ogrenciFormundanAcilma = ogrenciFormundanAcilma;
                btnSil.Enabled = false;
                txtIslemTarihi.DateTime = DateTime.Now;
                _ogrenciFormundanAcilmaOgrenciId = OgrenciFormundanAcilmaOgrenciId;
                var ogrenci = OgrenciF.Secim(OgrenciFormundanAcilmaOgrenciId);
                Text = "Nakit Öğrenci Tahsilatı - " + ogrenci.AdiSoyadi.ToUpper();
                txtNakitIslemAdi.Text = "Öğrenci Tahsilatı";
                txtNakitIslemAdi.Enabled = rdbCikis.Enabled = rdbGiris.Enabled = false;
                lblBilgi.Text = OgrenciFormundanAcilmaOgrenciId == 0 ? "" : "Not: Yapacağınız Tahsilatın Güncelleme ve Silme işlemlerini Nakit İşlemlerinden Yapabilirsiniz...";

            }
            else
            {
                if (NakitListForm.SeciliId <= 0)
                {
                    _YeniKayit = true;
                    btnSil.Enabled = false;
                    txtIslemTarihi.DateTime = DateTime.Now;
                }
                else
                {
                    // Kayıtlı veriyi forma yükleme
                    NakitL nktL = NakitF.Secim(NakitListForm.SeciliId);

                    rdbGiris.Checked = nktL.GirisCikis == "Giriş";
                    rdbCikis.Checked = nktL.GirisCikis == "Çıkış";

                    _YeniKayit = false;
                    btnKaydet.Text = "Güncelle";
                    txtNakitIslemAdi.Text = nktL.IslemAdi;

                    if (nktL.OgrenciId != 0) txtCariSecim.Text = nktL.OgrenciAdi;
                    else if (nktL.PersonelId != 0) txtCariSecim.Text = nktL.PersonelAdi;
                    else if (nktL.FirmaId != 0) txtCariSecim.Text = nktL.FirmaAdi;
                    else if (nktL.HesapId != 0) txtCariSecim.Text = nktL.HesapAdi;
                    else
                    {
                        lblIslemAdi.Text = "";
                        lblIslemAdi.Enabled = false;
                        lblIslemAdi.Text = "...";
                    }
                    txtIslemTarihi.EditValue = nktL.Tarih;
                    txtIslemTutari.Value = nktL.Tutar;
                    txtAciklama.Text = nktL.Aciklama;

                    _OgrenciId = nktL.OgrenciId;
                    _OgrenciOdemePlaniId = nktL.OgrenciOdemePlaniId;
                    _Personel = nktL.PersonelId;
                    _FirmaId = nktL.FirmaId;
                    _HesapId = nktL.HesapId;
                    _Id = nktL.Id;

                }
            }

        }
        void IslemAdiDoldur(string isl)
        {
            txtNakitIslemAdi.AddItems(islemTuru: isl);
        }
        private void RdbGiris_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGiris.Checked)
                IslemAdiDoldur("Giriş");
            Temizle();
        }
        private void RdbCikis_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCikis.Checked)
                IslemAdiDoldur("Çıkış");
            Temizle();
        }
        void Temizle()
        {
            _dvm = false;
            txtNakitIslemAdi.Text = "";
            IslemDegisikligiTemizle();
            lblIslemAdi.Text = "";
            lblIslemAdi.Enabled = false;
            lblIslemAdi.Text = "...";
            txtNakitIslemAdi.Tag = 0;
            _dvm = true;
        }

        void IslemDegisikligiTemizle()
        {
            txtCariSecim.Text = "";
            _OgrenciOdemePlaniId = 0;
            _OgrenciId = 0;
            _Personel = 0;
            _FirmaId = 0;
            _HesapId = 0;
            txtIslemTutari.Text = "";
            txtIslemTarihi.DateTime = DateTime.Now;
            txtAciklama.Text = "";
        }
        private void TxtIslemAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            lblIslemAdi.Enabled = true;
            txtNakitIslemAdi.Tag = txtNakitIslemAdi.ItemsId();
            switch (txtNakitIslemAdi.Tag.ToInt32())
            {
                case 1:
                    lblIslemAdi.Text = "Taksit No";
                    break;

                case 2:
                    lblIslemAdi.Text = "Öğrenci Adı";
                    break;

                case 3:
                case 4:
                    lblIslemAdi.Text = "Personel Adı";
                    break;

                case 5:
                case 6:
                    lblIslemAdi.Text = "Firma Adı";
                    break;

                case 7:
                    lblIslemAdi.Text = "Hesap Adı";
                    break;

                default:
                    lblIslemAdi.Text = "";
                    lblIslemAdi.Enabled = false;
                    lblIslemAdi.Text = "...";
                    break;

            }
            IslemDegisikligiTemizle();
        }
        private void TxtCariSecim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtNakitIslemAdi.Text == "") return;

            switch (txtNakitIslemAdi.Tag.ToInt32())
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
                        txtAciklama.Text = (int)_secimListesi[0].TaksitNo != 0 ? _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " " + _secimListesi[0].TaksitNo + " Nolu Taksit Ödemesi" : _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " Eğitim Ücreti Ödemesi";

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
                case 4:
                    PersonelListForm fr3 = new PersonelListForm(true);
                    if (!fr3.Gorebilir)
                    {
                        Messages.YetkinizYokMesaji("Personel Listesini Görme Yetkiniz Bulunmamaktadır.");
                        fr3.Dispose();
                        return;
                    }
                    fr3.ShowDialog();
                    txtCariSecim.Text = fr3.PersonelAdi;
                    _Personel = fr3.personelId;
                    txtAciklama.Text = fr3.Aciklama;
                    fr3.Dispose();
                    break;

                case 5:
                case 6:
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
                    txtAciklama.Text = fr5.Aciklama;
                    fr5.Dispose();
                    break;



                case 7:
                    BankaHesapListForm fr7 = new BankaHesapListForm(true);
                    fr7.ShowDialog();
                    txtCariSecim.Text = fr7.SeciliHesap;
                    _HesapId = fr7.SeciliHesapId;
                    txtAciklama.Text = fr7.SeciliHesap + " Nolu Hesaba Aktarma";
                    fr7.Dispose();

                    break;

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
                if (_YeniKayit)
                    kayitVar = txtNakitIslemAdi.Tag.ToInt32()==1 ? NakitF.Ekle(NakitEntities(_secimListesi),txtIslemTutari.Value) : NakitF.Ekle(NakitEntity());

                else
                    kayitVar = NakitF.Guncelle(NakitEntity(), NakitListForm.SeciliId);
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }

            if (kayitVar)
                this.Close();

        }
        private Nakit NakitEntity()
        {
            if (rdbGiris.Checked) _girisCikis = "Giriş"; else _girisCikis = "Çıkış";
            if (txtNakitIslemAdi.Tag.ToInt32() != 1 && txtNakitIslemAdi.Tag.ToInt32() != 2)
            {
                _OgrenciId = 0;
                _OgrenciOdemePlaniId = 0;
            }
            if (txtNakitIslemAdi.Tag.ToInt32() != 3 && txtNakitIslemAdi.Tag.ToInt32() != 4)
            {
                _Personel = 0;
            }
            if (txtNakitIslemAdi.Tag.ToInt32() != 5 && txtNakitIslemAdi.Tag.ToInt32() != 6) _FirmaId = 0;
            if (txtNakitIslemAdi.Tag.ToInt32() != 7) _HesapId = 0;
            if (_YeniKayit) _Id = GenelFunctions.IdOlustur();

            Nakit nkt = new Nakit
            {
                Id = _Id,
                Tarih = txtIslemTarihi.DateTime,
                GirisCikis = _girisCikis,
                IslemId = txtNakitIslemAdi.Tag.ToInt32(),
                Tutar = txtIslemTutari.Value,
                OgrenciOdemePlaniId = _OgrenciOdemePlaniId,
                OgrenciId = _OgrenciId,
                PersonelId = _Personel,
                FirmaId = _FirmaId,
                HesapId = _HesapId,
                Aciklama = txtAciklama.Text,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now
            };
            return nkt;

        }
        private List<Nakit> NakitEntities(List<OgrenciCariOdemeL> _secimListesi)
        {
            if (_secimListesi == null) return null;


            var list = new List<Nakit>();
            _Id = GenelFunctions.IdOlustur();
            foreach (var item in _secimListesi)
            {
                Nakit nkt = new Nakit
                {
                    Id = _Id++,
                    Tarih = txtIslemTarihi.DateTime,
                    GirisCikis = "Giriş",
                    IslemId = txtNakitIslemAdi.Tag.ToInt32(),
                    Tutar =  item.Kalan,
                    OgrenciOdemePlaniId = item.OdemePlaniId,
                    OgrenciId = item.OgrenciId,
                    Aciklama = _secimListesi.Count==1? txtAciklama.Text:  item.AdiSoyadi + " (TC:" + item.TcKimlikNo + ") " + item.DonemAdi + " " + item.TaksitNo + " Nolu Taksit Ödemesi",
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = DateTime.Now
                };
                list.Add(nkt);
            }

            return list;

        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            if (kayitVar = NakitF.Sil(NakitListForm.SeciliId) == true)
                Close();
        }


        private void TxtCariSecim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _OgrenciId = _OgrenciOdemePlaniId = _FirmaId = _Personel = _HesapId = 0;
                _secimListesi = null;
            }
        }
    }
}