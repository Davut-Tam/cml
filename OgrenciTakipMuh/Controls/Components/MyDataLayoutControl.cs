using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.Windows.Forms;
using System.ComponentModel;
using OgrenciTakipMuh.Forms.GenelForms;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false;// tab kontrolu etkisiz hake getirme
        }
        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(AnaForm.OtoKapanma)// otomatik kapanma açma
                AnaForm.OtoKapanmaZamani = AnaForm.OtoKapanmaSuresi;
        }
    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor// Yeni bir layout tasarım clası oluşturma
    {
        public MyLayoutControlImplementor(ILayoutControlOwner owner) : base(owner)
        {
        }
        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)// control etiketini güncelleme
        {
            var item = base.CreateLayoutItem(parent);
            //item.AppearanceItemCaption.ForeColor = Color.Maroon;
            return item;
        }
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            var grp = base.CreateLayoutGroup(parent);
            grp.LayoutMode = LayoutMode.Table;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;
            grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

            grp.OptionsTableLayoutGroup.RowDefinitions.Clear();

            for (int i = 0; i < 9; i++)
            {
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Absolute,
                    Height = 24

                });
                if (i + 1 != 9) continue;
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Percent,
                    Height = 100

                });

            }

            return grp;
        }
    }
}
