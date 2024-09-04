using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        public class ItemData {
            public string Title { get; set; }
            public string Link { get; set; }
        }
        List<ItemData> xitems;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);

                xitems = xdoc.Root.Descendants("item").Select(item => new ItemData {
                    Title = item.Element("title").Value,
                    Link = item.Element("link").Value
                }).ToList();
                foreach (var item in xitems) {
                    lbRssTitle.Items.Add(item.Title);
                }
            }
        }

        //押されたタイトルの記事出す
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            webBrowser1.Navigate(xitems[lbRssTitle.SelectedIndex].Link);
        }
    }
}
