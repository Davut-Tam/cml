namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class PersonelHatirlatmaListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelHatirlatmaListesi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tglDurum = new OgrenciTakipMuh.Controls.Components.MyToogleSwitch();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.myGridControl1 = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colGorev = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colSonOdeme = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn6 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn8 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(994, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tglDurum);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 104);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(994, 24);
            this.panelControl1.TabIndex = 12;
            // 
            // tglDurum
            // 
            this.tglDurum.Dock = System.Windows.Forms.DockStyle.Left;
            this.tglDurum.EditValue = true;
            this.tglDurum.EnterMoveNextControl = true;
            this.tglDurum.Location = new System.Drawing.Point(2, 2);
            this.tglDurum.Name = "tglDurum";
            this.tglDurum.Properties.AutoHeight = false;
            this.tglDurum.Properties.AutoWidth = true;
            this.tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tglDurum.Properties.OffText = "Geçmiş";
            this.tglDurum.Properties.OnText = "Bu Gün";
            this.tglDurum.Size = new System.Drawing.Size(107, 20);
            this.tglDurum.TabIndex = 8;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblBilgi);
            this.panelControl2.Controls.Add(this.controlNavigator);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 485);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(994, 25);
            this.panelControl2.TabIndex = 10;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(891, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 9;
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
            // myGridControl1
            // 
            this.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridControl1.Location = new System.Drawing.Point(0, 128);
            this.myGridControl1.MainView = this.tablo;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(994, 357);
            this.myGridControl1.TabIndex = 14;
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
            this.myGridColumn2,
            this.myGridColumn1,
            this.colGorev,
            this.colSonOdeme,
            this.myGridColumn6,
            this.myGridColumn8,
            this.myGridColumn5});
            this.tablo.GridControl = this.myGridControl1;
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
            // 
            // colId
            // 
            this.colId.Caption = "OdemePlaniId";
            this.colId.FieldName = "OdemePlaniId";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OdemePlaniId", "{0:n2}")});
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn2.Caption = "Tc Kimlik No";
            this.myGridColumn2.FieldName = "TcKimlikNo";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 0;
            this.myGridColumn2.Width = 95;
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.Caption = "Adı Soyadi";
            this.myGridColumn1.FieldName = "AdiSoyadi";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.OptionsColumn.AllowEdit = false;
            this.myGridColumn1.OptionsColumn.AllowFocus = false;
            this.myGridColumn1.Visible = true;
            this.myGridColumn1.VisibleIndex = 1;
            this.myGridColumn1.Width = 162;
            // 
            // colGorev
            // 
            this.colGorev.Caption = "Görevi";
            this.colGorev.FieldName = "GorevAdi";
            this.colGorev.Name = "colGorev";
            this.colGorev.OptionsColumn.AllowEdit = false;
            this.colGorev.OptionsColumn.AllowFocus = false;
            this.colGorev.Visible = true;
            this.colGorev.VisibleIndex = 2;
            // 
            // colSonOdeme
            // 
            this.colSonOdeme.AppearanceCell.Options.UseTextOptions = true;
            this.colSonOdeme.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSonOdeme.Caption = "Son Odeme";
            this.colSonOdeme.DisplayFormat.FormatString = "d";
            this.colSonOdeme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSonOdeme.FieldName = "SonMaasTahakkukTarihi";
            this.colSonOdeme.Name = "colSonOdeme";
            this.colSonOdeme.OptionsColumn.AllowEdit = false;
            this.colSonOdeme.OptionsColumn.AllowFocus = false;
            this.colSonOdeme.Visible = true;
            this.colSonOdeme.VisibleIndex = 3;
            this.colSonOdeme.Width = 95;
            // 
            // myGridColumn6
            // 
            this.myGridColumn6.Caption = "Maaş";
            this.myGridColumn6.DisplayFormat.FormatString = "n2";
            this.myGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myGridColumn6.FieldName = "Maas";
            this.myGridColumn6.Name = "myGridColumn6";
            this.myGridColumn6.OptionsColumn.AllowEdit = false;
            this.myGridColumn6.OptionsColumn.AllowFocus = false;
            this.myGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Maas", "{0:n2}")});
            this.myGridColumn6.Visible = true;
            this.myGridColumn6.VisibleIndex = 4;
            this.myGridColumn6.Width = 100;
            // 
            // myGridColumn8
            // 
            this.myGridColumn8.Caption = "Kalan";
            this.myGridColumn8.DisplayFormat.FormatString = "n2";
            this.myGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myGridColumn8.FieldName = "KalanBakiye";
            this.myGridColumn8.Name = "myGridColumn8";
            this.myGridColumn8.OptionsColumn.AllowEdit = false;
            this.myGridColumn8.OptionsColumn.AllowFocus = false;
            this.myGridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KalanBakiye", "{0:n2}")});
            this.myGridColumn8.Visible = true;
            this.myGridColumn8.VisibleIndex = 5;
            this.myGridColumn8.Width = 100;
            // 
            // myGridColumn5
            // 
            this.myGridColumn5.Caption = "Açıklama";
            this.myGridColumn5.FieldName = "Aciklama";
            this.myGridColumn5.Name = "myGridColumn5";
            this.myGridColumn5.OptionsColumn.AllowEdit = false;
            this.myGridColumn5.OptionsColumn.AllowFocus = false;
            this.myGridColumn5.Visible = true;
            this.myGridColumn5.VisibleIndex = 6;
            this.myGridColumn5.Width = 282;
            // 
            // PersonelHatirlatmaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 510);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "PersonelHatirlatmaListesi";
            this.Tag = "21";
            this.Text = "Personel Hatırlatma Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Controls.Components.MyToogleSwitch tglDurum;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        public Controls.Components.MyGridControl myGridControl1;
        private Controls.Components.MyGridView tablo;
        private Controls.Components.MyGridColumn colId;
        private Controls.Components.MyGridColumn colSonOdeme;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyGridColumn myGridColumn1;
        private Controls.Components.MyGridColumn myGridColumn6;
        private Controls.Components.MyGridColumn myGridColumn8;
        private Controls.Components.MyGridColumn myGridColumn5;
        private Controls.Components.MyGridColumn colGorev;
    }
}