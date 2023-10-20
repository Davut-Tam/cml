
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using OgrenciTakipMuh.Forms.GenelForms;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyBandedGridControl : GridControl
    {

        protected override BaseView CreateDefaultView()
        {
            var view = (MyBandedGridView)CreateView("MyBandedGridView");

            //view.Appearance.BandPanel.ForeColor = Color.DarkBlue;
            view.Appearance.BandPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);
            view.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.BandPanelRowHeight = 40;

            //view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            //view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            view.OptionsMenu.EnableColumnMenu = false;//sağ tuşla açılan menuleri iptal etme
            view.OptionsMenu.EnableFooterMenu = false;//sağ tuşla açılan menuleri iptal etme
            view.OptionsMenu.EnableGroupPanelMenu = false;//sağ tuşla açılan menuleri iptal etme

            view.OptionsNavigation.EnterMoveNextColumn = true;// kolonlar arasında enter ile dolaşma açık

            view.OptionsPrint.AutoWidth = false; // Kolon genişliklerini olduğu gibi yazıcıya gönder
            view.OptionsPrint.PrintFooter = false;// Foolter(Kolon Alt Bilgi) yazıcıya gönderme
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;// üst başlık göster
            view.OptionsView.ShowAutoFilterRow = true;// filtre paneli
            view.OptionsView.ShowGroupPanel = false;// üst panel gizleme
            view.OptionsView.ColumnAutoWidth = false;// kolon genişliklerini sabitleme
            view.OptionsView.RowAutoHeight = true;// kolon yüksekliğini otomatik ayarlama yazıya göre
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;//filtre özel buton

            var columns = new[]
            {
              new BandedGridColumn
              {
                Caption = "Id",
                FieldName = "Id",
                OptionsColumn = { AllowEdit = false, ShowInCustomizationForm = false }
              }
          };



            view.Columns.AddRange(columns);
            return view;
        }

  
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyBandedGridInfoRegistrator());
        }

        protected override void OnMouseMove(MouseEventArgs ev)
        {
            base.OnMouseMove(ev);
            if (AnaForm.OtoKapanma)// otomatik kapanma açma
                AnaForm.OtoKapanmaZamani = AnaForm.OtoKapanmaSuresi;
        }
        private class MyBandedGridInfoRegistrator : BandedGridInfoRegistrator
        {
            public override string ViewName => "MyBandedGridView";

            public override BaseView CreateView(GridControl grid) => new MyBandedGridView(grid);

        }
    }



    public class MyBandedGridView : BandedGridView
    {

 
        public MyBandedGridView() { }
        public MyBandedGridView(GridControl ownerGrid) : base(ownerGrid) { }
        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);
            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;

            }
        }
        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(this);
        }
        private class MyGridColumnCollection : BandedGridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyBandedGridColumn();
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowFocus = false;
                return column;
            }
        }

    }




    public class MyBandedGridColumn : BandedGridColumn
    {

    }
}
