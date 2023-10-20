using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Raporlar;


namespace OgrenciTakipMuh.Forms.RaporForms
{
    public partial class MakbuzForm : BaseEditForm
    {
        public MakbuzForm(byte kanal, long IslemId,bool giris=true)
        {
            InitializeComponent();
            if (kanal == 1 || kanal == 2)
            {
                RptMakbuz rpt = new RptMakbuz(kanal, IslemId);
                documentViewer1.DocumentSource = rpt;
                rpt.CreateDocument();
            }
            else
            {
                RptMakbuzCek rpt = new RptMakbuzCek(giris,IslemId);
                documentViewer1.DocumentSource = rpt;
                rpt.CreateDocument();
            }

            bbiZoom.EditValue = 75;
        }
    }
}
