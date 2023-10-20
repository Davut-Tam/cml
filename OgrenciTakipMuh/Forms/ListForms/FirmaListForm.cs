using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class FirmaListForm : BaseListForm
    {
        public static long SeciliId;
        public long FirmaId;// seçim formu
        public string FirmaAdi;// seçim formu
        public string Aciklama;// seçim formu
        

        public FirmaListForm(bool secimFormuOlarakAcilma = false)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            Yukle();

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;

        }

        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(secimFormuolarakAcilma);
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            TglDurum = tglDurum;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            EventLoad();
            tablo.OptionsFind.AlwaysVisible = SecimFormuOlarakAcilma;
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
            tablo.DoubleClick += Tablo_DoubleClick;
            tglDurum.Toggled += TglDurum_Toggled1;


        }



        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

  

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }

        void Listele(bool durum = true, bool aktifPasif = true)
        {
            if (!durum) return;
  

            tablo.GridControl.DataSource = FirmaF.Liste(aktifPasif);
            
            tablo.Focus();
        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            FirmaEditForm fr = new FirmaEditForm();
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }
        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            FirmaId = (long)tablo.GetFocusedRowCellValue("Id");
            FirmaAdi = tablo.GetFocusedRowCellValue("FirmaAdi").ToString();
            Aciklama = tablo.GetFocusedRowCellValue("FirmaAdi").ToString() + " (Vergi No:" + tablo.GetFocusedRowCellValue("VergiTcKimlikNo").ToString() + ") ";
            this.Close();
        }




        private void BtnDuzelt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                Listele(FirmaF.Sil((long)tablo.GetFocusedRowCellValue("Id")), tglDurum.IsOn);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SeciliId = 0;
            FirmaEditForm fr = new FirmaEditForm();
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn);
            fr.Dispose();

        }

        private void TglDurum_Toggled1(object sender, EventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }
    }
}
