using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Forms.RaporForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class CekListForm : BaseListForm
    {

   
        public static long SeciliId;
        CekGirisCikis GirisCikisTutari = new CekGirisCikis();


        public CekListForm()
        {
            InitializeComponent();
            btnCekCikis.Visibility = BarItemVisibility.Always;
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
            BaseEventLoad();
            //buton event
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnSil.ItemClick += BtnSil_ItemClick;
            btnDuzelt.ItemClick += BtnDuzelt_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnCekCikis.ItemClick += BtnCekCikis_ItemClick;
            tablo.DoubleClick += Tablo_DoubleClick;


            Listele(true);
        }

        public override void Tablo_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            try
            {
                if (tglDurum.IsOn)
                    LblBilgi.Text = $"● Giriş Kayıt: ({KullaniciF.Secim((long)Tablo.GetFocusedRowCellValue("GirisKullaniciId")).AdiSoyadi})        ● Giriş İşlem Tarihi: ({Tablo.GetFocusedRowCellValue("GirisIslemTarihi")})       ";
                else
                    LblBilgi.Text = $"● Çıkış Kayıt: ({KullaniciF.Secim((long)Tablo.GetFocusedRowCellValue("CikisKullaniciId")).AdiSoyadi})        ● Çıkış İşlem Tarihi: ({Tablo.GetFocusedRowCellValue("CikisIslemTarihi")})       ";
            }
            catch (Exception)
            {
                try { LblBilgi.Text = ""; } catch (Exception) { }
            }
        }

        private void BtnCekCikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            CekCikisEditForm fr = new CekCikisEditForm();

            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = CekF.Liste(!tglDurum.IsOn);
            btnCekCikis.Enabled = tablo.RowCount > 0;
            bndCikisBilgileri.Visible = !tglDurum.IsOn;
            if (tglDurum.IsOn)
                tablo.ViewCaption = "Bekleyen Evrak Listesi";
            else
                tablo.ViewCaption = "Çıkışı Yapılan Evrak Listesi";


            txtGenelBakiye.Text = CekF.GenelBakiye().ToString("n2");

            //Günlük
            GirisCikisTutari = CekF.TarihArasiBakiye(DateTime.Now, DateTime.Now);
            txtGunlukGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtGunlukCikis.Text = GirisCikisTutari.Cikis.ToString("n2");
            // Aylık
            GirisCikisTutari = CekF.TarihArasiBakiye(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1));
            txtAylikGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtAylikCikis.Text = GirisCikisTutari.Cikis.ToString("n2");



        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            CekGirisEditForm fr = new CekGirisEditForm();

            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
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
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(CekF.Sil((long)tablo.GetFocusedRowCellValue("Id")));

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
            CekGirisEditForm fr = new CekGirisEditForm();
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

        }

        private void TglDurum_Toggled(object sender, EventArgs e)
        {
            Listele(true);
            Tablo_FocusedRowChanged(null, null);
        }

        private void RepositoryGiris_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MakbuzForm fr = new MakbuzForm(3, (long)tablo.GetFocusedRowCellValue("Id"));
            fr.ShowDialog();
            fr.Dispose();
        }

        private void RepositoryCikis_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MakbuzForm fr = new MakbuzForm(3, (long)tablo.GetFocusedRowCellValue("Id"),false);
            fr.ShowDialog();
            fr.Dispose();
        }
    }
}
