using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    class MySimpleButton:SimpleButton
    {
        public MySimpleButton()
        {
            Appearance.Font = new Font("Tahoma", 9);
            
        }
    }
}
