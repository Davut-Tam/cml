using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Enums;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Raporlar;
using OgrenciTakipMuh.Tools;
using System;

namespace OgrenciTakipMuh.Forms.RaporForms
{
    public partial class OgrenciRaporForm : BaseEditForm
    {
        private OgrenciRaporTuru _ogrenciRaporTuru;
        private long _donemId;
        private long _grupId;
        private long _sinifId;
        public OgrenciRaporForm(long donemId)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            _donemId = donemId;
            txtRaporTuru.Properties.Items.AddRange(EnumFunctions.GetEnumsDescriptionList<OgrenciRaporTuru>());
            txtRaporTuru.SelectedIndex = 0;
            txtGrupAdi.AddItems(true, dnmId: _donemId);
            txtSinifAdi.AddItems(true, grupId:_grupId);
            txtBaslamaTarihi.DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtBitisTarihi.DateTime= txtBaslamaTarihi.DateTime.AddMonths(1).AddDays(-1); ;
            OgrenciOdemeRaporlari();

        }

        void OgrenciOdemeRaporlari()
        {
            if (_ogrenciRaporTuru == OgrenciRaporTuru.HicOdemeYapmayanlar ||
                _ogrenciRaporTuru == OgrenciRaporTuru.OdemesiTamamlananlar ||
                _ogrenciRaporTuru == OgrenciRaporTuru.OdemesiTamamlanmayanlar ||
                _ogrenciRaporTuru == OgrenciRaporTuru.TahakkukYapilmayanlar)
            {

                RprOgrenciRaporlari rpt = new RprOgrenciRaporlari(_donemId, _grupId, _sinifId, _ogrenciRaporTuru);
                documentViewer1.DocumentSource = rpt;
                rpt.CreateDocument();
            }
            else if(_ogrenciRaporTuru == OgrenciRaporTuru.OdemeYapmayanlar)
            {
                RprOdemesiYapilmayanTaksitler rpt = new RprOdemesiYapilmayanTaksitler(_donemId, _grupId, _sinifId, _ogrenciRaporTuru, txtBaslamaTarihi.DateTime,txtBitisTarihi.DateTime);
                documentViewer1.DocumentSource = rpt;
                rpt.CreateDocument();
            }
            else if (_ogrenciRaporTuru == OgrenciRaporTuru.OdemeYapanlar)
            {
                RprOdemesiYapilanTaksitler rpt = new RprOdemesiYapilanTaksitler(_donemId, _grupId, _sinifId, _ogrenciRaporTuru, txtBaslamaTarihi.DateTime, txtBitisTarihi.DateTime);
                documentViewer1.DocumentSource = rpt;
                rpt.CreateDocument();
            }

        }

        private void mySimpleButton1_Click(object sender, EventArgs e)
        {

            OgrenciOdemeRaporlari();
        }

        private void txtGrupAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

            _grupId = txtGrupAdi.Text == "-Tüm Kayıtlar-" ? 0 : txtGrupAdi.ItemsId(_donemId);
            if (_grupId != 0)
                txtSinifAdi.AddItems(true,dnmId:_donemId,grupId:_grupId);
            else
                txtSinifAdi.AddItems(true);

        }

        private void txtSinifAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sinifId = txtSinifAdi.Text == "-Tüm Kayıtlar-" ? 0 : txtSinifAdi.ItemsId(_donemId);
        }

        private void txtRaporTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ogrenciRaporTuru = (OgrenciRaporTuru)txtRaporTuru.SelectedIndex;
            if (txtRaporTuru.SelectedIndex == 0 || txtRaporTuru.SelectedIndex == 1 || txtRaporTuru.SelectedIndex == 2)
                layoutBaslamaTarihi.Visibility = layoutBitisTarihi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            else
                layoutBaslamaTarihi.Visibility = layoutBitisTarihi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void btnKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ribbonControl1.Visible = !ribbonControl1.Visible;
        }

        private void txtBaslamaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            txtBitisTarihi.Properties.MinValue = txtBaslamaTarihi.DateTime;
        }

        private void txtBitisTarihi_EditValueChanged(object sender, EventArgs e)
        {
            txtBaslamaTarihi.Properties.MaxValue = txtBitisTarihi.DateTime;
        }
    }
}
