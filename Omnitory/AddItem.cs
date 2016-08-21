using DYMO.Label.Framework;
using Omnitory.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omnitory {
    public partial class AddItem : Form {
        public AddItem(ImageList list) {
            InitializeComponent();
            imageList = list;
        }

        public ImageList imageList { get; set; }
        private void RenderCombo() {
      
                tagCombo.Items.Clear();
            Db.Context.Tags.OrderBy(n=> n.Name).ToList().ForEach(n => tagCombo.Items.Add(n));
          
        }


        private void AddItem_Load(object sender, EventArgs e) {

        }

        private void Newtagbutton_Click(object sender, EventArgs e) {
      
                if (tagCombo.SelectedItem == null) {
                    if (tagCombo.Text != string.Empty) {
                        var item = Db.Context.Tags.FirstOrDefault(n => n.Name == tagCombo.Text);
                        if (item == null) {
                            var newTag = new Model.Tag() { Id = Guid.NewGuid(), Name = tagCombo.Text };
                        Db.Context.Tags.Add(newTag);
                        Db.Context.SaveChanges();
                            taglistBox.Items.Add(newTag);
                        } else {
                            taglistBox.Items.Add(item);
                        }
                    }
                } else {
                    taglistBox.Items.Add(tagCombo.SelectedItem);
                }
         
        }

        private void barcode_Leave(object sender, EventArgs e) {
     
                var item = Db.Context.Items.FirstOrDefault(n => n.Id == barcode.Text);
                if (item != null) {
                Result = item;
                DialogResult = DialogResult.OK;
                    //select this item and exit dialog
                } else {
                // reveal add item ui
                this.Size = new Size(413, 425);


            }
        
        }

        private void AddItem_Shown(object sender, EventArgs e) {
            this.Size = new Size(329, 122);
            RenderCombo();
            Result = null;
            barcode.Text = "";
            nameBox.Text = "";
            descriptionBox.Text = "";       
            taglistBox.Items.Clear();
            barcode.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (taglistBox.SelectedItem != null) {
                removeButton.Enabled = true;
            } else {
                removeButton.Enabled = false;
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            if (taglistBox.SelectedItem != null) {
                taglistBox.Items.Remove(taglistBox.SelectedItem);
            }
        }

        public Model.Item Result;

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            if (isContainer.Checked) {
                Result = new Model.Container() {
                    Id = barcode.Text,
                    Name = nameBox.Text,
                    Description = descriptionBox.Text,
                    Added = DateTime.Now,
                    Tags = taglistBox.Items.Cast<Model.Tag>().ToList()
                };
            } else {
                Result = new Model.Item() {
                    Id = barcode.Text,
                    Name = nameBox.Text,
                    Description = descriptionBox.Text,
                    Added = DateTime.Now,
                    Tags = taglistBox.Items.Cast<Model.Tag>().ToList()
                };
            }


        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void AddItem_Load_1(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
          //  "85fdbd26-0a86-4ce4-944c-14b5546e7283"
            var key = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);

            while (DAL.Db.Context.Items.Count(n => n.Id == key) > 0) {
                key = Guid.NewGuid().ToString().Substring(0, 8);
            }

            Printers x = new Printers();
            var printer = x.First();
            ILabel label = DYMO.Label.Framework.Label.Open("barcode.label");
            label.SetObjectText("BARCODE", key);
            label.Print(printer);
           
        }
        Browser browserDialog = new Browser();
        private void button4_Click(object sender, EventArgs e) {

            browserDialog.SaveTumb(barcode.Text, imageList);
         
        }

        private bool callbackAbort() {
            throw new NotImplementedException();
        }
        ColorDialog colorDialog = new ColorDialog();
        private void button5_Click(object sender, EventArgs e)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}Images/{barcode}.png";
            if (File.Exists(path)) {
                Bitmap bmp = new Bitmap( Image.FromFile(path));
               colorDialog.Color =  bmp.GetPixel(0, 0);
            }
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                System.Drawing.Image bmp = new Bitmap(32,32);
                using (Graphics g = Graphics.FromImage(bmp)) {
                    g.FillRectangle( new SolidBrush(colorDialog.Color), new Rectangle(0, 0, 32, 32));
                }
                var image = bmp.GetThumbnailImage(32, 32, callbackAbort, IntPtr.Zero);
                image.Save(path, ImageFormat.Png);
                imageList.Images.RemoveByKey(barcode.Text);
                imageList.Images.Add(barcode.Text, image);
            }
      
        }
    }
}