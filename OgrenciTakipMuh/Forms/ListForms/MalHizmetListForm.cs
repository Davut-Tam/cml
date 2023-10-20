using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class MalHizmetListForm : BaseListForm
    {
        public static long SeciliId;
        public string MalHizmetAdi;
        public long MalHizmetId;

        public MalHizmetListForm()
        {
            InitializeComponent();
            Yukle();

        }

        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            controlNavigator.NavigatableControl = tablo.GridControl;
            LblBilgi = lblBilgi;
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

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SeciliId = 0;
            MalHizmetEditForm fr = new MalHizmetEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

        }
        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = MalHizmetF.Liste();
        }

        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            MalHizmetEditForm fr = new MalHizmetEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }

        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            MalHizmetAdi = tablo.GetFocusedRowCellValue("MalHizmetAdi").ToString();
            MalHizmetId = (long)tablo.GetFocusedRowCellValue("Id");
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
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(MalHizmetF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }
    }
}
