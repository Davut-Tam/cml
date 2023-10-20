using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors.Controls;


namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyPictureEdit : PictureEdit
    {
        public MyPictureEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.NullText = "Resim Yok";
            Properties.SizeMode = PictureSizeMode.Stretch;
            Properties.ShowMenu = false;
        }

    }
}