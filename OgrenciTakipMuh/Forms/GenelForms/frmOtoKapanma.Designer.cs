namespace OgrenciTakipMuh.Forms.GenelForms
{
    partial class frmOtoKapanma
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
            this.lblkapanmaSuresi = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblkapanmaSuresi
            // 
            this.lblkapanmaSuresi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblkapanmaSuresi.Appearance.Options.UseFont = true;
            this.lblkapanmaSuresi.Appearance.Options.UseTextOptions = true;
            this.lblkapanmaSuresi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblkapanmaSuresi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblkapanmaSuresi.Location = new System.Drawing.Point(13, 2);
            this.lblkapanmaSuresi.Name = "lblkapanmaSuresi";
            this.lblkapanmaSuresi.Size = new System.Drawing.Size(238, 61);
            this.lblkapanmaSuresi.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(79, 69);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 24);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "İptal";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOtoKapanma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 99);
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblkapanmaSuresi);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOtoKapanma";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                     Öğrenci Takip Sitemi";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblkapanmaSuresi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Timer timer1;
    }
}