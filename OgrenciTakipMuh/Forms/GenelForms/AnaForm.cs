using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Data.Facade;
using DevExpress.XtraTabbedMdi;
using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using System;
using DevExpress.LookAndFeel;
using OgrenciTakipMuh.Properties;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Forms.RaporForms;
using OgrenciTakipMuh.Facade;
using System.Net.NetworkInformation;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraBars.Ribbon;
using System.Collections.Generic;
using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using System.Drawing;
using System.Configuration;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class AnaForm : RibbonForm
    {

        public static bool SmsVeMailGonderme = Convert.ToBoolean(ConfigurationManager.AppSettings["SmsVeMailGonderme"]); // programcı kontrolü app configden kontrol ediyoruz
        #region Veriables
        FirmaCariHareketListForm CariHareketFrm;
        RaporForm RaporFrm;

        public static long KullanicilId;
        public static long DonemId;
        public static string DonemAdi;

        public static string KullaniciTuru;
        public static long RolId;


        public static int OtoKapanmaZamani;
        public static bool OtoKapanma;
        public static int OtoKapanmaSuresi;

        public static bool OtoYedeklemeMailAtilacak;
        public static string SonYedekYolu;
        string _dakika, _saniye;

        public static VarsayilanAyarlar GenAyr;
        public static Kullanici Kllnci;
        public static bool OgrenciTutarlariniGorme;
        string _gallery, _palette;


        #endregion
        public AnaForm()
        {

            InitializeComponent();
            GenelAyarlar();
            KullaniciAyarlari();
            UserLookAndFeel.Default.SetSkinStyle(Kllnci.Tema, Kllnci.TemaParametre);
            tmrOpakliAcilma.Start();
            PersonelOdemePlaniF.OtomatikMaasIslemi();
            Hatirlatma();
            OgrenciTutalariGorebilmeKontrolu();

            GalleryControlGallery gallery = ((skinGallery.DropDownControl as PopupControlContainer).Controls.OfType<GalleryControl>().FirstOrDefault()).Gallery;
            gallery.ItemClick += Gallery_ItemClick;
            skinPalette.GalleryItemClick += SkinPalette_GalleryItemClick;
            btnYedeklemeAyarlari.Visibility = Kllnci.KullaniciTuru == "Yönetici" ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (GenAyr.SmsGonderme)
                using (var sms = new SmsFunctions())
                    sms.BirinciOtoSms((List<OgrenciCariOdemeL>)OgrenciOdemePlaniF.OdenmeyenTaksitlerSmsGondermeListesi());
           
        }

        private void SkinPalette_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _palette = e.Item.Caption;
            TemaGuncelle();
        }



        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _gallery = e.Item.Caption;
            skinPalette.Visibility = _gallery == "The Bezier" ? BarItemVisibility.Always : BarItemVisibility.Never;
            TemaGuncelle();

        }


        void TemaGuncelle()
        {
            KullaniciF.TemaGuncelle(_gallery, _palette, KullanicilId);

        }

        private void OgrenciTutalariGorebilmeKontrolu()
        {
            if (Kllnci.KullaniciTuru == "Yönetici")
                OgrenciTutarlariniGorme = true;
            else
            {
                var a = RolF.Kontroller(25);
                if (a == null)
                    OgrenciTutarlariniGorme = false;
                else
                    OgrenciTutarlariniGorme = a.Gorebilir == 1;

            }
        }

        public void GenelAyarlar()
        {
            GenAyr = VarsayilanAyarlarF.Secim();
            if (GenAyr == null) return;


            DonemId = GenAyr.DonemId;
            try { DonemAdi = DonemF.Secim(DonemId).DonemAdi; } catch (Exception) { DonemAdi = ""; }
            if (GenAyr.OtomatikYedekleme)
                timerYedekleme.Start();
            else
                timerYedekleme.Stop();




        }
        public void KullaniciAyarlari()
        {
            Kllnci = KullaniciF.Secim(KullanicilId);
            RolId = Kllnci.RolId;
            KullaniciTuru = Kllnci.KullaniciTuru;
            lblKullaniciAdi.Caption = Kllnci.AdiSoyadi;
            lblYetki.Caption = Kllnci.KullaniciTuru + ":";
            lblProgramRolu.Caption = RolId == 1 ? "Tam Yetki" : RolF.Secim(RolId) != null ? RolF.Secim(RolId).RolAdi : "Tanımlanmayan Rol";

            _gallery = Kllnci.Tema;
            _palette = Kllnci.TemaParametre;
            skinPalette.Visibility = _gallery == "The Bezier" ? BarItemVisibility.Always : BarItemVisibility.Never;


            AnaformResim.EditValue = Kllnci.AnaResim ?? Resources.AnaResim.ToByte();
            OtoKapanma = Kllnci.OtoKapanma;
            OtoKapanmaSuresi = Kllnci.OtoKapanmaSuresi * 60;

            if (OtoKapanma)
            {
                OtoKapanmaZamani = OtoKapanmaSuresi;

                tmrKapanma.Start();
            }
            else
            {
                tmrKapanma.Stop();
                lblOtoKapanmaSure.Caption = "Kapalı";
            }
        }

        public void Hatirlatma()
        {
            int o, p, c;
            o = OgrenciOdemePlaniF.BuGunOdenecekTaksitSayisi();
            p = PersonelOdemePlaniF.BuGunkOdenecekMaasSayisi();
            c = CekF.VadesiBugunOlanCekSayisi();
            if (Kllnci.KullaniciTuru == "Yönetici")
            {
                btnOgrenciHatirlatma.Caption = $"Hatırlatma\n({o})";
                btnPersonelHatirlatma.Caption = $"Personel\n({p})";
                btnCekHatirlatma.Caption = $"Hatırlatma\n({c})";
                btnOgrenciHatirlatma.ItemAppearance.Normal.ForeColor = o > 0 ? Color.Red : DefaultForeColor;
                btnPersonelHatirlatma.ItemAppearance.Normal.ForeColor = p > 0 ? Color.Red : DefaultForeColor;
                btnCekHatirlatma.ItemAppearance.Normal.ForeColor = o > c ? Color.Red : DefaultForeColor;
            }
            else
            {
                if (RolF.Kontroller(21) == null) return;
                if (RolF.Kontroller(21).Gorebilir == 1)
                {
                    btnOgrenciHatirlatma.Caption = $"Hatırlatma\n({o})";
                    btnOgrenciHatirlatma.ItemAppearance.Normal.ForeColor = o > 0 ? Color.Red : DefaultForeColor;
                }


                if (RolF.Kontroller(22).Gorebilir == 1)
                {
                    btnPersonelHatirlatma.Caption = $"Hatırlatma\n({p})";
                    btnPersonelHatirlatma.ItemAppearance.Normal.ForeColor = p > 0 ? Color.Red : DefaultForeColor;
                }


                if (RolF.Kontroller(23).Gorebilir == 1)
                {
                    btnCekHatirlatma.Caption = $"Hatırlatma\n({c})";
                    btnCekHatirlatma.ItemAppearance.Normal.ForeColor = o > c ? Color.Red : DefaultForeColor;
                }


            }




        }
        public void FormAc(Form form)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!AktifForm(form))
            {
                if (KullaniciTuru == "Kullanıcı")
                {
                    var kont = RolF.Kontroller(form.Tag);

                    if (kont.Gorebilir == 1)
                    {
                        form.MdiParent = this;
                        form.Show();
                    }
                    else
                    {
                        Messages.YetkinizYokMesaji(form.Text + " Formuna Erişim Yetkiniz Yok");
                        form.Dispose();
                        return;
                    }
                }

                else
                {
                    form.MdiParent = this;
                    form.Show();
                }



            }
            Cursor.Current = Cursors.Default;
        }

        private bool AktifForm(Form form)
        {
            bool IsOpened = false;

            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        xtraTabbedMdiManager.Pages[item].MdiChild.Activate();
                        //try { ((BaseListForm)item).btnYenile.PerformClick(); } catch (Exception) { }
                        IsOpened = true;
                    }
                }
            }
            return IsOpened;
        }

        private void BtnOgrenciler_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new OgrenciListForm());
        }

        private void BtnVeliler_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new VeliListForm());
        }

        private void BtnDonemler_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new DonemListForm(false));
        }

        private void BtnGruplar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new GrupListForm());
        }

        private void BtnSiniflar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new SinifListForm());
        }

        private void XtraTabbedMdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            AnaformResim.SendToBack();

        }

        private void XtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (((XtraTabbedMdiManager)sender).Pages.Count == 0)
                AnaformResim.BringToFront();
        }



        private void BtnNakit_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new NakitListForm());
        }

        private void BtnBanka_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new BankaListForm());
        }

        private void BtnCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new CekListForm());
        }

        private void BtnKayitYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (KullaniciTuru == "Kullanıcı")
            {
                var kont = RolF.Kontroller(1);
                if (kont.Gorebilir != 1)
                {
                    Messages.YetkinizYokMesaji("Öğrenci Formuna Erişim Yetkiniz Yok");
                    return;
                }
            }



            var ogrenciid = GenelFunctions.SecilenOgrenciId();
            if (ogrenciid == 0) return;
            var mevcutdonemId = OgrenciF.Secim(ogrenciid).DonemId;

            var donemid = GenelFunctions.SecilenDonemId(mevcutdonemId);
            if (donemid == 0) return;



            OgrenciListForm.SeciliId = 0;
            OgrenciEditForm fr = new OgrenciEditForm(donemid, ogrenciid);
            fr.ShowDialog();
            fr.Dispose();

        }

        private void BtnOdenmeyenTahakkuklar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!OgrenciTutarlariniGorme)
            {
                Messages.OgrenciTutarlariGormeyeYetkinizYokMesaji();
                return;
            }
            FormAc(new OgrenciTaksitSecimListForm());
        }

        private void BarButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new YedeklemeEdifForm());

        }

        private void Ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            TumFormlariKapat();
            if (DonemId != 0)
                DonemId = VarsayilanAyarlarF.Secim().DonemId;
        }

        void TumFormlariKapat()
        {
            if (MdiChildren.Count() > 0)
                foreach (var item in MdiChildren)

                    item.Dispose();


        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                Hide();
                if (OtoYedeklemeMailAtilacak && NetworkInterface.GetIsNetworkAvailable())
                    MailFunctions.MailGonder(GenAyr.OtoYedeklemeMailAdres, SonYedekYolu + "MuhData.zip", "Veri Tabanı Yedekleme");
                if (GenAyr.SmsGonderme)
                    using (var sms = new SmsFunctions())
                        sms.IkinciOtoSms((List<OgrenciCariOdemeL>)OgrenciOdemePlaniF.OdenmeyenTaksitlerSmsGondermeListesi());
            }
            catch (Exception)
            {
                Application.Exit();
            }



            Application.Exit();
        }

        private void btnMeslek_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new MeslekListForm());
        }

        private void btnPersonel_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new PersonelListForm());
        }

        private void btnFirmaListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new FirmaListForm());
        }

        private void btnGelenFaturalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new FaturaListForm(true) { Name = "GelenFaturalar", Tag = 12 });

        }

        private void BtnKullaniciAyarlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (KullaniciF.Secim(KullanicilId).KullaniciTuru == "Kullanıcı")
            {
                KullaniciEditForm fr = new KullaniciEditForm(KullanicilId);
                fr.txtKullaniciTuru.Enabled = false;
                fr.txtAdiSoyadi.Enabled = false;
                fr.txtRolAdi.Enabled = false;
                fr.ShowDialog();
                fr.Dispose();
            }
            else
                FormAc(new KullaniciListForm());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1) Opacity += 0.05; else tmrOpakliAcilma.Stop();
        }

        private void btnGidenFaturalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new FaturaListForm(false) { Name = "GidenFaturalar", Tag = 13 });
        }

        private void btnMalHizmet_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new MalHizmetListForm());
        }

        private void btnVarsayilanAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (KullaniciTuru == "Kullanıcı")
                Messages.UyariMesaji("Bu Ayarlara Sadece Yöneticiler Ulaşabiir");
            else
            {

                VarsayilanEditForm fr = new VarsayilanEditForm();
                fr.ShowDialog();
                GenAyr = VarsayilanAyarlarF.Secim();
                fr.Dispose();
            }
        }

        private void btnKullaniciRolTanimlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (KullaniciTuru == "Kullanıcı")
            {
                Messages.UyariMesaji("Bu Ayarlara Sadece Yöneticiler Ulaşabiir");
                return;
            }
            FormAc(new RolListForm());
        }

        private void btnCariHareket_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FirmaListForm frm = new FirmaListForm(true) { Text = "Firma Seç" };
            if (!frm.Gorebilir)
            {
                Messages.YetkinizYokMesaji("Firma Listesini Görme Yetkiniz Bulunmamaktadır");
                frm.Dispose();
                return;
            }
            frm.ShowDialog();
            long Id = frm.FirmaId;
            frm.Dispose();

            if (Id == 0) return;

            CariHareketFrm = Application.OpenForms["FirmaCariHareketListForm"] as FirmaCariHareketListForm;
            if (CariHareketFrm == null)
                FormAc(new FirmaCariHareketListForm(Id));
            else
            {
                CariHareketFrm.tablo.GridControl.DataSource = FirmaCariHareketF.Liste(Id);
                CariHareketFrm.tablo.ViewCaption = FirmaF.Secim(Id).FirmaAdi + " Cari Hareket Listesi";
            }
        }
        private void TimerYedekleme_Tick(object sender, EventArgs e)
        {

            timerYedekleme.Stop();
            GenelAyarlar();

            if (GenAyr.SonYedeklemeTarihi.Date == DateTime.Now.Date) return;
            else
                if (GenAyr.YedeklemeSaati <= DateTime.Now.TimeOfDay)
            {
                bool _SesAyar = GenAyr.KayitSesi;
                GenAyr.KayitSesi = false;
                OtoYedeklemeMailAtilacak = YedeklemeKayitlariF.YedekAl(GenAyr.YedeklemeYolu, "Otomatik Yedekleme") && GenAyr.OtoYedeklemeMail;
                SonYedekYolu = YedeklemeKayitlariF.yedeklemeyolu;
                GenAyr.KayitSesi = _SesAyar;
                return;
            }
            else
                timerYedekleme.Start();
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (!OgrenciTutarlariniGorme)
            {
                Messages.OgrenciTutarlariGormeyeYetkinizYokMesaji();
                return;
            }
            FormAc(new OgrenciHatirlatma());
        }

        private void btnPersonelHatirlatma_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new PersonelHatirlatmaListesi());
        }


        private void btnCekHatirlatma_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new CekHatirlatma());
        }

        private void tmrKapanma_Tick(object sender, EventArgs e)
        {
            tmrKapanma.Stop();
            OtoKapanmaZamani--;
            _dakika = Convert.ToInt32(OtoKapanmaZamani / 60).ToString();
            _saniye = (OtoKapanmaZamani % 60).ToString();

            if (OtoKapanmaZamani <= 60)
            {
                if (_dakika.ToString().Length == 1) _dakika = "0" + _dakika;
                if (_saniye.ToString().Length == 1) _saniye = "0" + _saniye;
                lblOtoKapanmaSure.Caption = _dakika + ":" + _saniye;

                if (OtoKapanmaZamani <= 10)
                {
                    lblOtoKapanmaSure.Caption = "";
                    frmOtoKapanma fr = new frmOtoKapanma();
                    fr.ShowDialog();
                    fr.Dispose();
                    tmrKapanma.Start();
                }
                else
                {
                    tmrKapanma.Start();
                }
            }
            else
            {
                lblOtoKapanmaSure.Caption = "Açık";
            }

        }

        private void btnSmsTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormAc(new SmsListForm());
        }



        private void BtnOdemePlani_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!OgrenciTutarlariniGorme)
            {
                Messages.OgrenciTutarlariGormeyeYetkinizYokMesaji();
                return;
            }
            RaporFrm = Application.OpenForms["RaporForm"] as RaporForm;
            if (RaporFrm != null) return;

            var id = GenelFunctions.SecilenOgrenciId();
            if (id == 0) return;

            var donemId = OgrenciF.Secim(id).DonemId;

            if (!OgrenciOdemePlaniF.OdemePlaniVarmi(id, donemId))
            {
                OgrenciL ogrL = new OgrenciL();
                ogrL = OgrenciF.Secim(id);
                Messages.UyariMesaji(ogrL.AdiSoyadi + " " + ogrL.DonemAdi + " Ödeme Planı Bulunamadı");
            }
            else FormAc(new RaporForm(1, id));
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaporFrm = Application.OpenForms["RaporForm"] as RaporForm;
            if (RaporFrm != null) return;

            var id = GenelFunctions.SecilenOgrenciId();
            if (id == 0) return;
            if (!OgrenciOdemePlaniF.OdemeListesiVarmi(id))
            {
                OgrenciL ogrL = new OgrenciL();
                ogrL = OgrenciF.Secim(id);
                Messages.UyariMesaji(ogrL.AdiSoyadi + " " + ogrL.DonemAdi + " Herhangi bir Ödeme Bulunamadı");
            }
            else FormAc(new RaporForm(2, id));
        }


        private void btnTariheGoreOgrenciRaporu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!OgrenciTutarlariniGorme)
            {
                Messages.OgrenciTutarlariGormeyeYetkinizYokMesaji();
                return;
            }
            RaporFrm = Application.OpenForms["RaporForm"] as RaporForm;
            if (RaporFrm != null) return;

            var id = GenelFunctions.SecilenDonemId();
            if (id == 0) return;
            FormAc(new OgrenciRaporForm(id));
        }

        private void AnaformResim_MouseMove(object sender, MouseEventArgs e)
        {
            OtoKapanmaZamani = OtoKapanmaSuresi;
        }
    }
}