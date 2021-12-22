using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MCD_RSSOkumaUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private List<Haber> XMLCevir()
        {
            List<Haber> haberKayitları = new List<Haber>();
            XDocument xmlKaynak = XDocument.Load(txtRSS1.Text);
            List<XElement> Rows = xmlKaynak.Descendants("item").ToList(); //item alt xml parçasını aldık
            foreach (XElement item in Rows)
            {
                Haber temp = new Haber();
                temp.baslik = item.Element("title").Value; //bunlar sabahın rss sitesinden aldık
                temp.link = item.Element("link").Value;
                temp.aciklama = item.Element("description").Value;
                haberKayitları.Add(temp);
            }
            return haberKayitları;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Haber> kayitlar = XMLCevir();
            lstBaslik.DataSource = kayitlar;
        }

        private void lstBaslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox secilenDeger = (ListBox)sender;
            Haber secilenHaber = (Haber)secilenDeger.SelectedItem;
            webBrowser1.DocumentText = secilenHaber.aciklama;
        }
    }
}
