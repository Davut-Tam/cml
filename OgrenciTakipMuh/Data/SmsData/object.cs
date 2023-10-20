using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.SmsData
{
    public class @object
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> Data { get; set; }
    }


    public class Data
    {
        public string GonderimZaman { get; set; }
        public DateTime? Gonderim { get { return Convert.ToDateTime(GonderimZaman, System.Globalization.CultureInfo.InstalledUICulture);} set { } }
        public string smsGuidText { get; set; }
        public string Mesaj { get; set; }
        public int KisiAdet { get; set; }
        public int IletilenAdet { get; set; }
        public int BekleyenAdet { get; set; }
        public int IletilmeyenAdet { get; set; }
    }


    public class Root
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Datum> Data { get; set; }
    }
    public class Datum
    {
        public string AdSoyad { get; set; }
        public string Durum { get; set; }
        public string Durum2 { get { return Durum.Substring(2, Durum.Length-2); } }
        public string Gsm { get; set; }
        public string Gsm2 { get { return Gsm.TelefonFormati(); } set { } }
        public string Mesaj { get; set; }
        public DateTime? gonderimZaman { get; set; }
        public DateTime? iletimZaman { get; set; }

    }

    public class Telefonlar
    {
        public string AdiSoyadi { get; }
        public string Telefon { get;  }

    }
}
