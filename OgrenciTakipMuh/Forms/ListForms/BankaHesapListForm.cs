using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class BankaHesapListForm : BaseListForm
    {
    
        public string SeciliHesap;
        public long SeciliHesapId;
     


        public static long SeciliId;

        public BankaHesapListForm(bool secimFormuOlarakAcilma)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            Yukle();

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            TglDurum = tglDurum;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            EventLoad();
            Listele();
        }


        void EventLoad()
        {
            BaseEventLoad();
            //buton event
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnSil.ItemClick += BtnSil_ItemClick;
            btnDuzelt.ItemClick += BtnDuzelt_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnSec.ItemClick += BtnSec_ItemClick;
            tablo.DoubleClick += Tablo_DoubleClick;
        }

        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
            Close();
        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = BankaHesapF.Liste(tglDurum.IsOn);
        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            BankaHesapEditForm fr = new BankaHesapEditForm();

            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
        }

        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliHesapId = (long)tablo.GetFocusedRowCellValue("Id");
            SeciliHesap = tablo.GetFocusedRowCellValue("BankaAdi").ToString() + " " + tablo.GetFocusedRowCellValue("SubeAdi").ToString() + " / " + tablo.GetFocusedRowCellValue("IbanNo").ToString();
            Close();
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

        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                Listele(BankaHesapF.Sil((long)tablo.GetFocusedRowCellValue("Id")));

            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SeciliId = 0;
            BankaHesapEditForm fr = new BankaHesapEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

        }

        private void TglDurum_Toggled(object sender, EventArgs e)
        {
            Listele(true);
        }
    }
}
