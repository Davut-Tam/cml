namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class MeslekListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeslekListForm));
            this.myGridControl1 = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colGorevAdi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.ColAciklama = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(800, 104);
            this.ribbonControl1.Tag = "9";
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
            this.myGridControl1.Size = new System.Drawing.Size(800, 321);
            this.myGridControl1.TabIndex = 1;
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
            this.colGorevAdi,
            this.ColAciklama,
            this.myGridColumn2,
            this.myGridColumn3});
            this.tablo.GridControl = this.myGridControl1;
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
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Meslek Listesi";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colGorevAdi
            // 
            this.colGorevAdi.Caption = "Görev Adı";
            this.colGorevAdi.FieldName = "GorevAdi";
            this.colGorevAdi.Name = "colGorevAdi";
            this.colGorevAdi.OptionsColumn.AllowEdit = false;
            this.colGorevAdi.OptionsColumn.AllowFocus = false;
            this.colGorevAdi.OptionsColumn.FixedWidth = true;
            this.colGorevAdi.Visible = true;
            this.colGorevAdi.VisibleIndex = 0;
            this.colGorevAdi.Width = 191;
            // 
            // ColAciklama
            // 
            this.ColAciklama.Caption = "Açıklama";
            this.ColAciklama.FieldName = "Aciklama";
            this.ColAciklama.Name = "ColAciklama";
            this.ColAciklama.OptionsColumn.AllowEdit = false;
            this.ColAciklama.OptionsColumn.AllowFocus = false;
            this.ColAciklama.Visible = true;
            this.ColAciklama.VisibleIndex = 1;
            this.ColAciklama.Width = 420;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Kullanıcı Id";
            this.myGridColumn2.FieldName = "KullaniciId";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.Caption = "İşlem Tarihi";
            this.myGridColumn3.FieldName = "IslemTarihi";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.OptionsColumn.AllowEdit = false;
            this.myGridColumn3.OptionsColumn.AllowFocus = false;
            this.myGridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 425);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 25);
            this.panelControl1.TabIndex = 7;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(697, 2);
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
            // MeslekListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "MeslekListForm";
            this.Tag = "9";
            this.Text = "Meslek Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Components.MyGridControl myGridControl1;
        private Controls.Components.MyGridView tablo;
        private Controls.Components.MyGridColumn colId;
        private Controls.Components.MyGridColumn colGorevAdi;
        private Controls.Components.MyGridColumn ColAciklama;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyGridColumn myGridColumn3;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
    }
}