namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class SmsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsListForm));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.altTablo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGsm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMesaj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UstGrid = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colsmsGuidText = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn6 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn7 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn8 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBitis = new OgrenciTakipMuh.Controls.Components.MyDateEdit();
            this.txtBaslama = new OgrenciTakipMuh.Controls.Components.MyDateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblSmsBakiye = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altTablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UstGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBitis.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBitis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslama.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAktar
            // 
            this.btnAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAktar.ImageOptions.Image")));
            this.btnAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAktar.ImageOptions.LargeImage")));
            this.btnAktar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAktar.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            this.btnTahsilat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTahsilat.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // altTablo
            // 
            this.altTablo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.altTablo.Appearance.HeaderPanel.Options.UseFont = true;
            this.altTablo.ColumnPanelRowHeight = 20;
            this.altTablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdSoyad,
            this.colGsm,
            this.colMesaj,
            this.colDurum,
            this.gridColumn6,
            this.gridColumn7});
            this.altTablo.GridControl = this.UstGrid;
            this.altTablo.Name = "altTablo";
            this.altTablo.OptionsMenu.EnableColumnMenu = false;
            this.altTablo.OptionsView.ShowFooter = true;
            this.altTablo.OptionsView.ShowGroupPanel = false;
            this.altTablo.OptionsView.ShowIndicator = false;
            this.altTablo.ViewCaption = "Sms Detay Listesi";
            // 
            // colAdSoyad
            // 
            this.colAdSoyad.Caption = "Adı Soyadı";
            this.colAdSoyad.FieldName = "AdSoyad";
            this.colAdSoyad.Name = "colAdSoyad";
            this.colAdSoyad.OptionsColumn.AllowEdit = false;
            this.colAdSoyad.OptionsColumn.AllowFocus = false;
            this.colAdSoyad.OptionsColumn.FixedWidth = true;
            this.colAdSoyad.Visible = true;
            this.colAdSoyad.VisibleIndex = 0;
            this.colAdSoyad.Width = 140;
            // 
            // colGsm
            // 
            this.colGsm.AppearanceCell.Options.UseTextOptions = true;
            this.colGsm.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGsm.AppearanceHeader.Options.UseTextOptions = true;
            this.colGsm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGsm.Caption = "Telefon";
            this.colGsm.FieldName = "Gsm2";
            this.colGsm.Name = "colGsm";
            this.colGsm.OptionsColumn.AllowEdit = false;
            this.colGsm.OptionsColumn.AllowFocus = false;
            this.colGsm.OptionsColumn.FixedWidth = true;
            this.colGsm.Visible = true;
            this.colGsm.VisibleIndex = 1;
            this.colGsm.Width = 100;
            // 
            // colMesaj
            // 
            this.colMesaj.Caption = "Mesaj";
            this.colMesaj.FieldName = "Mesaj";
            this.colMesaj.Name = "colMesaj";
            this.colMesaj.OptionsColumn.AllowEdit = false;
            this.colMesaj.OptionsColumn.AllowFocus = false;
            this.colMesaj.Visible = true;
            this.colMesaj.VisibleIndex = 2;
            this.colMesaj.Width = 244;
            // 
            // colDurum
            // 
            this.colDurum.AppearanceCell.Options.UseTextOptions = true;
            this.colDurum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDurum.AppearanceHeader.Options.UseTextOptions = true;
            this.colDurum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDurum.Caption = "Durum";
            this.colDurum.FieldName = "Durum2";
            this.colDurum.Name = "colDurum";
            this.colDurum.OptionsColumn.AllowEdit = false;
            this.colDurum.OptionsColumn.AllowFocus = false;
            this.colDurum.OptionsColumn.FixedWidth = true;
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 5;
            this.colDurum.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Gönderim Zamanı";
            this.gridColumn6.DisplayFormat.FormatString = "G";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "gonderimZaman";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 140;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "İletim Zamanı";
            this.gridColumn7.DisplayFormat.FormatString = "G";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "iletimZaman";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 140;
            // 
            // UstGrid
            // 
            this.UstGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.altTablo;
            gridLevelNode1.RelationName = "AltGrid";
            this.UstGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.UstGrid.Location = new System.Drawing.Point(0, 134);
            this.UstGrid.MainView = this.tablo;
            this.UstGrid.MenuManager = this.ribbonControl1;
            this.UstGrid.Name = "UstGrid";
            this.UstGrid.Size = new System.Drawing.Size(1053, 351);
            this.UstGrid.TabIndex = 10;
            this.UstGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo,
            this.altTablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.HeaderPanel.Options.UseFont = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tablo.Appearance.Row.Options.UseFont = true;
            this.tablo.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.ViewCaption.Options.UseFont = true;
            this.tablo.ColumnPanelRowHeight = 40;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsmsGuidText,
            this.myGridColumn2,
            this.myGridColumn3,
            this.myGridColumn5,
            this.myGridColumn6,
            this.myGridColumn7,
            this.myGridColumn8});
            this.tablo.GridControl = this.UstGrid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsBehavior.Editable = false;
            this.tablo.OptionsDetail.EnableDetailToolTip = true;
            this.tablo.OptionsDetail.ShowDetailTabs = false;
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Gönderilen Sms Listesi";
            // 
            // colsmsGuidText
            // 
            this.colsmsGuidText.Caption = "smsGuidText";
            this.colsmsGuidText.FieldName = "smsGuidText";
            this.colsmsGuidText.Name = "colsmsGuidText";
            this.colsmsGuidText.OptionsColumn.AllowEdit = false;
            this.colsmsGuidText.Width = 224;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Mesaj";
            this.myGridColumn2.FieldName = "Mesaj";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 1;
            this.myGridColumn2.Width = 595;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn3.Caption = "Tarih";
            this.myGridColumn3.DisplayFormat.FormatString = "d";
            this.myGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.myGridColumn3.FieldName = "Gonderim";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.OptionsColumn.AllowEdit = false;
            this.myGridColumn3.OptionsColumn.AllowFocus = false;
            this.myGridColumn3.OptionsColumn.FixedWidth = true;
            this.myGridColumn3.Visible = true;
            this.myGridColumn3.VisibleIndex = 0;
            this.myGridColumn3.Width = 120;
            // 
            // myGridColumn5
            // 
            this.myGridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn5.Caption = "Kişi Sayısı";
            this.myGridColumn5.FieldName = "KisiAdet";
            this.myGridColumn5.Name = "myGridColumn5";
            this.myGridColumn5.OptionsColumn.AllowEdit = false;
            this.myGridColumn5.OptionsColumn.AllowFocus = false;
            this.myGridColumn5.OptionsColumn.FixedWidth = true;
            this.myGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KisiAdet", "{0:f0}")});
            this.myGridColumn5.Visible = true;
            this.myGridColumn5.VisibleIndex = 2;
            this.myGridColumn5.Width = 80;
            // 
            // myGridColumn6
            // 
            this.myGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn6.Caption = "İletilen";
            this.myGridColumn6.FieldName = "IletilenAdet";
            this.myGridColumn6.Name = "myGridColumn6";
            this.myGridColumn6.OptionsColumn.AllowEdit = false;
            this.myGridColumn6.OptionsColumn.AllowFocus = false;
            this.myGridColumn6.OptionsColumn.FixedWidth = true;
            this.myGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IletilenAdet", "{0:f0}")});
            this.myGridColumn6.Visible = true;
            this.myGridColumn6.VisibleIndex = 3;
            this.myGridColumn6.Width = 80;
            // 
            // myGridColumn7
            // 
            this.myGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn7.Caption = "Bekleyen";
            this.myGridColumn7.FieldName = "BekleyenAdet";
            this.myGridColumn7.Name = "myGridColumn7";
            this.myGridColumn7.OptionsColumn.AllowEdit = false;
            this.myGridColumn7.OptionsColumn.AllowFocus = false;
            this.myGridColumn7.OptionsColumn.FixedWidth = true;
            this.myGridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BekleyenAdet", "{0:f0}")});
            this.myGridColumn7.Visible = true;
            this.myGridColumn7.VisibleIndex = 4;
            this.myGridColumn7.Width = 80;
            // 
            // myGridColumn8
            // 
            this.myGridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn8.Caption = "İletilmeyen";
            this.myGridColumn8.FieldName = "IletilmeyenAdet";
            this.myGridColumn8.Name = "myGridColumn8";
            this.myGridColumn8.OptionsColumn.AllowEdit = false;
            this.myGridColumn8.OptionsColumn.AllowFocus = false;
            this.myGridColumn8.OptionsColumn.FixedWidth = true;
            this.myGridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IletilmeyenAdet", "{0:f0}")});
            this.myGridColumn8.Visible = true;
            this.myGridColumn8.VisibleIndex = 5;
            this.myGridColumn8.Width = 80;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 485);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1053, 25);
            this.panelControl1.TabIndex = 9;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(950, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 13;
            this.lblBilgi.Text = "Kayıt ve Tarih Bilgileri";
            // 
            // controlNavigator
            // 
            this.controlNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.controlNavigator.Appearance.Options.UseFont = true;
            this.controlNavigator.Buttons.Append.Visible = false;
            this.controlNavigator.Buttons.CancelEdit.Visible = false;
            this.controlNavigator.Buttons.Edit.Visible = false;
            this.controlNavigator.Buttons.EndEdit.Visible = false;
            this.controlNavigator.Buttons.NextPage.Visible = false;
            this.controlNavigator.Buttons.PrevPage.Visible = false;
            this.controlNavigator.Buttons.Remove.Visible = false;
            this.controlNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.controlNavigator.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlNavigator.Location = new System.Drawing.Point(2, 2);
            this.controlNavigator.Name = "controlNavigator";
            this.controlNavigator.ShowToolTips = true;
            this.controlNavigator.Size = new System.Drawing.Size(368, 21);
            this.controlNavigator.TabIndex = 8;
            this.controlNavigator.Text = "controlNavigator1";
            this.controlNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.controlNavigator.TextStringFormat = "Kayıt {0} / {1}";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtBitis);
            this.panelControl2.Controls.Add(this.txtBaslama);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.lblSmsBakiye);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 104);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1053, 30);
            this.panelControl2.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl2.Location = new System.Drawing.Point(864, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelControl2.Size = new System.Drawing.Size(122, 26);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Kalan Sms Bakiyesi :";
            // 
            // txtBitis
            // 
            this.txtBitis.EditValue = null;
            this.txtBitis.EnterMoveNextControl = true;
            this.txtBitis.Location = new System.Drawing.Point(231, 4);
            this.txtBitis.MenuManager = this.ribbonControl1;
            this.txtBitis.Name = "txtBitis";
            this.txtBitis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtBitis.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBitis.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtBitis.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtBitis.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBitis.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtBitis.Size = new System.Drawing.Size(100, 20);
            this.txtBitis.TabIndex = 2;
            // 
            // txtBaslama
            // 
            this.txtBaslama.EditValue = null;
            this.txtBaslama.EnterMoveNextControl = true;
            this.txtBaslama.Location = new System.Drawing.Point(125, 4);
            this.txtBaslama.MenuManager = this.ribbonControl1;
            this.txtBaslama.Name = "txtBaslama";
            this.txtBaslama.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtBaslama.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBaslama.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtBaslama.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtBaslama.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtBaslama.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBaslama.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBaslama.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtBaslama.Size = new System.Drawing.Size(100, 20);
            this.txtBaslama.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Rapor Tarih Aralığı";
            // 
            // lblSmsBakiye
            // 
            this.lblSmsBakiye.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblSmsBakiye.Appearance.Options.UseFont = true;
            this.lblSmsBakiye.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSmsBakiye.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSmsBakiye.Location = new System.Drawing.Point(986, 2);
            this.lblSmsBakiye.Name = "lblSmsBakiye";
            this.lblSmsBakiye.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblSmsBakiye.Size = new System.Drawing.Size(65, 26);
            this.lblSmsBakiye.TabIndex = 4;
            this.lblSmsBakiye.Text = "52547";
            // 
            // SmsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 510);
            this.Controls.Add(this.UstGrid);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "SmsListForm";
            this.Tag = "24";
            this.Text = "Sms Listesi";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.UstGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altTablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UstGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBitis.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBitis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslama.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridControl UstGrid;
        private Controls.Components.MyGridView tablo;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyGridColumn myGridColumn3;
        private Controls.Components.MyGridColumn myGridColumn5;
        private Controls.Components.MyGridColumn myGridColumn6;
        private Controls.Components.MyGridColumn myGridColumn7;
        private Controls.Components.MyGridColumn myGridColumn8;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private Controls.Components.MyDateEdit txtBitis;
        private Controls.Components.MyDateEdit txtBaslama;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Controls.Components.MyGridColumn colsmsGuidText;
        private DevExpress.XtraGrid.Views.Grid.GridView altTablo;
        private DevExpress.XtraGrid.Columns.GridColumn colAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colGsm;
        private DevExpress.XtraGrid.Columns.GridColumn colMesaj;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblSmsBakiye;
    }
}