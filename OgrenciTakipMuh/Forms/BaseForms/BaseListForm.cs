
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using OgrenciTakipMuh.Data.Facade;
using System;
using OgrenciTakipMuh.Controls.Components;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.ListForms;

namespace OgrenciTakipMuh.Forms.MenuForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected internal GridView Tablo;
        protected internal LabelControl LblBilgi;
        protected internal MyToogleSwitch TglDurum;
        protected ControlNavigator Navigator;
        protected internal bool SecimFormuOlarakAcilma;
        private bool _formSablonKayitEdilecek;
        protected internal long[] Secilenler;
        AnaForm Afrm;


        public bool Gorebilir, Ekleyebilir, Guncelleyebilir, Silebilir;

        public BaseListForm()
        {
            InitializeComponent();
            FormClosing += BaseListForm_FormClosing;
            SizeChanged += BaseListForm_SizeChanged;
            LocationChanged += BaseListForm_LocationChanged;

        }

        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }

        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {

            _formSablonKayitEdilecek = true;
        }

        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!IsMdiChild && _formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
        
        }

        public virtual void YetkiKontrol(object tag)
        {
            if (KullaniciF.Secim(AnaForm.KullanicilId).KullaniciTuru == "Yönetici")
            {
                Gorebilir = true;
                Ekleyebilir = true;
                Guncelleyebilir = true;
                Silebilir = true;
            }
            else
            {
                RolDetay kont = RolF.Kontroller(tag);
                if (kont == null) return;
                Gorebilir = kont.Gorebilir == 1;
                Ekleyebilir = kont.Ekleyebilir == 1;
                Guncelleyebilir = kont.Guncelleyebilir == 1;
                Silebilir = kont.Silebilir == 1;
            }
  
        }
        private void BaseListForm_Load(object sender, System.EventArgs e)
        {
            Name.FormSablonYukle(this);
            ButonGizle(SecimFormuOlarakAcilma);
            btnYenile.PerformClick();
        }

        public virtual void ButonGizle(bool secimFormuolarakAcilma)
        {
            if (secimFormuolarakAcilma)
            {
                btnSec.Visibility = BarItemVisibility.Always;
                btnAktar.Visibility = btnKolonlar.Visibility = btnAltToplamlar.Visibility = btnYazdir.Visibility = btnTahakkuk.Visibility = BarItemVisibility.Never;
                Tablo.OptionsFind.AlwaysVisible = true;
                bar3.Visible = secimFormuolarakAcilma;
                try { TglDurum.Visible = false; } catch (Exception) { }

            }

            else
                btnSec.Visibility = BarItemVisibility.Never;

        }

        public void BaseEventLoad()
        {
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.FocusedRowChanged += Tablo_FocusedRowChanged;

        }

        public virtual void Tablo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LblBilgi.Text = $"● Kayıt: ({KullaniciF.Secim((long)Tablo.GetFocusedRowCellValue("KullaniciId")).AdiSoyadi})        ● Tarih: ({Tablo.GetFocusedRowCellValue("IslemTarihi")})       ";
            }
            catch (Exception)
            {
                try { LblBilgi.Text = ""; } catch (Exception) { }
            }
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.ShowPopupMenu(popupMenu);
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnKolonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Tablo.CustomizationForm == null)
                Tablo.ShowCustomization();
            else
                Tablo.HideCustomization();
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tablo.TabloDisariAktar("Excel", e.Item.Caption, Text);
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tablo.TabloDisariAktar("Word", e.Item.Caption, Text);
        }

        private void btnPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tablo.TabloDisariAktar("Pdf", e.Item.Caption, Text);
        }

        private void BaseListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Dispose();

        }

        private void btnAltToplamlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Tablo.OptionsView.ShowFooter)
            {
                Tablo.OptionsView.ShowFooter = Tablo.OptionsPrint.PrintFooter = false;
            }

            else
            {
                Tablo.OptionsView.ShowFooter = Tablo.OptionsPrint.PrintFooter = true;
            }

        }



        private void btnHesaplar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Afrm = Application.OpenForms["AnaForm"] as AnaForm;
            Afrm.FormAc(new BankaHesapListForm(false));
        }

        private void btnTxt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tablo.TabloDisariAktar("Txt", e.Item.Caption, Text);
        }

        private void btnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdırEditForm fr = new YazdırEditForm(Tablo, AnaForm.DonemAdi);
            fr.ShowDialog();
            fr.Dispose();
        }
    }
}

