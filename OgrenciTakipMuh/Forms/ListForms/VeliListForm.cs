using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;

namespace OgrenciTakipMuh.Forms.MenuForms
{
    public partial class VeliListForm : BaseListForm
    {
        
        public long SeciliId;
        Color clr = new Color();
        public bool _devam;

        public VeliListForm(bool secimFormuOlarakAcilma = false)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            Yukle();
            clr = txtDonemAdi.ForeColor;
            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
            _devam = true;
        }
    
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            TglDurum = tglDurum;
            controlNavigator.NavigatableControl = tablo.GridControl;
            txtDonemAdi.AddItems(AnaForm.DonemId);
            EventLoad();


        }
        void EventLoad()
        {
            BaseEventLoad();
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnSil.ItemClick += BtnSil_ItemClick;
            btnDuzelt.ItemClick += BtnDuzelt_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnSec.ItemClick += BtnSec_ItemClick;
            txtDonemAdi.EditValueChanged += TxtDonemAdi_EditValueChanged;


            tablo.DoubleClick += Tablo_DoubleClick;
            tglDurum.Toggled += TglDurum_Toggled;
        }

        private void TxtDonemAdi_EditValueChanged(object sender, EventArgs e)
        {

            if (!_devam) return;
            if (AnaForm.DonemId != (long)txtDonemAdi.EditValue)
                txtDonemAdi.ForeColor = Color.Red;
            else
                txtDonemAdi.ForeColor = clr;
            Listele();
        }

        private void TglDurum_Toggled(object sender, EventArgs e)
        {
            Listele(true);
        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (AnaForm.DonemId == 0)
            {
                Messages.HataMesaji("Dönem tanımlanmadığı için Yeni kayıt yapılamaz");
                return;
            }
            VeliEditForm fr = new VeliEditForm(0);
            fr.ShowDialog();
            Listele(fr.kayitVar,fr.Id);
            fr.Dispose();

        }
        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

        void Listele(bool durum = true,long seciliId=0)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = VeliF.Liste(tglDurum.IsOn,Convert.ToInt64(txtDonemAdi.EditValue));
            if (seciliId != 0) tablo.RowFocus("Id", seciliId);
          
 
        }

        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            VeliEditForm fr = new VeliEditForm(SeciliId);
            fr.ShowDialog();
            Listele(fr.kayitVar, SeciliId);
            fr.Dispose();
        }

        void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0|| tablo.FocusedRowHandle<0) return;

            SeciliId =(long)tablo.GetFocusedRowCellValue("Id");
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
                Listele(VeliF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
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
