using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Forms.RaporForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class BankaListForm : BaseListForm
    {
        public  long HesapId;
        public static long SeciliId;
        BankaGirisCikis GirisCikisTutari = new BankaGirisCikis();
        private bool _devam;
        private string _seciliHesapAdi;

        public BankaListForm()
        {
            InitializeComponent();
            txtBankaHesaplari.AddItems();
            HesapId = AnaForm.GenAyr.BankaHesapId;
            _devam = true;
            if (AnaForm.GenAyr.BankaHesapId != 0)
            {
                var bankaHesap = BankaHesapF.Secim(AnaForm.GenAyr.BankaHesapId);
                txtBankaHesaplari.Text = _seciliHesapAdi = bankaHesap.HesapAdi;
            }
            Yukle();

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
            btnHesaplar.Visibility = BarItemVisibility.Always;
            txtBankaHesaplari_SelectedIndexChanged(null, null);
            
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

            tablo.GridControl.DataSource = BankaF.Liste(HesapId);
            txtGenelBakiye.Text = BankaF.GenelBakiye(HesapId).ToString("n2");

            //Günlük
            GirisCikisTutari = BankaF.TarihArasiBakiye(HesapId, DateTime.Now, DateTime.Now);
            txtGunlukGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtGunlukCikis.Text = GirisCikisTutari.Cikis.ToString("n2");
            // Aylık
            GirisCikisTutari = BankaF.TarihArasiBakiye(HesapId, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1));
            txtAylikGiris.Text = GirisCikisTutari.Giris.ToString("n2");
            txtAylikCikis.Text = GirisCikisTutari.Cikis.ToString("n2");

        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Hesaptan Virman" || tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Nakit Kasadan Aktarılan" || tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Çek / Senet Hesaba Aktarma")
            {
                Messages.UyariMesaji("Bu İşlemi Ancak Gelen Hesabın hareketlerinden Güncelleyebilirsiniz.");
                return;
            }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            BankaEditForm fr = new BankaEditForm(HesapId);
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
            Tablo.RowFocus("Id", SeciliId);
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
            if (tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Hesaptan Virman" || tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Nakit Kasadan Aktarılan" || tablo.GetFocusedRowCellValue("IslemAdi").ToString() == "Çek / Senet Hesaba Aktarma")

            {
                Messages.UyariMesaji("Bu İşlemi Ancak Gelen Hesabın hareketlerinden Silebilirsiniz.");
                return;
            }

            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(BankaF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
            }
            catch (Exception ex)
            {

                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (HesapId == 0)
            {
                Messages.HataMesaji("Hesap Seçiniz");
                return;
            }

            SeciliId = 0;
            BankaEditForm fr = new BankaEditForm(HesapId);
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();


        }

        private void TxtGenelBakiye_TextChanged(object sender, EventArgs e)
        {
            if (txtGenelBakiye.Text.ToDecimal() <= 0)
                txtGenelBakiye.ForeColor = Color.Red;
            else
                txtGenelBakiye.ForeColor = Color.Green;
        }

        private void RepositoryMakbuz_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MakbuzForm fr = new MakbuzForm(2, (long)tablo.GetFocusedRowCellValue("Id"));
            fr.ShowDialog();
            fr.Dispose();
        }

        private void txtBankaHesaplari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_devam) return;
            HesapId = Convert.ToInt64(txtBankaHesaplari.ItemsId());
            var bankaHesap = BankaHesapF.Secim(HesapId);
            tablo.ViewCaption = txtBankaHesaplari.Text + $" Hesap Hareket Listesi\n( {bankaHesap.BankaAdi} {bankaHesap.SubeAdi} {bankaHesap.IbanNo} )";
            _seciliHesapAdi = txtBankaHesaplari.Text;
            Listele();
            tablo.Focus();
        }

        private void BankaListForm_Activated(object sender, EventArgs e)
        {
            _devam = false;
            txtBankaHesaplari.AddItems();
            txtBankaHesaplari.Text = _seciliHesapAdi;
            _devam = true;
        }

        private void TxtBaslama_EditValueChanged(object sender, EventArgs e)
        {
            if (!_devam) return;
            Listele();
        }
    }
}
