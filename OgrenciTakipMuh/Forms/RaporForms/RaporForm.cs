using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Raporlar;
using System.Windows.Forms;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh.Forms.RaporForms
{

    public partial class RaporForm : BaseEditForm
    {
        private byte _raporTuru;
        public RaporForm(byte raporTuru, long Id)
        {
            InitializeComponent();
            _raporTuru = raporTuru;
            YetkiKontrol(Tag);

            switch (raporTuru)
            {
                case 1:
                    OgrenciOdemePlani(Id);
                    break;
            }

        }

        void OgrenciOdemePlani(long OgrenciId)
        {
            RprOgrenciOdemePlani Rapor = new RprOgrenciOdemePlani(OgrenciId);
            documentViewer1.DocumentSource = Rapor;
            Rapor.CreateDocument();
        }

        long donemid;
        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = GenelFunctions.SecilenOgrenciId();
           
            if (id!=0) donemid = OgrenciF.Secim(id).DonemId;
            switch (_raporTuru)
            {
                case 1:


                    if (id != 0)
                    {
                        if (!OgrenciOdemePlaniF.OdemePlaniVarmi(id,donemid))
                        {
                            OgrenciL ogrL = new OgrenciL();
                            ogrL = OgrenciF.Secim(id);
                            Messages.UyariMesaji(ogrL.AdiSoyadi + " " + ogrL.DonemAdi + " Ödeme Planı Bulunamadı");
                            return;
                        }
                        OgrenciOdemePlani(id);
                    }

                    break;


            }
        }

        private void BtnKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void RaporForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}