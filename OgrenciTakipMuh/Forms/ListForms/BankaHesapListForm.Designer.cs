namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class BankaHesapListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankaHesapListForm));
            this.myGridControl1 = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colHesapAdi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn4 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn6 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn7 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.tglDurum = new OgrenciTakipMuh.Controls.Components.MyToogleSwitch();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(867, 104);
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
            this.myGridControl1.MenuManager = this.ribbonControl1;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(867, 397);
            this.myGridControl1.TabIndex = 2;
            this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
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
            this.colHesapAdi,
            this.myGridColumn1,
            this.myGridColumn2,
            this.myGridColumn3,
            this.myGridColumn4,
            this.myGridColumn5,
            this.myGridColumn6,
            this.myGridColumn7});
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
            this.tablo.ViewCaption = "Banka Hesap Listesi";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colHesapAdi
            // 
            this.colHesapAdi.Caption = "Hesap Adı";
            this.colHesapAdi.FieldName = "HesapAdi";
            this.colHesapAdi.Name = "colHesapAdi";
            this.colHesapAdi.OptionsColumn.AllowEdit = false;
            this.colHesapAdi.OptionsColumn.AllowFocus = false;
            this.colHesapAdi.Visible = true;
            this.colHesapAdi.VisibleIndex = 0;
            this.colHesapAdi.Width = 194;
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.Caption = "Banka Adı";
            this.myGridColumn1.FieldName = "BankaAdi";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.OptionsColumn.AllowEdit = false;
            this.myGridColumn1.OptionsColumn.AllowFocus = false;
            this.myGridColumn1.Visible = true;
            this.myGridColumn1.VisibleIndex = 1;
            this.myGridColumn1.Width = 156;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Şube Adı";
            this.myGridColumn2.FieldName = "SubeAdi";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 2;
            this.myGridColumn2.Width = 157;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn3.Caption = "Iban No";
            this.myGridColumn3.FieldName = "IbanNo";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.OptionsColumn.AllowEdit = false;
            this.myGridColumn3.OptionsColumn.AllowFocus = false;
            this.myGridColumn3.Visible = true;
            this.myGridColumn3.VisibleIndex = 3;
            this.myGridColumn3.Width = 200;
            // 
            // myGridColumn4
            // 
            this.myGridColumn4.Caption = "Aciklama";
            this.myGridColumn4.FieldName = "Aciklama";
            this.myGridColumn4.Name = "myGridColumn4";
            this.myGridColumn4.OptionsColumn.AllowEdit = false;
            this.myGridColumn4.OptionsColumn.AllowFocus = false;
            this.myGridColumn4.Visible = true;
            this.myGridColumn4.VisibleIndex = 5;
            this.myGridColumn4.Width = 251;
            // 
            // myGridColumn5
            // 
            this.myGridColumn5.Caption = "Bakiye";
            this.myGridColumn5.DisplayFormat.FormatString = "n2";
            this.myGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myGridColumn5.FieldName = "Bakiye";
            this.myGridColumn5.Name = "myGridColumn5";
            this.myGridColumn5.OptionsColumn.AllowEdit = false;
            this.myGridColumn5.OptionsColumn.AllowFocus = false;
            this.myGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bakiye", "{0:n2}")});
            this.myGridColumn5.Visible = true;
            this.myGridColumn5.VisibleIndex = 4;
            this.myGridColumn5.Width = 102;
            // 
            // myGridColumn6
            // 
            this.myGridColumn6.Caption = "İşlem Tarihi";
            this.myGridColumn6.FieldName = "IslemTarihi";
            this.myGridColumn6.Name = "myGridColumn6";
            this.myGridColumn6.OptionsColumn.AllowEdit = false;
            this.myGridColumn6.OptionsColumn.AllowFocus = false;
            this.myGridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn7
            // 
            this.myGridColumn7.Caption = "Kullanıcı Id";
            this.myGridColumn7.FieldName = "KullaniciId";
            this.myGridColumn7.Name = "myGridColumn7";
            this.myGridColumn7.OptionsColumn.AllowEdit = false;
            this.myGridColumn7.OptionsColumn.AllowFocus = false;
            this.myGridColumn7.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // tglDurum
            // 
            this.tglDurum.Dock = System.Windows.Forms.DockStyle.Right;
            this.tglDurum.EditValue = true;
            this.tglDurum.EnterMoveNextControl = true;
            this.tglDurum.Location = new System.Drawing.Point(768, 2);
            this.tglDurum.MenuManager = this.ribbonControl1;
            this.tglDurum.Name = "tglDurum";
            this.tglDurum.Properties.AutoHeight = false;
            this.tglDurum.Properties.AutoWidth = true;
            this.tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tglDurum.Properties.OffText = "Pasif";
            this.tglDurum.Properties.OnText = "Aktif";
            this.tglDurum.Size = new System.Drawing.Size(97, 21);
            this.tglDurum.TabIndex = 8;
            this.tglDurum.Toggled += new System.EventHandler(this.TglDurum_Toggled);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblBilgi);
            this.panelControl2.Controls.Add(this.tglDurum);
            this.panelControl2.Controls.Add(this.controlNavigator);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 476);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(867, 25);
            this.panelControl2.TabIndex = 9;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(667, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 14;
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
            // BankaHesapListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 501);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.myGridControl1);
            this.Name = "BankaHesapListForm";
            this.Tag = "17";
            this.Text = "Banka Hesap Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.myGridControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OgrenciTakipMuh.Controls.Components.MyGridControl myGridControl1;
        private OgrenciTakipMuh.Controls.Components.MyGridView tablo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colId;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn myGridColumn1;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn myGridColumn2;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn myGridColumn3;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn myGridColumn4;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn myGridColumn5;
        private Controls.Components.MyToogleSwitch tglDurum;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridColumn myGridColumn6;
        private Controls.Components.MyGridColumn myGridColumn7;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private Controls.Components.MyGridColumn colHesapAdi;
    }
}