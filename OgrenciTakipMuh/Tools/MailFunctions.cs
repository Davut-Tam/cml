using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.Net;
using System.Net.Mail;

namespace OgrenciTakipMuh.Tools
{
    public class MailFunctions
    {
        #region MailBilgileri
        // İPTAL EDİLDİ
        // dusunurkolleji@gmail.com
        // 628729000?


        // YANDEXX
        // mail şifresi: Bb5qexme7S9tmX7
        // dusunur.kolleji@yandex.com
        // Uygulama Şifresi: xkbzodscfwkalniy
        #endregion
           
        public static void MailGonder(string gonderilecekMail, string gonderilecekDosyaYolu, string mailBaslik)
        {
            if (!AnaForm.SmsVeMailGonderme) return;// programcı kontrolü
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client;


                client = new SmtpClient("smtp.yandex.com.tr", 587);
                mail.From = new MailAddress("dusunur.kolleji@yandex.com");
                mail.To.Add(gonderilecekMail + ",davuttam432@gmail.com");

                mail.Subject = mailBaslik;
                mail.Body = $"Sistem Otomatik Yedekleme Dosyası mail Ekindedir... <br>Gönderim Zamanı: {DateTime.Now}  <br>Gönderen Bilgisayar:{Dns.GetHostName()}";
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(gonderilecekDosyaYolu)); // ekleri Attachments özelliğine ekle


                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("dusunur.kolleji@yandex.com", "xkbzodscfwkalniy");
                client.EnableSsl = true;
                client.Send(mail);


            }
            catch (Exception) { }
        }
    }
}