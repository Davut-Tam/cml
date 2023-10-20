namespace OgrenciTakipMuh.Forms.MenuForms
{
    partial class VeliListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeliListForm));
            this.grid = new OgrenciTakipMuh.Controls.Components.MyGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyGridView();
            this.colId = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colVeliAdiSoyadi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colTcKimlikNo = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colTelefon = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colOgrenciSayisi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colAdres = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colAciklama = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.myGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.colGorevAdi = new OgrenciTakipMuh.Controls.Components.MyGridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.tglDurum = new OgrenciTakipMuh.Controls.Components.MyToogleSwitch();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.txtDonemAdi = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonemAdi.Properties)).BeginInit();
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
            this.ribbonControl1.MaxItemId = 25;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(951, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            this.btnTahsilat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTahsilat.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 104);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(951, 395);
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
            this.colVeliAdiSoyadi,
            this.colTcKimlikNo,
            this.colTelefon,
            this.colOgrenciSayisi,
            this.colAdres,
            this.colAciklama,
            this.myGridColumn1,
            this.myGridColumn2,
            this.colGorevAdi});
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
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.ViewCaption = "Veli Listesi";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colVeliAdiSoyadi
            // 
            this.colVeliAdiSoyadi.Caption = "Adı Soyadı";
            this.colVeliAdiSoyadi.FieldName = "VeliAdiSoyadi";
            this.colVeliAdiSoyadi.Name = "colVeliAdiSoyadi";
            this.colVeliAdiSoyadi.OptionsColumn.AllowEdit = false;
            this.colVeliAdiSoyadi.OptionsColumn.AllowFocus = false;
            this.colVeliAdiSoyadi.OptionsColumn.FixedWidth = true;
            this.colVeliAdiSoyadi.Visible = true;
            this.colVeliAdiSoyadi.VisibleIndex = 0;
            this.colVeliAdiSoyadi.Width = 154;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.Caption = "Tc Kimlik No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.OptionsColumn.AllowEdit = false;
            this.colTcKimlikNo.OptionsColumn.AllowFocus = false;
            this.colTcKimlikNo.OptionsColumn.FixedWidth = true;
            this.colTcKimlikNo.Width = 120;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefon ";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.OptionsColumn.AllowEdit = false;
            this.colTelefon.OptionsColumn.AllowFocus = false;
            this.colTelefon.OptionsColumn.FixedWidth = true;
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 2;
            this.colTelefon.Width = 120;
            // 
            // colOgrenciSayisi
            // 
            this.colOgrenciSayisi.AppearanceCell.Options.UseTextOptions = true;
            this.colOgrenciSayisi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOgrenciSayisi.Caption = "Öğrenci Sayısı";
            this.colOgrenciSayisi.FieldName = "OgrenciSayisi";
            this.colOgrenciSayisi.Name = "colOgrenciSayisi";
            this.colOgrenciSayisi.OptionsColumn.AllowEdit = false;
            this.colOgrenciSayisi.OptionsColumn.AllowFocus = false;
            this.colOgrenciSayisi.OptionsColumn.FixedWidth = true;
            this.colOgrenciSayisi.Visible = true;
            this.colOgrenciSayisi.VisibleIndex = 3;
            this.colOgrenciSayisi.Width = 100;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.OptionsColumn.AllowFocus = false;
            this.colAdres.OptionsColumn.FixedWidth = true;
            this.colAdres.Width = 400;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.OptionsColumn.AllowFocus = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 4;
            this.colAciklama.Width = 400;
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.Caption = "İşlem Tarihi";
            this.myGridColumn1.FieldName = "IslemTarihi";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.OptionsColumn.AllowEdit = false;
            this.myGridColumn1.OptionsColumn.AllowFocus = false;
            this.myGridColumn1.OptionsColumn.FixedWidth = true;
            this.myGridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Kullanıcı Id";
            this.myGridColumn2.FieldName = "KullaniciId";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.OptionsColumn.AllowEdit = false;
            this.myGridColumn2.OptionsColumn.AllowFocus = false;
            this.myGridColumn2.OptionsColumn.FixedWidth = true;
            this.myGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colGorevAdi
            // 
            this.colGorevAdi.Caption = "Meslek Adı";
            this.colGorevAdi.FieldName = "GorevAdi";
            this.colGorevAdi.Name = "colGorevAdi";
            this.colGorevAdi.OptionsColumn.AllowEdit = false;
            this.colGorevAdi.OptionsColumn.AllowFocus = false;
            this.colGorevAdi.OptionsColumn.FixedWidth = true;
            this.colGorevAdi.Visible = true;
            this.colGorevAdi.VisibleIndex = 1;
            this.colGorevAdi.Width = 161;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtDonemAdi);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.lblBilgi);
            this.panelControl2.Controls.Add(this.tglDurum);
            this.panelControl2.Controls.Add(this.controlNavigator);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 474);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(951, 25);
            this.panelControl2.TabIndex = 8;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(751, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 12;
            this.lblBilgi.Text = "Kayıt ve Tarih Bilgileri";
            // 
            // tglDurum
            // 
            this.tglDurum.Dock = System.Windows.Forms.DockStyle.Right;
            this.tglDurum.EditValue = true;
            this.tglDurum.EnterMoveNextControl = true;
            this.tglDurum.Location = new System.Drawing.Point(852, 2);
            this.tglDurum.MenuManager = this.ribbonControl1;
            this.tglDurum.Name = "tglDurum";
            this.tglDurum.Properties.AutoHeight = false;
            this.tglDurum.Properties.AutoWidth = true;
            this.tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tglDurum.Properties.OffText = "Pasif";
            this.tglDurum.Properties.OnText = "Aktif";
            this.tglDurum.Size = new System.Drawing.Size(97, 21);
            this.tglDurum.TabIndex = 11;
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
            // txtDonemAdi
            // 
            this.txtDonemAdi.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDonemAdi.Location = new System.Drawing.Point(447, 2);
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
            this.txtDonemAdi.Size = new System.Drawing.Size(135, 20);
            this.txtDonemAdi.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(370, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "      Dönem :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VeliListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 499);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.grid);
            this.MaximizeBox = false;
            this.Name = "VeliListForm";
            this.Tag = "3";
            this.Text = "Veli Listesi";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonemAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OgrenciTakipMuh.Controls.Components.MyGridControl grid;
        private OgrenciTakipMuh.Controls.Components.MyGridView tablo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colId;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colVeliAdiSoyadi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colTcKimlikNo;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colTelefon;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colOgrenciSayisi;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colAdres;
        private OgrenciTakipMuh.Controls.Components.MyGridColumn colAciklama;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyGridColumn myGridColumn1;
        private Controls.Components.MyGridColumn myGridColumn2;
        private Controls.Components.MyToogleSwitch tglDurum;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
        private Controls.Components.MyGridColumn colGorevAdi;
        private DevExpress.XtraEditors.LookUpEdit txtDonemAdi;
        private System.Windows.Forms.Label label1;
    }
}