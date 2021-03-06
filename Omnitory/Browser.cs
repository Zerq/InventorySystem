﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omnitory {
    public partial class Browser : Form {
        public Browser() {
            InitializeComponent();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e) {
            webBrowser1.GoForward();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            navbox.Text = webBrowser1.Url.ToString();
            webBrowser1.Document.MouseMove += Document_MouseMove;
        }
        Point mousePoint = new Point();
        private void Document_MouseMove(object sender, HtmlElementEventArgs e) {
            mousePoint.X = e.MousePosition.X;
            mousePoint.Y = e.MousePosition.Y;
        }

        private void GoTo_Click(object sender, EventArgs e) {
            webBrowser1.Navigate(navbox.Text);
        }

        private void forward_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }
        public string Url { get; set; }
        private void Browser_Load(object sender, EventArgs e) {

        }

        private void Browser_Shown(object sender, EventArgs e) {
            webBrowser1.Navigate(Url);
        }

        private void Select_Click(object sender, EventArgs e) {
            Url = navbox.Text;
            this.DialogResult = DialogResult.OK;

        }

        private void cansleToolStripMenuItem_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }


        private bool callbackAbort() {
            throw new NotImplementedException();
        }
        public static ImageFormat IsImage(string url) {
            var index = url.LastIndexOf(".");
            var extension = url.Substring(index).ToLower();
            if (extension == ".jpg") {
                return ImageFormat.Jpeg;
            } else
            if (extension == ".jpeg") {
                return ImageFormat.Jpeg;
            } else
            if (extension == ".png") {
                return ImageFormat.Png;
            } else
            if (extension == ".gif") {
                return ImageFormat.Gif;
            } else {
                return null;
            }
        }
        public  void SaveTumb(string reference, ImageList imageList) {
            this.Url = $@"https://www.google.se/search?q=product+search&ie=utf-8&oe=utf-8&client=firefox-b&gfe_rd=cr&ei=pJCtV_-sHOzk8AfgsISoDw#q={reference}";
            if (this.ShowDialog() == DialogResult.OK) {
                var format = IsImage(this.Url);

                if (format!=null) {
                    WebClient client = new WebClient();
                    var data = client.DownloadData(this.Url);

                    var index = this.Url.LastIndexOf(".");
                    var extension = this.Url.Substring(index).ToLower();
               

                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(data)) {
                        System.Drawing.Image bmp = new Bitmap(stream);
                        var image = bmp.GetThumbnailImage(32, 32, callbackAbort, IntPtr.Zero);
                        image.Save($"{AppDomain.CurrentDomain.BaseDirectory}Images/{reference}.png", format);

                        imageList.Images.RemoveByKey(reference);
                        imageList.Images.Add(reference, image);


                    }



                }
            }
        }

        string selectedUrl = string.Empty;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
           
            var element = webBrowser1.Document.GetElementFromPoint(mousePoint);
            if (element.TagName == "IMG") {
                var source = element.GetAttribute("src");
                var index = source.IndexOf("?");
                if (index != -1) {
                    source = source.Substring(0, index);
                }
               var format = IsImage(source);

                if (format != null) {
                    selectedUrl = source;
                } else {
                    e.Cancel = true;
                }


            } else {
                e.Cancel = true;
            }
        }

        private void getUrlToolStripMenuItem_Click(object sender, EventArgs e) {
            navbox.Text = selectedUrl;
            webBrowser1.Navigate(navbox.Text);
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e) {
         //   e.Cancel = true;
    
            HtmlElement link = webBrowser1.Document.ActiveElement;
           // String url = link.GetAttribute("href");
           // webBrowser1.Navigate(url);

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            
        }
    }
}
