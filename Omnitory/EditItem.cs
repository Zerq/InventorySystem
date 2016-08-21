using DYMO.Label.Framework;
using Omnitory.DAL;
using System;
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
    public partial class EditItem : Form {
        public EditItem(ImageList list) {
            InitializeComponent();
            imageList = list;
        }
        public ImageList imageList { get; private set; }
        public Model.Item Item { get; set; }
        private void EditItem_Load(object sender, EventArgs e) {

        }
        private void RenderCombo() {

            tagCombo.Items.Clear();
            Db.Context.Tags.OrderBy(n=> n.Name).ToList().ForEach(n => tagCombo.Items.Add(n));

        }
        private void EditItem_Shown(object sender, EventArgs e) {
            this.nameBox.Text = Item.Name;
            this.descriptionBox.Text = Item.Description;
            this.taglistBox.Items.Clear();
            this.taglistBox.Items.AddRange(Item.Tags.ToArray());
            this.IsContainer.Checked = Item is Model.Container;
            RenderCombo();
            nameBox.Focus();

        }

        private void button2_Click(object sender, EventArgs e) {
            Item.Name = this.nameBox.Text;
            Item.Description= this.descriptionBox.Text;
            Item.Tags = this.taglistBox.Items.Cast<Model.Tag>().ToList();
            DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e) {
            Printers x = new Printers();
            var printer = x.First();
            ILabel label = DYMO.Label.Framework.Label.Open("barcode.label");
            label.SetObjectText("BARCODE", Item.Id);
            label.Print(printer);
        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
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

        private void removeButton_Click(object sender, EventArgs e) {
            if (taglistBox.SelectedItem != null) {
                taglistBox.Items.Remove(taglistBox.SelectedItem);
            }
        }

        private void tagCombo_SelectedIndexChanged(object sender, EventArgs e) {

        }
        Browser browserDialog = new Browser();
        private void button1_Click(object sender, EventArgs e) {
            browserDialog.SaveTumb(Item.Id, imageList); 
        }

        private bool callbackAbort() {
            throw new NotImplementedException();
        }
        ColorDialog colorDialog = new ColorDialog();
        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image bmp = new Bitmap(32, 32);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(new SolidBrush(colorDialog.Color), new Rectangle(0, 0, 32, 32));
                }
                var image = bmp.GetThumbnailImage(32, 32, callbackAbort, IntPtr.Zero);
                image.Save($"{AppDomain.CurrentDomain.BaseDirectory}Images/{Item.Id}.png", ImageFormat.Png);
                imageList.Images.RemoveByKey(Item.Id);
                imageList.Images.Add(Item.Id,image);
            }
        }

        private void IsContainer_CheckStateChanged(object sender, EventArgs e)
        {
           
        }
    }
}
