using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class GrupListForm : BaseListForm
    {
        public long SeciliId;
        public string GrupAdi;
        public bool _aktifPasif = true;
        private bool _devam;
        private long _donemId;
        Color clr = new Color();
        public GrupListForm(bool secimFormuOlarakAcilma = false,long donemId=0)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;

            _donemId = donemId;
            if (_donemId == 0) _donemId = AnaForm.DonemId;
            Yukle();
            clr = txtDonemAdi.ForeColor;
            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
            _devam = true;
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            txtDonemAdi.AddItems(_donemId);
            txtDonemAdi.Enabled = !SecimFormuOlarakAcilma;
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = tablo.GridControl;
            EventLoad();
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
        }

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true, bool aktifPasif = true)
        {
            if (!durum) return;
            tablo.ViewCaption = txtDonemAdi.Text + " Grupları";
            tablo.GridControl.DataSource = GrupF.Liste((long)txtDonemAdi.EditValue);
        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            GrupEditForm fr = new GrupEditForm(SeciliId,(long)txtDonemAdi.EditValue);

            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();
        }


        private void BtnDuzelt_ItemClick(object sender,ItemClickEventArgs e)
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

        private void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0 || tablo.FocusedRowHandle < 0) return;

            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            GrupAdi = tablo.GetFocusedRowCellValue("GrupAdi").ToString();
            this.Close();
        }

        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(GrupF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }
        
        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (AnaForm.DonemId == 0)
            {
                Messages.HataMesaji("Dönem tanımlanmadığı için Yeni kayıt yapılamaz");
                return;
            }
            SeciliId = 0;
            GrupEditForm fr = new GrupEditForm(0,(long)txtDonemAdi.EditValue);
            fr.ShowDialog();
            Listele(fr.kayitVar, _aktifPasif);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);

        }


        private void txtDonemAdi_EditValueChanged(object sender, EventArgs e)
        {
            if (!_devam) return;
            if (AnaForm.DonemId != (long)txtDonemAdi.EditValue)
                txtDonemAdi.ForeColor = Color.Red;
            else
                txtDonemAdi.ForeColor = clr;
            Listele();
        }
    }
}
