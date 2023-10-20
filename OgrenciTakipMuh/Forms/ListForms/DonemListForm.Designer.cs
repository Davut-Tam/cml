namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class DonemListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonemListForm));
            this.grid = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colDonemAdi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colBaslamaTarihi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colBitisTarihi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colAciklama = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn4 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 104);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl1;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(934, 396);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.colDonemAdi,
            this.colBaslamaTarihi,
            this.colBitisTarihi,
            this.colAciklama,
            this.myGridColumn1,
            this.myGridColumn2,
            this.myGridColumn3,
            this.myGridColumn4,
            this.myGridColumn5});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
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
            this.tablo.ViewCaption = "Dönem Kartları";
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
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDonemAdi
            // 
            this.colDonemAdi.Caption = "Dönem Adı";
            this.colDonemAdi.FieldName = "DonemAdi";
            this.colDonemAdi.Name = "colDonemAdi";
            this.colDonemAdi.OptionsColumn.AllowEdit = false;
            this.colDonemAdi.OptionsColumn.AllowFocus = false;
            this.colDonemAdi.OptionsColumn.FixedWidth = true;
            this.colDonemAdi.Visible = true;
            this.colDonemAdi.VisibleIndex = 0;
            this.colDonemAdi.Width = 223;
            // 
            // colBaslamaTarihi
            // 
            this.colBaslamaTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colBaslamaTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBaslamaTarihi.Caption = "Dönem Baslama Tarihi";
            this.colBaslamaTarihi.FieldName = "BaslamaTarihi";
            this.colBaslamaTarihi.Name = "colBaslamaTarihi";
            this.colBaslamaTarihi.OptionsColumn.AllowEdit = false;
            this.colBaslamaTarihi.OptionsColumn.AllowFocus = false;
            this.colBaslamaTarihi.OptionsColumn.FixedWidth = true;
            this.colBaslamaTarihi.Visible = true;
            this.colBaslamaTarihi.VisibleIndex = 4;
            this.colBaslamaTarihi.Width = 120;
            // 
            // colBitisTarihi
            // 
            this.colBitisTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colBitisTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBitisTarihi.Caption = "Dönem Bitiş Tarihi";
            this.colBitisTarihi.FieldName = "BitisTarihi";
            this.colBitisTarihi.Name = "colBitisTarihi";
            this.colBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colBitisTarihi.OptionsColumn.AllowFocus = false;
            this.colBitisTarihi.OptionsColumn.FixedWidth = true;
            this.colBitisTarihi.Visible = true;
            this.colBitisTarihi.VisibleIndex = 5;
            this.colBitisTarihi.Width = 120;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.OptionsColumn.AllowFocus = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 6;
            this.colAciklama.Width = 450;
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn1.Caption = "Grup Sayısı";
            this.myGridColumn1.FieldName = "GrupSayisi";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.OptionsColumn.AllowEdit = false;
            this.myGridColumn1.OptionsColumn.AllowFocus = false;
            this.myGridColumn1.OptionsColumn.FixedWidth = true;
            this.myGridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrupSayisi", "{0:n0}")});
            this.myGridColumn1.Visible = true;
            this.myGridColumn1.VisibleIndex = 1;
            this.myGridColumn1.Width = 66;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn2.Caption = "Sınıf Sayısı";
            this.myGridColumn2.FieldName = "SinifSayisi";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.OptionsColumn.FixedWidth = true;
            this.myGridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SinifSayisi", "{0:n0}")});
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 2;
            this.myGridColumn2.Width = 64;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.myGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myGridColumn3.Caption = "Öğrenci Sayısı";
            this.myGridColumn3.FieldName = "OgrenciSayisi";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.OptionsColumn.AllowEdit = false;
            this.myGridColumn3.OptionsColumn.AllowFocus = false;
            this.myGridColumn3.OptionsColumn.FixedWidth = true;
            this.myGridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OgrenciSayisi", "{0:n0}")});
            this.myGridColumn3.Visible = true;
            this.myGridColumn3.VisibleIndex = 3;
            this.myGridColumn3.Width = 80;
            // 
            // myGridColumn4
            // 
            this.myGridColumn4.Caption = "Kullanıcı Id";
            this.myGridColumn4.FieldName = "KullaniciId";
            this.myGridColumn4.Name = "myGridColumn4";
            this.myGridColumn4.OptionsColumn.AllowEdit = false;
            this.myGridColumn4.OptionsColumn.AllowFocus = false;
            this.myGridColumn4.OptionsColumn.FixedWidth = true;
            this.myGridColumn4.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn5
            // 
            this.myGridColumn5.Caption = "İşlem Tarihi";
            this.myGridColumn5.FieldName = "IslemTarihi";
            this.myGridColumn5.Name = "myGridColumn5";
            this.myGridColumn5.OptionsColumn.AllowEdit = false;
            this.myGridColumn5.OptionsColumn.AllowFocus = false;
            this.myGridColumn5.OptionsColumn.FixedWidth = true;
            this.myGridColumn5.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 500);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(934, 25);
            this.panelControl1.TabIndex = 7;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(831, 2);
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
            // DonemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 525);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelControl1);
            this.Name = "DonemListForm";
            this.Tag = "5";
            this.Text = "Dönem Kartları";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OgrenciTakipMuh.Controls.Components.MyGridControl grid;
        private OgrenciTakipMuh.Controls.Components.MyGridView tablo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colId;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colDonemAdi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colAciklama;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colBaslamaTarihi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colBitisTarihi;
        private Controls.Components.MyGridColumn myGridColumn1;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyGridColumn myGridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridColumn myGridColumn4;
        private Controls.Components.MyGridColumn myGridColumn5;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
    }
}