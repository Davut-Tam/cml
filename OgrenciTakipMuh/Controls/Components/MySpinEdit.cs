using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;


namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MySpinEdit : SpinEdit
    {
        public MySpinEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "d";
        }
        public override bool EnterMoveNextControl { get; set; } = true;

    }
}
