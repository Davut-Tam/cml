using OgrenciTakipMuh.Enums;
using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.Media;

namespace OgrenciTakipMuh.Tools
{
    public static class SesFunctions
    {
        public static void IslemSesi(Ses ses)
        {
            if (!AnaForm.GenAyr.KayitSesi) return;
            try
            {
                SoundPlayer audio;
                switch (ses)
                {
                    case Ses.Kaydet:
                        audio = new SoundPlayer(Properties.Resources.Kaydet);
                        audio.Play();
                        break;
                    case Ses.Güncelle:
                        audio = new SoundPlayer(Properties.Resources.Guncelle);
                        audio.Play();
                        break;
                    case Ses.Sil:
                        audio = new SoundPlayer(Properties.Resources.Sil);
                        audio.Play();
                        break;
                }
            }
            catch (Exception) { }
        }
    }
}