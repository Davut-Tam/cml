﻿namespace OgrenciTakipMuh.Forms.EditForms
{
    partial class SinifEditForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl1 = new OgrenciTakipMuh.Controls.Components.MyDataLayoutControl();
            this.txtGrupAdi = new OgrenciTakipMuh.Controls.Components.MyComboBoxEdit();
            this.txtDonem = new OgrenciTakipMuh.Controls.Components.MyComboBoxEdit();
            this.txtSinifAdi = new OgrenciTakipMuh.Controls.Components.MyTextEdit();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtAciklama = new OgrenciTakipMuh.Controls.Components.MyMemoEdit();
            this.myTextEdit1 = new OgrenciTakipMuh.Controls.Components.MyTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinifAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.txtGrupAdi);
            this.myDataLayoutControl1.Controls.Add(this.txtDonem);
            this.myDataLayoutControl1.Controls.Add(this.txtSinifAdi);
            this.myDataLayoutControl1.Controls.Add(this.btnIptal);
            this.myDataLayoutControl1.Controls.Add(this.btnSil);
            this.myDataLayoutControl1.Controls.Add(this.btnKaydet);
            this.myDataLayoutControl1.Controls.Add(this.txtAciklama);
            this.myDataLayoutControl1.Controls.Add(this.myTextEdit1);
            this.myDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.myDataLayoutControl1.Name = "myDataLayoutControl1";
            this.myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl1.Root = this.layoutControlGroup1;
            this.myDataLayoutControl1.Size = new System.Drawing.Size(419, 151);
            this.myDataLayoutControl1.TabIndex = 0;
            this.myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtGrupAdi
            // 
            this.txtGrupAdi.EnterMoveNextControl = true;
            this.txtGrupAdi.Location = new System.Drawing.Point(87, 36);
            this.txtGrupAdi.Name = "txtGrupAdi";
            this.txtGrupAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtGrupAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtGrupAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtGrupAdi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtGrupAdi.Size = new System.Drawing.Size(221, 20);
            this.txtGrupAdi.StyleController = this.myDataLayoutControl1;
            this.txtGrupAdi.TabIndex = 0;
            this.txtGrupAdi.SelectedIndexChanged += new System.EventHandler(this.txtGrup_SelectedIndexChanged);
            // 
            // txtDonem
            // 
            this.txtDonem.Enabled = false;
            this.txtDonem.EnterMoveNextControl = true;
            this.txtDonem.Location = new System.Drawing.Point(87, 12);
            this.txtDonem.Name = "txtDonem";
            this.txtDonem.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtDonem.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDonem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtDonem.Size = new System.Drawing.Size(121, 20);
            this.txtDonem.StyleController = this.myDataLayoutControl1;
            this.txtDonem.TabIndex = 0;
            this.txtDonem.Tag = "0";
            // 
            // txtSinifAdi
            // 
            this.txtSinifAdi.EnterMoveNextControl = true;
            this.txtSinifAdi.Location = new System.Drawing.Point(87, 60);
            this.txtSinifAdi.Name = "txtSinifAdi";
            this.txtSinifAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtSinifAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSinifAdi.Properties.MaxLength = 50;
            this.txtSinifAdi.Size = new System.Drawing.Size(221, 20);
            this.txtSinifAdi.StyleController = this.myDataLayoutControl1;
            this.txtSinifAdi.TabIndex = 1;
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Location = new System.Drawing.Point(312, 84);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(95, 20);
            this.btnIptal.StyleController = this.myDataLayoutControl1;
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Location = new System.Drawing.Point(312, 60);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(95, 20);
            this.btnSil.StyleController = this.myDataLayoutControl1;
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Location = new System.Drawing.Point(312, 36);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(95, 20);
            this.btnKaydet.StyleController = this.myDataLayoutControl1;
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.EnterMoveNextControl = true;
            this.txtAciklama.Location = new System.Drawing.Point(87, 84);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtAciklama.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtAciklama.Properties.MaxLength = 500;
            this.txtAciklama.Size = new System.Drawing.Size(221, 55);
            this.txtAciklama.StyleController = this.myDataLayoutControl1;
            this.txtAciklama.TabIndex = 2;
            // 
            // myTextEdit1
            // 
            this.myTextEdit1.EnterMoveNextControl = true;
            this.myTextEdit1.Location = new System.Drawing.Point(374, 60);
            this.myTextEdit1.Name = "myTextEdit1";
            this.myTextEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.myTextEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.myTextEdit1.Properties.MaxLength = 50;
            this.myTextEdit1.Size = new System.Drawing.Size(0, 20);
            this.myTextEdit1.StyleController = this.myDataLayoutControl1;
            this.myTextEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem7});
            this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 200D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 99D;
            this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 24D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition4.Height = 24D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition5.Height = 24D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5});
            this.layoutControlGroup1.Size = new System.Drawing.Size(419, 151);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.btnKaydet;
            this.layoutControlItem4.Location = new System.Drawing.Point(300, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem4.Size = new System.Drawing.Size(99, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.btnSil;
            this.layoutControlItem3.Location = new System.Drawing.Point(300, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(99, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.btnIptal;
            this.layoutControlItem1.Location = new System.Drawing.Point(300, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem1.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem1.Size = new System.Drawing.Size(99, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.txtDonem;
            this.layoutControlItem6.Enabled = false;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem6.Text = "Dönem";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtSinifAdi;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem5.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem5.Text = "Sınıf Adı";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAciklama;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem2.OptionsTableLayoutItem.RowSpan = 2;
            this.layoutControlItem2.Size = new System.Drawing.Size(300, 59);
            this.layoutControlItem2.Text = "Açıklama";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtGrupAdi;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem7.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem7.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem7.Text = "Grup";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // SinifEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 151);
            this.Controls.Add(this.myDataLayoutControl1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 190);
            this.Name = "SinifEditForm";
            this.Text = "Sınıf Kartı";
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).EndInit();
            this.myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGrupAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinifAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OgrenciTakipMuh.Controls.Components.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private OgrenciTakipMuh.Controls.Components.MyMemoEdit txtAciklama;
        private OgrenciTakipMuh.Controls.Components.MyTextEdit myTextEdit1;
        private OgrenciTakipMuh.Controls.Components.MyTextEdit txtSinifAdi;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private OgrenciTakipMuh.Controls.Components.MyComboBoxEdit txtDonem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private OgrenciTakipMuh.Controls.Components.MyComboBoxEdit txtGrupAdi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}