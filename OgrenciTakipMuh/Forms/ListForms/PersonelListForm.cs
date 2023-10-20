using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class PersonelListForm : BaseListForm
    {
        public static long SeciliId;
        public long personelId;// seçim formu
        public string PersonelAdi;// seçim formu
        public string Aciklama;// seçim formu

        public PersonelListForm(bool secimFormuOlarakAcilma = false)
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
            btnTahakkuk.Visibility = BarItemVisibility.Always;
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
            btnTahakkuk.ItemClick += BtnTahakkuk_ItemClick;
            tablo.DoubleClick += Tablo_DoubleClick;
            tglDurum.Toggled += TglDurum_Toggled1;

        }

        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

        private void BtnTahakkuk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (tablo.DataRowCount <= 0) return;


            if (AnaForm.KullaniciTuru == "Kullanıcı")
                if (RolF.Kontroller(20).Gorebilir != 1) { Messages.YetkinizYokMesaji(); return; }

            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            PersonelTahakkukEditForm fr = new PersonelTahakkukEditForm(SeciliId);
            if (AnaForm.KullaniciTuru == "Kullanici")
            {
                if (!fr.Gorebilir) { Messages.YetkinizYokMesaji(); return; }
            }
            else
            {
                fr.ShowDialog();
                fr.Dispose();
                Listele(fr.KayitVar, tglDurum.IsOn, SeciliId);
                tablo.RowFocus("Id", SeciliId);
            }





        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }

        void Listele(bool durum = true, bool aktifPasif = true, long seciliId = 0)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = PersonelF.Liste(aktifPasif);
            if (seciliId != 0) tablo.RowFocus("Id", seciliId);
        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            PersonelEditForm fr = new PersonelEditForm();
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn,SeciliId);
            fr.Dispose();
  
        }
        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0) return;
            personelId = (long)tablo.GetFocusedRowCellValue("Id");
            PersonelAdi = tablo.GetFocusedRowCellValue("AdiSoyadi").ToString();
            Aciklama = tablo.GetFocusedRowCellValue("AdiSoyadi").ToString() + " (TC:" + tablo.GetFocusedRowCellValue("TcKimlikNo").ToString() + ")  Maaş Ödemesi";

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
                Listele(PersonelF.Sil((long)tablo.GetFocusedRowCellValue("Id")), tglDurum.IsOn);
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
            PersonelEditForm fr = new PersonelEditForm();
            fr.ShowDialog();
            Listele(fr.KayitVar, tglDurum.IsOn,fr.Id);
            fr.Dispose();

        }

        private void TglDurum_Toggled1(object sender, EventArgs e)
        {
            Listele(true, tglDurum.IsOn);
        }

    }
}