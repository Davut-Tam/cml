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
    public partial class BankaEditForm : BaseEditForm
    {

        #region Değişkenler

        private long _hesapId;
        private long _Id;
        private long _OgrenciId;
        private long _OgrenciOdemePlaniId;
        private long _Personel;
        private long _FirmaId;
        private long _VirmanHesapId;
        private bool _dvm;

        private string _girisCikis;
        private bool _YeniKayit;
        public bool kayitVar;
        private string _gelenAciklama = "";

        List<OgrenciCariOdemeL> _secimListesi;
        //List<Banka> _list;

        private long _ogrenciFormundanAcilmaOgrenciId;
        #endregion

        public BankaEditForm(long hesapId, bool ogrenciFormundanAcilma = false, long OgrenciFormundanAcilmaOgrenciId = 0)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            IslemAdiDoldur("Giriş");
            _hesapId = hesapId;
            txtHesapAdi.AddItems();
            txtHesapAdi.Text = BankaHesapF.Secim(_hesapId).HesapAdi;
            _dvm = true;

            if (ogrenciFormundanAcilma)
            {
                _YeniKayit = true;
                btnSil.Enabled = false;
                txtIslemTarihi.DateTime = DateTime.Now;
                _ogrenciFormundanAcilmaOgrenciId = OgrenciFormundanAcilmaOgrenciId;
                var ogrenci = OgrenciF.Secim(OgrenciFormundanAcilmaOgrenciId);
                Text = "Bankadan Öğrenci Tahsilatı - " + ogrenci.AdiSoyadi.ToUpper();
                txtBankaIslemAdi.Text = "Öğrenci Tahsilatı";
                txtBankaIslemAdi.Enabled = rdbCikis.Enabled = rdbGiris.Enabled = false;
                txtHesapAdi.Enabled = true;
                lblBilgi.Text = OgrenciFormundanAcilmaOgrenciId == 0 ? "" : "Not: Yapacağınız Tahsilatın Güncelleme ve Silme işlemlerini Banka İşlemlerinden Yapabilirsiniz...";

            }
            else
            {
                if (BankaListForm.SeciliId <= 0)
                {
                    _YeniKayit = true;
                    btnSil.Enabled = false;
                    txtIslemTarihi.DateTime = DateTime.Now;
                }
                else
                {
                    // Kayıtlı veriyi forma yükleme

                    BankaL bnkL = BankaF.Secim(BankaListForm.SeciliId);

                    rdbGiris.Checked = bnkL.GirisCikis == "Giriş";
                    rdbCikis.Checked = bnkL.GirisCikis == "Çıkış";

                    _YeniKayit = false;
                    btnKaydet.Text = "Güncelle";
                    txtBankaIslemAdi.Text = bnkL.IslemAdi;



                    if (bnkL.OgrenciId != 0) txtCariSecim.Text = bnkL.OgrenciAdi;
                    else if (bnkL.PersonelId != 0) txtCariSecim.Text = bnkL.PersonelAdi;
                    else if (bnkL.FirmaId != 0) txtCariSecim.Text = bnkL.FirmaAdi;
                    else if (bnkL.IslemId == 8)
                    {
                        _VirmanHesapId = BankaF.Secim(BankaListForm.SeciliId + 1).HesapId;
                        txtCariSecim.Text = BankaHesapF.Secim(_VirmanHesapId).BankaAdi + " " + BankaHesapF.Secim(_VirmanHesapId).SubeAdi + " / " + BankaHesapF.Secim(_VirmanHesapId).IbanNo;
                    }
                    else
                    {
                        lblIslemAdi.Text = "";
                        lblIslemAdi.Enabled = false;
                        lblIslemAdi.Text = "...";
                    }




                    txtIslemTarihi.EditValue = bnkL.Tarih;
                    txtIslemTutari.Value = bnkL.Tutar;
                    cbxPos.Checked = bnkL.Aciklama.IndexOf(" || ( POS )", 0, bnkL.Aciklama.Length) != -1;
                    _gelenAciklama = bnkL.Aciklama.Replace(" || ( POS )", "").Replace(" || ( IBAN )", "");
                    txtAciklama.Text = bnkL.Aciklama;

                    _OgrenciId = bnkL.OgrenciId;
                    _OgrenciOdemePlaniId = bnkL.OgrenciOdemePlaniId;
                    _Personel = bnkL.PersonelId;
                    _FirmaId = bnkL.FirmaId;
                    _Id = bnkL.Id;
                }
            }

        }

        void IslemAdiDoldur(string isl)
        {
            txtBankaIslemAdi.AddItems(islemTuru:isl);
        }

        void Temizle()
        {
            _dvm = false;
            txtBankaIslemAdi.Text = "";
            IslemDegisikligiTemizle();
            lblIslemAdi.Text = "";
            lblIslemAdi.Enabled = false;
            lblIslemAdi.Text = "...";
            txtBankaIslemAdi.Tag = 0;
            _dvm = true;
        }

        void IslemDegisikligiTemizle()
        {
            txtCariSecim.Text = "";
            _OgrenciOdemePlaniId = 0;
            _OgrenciId = 0;
            _Personel = 0;
            _FirmaId = 0;
            txtIslemTutari.Text = "";
            txtIslemTarihi.DateTime = DateTime.Now;
            txtAciklama.Text = "";
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
                    kayitVar = txtBankaIslemAdi.Tag.ToInt32() == 1 ? BankaF.Ekle(BankaEntities(_secimListesi), txtIslemTutari.Value) : BankaF.Ekle(BankaEntity());

                else
                    kayitVar = BankaF.Guncelle(BankaEntity(), BankaListForm.SeciliId);

            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }

            if (kayitVar)
                this.Close();

        }

        private Banka BankaEntity()
        {
            if (rdbGiris.Checked) _girisCikis = "Giriş"; else _girisCikis = "Çıkış";
            if (txtBankaIslemAdi.Tag.ToInt32() != 1 && txtBankaIslemAdi.Tag.ToInt32() != 2)
            {
                _OgrenciId = 0;
                _OgrenciOdemePlaniId = 0;
            }
            if (txtBankaIslemAdi.Tag.ToInt32() != 3 && txtBankaIslemAdi.Tag.ToInt32() != 4) _Personel = 0;
            if (txtBankaIslemAdi.Tag.ToInt32() != 5 && txtBankaIslemAdi.Tag.ToInt32() != 6) _FirmaId = 0;
            if (txtBankaIslemAdi.Tag.ToInt32() != 8) _VirmanHesapId = 0;
            if (_YeniKayit) _Id = GenelFunctions.IdOlustur();

            Banka bnk = new Banka
            {
                Id = _Id,
                Tarih = txtIslemTarihi.DateTime,
                HesapId = _hesapId,
                GirisCikis = _girisCikis,
                IslemId = txtBankaIslemAdi.Tag.ToInt32(),
                Tutar = txtIslemTutari.Value,
                OgrenciOdemePlaniId = _OgrenciOdemePlaniId,
                OgrenciId = _OgrenciId,
                PersonelId = _Personel,
                FirmaId = _FirmaId,
                Aciklama = txtAciklama.Text,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now,
                NakitIslemId = 0,
                VirmanHesapId = _VirmanHesapId

            };
            return bnk;

        }

        private List<Banka> BankaEntities(List<OgrenciCariOdemeL> _secimListesi)
        {
            if (_secimListesi == null) return null;



            var list = new List<Banka>();
            _Id = GenelFunctions.IdOlustur();
            foreach (var item in _secimListesi)
            {
                string pos = cbxPos.Checked ? " || ( POS )" : " || ( IBAN )";
                Banka nkt = new Banka
                {
                    Id = _Id++,
                    Tarih = txtIslemTarihi.DateTime,
                    HesapId = _hesapId,
                    GirisCikis = "Giriş",
                    IslemId = txtBankaIslemAdi.Tag.ToInt32(),
                    Tutar = item.Kalan,
                    OgrenciOdemePlaniId = item.OdemePlaniId,
                    OgrenciId = item.OgrenciId,
                    Aciklama = _secimListesi.Count == 1 ? txtAciklama.Text : item.AdiSoyadi + " (TC:" + item.TcKimlikNo + ") " + item.DonemAdi + " " + item.TaksitNo + " Nolu Taksit Ödemesi" + pos,
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = DateTime.Now
                };
                list.Add(nkt);
            }

            return list;

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                kayitVar = BankaF.Sil(BankaListForm.SeciliId);
            }
            catch (Exception ex)
            {

                Messages.UyariMesaji(ex.Message);
            }
            if (kayitVar)
                Close();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TxtIslemAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            lblIslemAdi.Enabled = true;
            txtBankaIslemAdi.Tag = txtBankaIslemAdi.ItemsId();
            switch (txtBankaIslemAdi.Tag.ToInt32())
            {
                case 1:
                    lblIslemAdi.Text = "Taksit No";
                    break;

                case 2:
                    lblIslemAdi.Text = "Öğrenc Adı";
                    break;

                case 3:
                case 4:
                    lblIslemAdi.Text = "Personel Adı";
                    break;

                case 5:
                case 6:
                    lblIslemAdi.Text = "Firma Adı";
                    break;

                case 8:
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





        private void CbxPos_CheckedChanged(object sender, EventArgs e)
        {
            if (_gelenAciklama != "")
                txtAciklama.Text = cbxPos.Checked ? _gelenAciklama + " || ( POS )" : _gelenAciklama + " || ( IBAN )";
        }


        private void TxtCariSecim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _OgrenciId = _OgrenciOdemePlaniId = _FirmaId = _Personel = _VirmanHesapId = 0;
            }
        }

        private void TxtCariSecim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtBankaIslemAdi.Text == "") return;

            switch (txtBankaIslemAdi.Tag.ToInt32())
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
                        txtCariSecim.Text = _secimListesi[0].AdiSoyadi + $" {_secimListesi[0].TaksitNo} Nolu Taksit"; 
                        _OgrenciOdemePlaniId = _secimListesi[0].OdemePlaniId;
                        _OgrenciId = _secimListesi[0].OgrenciId;
                        txtIslemTutari.EditValue = _secimListesi[0].Kalan;
                        _gelenAciklama= txtAciklama.Text = _secimListesi[0].TaksitNo != 0 ? _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " " + _secimListesi[0].TaksitNo + " Nolu Taksit Ödemesi" : _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + " Eğitim Ücreti Ödemesi";

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
                        _gelenAciklama= txtAciklama.Text = _secimListesi[0].AdiSoyadi + " (TC:" + _secimListesi[0].TcKimlikNo + ") " + _secimListesi[0].DonemAdi + $" ({taksitler.Remove(taksitler.Length - 1, 1)}) Nolu Taksitler Ödemesi";
                    }


                    CbxPos_CheckedChanged(null, null);
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
                    _gelenAciklama = fr2.Aciklama;
                    CbxPos_CheckedChanged(null, null);
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
                    _gelenAciklama = fr3.Aciklama;
                    CbxPos_CheckedChanged(null, null);
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
                    _gelenAciklama = fr5.Aciklama;
                    CbxPos_CheckedChanged(null, null);
                    fr5.Dispose();
                    break;



                case 8:
                    BankaHesapListForm fr8 = new BankaHesapListForm(true);
                    fr8.ShowDialog();
                    if (_hesapId == fr8.SeciliHesapId)
                    {
                        Messages.HataMesaji("Aynı Hesaba Virman Yapılamaz");
                        return;
                    }
                    txtCariSecim.Text = fr8.SeciliHesap;
                    _VirmanHesapId = fr8.SeciliHesapId;
                    txtAciklama.Text = fr8.SeciliHesap + " Nolu Hesaba Virman";
                    fr8.Dispose();

                    break;

            }
        }

        private void txtHesapAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            _hesapId = txtHesapAdi.ItemsId();
        }


    }
}
