using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Forms.RaporForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class NakitListForm : BaseListForm
    {

        public static long SeciliId;
        NakitGirisCikis GirisCikisTutari = new NakitGirisCikis();

        public NakitListForm()
        {
            InitializeComponent();
            Yukle();
            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            controlNavigator.NavigatableControl = Tablo.GridControl;
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

       

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;


            tablo.GridControl.DataSource = NakitF.Liste();
            txtGenelBakiye.Text = NakitF.GenelBakiye().ToString("n2");

            //Günlük
            GirisCikisTutari = NakitF.TarihArasiBakiye(DateTime.Now, DateTime.Now);
            txtGunlukGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtGunlukCikis.Text = GirisCikisTutari.Cikis.ToString("n2");
            // Aylık
            GirisCikisTutari = NakitF.TarihArasiBakiye(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1));
            txtAylikGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtAylikCikis.Text = GirisCikisTutari.Cikis.ToString("n2");

        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Bankadan Aktarılan" || tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Çek / Senet Nakite Çevirme")
            {
                Messages.UyariMesaji("Bu İşlemi Ancak Gelen Hesabın hareketlerinden Güncelleyebilirsiniz");
                return;

            }
            
            if (tablo.DataRowCount <= 0) return;
            SeciliId  = (long)tablo.GetFocusedRowCellValue("Id");
            NakitEditForm fr = new NakitEditForm();

            fr.ShowDialog();
            Listele(fr.kayitVar);
            tablo.RowFocus("Id",SeciliId);
            fr.Dispose();
        }


        private void BtnDuzelt_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitGuncelleme();
        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {

            SeciliKayitGuncelleme();
        }

        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Bankadan Aktarılan"|| tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Çek / Senet Nakite Çevirme")
            {
                Messages.UyariMesaji("Bu İşlemi Ancak Gelen Hesabın hareketlerinden Silebilirsiniz.");
                return;

            }

            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;

            Listele(NakitF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SeciliId = 0;
            NakitEditForm fr = new NakitEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

        }

        private void TxtGenelBakiye_TextChanged(object sender, EventArgs e)
        {
            if (NakitF.GenelBakiye() <= 0)
                txtGenelBakiye.ForeColor = Color.Red;
            else
                txtGenelBakiye.ForeColor = Color.Green;
        }

        private void RepositoryMakbuz_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MakbuzForm fr = new MakbuzForm(1, (long)tablo.GetFocusedRowCellValue("Id"));
            fr.ShowDialog();
            fr.Dispose();
        }
    }
}
