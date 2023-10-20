using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.UserSkins;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Tools;

namespace OgrenciTakipMuh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GenelFunctions.BaglantiSifreleme(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

            DefaultListelerF.MenuListesiKontrol();

            // Yönetici var mı yok mu kontrolü
            if (KullaniciF.KullaniciKontrolu() <= 0)
            {
                KullaniciEditForm fr = new KullaniciEditForm(0) { Text = "Yönetici Kaydı" };
                fr.txtKullaniciTuru.Text = "Yönetici";
                fr.IlkYoneticiTanimi = true;
                fr.txtKullaniciTuru.Enabled = false;
                fr.ShowDialog();
                fr.Dispose();
                if (fr.KayitVar)
                    Messages.BilgiMesaji("Yönetici Tanımlandı. Yeniden Griş Yapabilirsiniz");
                Application.Exit();
            }
            else
                Application.Run(new LoginForm());
        }
    }
}
