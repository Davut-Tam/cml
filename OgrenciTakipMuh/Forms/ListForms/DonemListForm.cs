using System;
using OgrenciTakipMuh.Forms.MenuForms;
using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class DonemListForm : BaseListForm
    {
        public static long SeciliId;
        public string SeciliDonemAdi;
        public long donemId;
        public long _kayitdisiDonemId;
        public DonemListForm(bool SecimolarakAcilma=false, long kayitdisiDonemId=0)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = SecimolarakAcilma;
            _kayitdisiDonemId = kayitdisiDonemId;
            Yukle();

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = tablo.GridControl;
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
            if (_kayitdisiDonemId == 0)
                tablo.GridControl.DataSource = DonemF.Liste();
            else
                tablo.GridControl.DataSource = DonemF.Liste(_kayitdisiDonemId);

        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            DonemEditForm fr = new DonemEditForm();

            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
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

        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliId = donemId = (long)tablo.GetFocusedRowCellValue("Id");
            SeciliDonemAdi = tablo.GetFocusedRowCellValue("DonemAdi").ToString();
            Close();
        }
        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                Listele(DonemF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
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
            DonemEditForm fr = new DonemEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

        }
    }
}