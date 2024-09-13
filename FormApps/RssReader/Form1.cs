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
using Windows.UI.Xaml.Controls;

namespace RssReader {
    public partial class Form1 : Form {
        public class ItemData {
            public string Title { get; set; }
            public string Link { get; set; }
        }
        List<ItemData> xitems;
        List<ItemData> cb_items;

        WebClient wc;
        string text;

        public Form1() {
            InitializeComponent();
        }

        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            //初期化
            if (xitems != null) {
                xitems = new List<ItemData>();
                lbRssTitle.Items.Clear();
            }
            //取得
            if (!cb_get.Text.Contains("rss")) {
                text = SetItemsText(cb_get.Text);
            } else {
                text = cb_get.Text;
            }
            using (wc = new WebClient()) {
                var url = wc.OpenRead(text);
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
        private async void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate(xitems[lbRssTitle.SelectedIndex].Link);
        }

        //起動
        private void Form1_Load(object sender, EventArgs e) {
            cb_get.Items.AddRange(new string[] {"主要","国内","国際","経済","エンタメ","スポーツ",
                                                "ＩＴ","科学","地域"});

            cb_get.SelectedIndex = -1;
        }

        private string SetItemsText(string text) {
            string lk;
            switch (text) {
                case "主要":
                    lk = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
                    return lk;
                case "国内":
                    lk = "https://news.yahoo.co.jp/rss/topics/domestic.xml";
                    return lk;
                case "国際":
                    lk = "https://news.yahoo.co.jp/rss/topics/world.xml";
                    return lk;
                case "経済":
                    lk = "https://news.yahoo.co.jp/rss/topics/business.xml";
                    return lk;
                case "エンタメ":
                    lk = "https://news.yahoo.co.jp/rss/topics/entertainment.xml";
                    return lk;
                case "スポーツ":
                    lk = "https://news.yahoo.co.jp/rss/topics/sports.xml";
                    return lk;
                case "ＩＴ":
                    lk = "https://news.yahoo.co.jp/rss/topics/it.xml";
                    return lk;
                case "科学":
                    lk = "https://news.yahoo.co.jp/rss/topics/science.xml";
                    return lk;
                case "地域":
                    lk = "https://news.yahoo.co.jp/rss/topics/local.xml";
                    return lk;
                default:
                    return lk = null;
            }
        }

        //お気に入り設定
        private void bt_like_Click(object sender, EventArgs e) {
            var txt=tb_like.Text;
            var link=cb_get.Text;
            //xitems.
        }
    }
}

//めも　Array.IndexOf(numbers, 3);
