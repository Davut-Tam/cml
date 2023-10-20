namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class FirmaListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmaListForm));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.bandedGrid = new OgrenciTakipMuh.Controls.Components.MyBandedGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFirmaAdi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colVergiTcKimlikNo = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.VergiDairesi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn6 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.bndBorcAlacakBilgileri = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colToplamCiro = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn9 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colToplamOdeme = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn8 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn10 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTel = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.myBandedGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn4 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.myBandedGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn7 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.tglDurum = new OgrenciTakipMuh.Controls.Components.MyToogleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1081, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            this.btnTahsilat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTahsilat.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // bandedGrid
            // 
            this.bandedGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bandedGrid.Location = new System.Drawing.Point(0, 104);
            this.bandedGrid.MainView = this.tablo;
            this.bandedGrid.MenuManager = this.ribbonControl1;
            this.bandedGrid.Name = "bandedGrid";
            this.bandedGrid.Size = new System.Drawing.Size(1081, 390);
            this.bandedGrid.TabIndex = 9;
            this.bandedGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.BandPanel.Options.UseFont = true;
            this.tablo.Appearance.BandPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.tablo.Appearance.GroupPanel.Options.UseFont = true;
            this.tablo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.HeaderPanel.Options.UseFont = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tablo.Appearance.Row.Options.UseFont = true;
            this.tablo.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.ViewCaption.Options.UseFont = true;
            this.tablo.Appearance.ViewCaption.Options.UseImage = true;
            this.tablo.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.tablo.BandPanelRowHeight = 40;
            this.tablo.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.bndBorcAlacakBilgileri,
            this.gridBand2,
            this.gridBand4});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colFirmaAdi,
            this.colVergiTcKimlikNo,
            this.VergiDairesi,
            this.myBandedGridColumn1,
            this.colTel,
            this.myBandedGridColumn3,
            this.myBandedGridColumn4,
            this.myBandedGridColumn5,
            this.myBandedGridColumn6,
            this.myBandedGridColumn2,
            this.myBandedGridColumn7,
            this.colToplamCiro,
            this.myBandedGridColumn9,
            this.colToplamOdeme,
            this.myBandedGridColumn10,
            this.myBandedGridColumn8});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format1";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleExpression1.Appearance.Options.HighPriority = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[KalanBakiye] <= 0 And [TahakkukTutari] > 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.tablo.FormatRules.Add(gridFormatRule1);
            this.tablo.GridControl = this.bandedGrid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Firma Listesi";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Firma Bilgileri";
            this.gridBand1.Columns.Add(this.colFirmaAdi);
            this.gridBand1.Columns.Add(this.colVergiTcKimlikNo);
            this.gridBand1.Columns.Add(this.VergiDairesi);
            this.gridBand1.Columns.Add(this.myBandedGridColumn1);
            this.gridBand1.Columns.Add(this.myBandedGridColumn6);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 509;
            // 
            // colFirmaAdi
            // 
            this.colFirmaAdi.Caption = "Firma Ünvanı";
            this.colFirmaAdi.FieldName = "FirmaAdi";
            this.colFirmaAdi.Name = "colFirmaAdi";
            this.colFirmaAdi.OptionsColumn.AllowEdit = false;
            this.colFirmaAdi.OptionsColumn.AllowFocus = false;
            this.colFirmaAdi.Visible = true;
            this.colFirmaAdi.Width = 171;
            // 
            // colVergiTcKimlikNo
            // 
            this.colVergiTcKimlikNo.AppearanceCell.Options.UseTextOptions = true;
            this.colVergiTcKimlikNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVergiTcKimlikNo.Caption = "Vergi - Kimlik No";
            this.colVergiTcKimlikNo.FieldName = "VergiTcKimlikNo";
            this.colVergiTcKimlikNo.Name = "colVergiTcKimlikNo";
            this.colVergiTcKimlikNo.OptionsColumn.AllowEdit = false;
            this.colVergiTcKimlikNo.OptionsColumn.AllowFocus = false;
            this.colVergiTcKimlikNo.Visible = true;
            this.colVergiTcKimlikNo.Width = 113;
            // 
            // VergiDairesi
            // 
            this.VergiDairesi.Caption = "Vergi Dairesi";
            this.VergiDairesi.FieldName = "VergiDairesi";
            this.VergiDairesi.Name = "VergiDairesi";
            this.VergiDairesi.OptionsColumn.AllowEdit = false;
            this.VergiDairesi.OptionsColumn.AllowFocus = false;
            this.VergiDairesi.Visible = true;
            this.VergiDairesi.Width = 125;
            // 
            // myBandedGridColumn1
            // 
            this.myBandedGridColumn1.Caption = "Firma Türü";
            this.myBandedGridColumn1.FieldName = "Tur";
            this.myBandedGridColumn1.Name = "myBandedGridColumn1";
            this.myBandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn1.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn1.Visible = true;
            this.myBandedGridColumn1.Width = 100;
            // 
            // myBandedGridColumn6
            // 
            this.myBandedGridColumn6.Caption = "Açıklama";
            this.myBandedGridColumn6.FieldName = "Aciklama";
            this.myBandedGridColumn6.Name = "myBandedGridColumn6";
            this.myBandedGridColumn6.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn6.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn6.Width = 450;
            // 
            // bndBorcAlacakBilgileri
            // 
            this.bndBorcAlacakBilgileri.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bndBorcAlacakBilgileri.AppearanceHeader.Options.UseBackColor = true;
            this.bndBorcAlacakBilgileri.AutoFillDown = false;
            this.bndBorcAlacakBilgileri.Caption = "Borç - Alacak Bilgileri";
            this.bndBorcAlacakBilgileri.Columns.Add(this.colToplamCiro);
            this.bndBorcAlacakBilgileri.Columns.Add(this.myBandedGridColumn9);
            this.bndBorcAlacakBilgileri.Columns.Add(this.colToplamOdeme);
            this.bndBorcAlacakBilgileri.Columns.Add(this.myBandedGridColumn8);
            this.bndBorcAlacakBilgileri.Columns.Add(this.myBandedGridColumn10);
            this.bndBorcAlacakBilgileri.Name = "bndBorcAlacakBilgileri";
            this.bndBorcAlacakBilgileri.VisibleIndex = 1;
            this.bndBorcAlacakBilgileri.Width = 604;
            // 
            // colToplamCiro
            // 
            this.colToplamCiro.Caption = "Toplam Alış";
            this.colToplamCiro.DisplayFormat.FormatString = "n2";
            this.colToplamCiro.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colToplamCiro.FieldName = "ToplamAlis";
            this.colToplamCiro.Name = "colToplamCiro";
            this.colToplamCiro.OptionsColumn.AllowEdit = false;
            this.colToplamCiro.OptionsColumn.AllowFocus = false;
            this.colToplamCiro.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamAlis", "{0:n2}")});
            this.colToplamCiro.Visible = true;
            this.colToplamCiro.Width = 120;
            // 
            // myBandedGridColumn9
            // 
            this.myBandedGridColumn9.Caption = "Toplam Satış";
            this.myBandedGridColumn9.DisplayFormat.FormatString = "n2";
            this.myBandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myBandedGridColumn9.FieldName = "ToplamSatis";
            this.myBandedGridColumn9.Name = "myBandedGridColumn9";
            this.myBandedGridColumn9.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn9.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamSatis", "{0:n2}")});
            this.myBandedGridColumn9.Visible = true;
            this.myBandedGridColumn9.Width = 120;
            // 
            // colToplamOdeme
            // 
            this.colToplamOdeme.Caption = "Toplam Ödeme";
            this.colToplamOdeme.DisplayFormat.FormatString = "n2";
            this.colToplamOdeme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colToplamOdeme.FieldName = "ToplamOdeme";
            this.colToplamOdeme.Name = "colToplamOdeme";
            this.colToplamOdeme.OptionsColumn.AllowEdit = false;
            this.colToplamOdeme.OptionsColumn.AllowFocus = false;
            this.colToplamOdeme.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamOdeme", "{0:n2}")});
            this.colToplamOdeme.Visible = true;
            this.colToplamOdeme.Width = 120;
            // 
            // myBandedGridColumn8
            // 
            this.myBandedGridColumn8.Caption = "Toplam Tahsilat";
            this.myBandedGridColumn8.DisplayFormat.FormatString = "n2";
            this.myBandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myBandedGridColumn8.FieldName = "ToplamTahsilat";
            this.myBandedGridColumn8.Name = "myBandedGridColumn8";
            this.myBandedGridColumn8.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn8.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamTahsilat", "{0:n2}")});
            this.myBandedGridColumn8.Visible = true;
            this.myBandedGridColumn8.Width = 124;
            // 
            // myBandedGridColumn10
            // 
            this.myBandedGridColumn10.Caption = "Bakiye";
            this.myBandedGridColumn10.DisplayFormat.FormatString = "n2";
            this.myBandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myBandedGridColumn10.FieldName = "Bakiye";
            this.myBandedGridColumn10.Name = "myBandedGridColumn10";
            this.myBandedGridColumn10.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn10.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bakiye", "{0:n2}")});
            this.myBandedGridColumn10.Visible = true;
            this.myBandedGridColumn10.Width = 120;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "İletişim Bilgileri";
            this.gridBand2.Columns.Add(this.colTel);
            this.gridBand2.Columns.Add(this.myBandedGridColumn5);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 406;
            // 
            // colTel
            // 
            this.colTel.AppearanceCell.Options.UseTextOptions = true;
            this.colTel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTel.Caption = "Telefon";
            this.colTel.FieldName = "Telefon";
            this.colTel.Name = "colTel";
            this.colTel.OptionsColumn.AllowEdit = false;
            this.colTel.OptionsColumn.AllowFocus = false;
            this.colTel.Visible = true;
            this.colTel.Width = 101;
            // 
            // myBandedGridColumn5
            // 
            this.myBandedGridColumn5.Caption = "Adres";
            this.myBandedGridColumn5.FieldName = "Adres";
            this.myBandedGridColumn5.Name = "myBandedGridColumn5";
            this.myBandedGridColumn5.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn5.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn5.Visible = true;
            this.myBandedGridColumn5.Width = 305;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Hesap Bilgileri";
            this.gridBand4.Columns.Add(this.myBandedGridColumn3);
            this.gridBand4.Columns.Add(this.myBandedGridColumn4);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            this.gridBand4.VisibleIndex = -1;
            this.gridBand4.Width = 470;
            // 
            // myBandedGridColumn3
            // 
            this.myBandedGridColumn3.Caption = "Banka Adı";
            this.myBandedGridColumn3.FieldName = "BankaAdi";
            this.myBandedGridColumn3.Name = "myBandedGridColumn3";
            this.myBandedGridColumn3.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn3.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn3.Visible = true;
            this.myBandedGridColumn3.Width = 256;
            // 
            // myBandedGridColumn4
            // 
            this.myBandedGridColumn4.Caption = "İban No";
            this.myBandedGridColumn4.FieldName = "IbanNo";
            this.myBandedGridColumn4.Name = "myBandedGridColumn4";
            this.myBandedGridColumn4.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn4.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn4.Visible = true;
            this.myBandedGridColumn4.Width = 214;
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Id", "{0:n2}")});
            this.colId.Width = 120;
            // 
            // myBandedGridColumn2
            // 
            this.myBandedGridColumn2.Caption = "Kullanıcı Id";
            this.myBandedGridColumn2.FieldName = "KullaniciId";
            this.myBandedGridColumn2.Name = "myBandedGridColumn2";
            this.myBandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // myBandedGridColumn7
            // 
            this.myBandedGridColumn7.Caption = "İşlem Tarihi";
            this.myBandedGridColumn7.FieldName = "IslemTarihi";
            this.myBandedGridColumn7.Name = "myBandedGridColumn7";
            this.myBandedGridColumn7.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Controls.Add(this.tglDurum);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 494);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1081, 25);
            this.panelControl1.TabIndex = 10;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(881, 2);
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
            // tglDurum
            // 
            this.tglDurum.Dock = System.Windows.Forms.DockStyle.Right;
            this.tglDurum.EditValue = true;
            this.tglDurum.EnterMoveNextControl = true;
            this.tglDurum.Location = new System.Drawing.Point(982, 2);
            this.tglDurum.MenuManager = this.ribbonControl1;
            this.tglDurum.Name = "tglDurum";
            this.tglDurum.Properties.AutoHeight = false;
            this.tglDurum.Properties.AutoWidth = true;
            this.tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tglDurum.Properties.OffText = "Pasif";
            this.tglDurum.Properties.OnText = "Aktif";
            this.tglDurum.Size = new System.Drawing.Size(97, 21);
            this.tglDurum.TabIndex = 7;
            // 
            // FirmaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 519);
            this.Controls.Add(this.bandedGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "FirmaListForm";
            this.Tag = "10";
            this.Text = "Firma Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.bandedGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Components.MyBandedGridControl bandedGrid;
        private Controls.Components.MyBandedGridView tablo;
        private Controls.Components.MyBandedGridColumn colVergiTcKimlikNo;
        private Controls.Components.MyBandedGridColumn colFirmaAdi;
        private Controls.Components.MyBandedGridColumn VergiDairesi;
        private Controls.Components.MyBandedGridColumn colTel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn1;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn6;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn5;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn3;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn4;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn2;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn7;
        private Controls.Components.MyBandedGridColumn colToplamCiro;
        private Controls.Components.MyBandedGridColumn colToplamOdeme;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn10;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn8;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bndBorcAlacakBilgileri;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        public Controls.Components.MyToogleSwitch tglDurum;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
    }
}