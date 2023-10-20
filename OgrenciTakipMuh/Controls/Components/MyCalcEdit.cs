using DevExpress.XtraEditors;
using System.Drawing;
using System.ComponentModel;
using DevExpress.Utils;

namespace OgrenciTakipMuh.Controls.Components
{

    public class MyCalcEdit : CalcEdit
    {
        [ToolboxItem(true)]
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.DisplayFormat.FormatType = FormatType.Numeric;
            Properties.DisplayFormat.FormatString = "n2";
            Properties.EditMask = "n2";
        }
        public override bool EnterMoveNextControl { get; set; } = true;

    }
}