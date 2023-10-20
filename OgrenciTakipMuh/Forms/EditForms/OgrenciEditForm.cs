using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Controls.Components;
using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System.Windows.Forms;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Data.Entities.Entity;
using System.Collections.Generic;
using DevExpress.XtraLayout.Utils;
using System;
using OgrenciTakipMuh.Data.Tools;
using DevExpress.XtraBars;
using OgrenciTakipMuh.Forms.ListForms;

namespace OgrenciTakipMuh.Forms.MenuForms
{


    public partial class OgrenciEditForm : BaseEditForm
    {
        private bool _dvm;
        public Ogrenci ogr;
        public OgrenciL ogrL;
        public bool YeniKayit;
        public bool KayitVar;
        private long _donemId;
        private long _id;
      
        private long _odemePlaniId;
        private int _tahakkukNo;
        private bool _tahakkukVar;
        private long _kayityenilenecekOgrenciId;


        List<OgrenciOdemePlaniL> CurrentOdemePlani = new List<OgrenciOdemePlaniL>();//  Yeni
        List<OgrenciOdemePlaniL> OldOdemePlani = new List<OgrenciOdemePlaniL>();// Eski

       
        List<Notlar> CurrentNot = new List<Notlar>();//  Yeni

        public OgrenciEditForm(long donemId=0,long kayityenilenecekOgrenciId = 0)
        {
            InitializeComponent();
            NavTaksit.NavigatableControl = tabloOdemePlani.GridControl;
            NavNot.NavigatableControl = tabloNot.GridControl;
            NavOdemeBilgileri.NavigatableControl = tabloOdemeBilgileri.GridControl;
            _donemId = donemId;
            _kayityenilenecekOgrenciId = kayityenilenecekOgrenciId;
            txtDonemAdi.Tag = _donemId;
            txtDonemAdi.Text = DonemF.Secim(_donemId).DonemAdi;

            txtKayitTarihi.EditValue = DateTime.Now;
            rdbSms.SelectedIndex =  1;


            if (OgrenciListForm.SeciliId > 0)
            {
                _id = OgrenciListForm.SeciliId;
                ogrL = OgrenciF.Secim(_id);
                OgrenciBilgileri(ogrL);
                tabloOdemeBilgileri.GridControl.DataSource = OgrenciOdemePlaniF.OdemeListesi(_id);
                // tahakkuk var
                if (ogrL.TahakkukNo != 0)
                {
                    TahakkukBilgileri(ogrL);
                    _tahakkukVar = true;
                }
                else
                {
                    _tahakkukVar = false;
                    _tahakkukNo = OgrenciTahakkukF.TahakkukNoVer();
                    txtIlkOdemeTarihi.EditValue = DateTime.Now;
                  
                }

            }
            else
            {
                _id = GenelFunctions.IdOlustur();
                _tahakkukNo = OgrenciTahakkukF.TahakkukNoVer();
                txtIlkOdemeTarihi.EditValue = DateTime.Now;
                this.Text += " ( Yeni Kayıt )";
                myPictureEdit1.EditValue =  Properties.Resources.BosResim.ToByte();
                YeniKayit = true;
                _tahakkukVar = false;
            }

            // FORM KAYIT YENİLEME OLARAK AÇILIRSA
            if (kayityenilenecekOgrenciId > 0)
            {
                ogrL = OgrenciF.Secim(kayityenilenecekOgrenciId);
                this.Text += " - KAYIT YENİLEME";
                txtTcKimlikNo.Text = ogrL.TcKimlikNo;
                txtAdiSoyadi.Text = ogrL.AdiSoyadi;
                txtVeli1AdiSoyadi.Tag = ogrL.Veli1Id;
                txtVeli1AdiSoyadi.Text = ogrL.Veli1AdiSoyadi;
                txtVeli2AdiSoyadi.Tag = ogrL.Veli2Id;
                txtVeli2AdiSoyadi.Text = ogrL.Veli2AdiSoyadi;
                txtVeli1Tel.Text = ogrL.Veli1Telefon;
                txtVeli2Tel.Text = ogrL.Veli2Telefon;
                txtEmail.Text = ogrL.EmailAdresi;
                txtGeldigiOkul.Text = ogrL.GeldigiOkul;
                txtAdres.Text = ogrL.Adres;
                myPictureEdit1.EditValue = ogrL.Resim??Properties.Resources.BosResim.ToByte();
                btnSil.Enabled = true;
                rdbSms.SelectedIndex = ogrL.OtoSms ? 0 : 1;

            }

            if (!AnaForm.OgrenciTutarlariniGorme)
            {

                txtKayitTutari.Properties.PasswordChar = txtAciklama.Properties.PasswordChar = '#';
                txtKayitTutari.ReadOnly = txtAciklama.ReadOnly = true;
                layoutTahakkukTutari.Visibility = layoutTaksitSayisi.Visibility = layoutIlkOdemeTarihi.Visibility =
                layoutOdemePlaniListesi.Visibility = LayoutVisibility.Never;


            }

            BtnSatirSil.ItemClick += BtnTaksitSatirSil_ItemClick;
            btnYenile.ItemClick += BtnTaksitYenile_ItemClick;
            btnSatirEkle.ItemClick += BtnTaksitSatirEkle_ItemClick;
            btnTumunuSil.ItemClick += BtnOdenmeyenTaksitleriSil_ItemClick;

            btnYeniNot.ItemClick += BtnYeniNot_ItemClick;
            btnNotSil.ItemClick += BtnNotSil_ItemClick;

            _dvm = true;

        }


        void OgrenciBilgileri(OgrenciL ogrL)
        {

            txtTcKimlikNo.Text = ogrL.TcKimlikNo;
            txtAdiSoyadi.Text = ogrL.AdiSoyadi;
            txtVeli1AdiSoyadi.Tag = ogrL.Veli1Id;
            txtVeli1AdiSoyadi.Text = ogrL.Veli1AdiSoyadi;
            txtVeli2AdiSoyadi.Tag = ogrL.Veli2Id;
            txtVeli2AdiSoyadi.Text = ogrL.Veli2AdiSoyadi;
            txtVeli1Tel.Text = ogrL.Veli1Telefon;
            txtVeli2Tel.Text = ogrL.Veli2Telefon;
            txtEmail.Text = ogrL.EmailAdresi;
            txtGeldigiOkul.Text = ogrL.GeldigiOkul;
            txtAdres.Text = ogrL.Adres;
            _dvm = true;
            txtGrupAdi.Text = ogrL.GrupAdi;
            txtGrupAdi.Tag = ogrL.GrupId;
            txtSinifAdi.Text = ogrL.SinifAdi;
            txtSinifAdi.Tag = ogrL.SinifId;
            _dvm = false;
            txtKayitTarihi.EditValue = ogrL.KayitTarihi;
            txtKayitTutari.EditValue = ogrL.KayitTutari;
            txtAciklama.Text = ogrL.Aciklama;
            tglDurum.IsOn = ogrL.Durum;
            myPictureEdit1.EditValue = ogrL.Resim ?? Properties.Resources.BosResim.ToByte();
            btnSil.Enabled = true;
            rdbSms.SelectedIndex = ogrL.OtoSms?0:1;
            this.Text += " ( Kayıt Güncelleme )";
            btnKaydet.Text = "Güncelle";

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci
            {
                Id = _id,
                TcKimlikNo = txtTcKimlikNo.Text,
                AdiSoyadi = txtAdiSoyadi.Text,
                Veli1Id = Convert.ToInt64(txtVeli1AdiSoyadi.Tag),
                Veli2Id = Convert.ToInt64(txtVeli2AdiSoyadi.Tag),
                EmailAdresi = txtEmail.Text,
                GeldigiOkul = txtGeldigiOkul.Text,
                Adres = txtAdres.Text,
                DonemId = _donemId,
                GrupId = Convert.ToInt64(txtGrupAdi.Tag),
                SinifId = Convert.ToInt64(txtSinifAdi.Tag),
                KayitTutari = txtKayitTutari.Value,
                KayitTarihi = txtKayitTarihi.DateTime,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
                Resim = ((byte[])myPictureEdit1.EditValue).Length==9099? null: (byte[])myPictureEdit1.EditValue,
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now,
                OtoSms = rdbSms.SelectedIndex == 0
        };




            try
            {
                if (txtKayitTutari.Value > 0 && CurrentOdemePlani.Count > 0)
                    OgrenciOdemePlaniF.HataKont(CurrentOdemePlani);
                if (YeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No) return;

                    if (OgrenciF.Ekle(ogr))
                    {
                        ogrL = OgrenciF.Secim(_id);
                        OgrenciBilgileri(ogrL);
                        if (CurrentOdemePlani.Count <= 0)
                        {
                            KayitVar = true;
                        }
                        else
                        {
                            KayitVar = OgrenciOdemePlaniF.OdemePlaniOlustur(CurrentOdemePlani);
                        }
                        if(CurrentNot!=null && CurrentNot.Count>0)
                        NotlarF.Guncelle(CurrentNot);

                    }


                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No) return;
                    if (OgrenciF.Guncelle(ogr, _id))
                    {
                        if (OgrenciOdemePlaniF.OdemePlaniVarmi(_id, _donemId))
                            KayitVar = OgrenciOdemePlaniF.OdemePlaniGuncelle(OldOdemePlani, CurrentOdemePlani);
                        else
                        {
                            if (CurrentOdemePlani.Count != 0)
                                KayitVar = OgrenciOdemePlaniF.OdemePlaniOlustur(CurrentOdemePlani);
                            else
                                KayitVar = true;
                          
                        }
                        if (CurrentNot != null && CurrentNot.Count > 0)
                            NotlarF.Guncelle(CurrentNot);

                    }
                }

            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);

            }

            if (KayitVar)
            {
                Id = ogr.Id;
                this.Close();
            }


        }


        private void BtnIptal_Click(object sender, EventArgs e)
        {
            KayitVar = false;
            this.Close();
        }



        private void TxtVeliAdiSoyadi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var buttonedit = sender as MyButtonEdit;


            VeliListForm fr = new VeliListForm(true) { Text = "Veli Seç" };
            if (!fr.Gorebilir)
            {
                Messages.YetkinizYokMesaji("Veli Listesini Görme Yetkiniz Bulunmamaktadır");
                fr.Dispose();
                return;
            }
            fr.ShowDialog();
            if (fr.SeciliId <= 0) { fr.Dispose(); return; }
            var veli = VeliF.Secim(fr.SeciliId);

            buttonedit.Tag = veli.Id;
            buttonedit.Text = veli.VeliAdiSoyadi;
            if(buttonedit==txtVeli1AdiSoyadi) txtVeli1Tel.Text = veli.Telefon;
            if(buttonedit==txtVeli2AdiSoyadi) txtVeli2Tel.Text = veli.Telefon;



            fr.Dispose();

        }

        private void TxtGrupAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GrupListForm fr = new GrupListForm(true, _donemId) { Text = "Grup Seç" };
            if (!fr.Gorebilir)
            {
                Messages.YetkinizYokMesaji("Grup Listesini Görme Yetkiniz Bulunmamaktadır");
                fr.Dispose();
                return;
            }
            fr.ShowDialog();
            txtGrupAdi.Text = fr.GrupAdi;
            txtGrupAdi.Tag = fr.SeciliId;
            fr.Dispose();
        }

        private void TxtSinifAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtGrupAdi.Text == "")
            {
                Messages.UyariMesaji("Önce Grup Seçmelisiniz");
                return;
            }
            SinifListForm fr = new SinifListForm(true, _donemId,Convert.ToInt64(txtGrupAdi.Tag)) { Text = txtGrupAdi.Text + " Grubu - Sınıf Seç" };
            if (!fr.Gorebilir)
            {
                Messages.YetkinizYokMesaji("Sınıf Listesini Görme Yetkiniz Bulunmamaktadır");
                fr.Dispose();
                return;
            }
            fr.ShowDialog();
            txtSinifAdi.Text = fr.SecilenSinifAdi;
            txtSinifAdi.Tag = fr.SeciliId;
            fr.Dispose();
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (OgrenciOdemePlaniF.OdemeListesiVarmi(_id))
            {
                Messages.UyariMesaji("Bu Öğrenciye ait ödemesi yapılan Taksitler olduğu için kayıt silinemez");
                return;
            }

            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {

                if (OgrenciOdemePlaniF.OdemePlaniVarmi(_id, _donemId))
                    OgrenciOdemePlaniF.OdemePlaniSil(OldOdemePlani, CurrentOdemePlani);

                KayitVar = OgrenciF.Sil(_id);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
                KayitVar = false;
            }

            if (KayitVar)
                this.Close();
        }


        private void myPictureEdit1_Enter(object sender, EventArgs e)
        {
            ((MyPictureEdit)sender).Sec(popupMenu1);
        }
        private void txtGrupAdi_TextChanged(object sender, EventArgs e)
        {
            txtSinifAdi.Text = null;
            txtSinifAdi.Tag = null;
        }
        private void TxtVeliAdiSoyadi_KeyDown(object sender, KeyEventArgs e)
        {
            var buttonedit = sender as MyButtonEdit;

            if (buttonedit == txtVeli1AdiSoyadi) txtVeli1Tel.Text = null;
            if (buttonedit == txtVeli2AdiSoyadi) txtVeli2Tel.Text = null;

        }




        #region TAHAKKUK


        void TahakkukBilgileri(OgrenciL ogrL)
        {
            _dvm = false;
            _tahakkukNo = ogrL.TahakkukNo;
            txtTahakkukTutari.EditValue = ogrL.TahakkukTutari;
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani = (List<OgrenciOdemePlaniL>)OgrenciOdemePlaniF.OdemePlani(ogrL.Id, _donemId);
            OldOdemePlani = (List<OgrenciOdemePlaniL>)OgrenciOdemePlaniF.OdemePlani(ogrL.Id, _donemId);
            tabloNot.GridControl.DataSource = CurrentNot = (List<Notlar>)NotlarF.Liste(ogrL.Id);

            

            layoutTahakkukTutari.Visibility = layoutTaksitSayisi.Visibility = layoutIlkOdemeTarihi.Visibility = LayoutVisibility.Never;

            try
            {
                if (CurrentOdemePlani[0].TaksitNo == 0)
                    txtTaksitSayisi.EditValue = 0;
                else
                    txtTaksitSayisi.EditValue = CurrentOdemePlani.Count;
            }
            catch (Exception) { }


            txtIlkOdemeTarihi.Text = "";

            _dvm = true;
        }

        private void BtnTaksitSatirSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            _dvm = false;
            int a = tabloOdemePlani.FocusedRowHandle;
            if (a < 0) return;
            CurrentOdemePlani.RemoveAt(a);
            tabloOdemePlani.GridControl.DataSource = null;
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;

            TaksitOdemeTutariGuncelle();
            tabloOdemePlani.FocusedRowHandle = a - 1;

            if (tabloOdemePlani.RowCount <= 0)
            {
                txtIlkOdemeTarihi.DateTime = DateTime.Now;
                layoutTahakkukTutari.Visibility = layoutTaksitSayisi.Visibility = layoutIlkOdemeTarihi.Visibility = LayoutVisibility.Always;

            }
            _dvm = true;
        }

        void TaksitOdemeTutariGuncelle()
        {
            _dvm = false;
            double toplam = 0;

            foreach (var item in CurrentOdemePlani)
            {
                item.OdemeSekliId = 4;
                toplam += (double)item.OdenecekTutar;
            }

            txtTahakkukTutari.EditValue = toplam;
            txtTaksitSayisi.EditValue = CurrentOdemePlani.Count;
            tabloOdemePlani.GridControl.DataSource = null;
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;
            _dvm = true;
        }


        private void BtnTaksitSatirEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            _dvm = false;
            if (CurrentOdemePlani.Count <= 0)
            {
                _odemePlaniId = GenelFunctions.IdOlustur();
                var odYeni = new OgrenciOdemePlaniL
                {
                    Id = _odemePlaniId,
                    TahakkukNo = _tahakkukNo,
                    OgrenciId = _id,
                    DonemId = _donemId,
                    TaksitNo = 1,
                    SonOdemeTarihi = DateTime.Now,
                    OdemeSekliId = 4,
                    OdemeSekliAdi = "",
                    OdenecekTutar = 0,
                    KullaniciId = AnaForm.KullanicilId,
                    Aciklama = "",
                    IslemTarihi = DateTime.Now,
                    Odendi = false,
                    
                };
                CurrentOdemePlani.Add(odYeni);

            }

            else
            {
                var od = new OgrenciOdemePlaniL
                {
                    Id = CurrentOdemePlani[CurrentOdemePlani.Count - 1].Id + 1,
                    TahakkukNo = _tahakkukNo,
                    OgrenciId = _id,
                    DonemId = _donemId,
                    TaksitNo = CurrentOdemePlani[CurrentOdemePlani.Count - 1].TaksitNo + 1,
                    SonOdemeTarihi = CurrentOdemePlani[CurrentOdemePlani.Count - 1].SonOdemeTarihi.AddMonths(1),
                    OdemeSekliId = 4,
                    OdemeSekliAdi = "",
                    OdenecekTutar = 0,
                    KullaniciId = AnaForm.KullanicilId,
                    Aciklama = "",
                    IslemTarihi = DateTime.Now,
                    Odendi = false
                };
                CurrentOdemePlani.Add(od);
            }

            TaksitOdemeTutariGuncelle();
            tabloOdemePlani.MoveLast();
            _dvm = true;

        }
        private void BtnOdenmeyenTaksitleriSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            _dvm = false;
            tabloOdemePlani.GridControl.DataSource = null;
            for (int i = CurrentOdemePlani.Count - 1; i >= 0; i--)
            {
                if (!CurrentOdemePlani[i].Odendi)
                    CurrentOdemePlani.RemoveAt(i);
            }

            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;

            TaksitOdemeTutariGuncelle();
            tabloOdemePlani.MoveLast();

            if (tabloOdemePlani.RowCount <= 0)
            {
                txtIlkOdemeTarihi.DateTime = DateTime.Now;
                layoutTahakkukTutari.Visibility = layoutTaksitSayisi.Visibility = layoutIlkOdemeTarihi.Visibility = LayoutVisibility.Always;

            }

            _dvm = true;

        }
        private void BtnTaksitYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            tabloOdemePlani.GridControl.DataSource = null;
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;
            TaksitOdemeTutariGuncelle();
        }





        void PesinOdemePlaniOlustur()
        {
            CurrentOdemePlani.Clear();
            tabloOdemePlani.GridControl.DataSource = null;
            _odemePlaniId = GenelFunctions.IdOlustur();

            var od = new OgrenciOdemePlaniL
            {
                Id = _odemePlaniId,
                TahakkukNo = _tahakkukNo,
                OgrenciId = _id,
                DonemId = _donemId,
                TaksitNo = 0,
                SonOdemeTarihi = txtIlkOdemeTarihi.DateTime,
                OdemeSekliId = 4,
                OdenecekTutar = Math.Round(txtTahakkukTutari.EditValue.ToDecimal(), 2),
                KullaniciId = AnaForm.KullanicilId,
                Aciklama = "Peşin ödeme Planı oluşturulmuştur...",
                IslemTarihi = DateTime.Now,
                Odendi = false
            };
            CurrentOdemePlani.Add(od);
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;
        }
        void TaksitliOdemePlaniOlustur()
        {
            if (!_dvm) return;


            if (CurrentOdemePlani.Count > 0)
            {
                CurrentOdemePlani.Clear();
                tabloOdemePlani.GridControl.DataSource = null;
            }



            _odemePlaniId = GenelFunctions.IdOlustur();
            for (int i = 0; i < txtTaksitSayisi.Value; i++)
            {
                var od = new OgrenciOdemePlaniL
                {
                    Id = _odemePlaniId + i,
                    TahakkukNo = _tahakkukNo,
                    OgrenciId = _id,
                    DonemId = _donemId,
                    TaksitNo = i + 1,
                    SonOdemeTarihi = txtIlkOdemeTarihi.DateTime.AddMonths(i),
                    OdemeSekliId = 4,
                    OdenecekTutar = Math.Round(txtTahakkukTutari.EditValue.ToDecimal() / txtTaksitSayisi.Value, 2),
                    KullaniciId = AnaForm.KullanicilId,
                    Aciklama = $"Otomatik  taksit oluşturulmuştur. (Taksit No: {i + 1}/{txtTaksitSayisi.Value})",
                    IslemTarihi = DateTime.Now,
                    Odendi = false
                };
                CurrentOdemePlani.Add(od);
            }
            tabloOdemePlani.GridControl.DataSource = CurrentOdemePlani;
        }

        void OdemePlaniTemizle()
        {
            CurrentOdemePlani.Clear();
            tabloOdemePlani.GridControl.DataSource = null;
        }




 

        private void TxtKayitTutari_EditValueChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            if (!_tahakkukVar && txtKayitTutari.Value > 0)
                txtTahakkukTutari.Value = txtKayitTutari.Value;


        }




        #endregion

        private void TabloOdemePlani_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (CurrentOdemePlani.Count <= 0 || e.FocusedRowHandle < 0) return;
            colSonOdemeTarihi.OptionsColumn.AllowEdit = colOdenecekTutar.OptionsColumn.AllowEdit = colAciklama.OptionsColumn.AllowEdit = !CurrentOdemePlani[e.FocusedRowHandle].Odendi;
            colSonOdemeTarihi.OptionsColumn.AllowFocus = colOdenecekTutar.OptionsColumn.AllowFocus = colAciklama.OptionsColumn.AllowFocus = !CurrentOdemePlani[e.FocusedRowHandle].Odendi;

        }

        private void TabloOdemePlani_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            TaksitOdemeTutariGuncelle();
        }

        private void TxtTaksitSayisi_EditValueChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;

            if (txtTahakkukTutari.Value <= 0)
            {
                OdemePlaniTemizle();
                return;
            }

            if (txtTaksitSayisi.Value == 0)
            {

                _dvm = false;
                txtIlkOdemeTarihi.DateTime = DateTime.Now;
                _dvm = true;
                PesinOdemePlaniOlustur();
            }

            else
            {

                _dvm = false;
                _dvm = true;
                TaksitliOdemePlaniOlustur();
            }
        }

        private void TabloOdemePlani_MouseUp(object sender, MouseEventArgs e)
        {

            btnTumunuSil.Enabled = false;
            BtnSatirSil.Enabled = tabloOdemePlani.RowCount > 0;// gösterilen row sayısı 0 dan küçükse pasifleştir
            if (tabloOdemePlani.RowCount > 0)
            {
                BtnSatirSil.Enabled = !(bool)tabloOdemePlani.GetFocusedRowCellValue("Odendi");// seçili row ödenmişse  pasifleştir
                foreach (var item in CurrentOdemePlani)
                {
                    if (!item.Odendi)
                    {
                        btnTumunuSil.Enabled = true;
                        continue;
                    }

                }
            }

            e.ShowPopupMenu(popupMenu2);
        }


        private void OdemePlani(object sender, EventArgs e)
        {
            if (!_dvm) return;


            if (txtTahakkukTutari.Value <= 0)
            {
                OdemePlaniTemizle();
                return;
            }


            if (txtTaksitSayisi.Value == 0)
                PesinOdemePlaniOlustur();
            else
                TaksitliOdemePlaniOlustur();
        }

        private void TabloNot_MouseUp(object sender, MouseEventArgs e)
        {
            btnNotSil.Enabled = tabloNot.RowCount > 0;
            e.ShowPopupMenu(popupMenu3);
        }


        private void BtnNotSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            int a = tabloNot.FocusedRowHandle;
            if (a < 0) return;
            CurrentNot.RemoveAt(a);
            tabloNot.GridControl.DataSource = null;
            tabloNot.GridControl.DataSource = CurrentNot;
            tabloNot.FocusedRowHandle = a - 1;         
        }

        private void BtnYeniNot_ItemClick(object sender, ItemClickEventArgs e)
        {
            var nt = new Notlar
            {
                Id = GenelFunctions.IdOlustur(),
                Tarih = DateTime.Now,
                OgrenciId = _id,
                KullaniciId = AnaForm.KullanicilId,
                Aciklama = "",
                IslemTarihi = DateTime.Now,
            };
            CurrentNot.Add(nt);

            tabloNot.GridControl.DataSource = null;
            tabloNot.GridControl.DataSource = CurrentNot;
            tabloNot.MoveLast();
            tabloNot.SelectCell(tabloNot.RowCount - 1, colAciklama);

        }

 
    }
}