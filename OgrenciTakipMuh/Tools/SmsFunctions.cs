using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.SmsData;
using OgrenciTakipMuh.Forms.GenelForms;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using Dapper;

namespace OgrenciTakipMuh.Tools
{
    public class SmsFunctions : IDisposable
    {
        IRestResponse response;
        const string Tırnak = "\"";
        long _OgrenciId;
        string _msj, _taksitTutar;
        List<long> _ids;
        public string  SmsBakiye()
        {
            if (!GenelFunctions.InternetKontrol(false)) return "";
            var client = new RestClient("https://apiv3.goldmesaj.net/api/kredi/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = "{" + $@"""username"":""{AnaForm.GenAyr.SmsKullaniciAdi }"",""password"":""{AnaForm.GenAyr.SmsSifre }""" + "}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            dynamic stuff = JObject.Parse(response.Content);
            return stuff.status.ToString() == "ok" ? stuff.result : ""; 
      
        }
        public bool SmsGonder(List<Sms> liste, bool bilgimesajiver, DateTime? gonderimZamani = null)
        {
            if (!AnaForm.GenAyr.SmsGonderme)
            {
                if (bilgimesajiver) Messages.UyariMesaji("Sms Gönderimi Kapalı...\nVarsayılan ayarlardan kontrol ediniz.");
                return false;
            }
            if (!GenelFunctions.InternetKontrol(bilgimesajiver)) return false;
            if (gonderimZamani != null)
                if (DateTime.Now > gonderimZamani)
                {
                    Messages.UyariMesaji("Geçmiş zamana zamanlı sms gönderemezsiniz...\nLütfen Sms Zamanını kontrol ediniz.");
                    return false;
                }

            if (bilgimesajiver)
                if (Messages.SoruHayirSeciliEvetHayir("Sms Gönderilecek Emin misiniz?", "Sms Gönderme") != DialogResult.Yes)
                    return false;

            if (bilgimesajiver) Cursor.Current = Cursors.WaitCursor;

            string hataAciklama = "";


            response = MultiSend(liste, gonderimZamani);

            dynamic stuff = JObject.Parse(response.Content);
            var durum = stuff.status.ToString() == "ok";
            hataAciklama = stuff.mesaj.ToString();


            if (durum)
                if (bilgimesajiver)
                    Messages.BilgiMesaji("Sms Gönderimi Başarılı\n(Kalan Sms Sayısı: " + stuff.result.kredi.ToString() + ")");
            else
                if (bilgimesajiver)
                    Messages.UyariMesaji("Sms Gönderimi Başarısız\n" + hataAciklama);

            return durum;
        }
        public void BirinciOtoSms(List<OgrenciCariOdemeL> liste)
        {
            var smsmsAtilmayanlar = liste.Where(x => x.BirinciHatirlatmaGunu.Date <= DateTime.Now.Date && x.BirinciHatirlatma == null && x.OtoSms);
            if (smsmsAtilmayanlar.Count() <= 0) return;

            var list = new List<Sms>();


            foreach (var oP in smsmsAtilmayanlar)
            {

                var tel1 = oP.Veli1Telefon;
                var tel2 = oP.Veli2Telefon;
                var telefonlar = new string[2];
                if (tel1 != null) telefonlar[0] = tel1.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");
                if (tel2 != null) telefonlar[1] = tel2.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");

                list.Add(new Sms
                {
                    Id = new List<long> { oP.OdemePlaniId },
                    Telefon = telefonlar,
                    Mesaj = AnaForm.GenAyr.OtoSmsMesaj
                    .Replace("[$AdıSoyadı]", oP.AdiSoyadi)
                    .Replace("[$DönemAdı]", oP.DonemAdi)
                    .Replace("[$GrupAdı]", oP.GrupAdi)
                    .Replace("[$SınıfAdı]", oP.SinifAdi)
                    .Replace("[$SonÖdemeTarihi]", oP.SonOdemeTarihi.ToShortDateString())
                    .Replace("[$TaksitNo]", oP.TaksitNo.ToString())
                    .Replace("[$Tutar]", oP.Odenecek.ToString("n2"))
                });

            }

            using (var smsF = new SmsFunctions())
            {
                if (AnaForm.SmsVeMailGonderme)// yazılımcı kontrolü
                {
                    if (smsF.SmsGonder(list, false))
                        foreach (var item in list)
                            OgrenciOdemePlaniF.BirinciSmsKayit(item.Id[0]);
                }
                else
                {
                    // deneme kayıtları
                    foreach (var item in list)
                        OgrenciOdemePlaniF.BirinciSmsKayit(item.Id[0]);
                }

            };

        }
        public void IkinciOtoSms(List<OgrenciCariOdemeL> liste)
        {
            var smsmsAtilmayanlar = liste.Where(x => x.IkinciHatirlatmaGunu.Date <= DateTime.Now.Date && x.IkinciHatirlatma == null && x.OtoSms).OrderBy(x => x.OgrenciId).ToList();
            if (smsmsAtilmayanlar.Count() <= 0) return;


            var list = new List<Sms>();
            foreach (var oP in smsmsAtilmayanlar)
            {
                // öğrencinin ödenmeyen taksitleri
                if (_OgrenciId == oP.OgrenciId) continue;
                var oplist = liste.Where(x => x.OgrenciId == oP.OgrenciId && x.IkinciHatirlatmaGunu.Date <= DateTime.Now.Date).OrderBy(x => x.DonemAdi).OrderBy(x => x.TaksitNo).ToList();

                if (oplist != null)
                {
                    _OgrenciId = oplist[0].OgrenciId;
                    _ids = new List<long>();
                    foreach (var item in oplist)
                    {
                        _taksitTutar += $"({item.SonOdemeTarihi.ToShortDateString()} son ödeme tarihli {item.TaksitNo} nolu {item.Kalan.ToString("n2")}) \n";
                        _ids.Add(item.OdemePlaniId);
                    }
                    var tekilcogul = oplist.Count() > 1 ? "taksitler" : "taksit";
                    _taksitTutar = _taksitTutar.Substring(0, _taksitTutar.Length - 2);
                    _msj = $"Sayın Velimiz\n{oplist[0].AdiSoyadi} isimli öğrencinizin {oplist[0].DonemAdi}\n{_taksitTutar} tutarındaki {tekilcogul} ödenmemiştir.\nÖdeme yaptıysanız bu mesajı dikkate almayınız.";

                }

                var tel1 = oP.Veli1Telefon;
                var tel2 = oP.Veli2Telefon;
                var telefonlar = new string[2];
                if (tel1 != null) telefonlar[0] = tel1.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");
                if (tel2 != null) telefonlar[1] = tel2.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");
                list.Add(new Sms
                {
                    Id = _ids,
                    Telefon = telefonlar,
                    Mesaj = _msj
                });

            }

            using (var smsF = new SmsFunctions())
                if (AnaForm.SmsVeMailGonderme)// yazılımcı kontrolü
                {
                    if (smsF.SmsGonder(list, false))
                    foreach (var item in list)
                        OgrenciOdemePlaniF.IkinciSmsKayit(item.Id);
                }
                else
                {
                    // deneme kayıtları
                    foreach (var item in list)
                        OgrenciOdemePlaniF.IkinciSmsKayit(item.Id);
                }

        }
        IRestResponse MultiSend(List<Sms> list, DateTime? gonderimZamani = null)
        {

            string zaman = gonderimZamani != null ? $@"{TarihAyarla((DateTime)gonderimZamani)}" : "";
            var msj = "";
            foreach (var item in list)
            {

                var tlf = "";
                foreach (var tel in item.Telefon)
                    if (tel != null) tlf += Tırnak + tel + Tırnak + ",";

                tlf = tlf.Substring(0, tlf.Length - 1);
                msj += "{" + $@"""sender"":""{AnaForm.GenAyr.SmsBaslik }"",""text"":""{item.Mesaj }"",""utf8"":""1"", ""gsm"":[{tlf}]" + "},";
            }

            msj = msj.Substring(0, msj.Length - 1);



            var client = new RestClient("https://apiv3.goldmesaj.net/api/multiSendSMS") { Timeout = -1 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = "{" + $@"""username"":""{AnaForm.GenAyr.SmsKullaniciAdi }"",""password"":""{AnaForm.GenAyr.SmsSifre }"",""sdate"":""{zaman}"", ""vperiod"":""48"",""gate"":""0"",""message"":[{msj}]" + "}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            return client.Execute(request);
        }
        public List<Telefonlar> TelList()
        {
            return Connections.cnn.Query<Telefonlar>(
                          @"select VeliAdiSoyadi as AdiSoyadi,Telefon from Veli where Telefon is not null
                            UNION ALL
                            select AdiSoyadi,Telefon from Personel where Telefon is not null
                            UNION ALL
                            select FirmaAdi as AdiSoyadi, Telefon from Firma where Telefon is not null ").ToList();
        }
        public List<Data.SmsData.Data> Liste(DateTime tr1, DateTime tr2)
        {
            if (!GenelFunctions.InternetKontrol(false)) return null;
            try
            {
                // genel rapor
                var client = new RestClient("https://apiv3.goldmesaj.net/api/report/ozet") { Timeout = -1 };
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = "{" + $@"""username"":""{AnaForm.GenAyr.SmsKullaniciAdi }"",""password"":""{AnaForm.GenAyr.SmsSifre }"",""reportDate_Start"":""{TarihAyarla(tr1)}"", ""reportDate_End"":""{TarihAyarla(tr2)}""" + "}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<OgrenciTakipMuh.Data.SmsData.@object>(response.Content).Data;

            }
            catch (Exception) { return null; }
        }
        public List<Datum> Detay(string guidText)
        {
            var client = new RestClient("https://apiv3.goldmesaj.net/api/report/detail") { Timeout = -1 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = "{" + $@"""username"":""{AnaForm.GenAyr.SmsKullaniciAdi }"",""password"":""{AnaForm.GenAyr.SmsSifre }"",""guidText"":""{guidText}""" + "}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Root>(response.Content).Data.ToList();
        }
        string TarihAyarla(DateTime tarih)
        {
            var ay = tarih.Month.ToString().Length == 1 ? "0" + tarih.Month.ToString() : tarih.Month.ToString();
            var gun = tarih.Day.ToString().Length == 1 ? "0" + tarih.Day.ToString() : tarih.Day.ToString();

            var saat = tarih.Hour.ToString().Length == 1 ? "0" + tarih.Hour.ToString() : tarih.Hour.ToString();
            var dakika = tarih.Minute.ToString().Length == 1 ? "0" + tarih.Minute.ToString() : tarih.Minute.ToString();
            var saniye = tarih.Second.ToString().Length == 1 ? "0" + tarih.Second.ToString() : tarih.Second.ToString();
            return $"{tarih.Year}-{ay}-{gun} {saat}:{dakika}:{saniye}";
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}