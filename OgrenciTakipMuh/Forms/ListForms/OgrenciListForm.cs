using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.RaporForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.MenuForms
{
    public partial class OgrenciListForm : BaseListForm
    {
        public static long SeciliId;
        public long OgrenciId;// seçim formu
        public string ogrenciAdi;// seçim formu
        public string Aciklama;// seçim formu
        public bool _devam;
        Color clr = new Color();

        public OgrenciListForm(bool secimFormuOlarakAcilma = false)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            Yukle();
            clr = txtDonemAdi.ForeColor;
            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnRenklendirme.Visibility = AnaForm.OgrenciTutarlariniGorme ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
           
            if (!AnaForm.OgrenciTutarlariniGorme)
            {
                tablo.Bands["bntTahakkukBilgileri"].Visible = tablo.Bands["bntDigerBilgiler"].Visible = false;
                tablo.Bands["bntTahakkukBilgileri"].OptionsBand.ShowInCustomizationForm = tablo.Bands["bntDigerBilgiler"].OptionsBand.ShowInCustomizationForm = false;
            }
            else
            {
                TabloRenkleri(!secimFormuOlarakAcilma);
            }
            TabloRenkleri(false);
            _devam = true;
        }

        void TabloRenkleri(bool renkler)
        {

            btnRenklendirme.Caption = renkler ? "Renklendirme Kapat" : "Renklendirme Aç";
            tablo.FormatRules[0].Enabled = tablo.FormatRules[1].Enabled = tablo.FormatRules[2].Enabled = renkler;
            pnlHicOdemeYapmayanlar.Visible = lblHicOdemeYapmayanlar.Visible = renkler;
            pnlOdemesiTamamlanmayan.Visible = lblOdemesiTamamlanmayan.Visible = renkler;
            pnlOdemesiTamamlananlar.Visible = lblOdemesiTamamlananlar.Visible = renkler;
        }

        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(secimFormuolarakAcilma);
            btnTahsilat.Visibility = btnOdemePlaniRaporu.Visibility  = secimFormuolarakAcilma ? BarItemVisibility.Never : BarItemVisibility.Always;

        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            txtDonemAdi.AddItems(AnaForm.DonemId);

            Tablo = tablo;
            LblBilgi = lblBilgi;
            TglDurum = tglDurum;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            EventLoad();
        }


        void EventLoad()
        {
            BaseEventLoad();

            //buton event
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnSec.ItemClick += BtnSec_ItemClick;
            btnSil.ItemClick += BtnSil_ItemClick;
            btnDuzelt.ItemClick += BtnDuzelt_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnNakit.ItemClick += BtnNakit_ItemClick;
            btnBanka.ItemClick += BtnBanka_ItemClick;
            btnCek.ItemClick += BtnCek_ItemClick;
            btnOdemePlaniRaporu.ItemClick += BtnOdemePlaniRaporu_ItemClick;
            tablo.DoubleClick += Tablo_DoubleClick;
            btnRenklendirme.ItemClick += BtnRenklendirme_ItemClick;


        }

        private void BtnRenklendirme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tablo.FormatRules[0].Enabled)
                TabloRenkleri(false);
            else
                TabloRenkleri(true);
        }



        private void BtnOdemePlaniRaporu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!AnaForm.OgrenciTutarlariniGorme)
            {
                Messages.OgrenciTutarlariGormeyeYetkinizYokMesaji();
                return;
            }

            if (!OgrenciOdemePlaniF.OdemePlaniVarmi((long)tablo.GetFocusedRowCellValue("Id"), (long)txtDonemAdi.EditValue))
            {
                OgrenciL ogrL = new OgrenciL();
                ogrL = OgrenciF.Secim((long)tablo.GetFocusedRowCellValue("Id"));

                Messages.UyariMesaji(ogrL.AdiSoyadi + " " + ogrL.DonemAdi + " Ödeme Planı Bulunamadı");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            RaporForm frm = new RaporForm(1, (long)tablo.GetFocusedRowCellValue("Id"));
            if (!frm.Gorebilir) { Messages.YetkinizYokMesaji(); return; }
            frm.barButtonItem1.Visibility = BarItemVisibility.Never;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void BtnCek_ItemClick(object sender, ItemClickEventArgs e)
        {

            CekGirisEditForm fr = new CekGirisEditForm(true, (long)tablo.GetFocusedRowCellValue("Id"));
            if (!fr.Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            fr.ShowDialog();
            Listele(fr.kayitVar, tglDurum.IsOn, (long)tablo.GetFocusedRowCellValue("Id"), true);
            fr.Dispose();
        }

        private void BtnBanka_ItemClick(object sender, ItemClickEventArgs e)
        {
            BankaEditForm fr = new BankaEditForm(AnaForm.GenAyr.BankaHesapId, true, (long)tablo.GetFocusedRowCellValue("Id"));
            if (!fr.Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            fr.ShowDialog();
            Listele(fr.kayitVar, tglDurum.IsOn, (long)tablo.GetFocusedRowCellValue("Id"), true);
            fr.Dispose();
        }

        private void BtnNakit_ItemClick(object sender, ItemClickEventArgs e)
        {

            NakitEditForm fr = new NakitEditForm(true, (long)tablo.GetFocusedRowCellValue("Id"));
            if (!fr.Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            fr.ShowDialog();

            Listele(fr.kayitVar, tglDurum.IsOn, (long)tablo.GetFocusedRowCellValue("Id"), true);
            fr.Dispose();
        }



        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }



        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }

        void Listele(bool durum = true, bool aktifPasif = true, long seciliId = 0, bool scrool = false)
        {
            if (!durum) return;
            var aktifpasifkart = aktifPasif ? tglDurum.Properties.OnText : tglDurum.Properties.OffText;

            var a = tablo.TopRowIndex;
            tablo.ViewCaption = $"{txtDonemAdi.Text} {aktifpasifkart} Öğrenci Listesi";
            var liste = OgrenciF.Liste(aktifPasif, (long)txtDonemAdi.EditValue);
            tablo.GridControl.DataSource = liste;
            if (seciliId != 0) tablo.RowFocus("Id", seciliId);
            if (AnaForm.OgrenciTutarlariniGorme)
            {
                lblOdemesiTamamlananlar.Text = $"Tamamlanan({liste.Where(x => x.KalanBakiye <= 0 && x.TahakkukTutari > 0).Count() })";
                lblOdemesiTamamlanmayan.Text = $"Tamamlanmayan({liste.Where(x => x.TahsilatTutari > 0 && x.KalanBakiye > 0).Count()})";
                lblHicOdemeYapmayanlar.Text = $"Hiç Öd. Yapmayan({liste.Where(x => x.TahakkukTutari > 0 && x.TahsilatTutari <= 0).Count()})";
            }
            if (scrool)
                tablo.TopRowIndex = a;

        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0 || tablo.FocusedRowHandle < -1) return;

            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            OgrenciEditForm fr = new OgrenciEditForm((long)txtDonemAdi.EditValue);
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn, SeciliId, true);
            fr.Dispose();
        }
        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;

            OgrenciId = (long)tablo.GetFocusedRowCellValue("Id");
            ogrenciAdi = tablo.GetFocusedRowCellValue("AdiSoyadi").ToString();
            Aciklama = tablo.GetFocusedRowCellValue("AdiSoyadi").ToString() + " (TC:" + tablo.GetFocusedRowCellValue("TcKimlikNo").ToString() + ") " + tablo.GetFocusedRowCellValue("DonemAdi").ToString() + " Tutar İadesi";

            this.Close();
        }




        private void BtnDuzelt_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitGuncelleme();
        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            if (SecimFormuOlarakAcilma)
                SeciliKayitSecme();
            else
                SeciliKayitGuncelleme();

        }

        private void BtnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;

            try
            {
                if (OgrenciOdemePlaniF.OdemeListesiVarmi((long)tablo.GetFocusedRowCellValue("Id")))
                {
                    Messages.UyariMesaji("Bu Öğrenciye ait ödemesi yapılan Taksitler olduğu için kayıt silinemez");
                    return;
                }

                if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
                if (OgrenciOdemePlaniF.OdemePlaniVarmi((long)tablo.GetFocusedRowCellValue("Id"), (long)txtDonemAdi.EditValue))
                    OgrenciOdemePlaniF.OdemePlaniSil((List<OgrenciOdemePlaniL>)OgrenciOdemePlaniF.OdemePlani((long)tablo.GetFocusedRowCellValue("Id"), (long)txtDonemAdi.EditValue), (List<OgrenciOdemePlaniL>)OgrenciOdemePlaniF.OdemePlani((long)tablo.GetFocusedRowCellValue("Id"), (long)txtDonemAdi.EditValue));
                Listele(OgrenciF.Sil((long)tablo.GetFocusedRowCellValue("Id")), tglDurum.IsOn, 0, true);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }

            if (AnaForm.DonemId == 0)
            {
                Messages.HataMesaji("Dönem tanımlanmadığı için Yeni kayıt yapılamaz");
                return;
            }

            SeciliId = 0;
            OgrenciEditForm fr = new OgrenciEditForm((long)txtDonemAdi.EditValue);
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn, fr.Id);
            fr.Dispose();

        }

        private void TglDurum_Toggled(object sender, EventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }




        private void txtDonemAdi_EditValueChanged(object sender, EventArgs e)
        {

            if (!_devam) return;
            if (AnaForm.DonemId != (long)txtDonemAdi.EditValue)
                txtDonemAdi.ForeColor = Color.Red;
            else
                txtDonemAdi.ForeColor = clr;
            Listele();
        }


    }
}
