using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit
    {

        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;// Yazı yazılmayı engelleme
        }
        public override bool EnterMoveNextControl { get; set; } = true;

    }
}
