using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class FirmaCariHareketListForm : BaseListForm
    {
        private long _firmaId;
        public FirmaCariHareketListForm(long firmaId)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            _firmaId = firmaId;
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = tablo.GridControl;
            EventLoad();
            tablo.GridControl.DataSource = FirmaCariHareketF.Liste(_firmaId);
            tablo.ViewCaption = FirmaF.Secim(firmaId).FirmaAdi + " Cari Hareket Listesi";

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;

        }

        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(false);
            btnYeni.Visibility = btnSil.Visibility = btnDuzelt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }


        void EventLoad()
        {
            BaseEventLoad();
            tablo.DoubleClick += Tablo_DoubleClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;

        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { tablo.GridControl.DataSource = FirmaCariHareketF.Liste(Convert.ToInt64(_firmaId)); } catch (Exception) { }
        }



        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            if (tablo.DataRowCount <= 0) return;
            if (tablo.GetFocusedRowCellValue("IslemTuru").ToString() == "Alış")
            {
                if (AnaForm.KullaniciTuru == "Kullanıcı")
                    if (RolF.Kontroller(12).Gorebilir != 1) { Messages.YetkinizYokMesaji(); return; }

                FaturaListForm.SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
                FaturaEditForm fr = new FaturaEditForm("Alış", true) { Text = "Satış Faturası" };
                fr.ShowDialog();
                fr.Dispose();


            }
            else if (tablo.GetFocusedRowCellValue("IslemTuru").ToString() == "Satış")
            {
                if (AnaForm.KullaniciTuru == "Kullanıcı")
                    if (RolF.Kontroller(13).Gorebilir != 1) { Messages.YetkinizYokMesaji(); return; }

                FaturaListForm.SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
                FaturaEditForm fr = new FaturaEditForm("Satış", true) { Text = "Alış Faturası" };
                fr.ShowDialog();
                fr.Dispose();
            }


        }

  
    }
}
