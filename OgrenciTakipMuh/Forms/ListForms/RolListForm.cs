using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class RolListForm : BaseListForm
    {
        public static long SeciliId;
        public long rolId;// seçim formu
        public string RolAdi;// seçim formu
        public string Aciklama;// seçim formu

        public RolListForm(bool secimFormuOlarakAcilma = false)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            Yukle();

        }

        //public override void ButonGizle(bool secimFormuolarakAcilma)
        //{
        //    base.ButonGizle(secimFormuolarakAcilma);
        //}
        void Yukle()
        {
            Tablo = tablo;
            LblBilgi = lblBilgi;
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
            btnTahakkuk.ItemClick += BtnTahakkuk_ItemClick;
            tablo.DoubleClick += Tablo_DoubleClick;
     

        }

        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

        private void BtnTahakkuk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");

            RolEditForm fr = new RolEditForm();
            fr.ShowDialog();
            fr.Dispose();
            Listele(fr.kayitVar);
            tablo.RowFocus("Id", SeciliId);

        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = RolF.Liste();
        }
        void SeciliKayitGuncelleme()
        {
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            RolEditForm fr = new RolEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }
        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            rolId = (long)tablo.GetFocusedRowCellValue("Id");
            RolAdi = tablo.GetFocusedRowCellValue("RolAdi").ToString();
            //Aciklama = tablo.GetFocusedRowCellValue("AdiSoyadi").ToString() + " (TC:" + tablo.GetFocusedRowCellValue("TcKimlikNo").ToString() + ")  Maaş Ödemesi";
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
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == System.Windows.Forms.DialogResult.No) return;
            try
            {
                Listele(RolF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SeciliId = 0;
            RolEditForm fr = new RolEditForm();
            fr.ShowDialog();
            //
            Listele(fr.kayitVar);
            fr.Dispose();

        }

    
    }
}
