namespace OgrenciTakipMuh.Forms.ListForms
{
    partial class PersonelListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelListForm));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colKalanBakiye = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.bandedGrid = new OgrenciTakipMuh.Controls.Components.MyBandedGridControl();
            this.tablo = new OgrenciTakipMuh.Controls.Components.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTcKimlikNo = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colPersonelAdiSoyadi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colGoreAdi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colBaslamaTarihi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colOgrenciAciklama = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colMaasOdemeGunu = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colOtomatikMaas = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.ColTahakkukTutari = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSonMaasTahakkukTarihi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colHakedilenMaas = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn1 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colOdenen = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTel = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colEmailAdresi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colAdres = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colBankaAdi = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colIbanNo = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.myBandedGridColumn2 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
            this.myBandedGridColumn3 = new OgrenciTakipMuh.Controls.Components.MyBandedGridColumn();
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
            this.ribbonControl1.Size = new System.Drawing.Size(835, 104);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.Image")));
            this.btnTahsilat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTahsilat.ImageOptions.LargeImage")));
            this.btnTahsilat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTahsilat.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // colKalanBakiye
            // 
            this.colKalanBakiye.Caption = "KalanBakiye";
            this.colKalanBakiye.DisplayFormat.FormatString = "n2";
            this.colKalanBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKalanBakiye.FieldName = "KalanBakiye";
            this.colKalanBakiye.Name = "colKalanBakiye";
            this.colKalanBakiye.OptionsColumn.AllowEdit = false;
            this.colKalanBakiye.OptionsColumn.AllowFocus = false;
            this.colKalanBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KalanBakiye", "{0:n2}")});
            this.colKalanBakiye.Visible = true;
            this.colKalanBakiye.Width = 130;
            // 
            // bandedGrid
            // 
            this.bandedGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bandedGrid.Location = new System.Drawing.Point(0, 104);
            this.bandedGrid.MainView = this.tablo;
            this.bandedGrid.MenuManager = this.ribbonControl1;
            this.bandedGrid.Name = "bandedGrid";
            this.bandedGrid.Size = new System.Drawing.Size(835, 341);
            this.bandedGrid.TabIndex = 7;
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
            this.gridBand3,
            this.gridBand5,
            this.gridBand2,
            this.gridBand4});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colTcKimlikNo,
            this.colPersonelAdiSoyadi,
            this.colGoreAdi,
            this.colTel,
            this.colEmailAdresi,
            this.colAdres,
            this.colOgrenciAciklama,
            this.colBaslamaTarihi,
            this.ColTahakkukTutari,
            this.colMaasOdemeGunu,
            this.colIbanNo,
            this.colBankaAdi,
            this.colHakedilenMaas,
            this.colOdenen,
            this.colKalanBakiye,
            this.colOtomatikMaas,
            this.colSonMaasTahakkukTarihi,
            this.myBandedGridColumn1,
            this.myBandedGridColumn2,
            this.myBandedGridColumn3});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colKalanBakiye;
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
            this.tablo.ViewCaption = "Personel Listesi";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Personel Bilgileri";
            this.gridBand1.Columns.Add(this.colTcKimlikNo);
            this.gridBand1.Columns.Add(this.colPersonelAdiSoyadi);
            this.gridBand1.Columns.Add(this.colGoreAdi);
            this.gridBand1.Columns.Add(this.colBaslamaTarihi);
            this.gridBand1.Columns.Add(this.colOgrenciAciklama);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 509;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.AppearanceCell.Options.UseTextOptions = true;
            this.colTcKimlikNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTcKimlikNo.Caption = "Tc Kimlik No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.OptionsColumn.AllowEdit = false;
            this.colTcKimlikNo.OptionsColumn.AllowFocus = false;
            this.colTcKimlikNo.Visible = true;
            this.colTcKimlikNo.Width = 113;
            // 
            // colPersonelAdiSoyadi
            // 
            this.colPersonelAdiSoyadi.Caption = "Adı Soyadı";
            this.colPersonelAdiSoyadi.FieldName = "AdiSoyadi";
            this.colPersonelAdiSoyadi.Name = "colPersonelAdiSoyadi";
            this.colPersonelAdiSoyadi.OptionsColumn.AllowEdit = false;
            this.colPersonelAdiSoyadi.OptionsColumn.AllowFocus = false;
            this.colPersonelAdiSoyadi.Visible = true;
            this.colPersonelAdiSoyadi.Width = 171;
            // 
            // colGoreAdi
            // 
            this.colGoreAdi.Caption = "Meslek Adı";
            this.colGoreAdi.FieldName = "GorevAdi";
            this.colGoreAdi.Name = "colGoreAdi";
            this.colGoreAdi.OptionsColumn.AllowEdit = false;
            this.colGoreAdi.OptionsColumn.AllowFocus = false;
            this.colGoreAdi.Visible = true;
            this.colGoreAdi.Width = 125;
            // 
            // colBaslamaTarihi
            // 
            this.colBaslamaTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colBaslamaTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBaslamaTarihi.Caption = "Başlama Tarihi";
            this.colBaslamaTarihi.FieldName = "BaslamaTarihi";
            this.colBaslamaTarihi.Name = "colBaslamaTarihi";
            this.colBaslamaTarihi.OptionsColumn.AllowEdit = false;
            this.colBaslamaTarihi.OptionsColumn.AllowFocus = false;
            this.colBaslamaTarihi.Visible = true;
            this.colBaslamaTarihi.Width = 100;
            // 
            // colOgrenciAciklama
            // 
            this.colOgrenciAciklama.Caption = "Açıklama";
            this.colOgrenciAciklama.FieldName = "Aciklama";
            this.colOgrenciAciklama.Name = "colOgrenciAciklama";
            this.colOgrenciAciklama.OptionsColumn.AllowEdit = false;
            this.colOgrenciAciklama.OptionsColumn.AllowFocus = false;
            this.colOgrenciAciklama.Width = 300;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Maaş Bilgileri";
            this.gridBand3.Columns.Add(this.colMaasOdemeGunu);
            this.gridBand3.Columns.Add(this.colOtomatikMaas);
            this.gridBand3.Columns.Add(this.ColTahakkukTutari);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 307;
            // 
            // colMaasOdemeGunu
            // 
            this.colMaasOdemeGunu.AppearanceCell.Options.UseTextOptions = true;
            this.colMaasOdemeGunu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaasOdemeGunu.Caption = "Maaş Günü";
            this.colMaasOdemeGunu.FieldName = "MaasOdemeGunu";
            this.colMaasOdemeGunu.Name = "colMaasOdemeGunu";
            this.colMaasOdemeGunu.OptionsColumn.AllowEdit = false;
            this.colMaasOdemeGunu.OptionsColumn.AllowFocus = false;
            this.colMaasOdemeGunu.Visible = true;
            this.colMaasOdemeGunu.Width = 89;
            // 
            // colOtomatikMaas
            // 
            this.colOtomatikMaas.AppearanceCell.Options.UseTextOptions = true;
            this.colOtomatikMaas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOtomatikMaas.Caption = "Tahakkuk Şekli";
            this.colOtomatikMaas.FieldName = "TahakkukSekli";
            this.colOtomatikMaas.Name = "colOtomatikMaas";
            this.colOtomatikMaas.OptionsColumn.AllowEdit = false;
            this.colOtomatikMaas.OptionsColumn.AllowFocus = false;
            this.colOtomatikMaas.Visible = true;
            this.colOtomatikMaas.Width = 131;
            // 
            // ColTahakkukTutari
            // 
            this.ColTahakkukTutari.Caption = "Maaş Tutarı";
            this.ColTahakkukTutari.DisplayFormat.FormatString = "n2";
            this.ColTahakkukTutari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColTahakkukTutari.FieldName = "Maas";
            this.ColTahakkukTutari.Name = "ColTahakkukTutari";
            this.ColTahakkukTutari.OptionsColumn.AllowEdit = false;
            this.ColTahakkukTutari.OptionsColumn.AllowFocus = false;
            this.ColTahakkukTutari.Visible = true;
            this.ColTahakkukTutari.Width = 87;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridBand5.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand5.Caption = "Tahakkuk Bilgileri";
            this.gridBand5.Columns.Add(this.colSonMaasTahakkukTarihi);
            this.gridBand5.Columns.Add(this.colHakedilenMaas);
            this.gridBand5.Columns.Add(this.myBandedGridColumn1);
            this.gridBand5.Columns.Add(this.colOdenen);
            this.gridBand5.Columns.Add(this.colKalanBakiye);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 528;
            // 
            // colSonMaasTahakkukTarihi
            // 
            this.colSonMaasTahakkukTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colSonMaasTahakkukTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSonMaasTahakkukTarihi.Caption = "Son Maaş Tahakkuk Tarihi";
            this.colSonMaasTahakkukTarihi.FieldName = "SonMaasTahakkukTarihi";
            this.colSonMaasTahakkukTarihi.Name = "colSonMaasTahakkukTarihi";
            this.colSonMaasTahakkukTarihi.OptionsColumn.AllowEdit = false;
            this.colSonMaasTahakkukTarihi.OptionsColumn.AllowFocus = false;
            this.colSonMaasTahakkukTarihi.Visible = true;
            this.colSonMaasTahakkukTarihi.Width = 142;
            // 
            // colHakedilenMaas
            // 
            this.colHakedilenMaas.Caption = "Hakedilen Maaş Toplamı";
            this.colHakedilenMaas.DisplayFormat.FormatString = "n2";
            this.colHakedilenMaas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHakedilenMaas.FieldName = "HakedilenMaas";
            this.colHakedilenMaas.Name = "colHakedilenMaas";
            this.colHakedilenMaas.OptionsColumn.AllowEdit = false;
            this.colHakedilenMaas.OptionsColumn.AllowFocus = false;
            this.colHakedilenMaas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HakedilenMaas", "{0:n2}")});
            this.colHakedilenMaas.Visible = true;
            this.colHakedilenMaas.Width = 126;
            // 
            // myBandedGridColumn1
            // 
            this.myBandedGridColumn1.Caption = "Toplam İade";
            this.myBandedGridColumn1.DisplayFormat.FormatString = "n2";
            this.myBandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.myBandedGridColumn1.FieldName = "ToplamIade";
            this.myBandedGridColumn1.Name = "myBandedGridColumn1";
            this.myBandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn1.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamIade", "{0:n2}")});
            this.myBandedGridColumn1.Width = 100;
            // 
            // colOdenen
            // 
            this.colOdenen.Caption = "Ödenen Toplam Maaş";
            this.colOdenen.DisplayFormat.FormatString = "n2";
            this.colOdenen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOdenen.FieldName = "OdenenMaas";
            this.colOdenen.Name = "colOdenen";
            this.colOdenen.OptionsColumn.AllowEdit = false;
            this.colOdenen.OptionsColumn.AllowFocus = false;
            this.colOdenen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OdenenMaas", "{0:n2}")});
            this.colOdenen.Visible = true;
            this.colOdenen.Width = 130;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "İletişim Bilgileri";
            this.gridBand2.Columns.Add(this.colTel);
            this.gridBand2.Columns.Add(this.colEmailAdresi);
            this.gridBand2.Columns.Add(this.colAdres);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Visible = false;
            this.gridBand2.VisibleIndex = -1;
            this.gridBand2.Width = 579;
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
            // colEmailAdresi
            // 
            this.colEmailAdresi.Caption = "EmailAdresi";
            this.colEmailAdresi.FieldName = "EmailAdresi";
            this.colEmailAdresi.Name = "colEmailAdresi";
            this.colEmailAdresi.OptionsColumn.AllowEdit = false;
            this.colEmailAdresi.OptionsColumn.AllowFocus = false;
            this.colEmailAdresi.Visible = true;
            this.colEmailAdresi.Width = 107;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.OptionsColumn.AllowFocus = false;
            this.colAdres.Visible = true;
            this.colAdres.Width = 296;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Hesap Bilgileri";
            this.gridBand4.Columns.Add(this.colBankaAdi);
            this.gridBand4.Columns.Add(this.colIbanNo);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            this.gridBand4.VisibleIndex = -1;
            this.gridBand4.Width = 150;
            // 
            // colBankaAdi
            // 
            this.colBankaAdi.Caption = "Banka";
            this.colBankaAdi.FieldName = "BankaAdi";
            this.colBankaAdi.Name = "colBankaAdi";
            this.colBankaAdi.OptionsColumn.AllowEdit = false;
            this.colBankaAdi.OptionsColumn.AllowFocus = false;
            this.colBankaAdi.Visible = true;
            // 
            // colIbanNo
            // 
            this.colIbanNo.Caption = "IbanNo";
            this.colIbanNo.FieldName = "IbanNo";
            this.colIbanNo.Name = "colIbanNo";
            this.colIbanNo.OptionsColumn.AllowEdit = false;
            this.colIbanNo.OptionsColumn.AllowFocus = false;
            this.colIbanNo.Visible = true;
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
            // 
            // myBandedGridColumn2
            // 
            this.myBandedGridColumn2.Caption = "İşlem Tarihi";
            this.myBandedGridColumn2.FieldName = "IslemTarihi";
            this.myBandedGridColumn2.Name = "myBandedGridColumn2";
            this.myBandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn2.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // myBandedGridColumn3
            // 
            this.myBandedGridColumn3.Caption = "Kullanıcı Id";
            this.myBandedGridColumn3.FieldName = "KullaniciId";
            this.myBandedGridColumn3.Name = "myBandedGridColumn3";
            this.myBandedGridColumn3.OptionsColumn.AllowEdit = false;
            this.myBandedGridColumn3.OptionsColumn.AllowFocus = false;
            this.myBandedGridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.controlNavigator);
            this.panelControl1.Controls.Add(this.tglDurum);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 445);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(835, 25);
            this.panelControl1.TabIndex = 8;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Options.UseTextOptions = true;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBilgi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBilgi.Location = new System.Drawing.Point(635, 2);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblBilgi.Size = new System.Drawing.Size(101, 17);
            this.lblBilgi.TabIndex = 12;
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
            this.tglDurum.Location = new System.Drawing.Point(736, 2);
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
            // PersonelListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 470);
            this.Controls.Add(this.bandedGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "PersonelListForm";
            this.Tag = "8";
            this.Text = "Personel Listesi";
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
        private Controls.Components.MyBandedGridColumn colTcKimlikNo;
        private Controls.Components.MyBandedGridColumn colPersonelAdiSoyadi;
        private Controls.Components.MyBandedGridColumn colBaslamaTarihi;
        private Controls.Components.MyBandedGridColumn colTel;
        private Controls.Components.MyBandedGridColumn colEmailAdresi;
        private Controls.Components.MyBandedGridColumn colAdres;
        private Controls.Components.MyBandedGridColumn colOgrenciAciklama;
        private Controls.Components.MyBandedGridColumn ColTahakkukTutari;
        private Controls.Components.MyBandedGridColumn colKalanBakiye;
        private Controls.Components.MyBandedGridColumn colGoreAdi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Controls.Components.MyToogleSwitch tglDurum;
        private Controls.Components.MyBandedGridColumn colMaasOdemeGunu;
        private Controls.Components.MyBandedGridColumn colHakedilenMaas;
        private Controls.Components.MyBandedGridColumn colOdenen;
        private Controls.Components.MyBandedGridColumn colBankaAdi;
        private Controls.Components.MyBandedGridColumn colIbanNo;
        private Controls.Components.MyBandedGridColumn colOtomatikMaas;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private Controls.Components.MyBandedGridColumn colSonMaasTahakkukTarihi;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn2;
        private Controls.Components.MyBandedGridColumn myBandedGridColumn3;
        private DevExpress.XtraEditors.LabelControl lblBilgi;
    }
}