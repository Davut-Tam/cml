using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class KullaniciListForm : BaseListForm
    {
        public static long SeciliId;
        public static string GorevAdi;

        public KullaniciListForm()
        {
            InitializeComponent();
            Yukle();

        }

        void Yukle()
        {
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

            tablo.DoubleClick += Tablo_DoubleClick;
        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SeciliId = 0;
            KullaniciEditForm fr = new KullaniciEditForm(0);
            fr.ShowDialog();
            Listele(fr.KayitVar);
            fr.Dispose();

        }


        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = KullaniciF.Liste();
        }

        void SeciliKayitGuncelleme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            KullaniciEditForm fr = new KullaniciEditForm(SeciliId);
            fr.ShowDialog();
            Listele(fr.KayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }

        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            GorevAdi = tablo.GetFocusedRowCellValue("GorevAdi").ToString();
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

            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(KullaniciF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
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
