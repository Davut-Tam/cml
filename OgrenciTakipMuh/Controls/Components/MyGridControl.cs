
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraGrid.Registrator;
using System.Windows.Forms;
using OgrenciTakipMuh.Forms.GenelForms;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridView");

            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
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

            var idColumn = new MyGridColumn { Caption = "Id", FieldName = "Id" };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;// id gizleme
            view.Columns.Add(idColumn);



            return view;

        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }
        protected override void OnMouseMove(MouseEventArgs ev)
        {
            base.OnMouseMove(ev);
            if (AnaForm.OtoKapanma)// otomatik kapanma açma
                AnaForm.OtoKapanmaZamani = AnaForm.OtoKapanmaSuresi;
        }
        private class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView";
            public override BaseView CreateView(GridControl grid) => new MyGridView(grid);
        }
    }
    public class MyGridView : GridView
    {
        #region Properties


        #endregion
        public MyGridView() { }
        public MyGridView(GridControl ownerGrid) : base(ownerGrid) { }
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
        private class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowFocus = true;
                return column;
            }
        }
    }
    public class MyGridColumn : GridColumn
    {

    }
}