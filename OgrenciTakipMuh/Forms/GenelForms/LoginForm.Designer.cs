namespace OgrenciTakipMuh.Forms.GenelForms
{
    partial class LoginForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pcLogo = new DevExpress.XtraEditors.PictureEdit();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkBeniHatirla = new DevExpress.XtraEditors.CheckEdit();
            this.txtKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.pcLogo);
            this.panelControl1.Controls.Add(this.txtSifre);
            this.panelControl1.Controls.Add(this.txtKullaniciAdi);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.chkBeniHatirla);
            this.panelControl1.Controls.Add(this.txtKapat);
            this.panelControl1.Controls.Add(this.btnGiris);
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(406, 188);
            this.panelControl1.TabIndex = 0;
            // 
            // pcLogo
            // 
            this.pcLogo.Location = new System.Drawing.Point(10, 23);
            this.pcLogo.Name = "pcLogo";
            this.pcLogo.Properties.AllowFocused = false;
            this.pcLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pcLogo.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.pcLogo.Properties.Appearance.Options.UseBackColor = true;
            this.pcLogo.Properties.Appearance.Options.UseBorderColor = true;
            this.pcLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pcLogo.Properties.NullText = " ";
            this.pcLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pcLogo.Properties.ShowMenu = false;
            this.pcLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pcLogo.Size = new System.Drawing.Size(205, 138);
            this.pcLogo.TabIndex = 9;
            this.pcLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcLogo_MouseDown);
            // 
            // txtSifre
            // 
            this.txtSifre.EditValue = "";
            this.txtSifre.EnterMoveNextControl = true;
            this.txtSifre.Location = new System.Drawing.Point(243, 86);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSifre.Properties.Appearance.Options.UseBackColor = true;
            this.txtSifre.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSifre.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSifre.Properties.MaxLength = 6;
            this.txtSifre.Properties.PasswordChar = '◆';
            this.txtSifre.Size = new System.Drawing.Size(130, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EditValue = "";
            this.txtKullaniciAdi.EnterMoveNextControl = true;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(243, 45);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtKullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txtKullaniciAdi.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKullaniciAdi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtKullaniciAdi.Properties.MaxLength = 20;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(130, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Versiyon: 1.0.0.2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(243, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 17);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Şifre";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(243, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 17);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // chkBeniHatirla
            // 
            this.chkBeniHatirla.Location = new System.Drawing.Point(269, 160);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkBeniHatirla.Properties.Appearance.Options.UseForeColor = true;
            this.chkBeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chkBeniHatirla.Size = new System.Drawing.Size(89, 19);
            this.chkBeniHatirla.TabIndex = 3;
            // 
            // txtKapat
            // 
            this.txtKapat.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtKapat.Appearance.BorderColor = System.Drawing.Color.White;
            this.txtKapat.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtKapat.Appearance.Options.UseBackColor = true;
            this.txtKapat.Appearance.Options.UseBorderColor = true;
            this.txtKapat.Appearance.Options.UseForeColor = true;
            this.txtKapat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtKapat.Location = new System.Drawing.Point(243, 118);
            this.txtKapat.Name = "txtKapat";
            this.txtKapat.Size = new System.Drawing.Size(61, 23);
            this.txtKapat.TabIndex = 4;
            this.txtKapat.Text = "Kapat";
            this.txtKapat.Click += new System.EventHandler(this.TxtKapat_Click);
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnGiris.Appearance.BorderColor = System.Drawing.Color.White;
            this.btnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Appearance.Options.UseBackColor = true;
            this.btnGiris.Appearance.Options.UseBorderColor = true;
            this.btnGiris.Appearance.Options.UseForeColor = true;
            this.btnGiris.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnGiris.Location = new System.Drawing.Point(310, 118);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(63, 23);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 197);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "LoginForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkBeniHatirla;
        private DevExpress.XtraEditors.SimpleButton txtKapat;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PictureEdit pcLogo;
    }
}