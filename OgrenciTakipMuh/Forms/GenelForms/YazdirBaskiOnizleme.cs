using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;
using OgrenciTakipMuh.Forms.BaseForms;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class YazdirBaskiOnizleme : BaseEditForm
    {
        public YazdirBaskiOnizleme(PrintingSystem ps,string baslik)
        {
            InitializeComponent();
            raporGosterici.PrintingSystem = ps;
            Text = $"{Text} ( {baslik} )";

        }

        private void YazdirBaskiOnizleme_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}