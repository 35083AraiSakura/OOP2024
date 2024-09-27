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
    public partial class RSS_Reader : Form {
        public class ItemData {
            public string Title { get; set; }
            public string Link { get; set; }
        }
        List<ItemData> xitems;

        private Dictionary<string, string> beginitems;
        WebClient wc;


        public RSS_Reader() {
            InitializeComponent();

            beginitems = new Dictionary<string, string> {
                {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
                {"国際", "https://news.yahoo.co.jp/rss/topics/world.xml"},
                {"経済", "https://news.yahoo.co.jp/rss/topics/business.xml"},
                {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
                {"スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"},
                {"ＩＴ", "https://news.yahoo.co.jp/rss/topics/it.xml"},
                {"科学", "https://news.yahoo.co.jp/rss/topics/science.xml"},
                {"地域", "https://news.yahoo.co.jp/rss/topics/local.xml"}
            };
        }

        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            //初期化
            if (xitems != null) {
                xitems = new List<ItemData>();
                lbRssTitle.Items.Clear();
            }
            //取得
            if (beginitems.TryGetValue(cb_get.AccessibilityObject.Value, out var rss_url)) {
                Display(rss_url);
            } else {
                Display(cb_get.Text);
            }
        }

        //表示するやつの中身
        public void Display(string text) {
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
            cb_get.Items.AddRange(beginitems.Keys.ToArray());
            cb_get.SelectedIndex = -1;
        }


        //お気に入り設定
        private void bt_like_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tb_like.Text)) {
                MessageBox.Show("テキストボックスがnullです", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            } else {
                var select_title = tb_like.Text;
                var select_link = cb_get.AccessibilityObject.Value;

                cb_get.Items.Add($"{select_title}");
                beginitems.Add(select_title, select_link);

                tb_like.Text = null;
            }
        }

        //ファイルから終了
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("本当に終了しますか?", "RSS_Reader", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK) this.Close();
        }
    }
}