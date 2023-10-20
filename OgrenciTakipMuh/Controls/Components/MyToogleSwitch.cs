using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.Utils;
using System.Drawing;


namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyToogleSwitch : ToggleSwitch
    {
        public MyToogleSwitch()
        {
            Name = "tglDurum";
            Properties.OffText = "Pasif";
            Properties.OnText = "Aktif";
            Properties.AutoHeight = false;
            Properties.AutoWidth = true;
            Properties.GlyphAlignment = HorzAlignment.Far;//Solunda
            //Properties.Appearance.ForeColor = Color.Maroon;
            IsOn = false;
           
        }
        public override bool EnterMoveNextControl { get; set; } = true;
       

    }
}