using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Enums;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Forms.MenuForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Tools
{
    public static class GenelFunctions
    {
        public static void ShowPopupMenu(this MouseEventArgs e, PopupMenu popupMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            popupMenu.ShowPopup(Control.MousePosition);//mausenin olduğu yerde açma
        }


        public static List<string> YaziciListesi()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }

        public static string VarsayilanYazici()
        {
            var settings = new PrinterSettings();
            return settings.PrinterName;
        }

        public static long IdOlustur()
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                    return "0" + deger;
                return deger;
            }

            string UcbasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;


                }
                return deger;
            }

            string Id()
            {
                var yil = DateTime.Now.Year.ToString();
                var ay = SifirEkle(DateTime.Now.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var miliSaniye = UcbasamakYap(DateTime.Now.Millisecond.ToString());
                var random = SifirEkle(new Random().Next(0, 99).ToString());

                return yil + ay + gun + saat + dakika + saniye + miliSaniye + random;
            }
            var id = Id();
            return long.Parse(Id());
        }


        public static void RowFocus(this GridView tablo, string aranacakKolon, object aranacakDeger)
        {
            var rowHandle = 0;
            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);
                if (aranacakDeger.Equals(bulunanDeger))
                    rowHandle = i;

            }

            tablo.FocusedRowHandle = rowHandle;
        }

    
        public static Image ByteToImageConvert(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception)
            {
                return null;

            }

        }

        public static void BaglantiSifreleme(string configFileName, params string[] sectionName)
        {
            var conf = ConfigurationManager.OpenExeConfiguration(configFileName);

            foreach (var x in sectionName)
            {
                var section = conf.GetSection(x);
                if (section.SectionInformation.IsProtected)
                    return;
                else
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

                section.SectionInformation.ForceSave = true;
                conf.Save();

            }
        }

        public static long SecilenOgrenciId()
        {
            if (AnaForm.KullaniciTuru != "Yönetici")
            {
                var kont = RolF.Kontroller(1);
                if (kont.Gorebilir != 1)
                {
                    Messages.YetkinizYokMesaji("Öğrenci listesine erişim yetkiniz yok");
                    return 0;
                }
            }
 

            Cursor.Current = Cursors.WaitCursor;
            OgrenciListForm frm = new OgrenciListForm(true) { Text = "Öğrenci Seç" };
            frm.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            var id = frm.OgrenciId;
            frm.Dispose();
            return id;

        }

        public static long SecilenDonemId()
        {

            if (AnaForm.KullaniciTuru != "Yönetici")
            {
                var kont = RolF.Kontroller(5);
                if (kont.Gorebilir != 1)
                {
                    Messages.YetkinizYokMesaji("Dönemler listesine erişim yetkiniz yok");
                    return 0;
                }
            }
 

            Cursor.Current = Cursors.WaitCursor;
            DonemListForm frm = new DonemListForm(true) { Text = "Dönem Seç" };
            frm.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            var id = frm.donemId;
            frm.Dispose();
            return id;

        }

        public static long SecilenDonemId(long kayitDisiDonemId)
        {

            if (AnaForm.KullaniciTuru != "Yönetici")
            {
                var kont = RolF.Kontroller(5);
                if (kont.Gorebilir != 1)
                {
                    Messages.YetkinizYokMesaji("Dönemler listesine erişim yetkiniz yok");
                    return 0;
                }
            }


            Cursor.Current = Cursors.WaitCursor;
            DonemListForm frm = new DonemListForm(true, kayitDisiDonemId) { Text = "Aktarılacak Dönem Seç" };
            frm.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            var id = frm.donemId;
            frm.Dispose();
            return id;

        }

        public static bool InternetKontrol(bool mesajver = true)
        {
            var baglanti = InternetBaglantisi();

            if (!baglanti && mesajver)
                Messages.InternetBaglantisiYok();
            return baglanti;

        }
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        extern static bool InternetGetConnectedState(ref InternetGetConnectedStateFlags Description, int ReservedValue);
        [Flags]
        public enum InternetGetConnectedStateFlags
        {
            INTERNET_CONNECTION_MODEM = 0x01,
            INTERNET_CONNECTION_LAN = 0x02,
            INTERNET_CONNECTION_PROXY = 0x04,
            INTERNET_CONNECTION_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        public static bool InternetBaglantisi()
        {
            try
            {
                InternetGetConnectedStateFlags flags = 0;
                if (InternetGetConnectedState(ref flags, 0))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime IsgunuHesapla(this DateTime trh)
        {
            return trh.AddDays(AnaForm.GenAyr.BirinciSmsSuresi).DayOfWeek == DayOfWeek.Saturday ? trh.AddDays(AnaForm.GenAyr.BirinciSmsSuresi + 2) : trh.AddDays(AnaForm.GenAyr.BirinciSmsSuresi).DayOfWeek == DayOfWeek.Sunday ? trh.AddDays(AnaForm.GenAyr.BirinciSmsSuresi + 1) : trh.AddDays(AnaForm.GenAyr.BirinciSmsSuresi);

        }
        public static string TelefonFormati(this string text)
        {
            if (text.Length == 11) text = text.Substring(1, text.Length - 1);
            return $"({text.Substring(0, 3)}) {text.Substring(3, 3)} {text.Substring(6, 2)} {text.Substring(8, 2)}";
        }
    }
}
