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

    public partial class SinifListForm : BaseListForm
    {
        public long SeciliId;
        public string SecilenSinifAdi;
        public bool _aktifPasif = true;
        private bool _devam;
        private long _donemId;
        private long _grupId;
        Color clr = new Color();

        public SinifListForm(bool secimFormuOlarakAcilma = false, long donemId = 0, long grupId = 0)
        {
            InitializeComponent();
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            _donemId = donemId;
            _grupId = grupId;

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

        private void SeciliKayitSecme()
        {
            if (tablo.DataRowCount <= 0 || tablo.FocusedRowHandle < 0) return;

            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            SecilenSinifAdi = tablo.GetFocusedRowCellValue("SinifAdi").ToString();
            this.Close();
        }

        private void BtnYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.ViewCaption = txtDonemAdi.Text + " Sınıfları";
            if(SecimFormuOlarakAcilma)
                tablo.GridControl.DataSource = SinifF.Liste((long)txtDonemAdi.EditValue, _grupId);

            else
                tablo.GridControl.DataSource = SinifF.Liste((long)txtDonemAdi.EditValue);

        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            SinifEditForm fr = new SinifEditForm(SeciliId, (long)txtDonemAdi.EditValue);

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


            if (SecimFormuOlarakAcilma)
                SeciliKayitSecme();
            else
                SeciliKayitGuncelleme();
        }

        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(SinifF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
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
            SinifEditForm fr = new SinifEditForm(0, (long)txtDonemAdi.EditValue);
            fr.ShowDialog();
            Listele(fr.kayitVar);
            fr.Dispose();

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
