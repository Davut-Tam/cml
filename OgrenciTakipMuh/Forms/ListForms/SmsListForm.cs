using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakipMuh.Data.SmsData;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class SmsListForm : BaseListForm
    {

        List<Telefonlar> _telefonlar;
        List<Datum> _list;
        public SmsListForm()
        {
            InitializeComponent();
            txtBaslama.DateTime = DateTime.Now.AddMonths(-1);
            txtBitis.DateTime = DateTime.Now;
            btnSil.Visibility = btnDuzelt.Visibility = btnKolonlar.Visibility = BarItemVisibility.Never;
            Yukle();
            using (var smsf = new SmsFunctions())
            {
                _telefonlar = smsf.TelList();
                lblSmsBakiye.Text = smsf.SmsBakiye();
            }
               
        }



        private void TxtBaslama_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                Listele();
        }

    

        void Listele()
        {
            Cursor.Current = Cursors.WaitCursor;
            tablo.ViewCaption = $"Gönderilen Sms Listesi ({txtBaslama.DateTime.ToShortDateString()}-{txtBitis.DateTime.ToShortDateString()})";
            tablo.GridControl.DataSource = new SmsFunctions().Liste(txtBaslama.DateTime,txtBitis.DateTime)?.OrderByDescending(x => x.Gonderim);
            Cursor.Current = Cursors.Default;
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = tablo.GridControl;
            EventLoad();
           
        }


        void EventLoad()
        {
            BaseEventLoad();
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            txtBaslama.KeyDown += TxtBaslama_KeyDown;
            txtBitis.KeyDown += TxtBaslama_KeyDown;
            tablo.MasterRowGetChildList += Tablo_MasterRowGetChildList;
            tablo.MasterRowGetRelationCount += Tablo_MasterRowGetRelationCount;
            tablo.MasterRowGetRelationName += Tablo_MasterRowGetRelationName;

        }

        
        private void Tablo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var bll = new SmsFunctions())
            {
                 _list = bll.Detay(tablo.GetFocusedRowCellValue(colsmsGuidText).ToString());
                foreach (var item in _list)
                {
                    item.AdSoyad = _telefonlar.FirstOrDefault(x => x.Telefon == item.Gsm2)?.AdiSoyadi;

                }
                e.ChildList = _list;
             
            }
            Cursor.Current = Cursors.Default;
        }




        private void Tablo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "AltGrid";
        }

        private void Tablo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }


        private void BtnYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            Listele();
          
        }

        private void BtnYeni_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SmsEditForm fr = new SmsEditForm();
            fr.ShowDialog();
            fr.Dispose();
        }

  
    }
}
