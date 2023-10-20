namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class KullaniciListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciListForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.myGridControl1 = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn4 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn5 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn6 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn7 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn8 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn9 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn10 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOtomatikKapanma = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOtomatikKapanmaSuresi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1115, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 478);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1115, 25);
            this.panelControl1.TabIndex = 8;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(1012, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 11;
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
            this.myGridControl1.Location = new System.Drawing.Point(0, 104);
            this.myGridControl1.MainView = this.tablo;
            this.myGridControl1.MenuManager = this.ribbonControl1;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(1115, 374);
            this.myGridControl1.TabIndex = 9;
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
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.ViewCaption.Options.UseFont = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.myGridColumn1,
            this.myGridColumn2,
            this.myGridColumn3,
            this.myGridColumn4,
            this.myGridColumn5,
            this.myGridColumn6,
            this.myGridColumn7,
            this.myGridColumn8,
            this.myGridColumn9,
            this.myGridColumn10,
            this.colOtomatikKapanma,
            this.colOtomatikKapanmaSuresi});
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
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Kullanıcı Listesi";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.Caption = "Kullanıcı Türü";
            this.myGridColumn1.FieldName = "KullaniciTuru";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.OptionsColumn.AllowEdit = false;
            this.myGridColumn1.OptionsColumn.AllowFocus = false;
            this.myGridColumn1.Visible = true;
            this.myGridColumn1.VisibleIndex = 0;
            this.myGridColumn1.Width = 97;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Adı Soyadı";
            this.myGridColumn2.FieldName = "AdiSoyadi";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 1;
            this.myGridColumn2.Width = 192;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.Caption = "Kullanıcı Adı";
            this.myGridColumn3.FieldName = "KullaniciAdi";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.OptionsColumn.AllowEdit = false;
            this.myGridColumn3.OptionsColumn.AllowFocus = false;
            this.myGridColumn3.Visible = true;
            this.myGridColumn3.VisibleIndex = 2;
            this.myGridColumn3.Width = 93;
            // 
            // myGridColumn4
            // 
            this.myGridColumn4.Caption = "Şifre";
            this.myGridColumn4.FieldName = "Sifre";
            this.myGridColumn4.Name = "myGridColumn4";
            this.myGridColumn4.OptionsColumn.AllowEdit = false;
            this.myGridColumn4.OptionsColumn.AllowFocus = false;
            this.myGridColumn4.Visible = true;
            this.myGridColumn4.VisibleIndex = 3;
            this.myGridColumn4.Width = 84;
            // 
            // myGridColumn5
            // 
            this.myGridColumn5.Caption = "Program Rolü";
            this.myGridColumn5.FieldName = "RolAdi";
            this.myGridColumn5.Name = "myGridColumn5";
            this.myGridColumn5.OptionsColumn.AllowEdit = false;
            this.myGridColumn5.OptionsColumn.AllowFocus = false;
            this.myGridColumn5.Visible = true;
            this.myGridColumn5.VisibleIndex = 4;
            this.myGridColumn5.Width = 192;
            // 
            // myGridColumn6
            // 
            this.myGridColumn6.Caption = "Tema";
            this.myGridColumn6.FieldName = "Tema";
            this.myGridColumn6.Name = "myGridColumn6";
            this.myGridColumn6.OptionsColumn.AllowEdit = false;
            this.myGridColumn6.OptionsColumn.AllowFocus = false;
            this.myGridColumn6.Visible = true;
            this.myGridColumn6.VisibleIndex = 5;
            this.myGridColumn6.Width = 129;
            // 
            // myGridColumn7
            // 
            this.myGridColumn7.Caption = "Tema Parametre";
            this.myGridColumn7.FieldName = "TemaParametre";
            this.myGridColumn7.Name = "myGridColumn7";
            this.myGridColumn7.OptionsColumn.AllowEdit = false;
            this.myGridColumn7.OptionsColumn.AllowFocus = false;
            this.myGridColumn7.Visible = true;
            this.myGridColumn7.VisibleIndex = 6;
            this.myGridColumn7.Width = 111;
            // 
            // myGridColumn8
            // 
            this.myGridColumn8.Caption = "Açıklama";
            this.myGridColumn8.FieldName = "Aciklama";
            this.myGridColumn8.Name = "myGridColumn8";
            this.myGridColumn8.OptionsColumn.AllowEdit = false;
            this.myGridColumn8.OptionsColumn.AllowFocus = false;
            this.myGridColumn8.Visible = true;
            this.myGridColumn8.VisibleIndex = 9;
            this.myGridColumn8.Width = 400;
            // 
            // myGridColumn9
            // 
            this.myGridColumn9.Caption = "Kullanıcı Id";
            this.myGridColumn9.FieldName = "KullaniciId";
            this.myGridColumn9.Name = "myGridColumn9";
            this.myGridColumn9.OptionsColumn.AllowEdit = false;
            this.myGridColumn9.OptionsColumn.AllowFocus = false;
            this.myGridColumn9.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn10
            // 
            this.myGridColumn10.Caption = "İşlem Tarihi";
            this.myGridColumn10.FieldName = "IslemTarihi";
            this.myGridColumn10.Name = "myGridColumn10";
            this.myGridColumn10.OptionsColumn.AllowEdit = false;
            this.myGridColumn10.OptionsColumn.AllowFocus = false;
            this.myGridColumn10.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colOtomatikKapanma
            // 
            this.colOtomatikKapanma.Caption = "Oto Kapanma";
            this.colOtomatikKapanma.FieldName = "OtoKapanma";
            this.colOtomatikKapanma.Name = "colOtomatikKapanma";
            this.colOtomatikKapanma.OptionsColumn.AllowEdit = false;
            this.colOtomatikKapanma.OptionsColumn.AllowFocus = false;
            this.colOtomatikKapanma.Visible = true;
            this.colOtomatikKapanma.VisibleIndex = 7;
            this.colOtomatikKapanma.Width = 85;
            // 
            // colOtomatikKapanmaSuresi
            // 
            this.colOtomatikKapanmaSuresi.AppearanceCell.Options.UseTextOptions = true;
            this.colOtomatikKapanmaSuresi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOtomatikKapanmaSuresi.Caption = "Oto Kapanma Süresi (dk)";
            this.colOtomatikKapanmaSuresi.DisplayFormat.FormatString = "n0";
            this.colOtomatikKapanmaSuresi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtomatikKapanmaSuresi.FieldName = "OtoKapanmaSuresi";
            this.colOtomatikKapanmaSuresi.Name = "colOtomatikKapanmaSuresi";
            this.colOtomatikKapanmaSuresi.OptionsColumn.AllowEdit = false;
            this.colOtomatikKapanmaSuresi.OptionsColumn.AllowFocus = false;
            this.colOtomatikKapanmaSuresi.Visible = true;
            this.colOtomatikKapanmaSuresi.VisibleIndex = 8;
            this.colOtomatikKapanmaSuresi.Width = 133;
            // 
            // KullaniciListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 503);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "KullaniciListForm";
            this.Text = "Kullanıcı Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridControl myGridControl1;
        private Controls.Components.MyGridView tablo;
        private Controls.Components.MyGridColumn colId;
        private Controls.Components.MyGridColumn myGridColumn1;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyGridColumn myGridColumn3;
        private Controls.Components.MyGridColumn myGridColumn4;
        private Controls.Components.MyGridColumn myGridColumn5;
        private Controls.Components.MyGridColumn myGridColumn6;
        private Controls.Components.MyGridColumn myGridColumn7;
        private Controls.Components.MyGridColumn myGridColumn8;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private Controls.Components.MyGridColumn myGridColumn9;
        private Controls.Components.MyGridColumn myGridColumn10;
        private Controls.Components.MyGridColumn colOtomatikKapanma;
        private Controls.Components.MyGridColumn colOtomatikKapanmaSuresi;
    }
}