namespace OgrenciTakipMuh.Forms.EditForms
{
    partial class OgrenciTaksitSecimListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciTaksitSecimListForm));
            this.myGridControl1 = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colSonOdemeTarihi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colTcKimlik = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colAdiSoyadi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colTaksitNo = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOdenecek = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOdenen = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colKAlan = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colAciklama = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOgrenciId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colTahakkukNo = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colDonemAdi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colKullaniciId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colIslemTarihi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colBirinciHatirlatma = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colIkinciHatirlatma = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtDonemAdi = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonemAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAktar
            // 
            this.btnAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAktar.ImageOptions.Image")));
            this.btnAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAktar.ImageOptions.LargeImage")));
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1146, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            // 
            // myGridControl1
            // 
            this.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridControl1.Location = new System.Drawing.Point(0, 104);
            this.myGridControl1.MainView = this.tablo;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(1146, 320);
            this.myGridControl1.TabIndex = 0;
            this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
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
            this.colId,
            this.colSonOdemeTarihi,
            this.colTcKimlik,
            this.colAdiSoyadi,
            this.colTaksitNo,
            this.colOdenecek,
            this.colOdenen,
            this.colKAlan,
            this.colAciklama,
            this.colOgrenciId,
            this.colTahakkukNo,
            this.colDonemAdi,
            this.colKullaniciId,
            this.colIslemTarihi,
            this.colBirinciHatirlatma,
            this.colIkinciHatirlatma});
            this.tablo.GridControl = this.myGridControl1;
            this.tablo.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.tablo.Name = "tablo";
            this.tablo.OptionsFind.AllowFindPanel = false;
            this.tablo.OptionsFind.AlwaysVisible = true;
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.tablo.OptionsSelection.MultiSelect = true;
            this.tablo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.tablo.OptionsSelection.UseIndicatorForSelection = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowIndicator = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Ödenmeyen Öğrenci Tahakkukları";
            // 
            // colId
            // 
            this.colId.Caption = "OdemePlaniId";
            this.colId.FieldName = "OdemePlaniId";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OdemePlaniId", "{0:n2}")});
            this.colId.Width = 110;
            // 
            // colSonOdemeTarihi
            // 
            this.colSonOdemeTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colSonOdemeTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSonOdemeTarihi.Caption = "Son Odeme";
            this.colSonOdemeTarihi.DisplayFormat.FormatString = "d";
            this.colSonOdemeTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSonOdemeTarihi.FieldName = "SonOdemeTarihi";
            this.colSonOdemeTarihi.Name = "colSonOdemeTarihi";
            this.colSonOdemeTarihi.OptionsColumn.AllowEdit = false;
            this.colSonOdemeTarihi.OptionsColumn.AllowFocus = false;
            this.colSonOdemeTarihi.OptionsColumn.FixedWidth = true;
            this.colSonOdemeTarihi.Visible = true;
            this.colSonOdemeTarihi.VisibleIndex = 3;
            this.colSonOdemeTarihi.Width = 119;
            // 
            // colTcKimlik
            // 
            this.colTcKimlik.AppearanceCell.Options.UseTextOptions = true;
            this.colTcKimlik.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTcKimlik.Caption = "Tc Kimlik No";
            this.colTcKimlik.FieldName = "TcKimlikNo";
            this.colTcKimlik.Name = "colTcKimlik";
            this.colTcKimlik.OptionsColumn.AllowEdit = false;
            this.colTcKimlik.OptionsColumn.AllowFocus = false;
            this.colTcKimlik.OptionsColumn.FixedWidth = true;
            this.colTcKimlik.Visible = true;
            this.colTcKimlik.VisibleIndex = 1;
            this.colTcKimlik.Width = 95;
            // 
            // colAdiSoyadi
            // 
            this.colAdiSoyadi.Caption = "Adı Soyadi";
            this.colAdiSoyadi.FieldName = "AdiSoyadi";
            this.colAdiSoyadi.Name = "colAdiSoyadi";
            this.colAdiSoyadi.OptionsColumn.AllowEdit = false;
            this.colAdiSoyadi.OptionsColumn.AllowFocus = false;
            this.colAdiSoyadi.OptionsColumn.FixedWidth = true;
            this.colAdiSoyadi.Visible = true;
            this.colAdiSoyadi.VisibleIndex = 2;
            this.colAdiSoyadi.Width = 166;
            // 
            // colTaksitNo
            // 
            this.colTaksitNo.AppearanceCell.Options.UseTextOptions = true;
            this.colTaksitNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTaksitNo.Caption = "Taksit No";
            this.colTaksitNo.FieldName = "TaksitNo";
            this.colTaksitNo.Name = "colTaksitNo";
            this.colTaksitNo.OptionsColumn.AllowEdit = false;
            this.colTaksitNo.OptionsColumn.AllowFocus = false;
            this.colTaksitNo.OptionsColumn.FixedWidth = true;
            this.colTaksitNo.Visible = true;
            this.colTaksitNo.VisibleIndex = 5;
            this.colTaksitNo.Width = 80;
            // 
            // colOdenecek
            // 
            this.colOdenecek.Caption = "Ödenecek";
            this.colOdenecek.DisplayFormat.FormatString = "n2";
            this.colOdenecek.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOdenecek.FieldName = "Odenecek";
            this.colOdenecek.Name = "colOdenecek";
            this.colOdenecek.OptionsColumn.AllowEdit = false;
            this.colOdenecek.OptionsColumn.AllowFocus = false;
            this.colOdenecek.OptionsColumn.FixedWidth = true;
            this.colOdenecek.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Odenecek", "{0:n2}")});
            this.colOdenecek.Visible = true;
            this.colOdenecek.VisibleIndex = 6;
            this.colOdenecek.Width = 90;
            // 
            // colOdenen
            // 
            this.colOdenen.Caption = "Ödenen";
            this.colOdenen.DisplayFormat.FormatString = "n2";
            this.colOdenen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOdenen.FieldName = "Odenen";
            this.colOdenen.Name = "colOdenen";
            this.colOdenen.OptionsColumn.AllowEdit = false;
            this.colOdenen.OptionsColumn.AllowFocus = false;
            this.colOdenen.OptionsColumn.FixedWidth = true;
            this.colOdenen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Odenen", "{0:n2}")});
            this.colOdenen.Visible = true;
            this.colOdenen.VisibleIndex = 7;
            this.colOdenen.Width = 90;
            // 
            // colKAlan
            // 
            this.colKAlan.Caption = "Kalan";
            this.colKAlan.DisplayFormat.FormatString = "n2";
            this.colKAlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKAlan.FieldName = "Kalan";
            this.colKAlan.Name = "colKAlan";
            this.colKAlan.OptionsColumn.AllowEdit = false;
            this.colKAlan.OptionsColumn.AllowFocus = false;
            this.colKAlan.OptionsColumn.FixedWidth = true;
            this.colKAlan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kalan", "{0:n2}")});
            this.colKAlan.Visible = true;
            this.colKAlan.VisibleIndex = 8;
            this.colKAlan.Width = 90;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.OptionsColumn.AllowFocus = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 9;
            this.colAciklama.Width = 22;
            // 
            // colOgrenciId
            // 
            this.colOgrenciId.Caption = "Öğrenci Id";
            this.colOgrenciId.FieldName = "OgrenciId";
            this.colOgrenciId.Name = "colOgrenciId";
            this.colOgrenciId.OptionsColumn.AllowEdit = false;
            this.colOgrenciId.OptionsColumn.AllowFocus = false;
            this.colOgrenciId.OptionsColumn.FixedWidth = true;
            // 
            // colTahakkukNo
            // 
            this.colTahakkukNo.Caption = "Tahakkuk No";
            this.colTahakkukNo.FieldName = "TahakkukNo";
            this.colTahakkukNo.Name = "colTahakkukNo";
            this.colTahakkukNo.OptionsColumn.AllowEdit = false;
            this.colTahakkukNo.OptionsColumn.AllowFocus = false;
            this.colTahakkukNo.OptionsColumn.FixedWidth = true;
            this.colTahakkukNo.Width = 97;
            // 
            // colDonemAdi
            // 
            this.colDonemAdi.Caption = "Dönem";
            this.colDonemAdi.FieldName = "DonemAdi";
            this.colDonemAdi.Name = "colDonemAdi";
            this.colDonemAdi.OptionsColumn.AllowEdit = false;
            this.colDonemAdi.OptionsColumn.AllowFocus = false;
            this.colDonemAdi.OptionsColumn.FixedWidth = true;
            this.colDonemAdi.Visible = true;
            this.colDonemAdi.VisibleIndex = 4;
            this.colDonemAdi.Width = 137;
            // 
            // colKullaniciId
            // 
            this.colKullaniciId.Caption = "Kullanıcı Id";
            this.colKullaniciId.FieldName = "KullaniciId";
            this.colKullaniciId.Name = "colKullaniciId";
            this.colKullaniciId.OptionsColumn.AllowEdit = false;
            this.colKullaniciId.OptionsColumn.AllowFocus = false;
            this.colKullaniciId.OptionsColumn.FixedWidth = true;
            this.colKullaniciId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIslemTarihi
            // 
            this.colIslemTarihi.Caption = "İşlem Tarihi";
            this.colIslemTarihi.FieldName = "IslemTarihi";
            this.colIslemTarihi.Name = "colIslemTarihi";
            this.colIslemTarihi.OptionsColumn.AllowEdit = false;
            this.colIslemTarihi.OptionsColumn.AllowFocus = false;
            this.colIslemTarihi.OptionsColumn.FixedWidth = true;
            this.colIslemTarihi.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colBirinciHatirlatma
            // 
            this.colBirinciHatirlatma.AppearanceCell.Options.UseTextOptions = true;
            this.colBirinciHatirlatma.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBirinciHatirlatma.Caption = "Birinci Hatırlatma";
            this.colBirinciHatirlatma.DisplayFormat.FormatString = "d";
            this.colBirinciHatirlatma.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBirinciHatirlatma.FieldName = "BirinciHatirlatma";
            this.colBirinciHatirlatma.Name = "colBirinciHatirlatma";
            this.colBirinciHatirlatma.OptionsColumn.AllowEdit = false;
            this.colBirinciHatirlatma.OptionsColumn.AllowFocus = false;
            this.colBirinciHatirlatma.OptionsColumn.FixedWidth = true;
            this.colBirinciHatirlatma.Visible = true;
            this.colBirinciHatirlatma.VisibleIndex = 10;
            this.colBirinciHatirlatma.Width = 115;
            // 
            // colIkinciHatirlatma
            // 
            this.colIkinciHatirlatma.AppearanceCell.Options.UseTextOptions = true;
            this.colIkinciHatirlatma.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIkinciHatirlatma.Caption = "İkinci Hatırlatma";
            this.colIkinciHatirlatma.DisplayFormat.FormatString = "d";
            this.colIkinciHatirlatma.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colIkinciHatirlatma.FieldName = "IkinciHatirlatma";
            this.colIkinciHatirlatma.Name = "colIkinciHatirlatma";
            this.colIkinciHatirlatma.OptionsColumn.AllowEdit = false;
            this.colIkinciHatirlatma.OptionsColumn.AllowFocus = false;
            this.colIkinciHatirlatma.OptionsColumn.FixedWidth = true;
            this.colIkinciHatirlatma.Visible = true;
            this.colIkinciHatirlatma.VisibleIndex = 11;
            this.colIkinciHatirlatma.Width = 115;
            // 
            // controlNavigator
            // 
            this.controlNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.controlNavigator.Appearance.Options.UseFont = true;
            this.controlNavigator.Buttons.Append.Visible = false;
            this.controlNavigator.Buttons.CancelEdit.Visible = false;
            this.controlNavigator.Buttons.Edit.Visible = false;
            this.controlNavigator.Buttons.EndEdit.Visible = false;
            this.controlNavigator.Buttons.First.Visible = false;
            this.controlNavigator.Buttons.Last.Visible = false;
            this.controlNavigator.Buttons.Remove.Visible = false;
            this.controlNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.controlNavigator.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlNavigator.Location = new System.Drawing.Point(2, 2);
            this.controlNavigator.Name = "controlNavigator";
            this.controlNavigator.Size = new System.Drawing.Size(320, 21);
            this.controlNavigator.TabIndex = 7;
            this.controlNavigator.Text = "controlNavigator1";
            this.controlNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.controlNavigator.TextStringFormat = "Kayıt {0} / {1}";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtDonemAdi);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 424);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1146, 25);
            this.panelControl1.TabIndex = 7;
            // 
            // txtDonemAdi
            // 
            this.txtDonemAdi.Location = new System.Drawing.Point(398, 3);
            this.txtDonemAdi.MenuManager = this.ribbonControl1;
            this.txtDonemAdi.Name = "txtDonemAdi";
            this.txtDonemAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDonemAdi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Name1", 5, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DonemAdi", "Name2", 135, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.txtDonemAdi.Properties.DisplayMember = "DonemAdi";
            this.txtDonemAdi.Properties.DropDownRows = 4;
            this.txtDonemAdi.Properties.NullText = "";
            this.txtDonemAdi.Properties.PopupWidth = 50;
            this.txtDonemAdi.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.txtDonemAdi.Properties.ShowFooter = false;
            this.txtDonemAdi.Properties.ShowHeader = false;
            this.txtDonemAdi.Properties.ShowLines = false;
            this.txtDonemAdi.Properties.ValueMember = "Id";
            this.txtDonemAdi.Size = new System.Drawing.Size(192, 20);
            this.txtDonemAdi.TabIndex = 19;
            this.txtDonemAdi.EditValueChanged += new System.EventHandler(this.TxtDonemAdi_EditValueChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(322, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "      Dönem :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(1043, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 13;
            this.lblBilgi.Text = "Kayıt ve Tarih Bilgileri";
            // 
            // OgrenciTaksitSecimListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 449);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "OgrenciTaksitSecimListForm";
            this.Tag = "4";
            this.Text = "Ödenmeyen Öğrenci Tahakkuk Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonemAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OgrenciTakipMuh.Controls.Components.MyGridView tablo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colId;
        public OgrenciTakipMuh.Controls.Components.MyGridControl myGridControl1;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colAdiSoyadi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colTaksitNo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colSonOdemeTarihi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colAciklama;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colOdenecek;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colTcKimlik;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colOdenen;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colKAlan;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colOgrenciId;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colTahakkukNo;
        private Controls.Components.MyGridColumn colDonemAdi;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private Controls.Components.MyGridColumn colKullaniciId;
        private Controls.Components.MyGridColumn colIslemTarihi;
        private DevExpress.XtraEditors.LookUpEdit txtDonemAdi;
        private Controls.Components.MyGridColumn colBirinciHatirlatma;
        private Controls.Components.MyGridColumn colIkinciHatirlatma;
        private System.Windows.Forms.Label label1;
    }
}