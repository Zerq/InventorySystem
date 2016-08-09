﻿using DYMO.Label.Framework;
using Omnitory.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omnitory {
    public partial class EditItem : Form {
        public EditItem() {
            InitializeComponent();
        }
        public Model.Item Item { get; set; }
        private void EditItem_Load(object sender, EventArgs e) {

        }
        private void RenderCombo() {

            tagCombo.Items.Clear();
            Db.Context.Tags.ToList().ForEach(n => tagCombo.Items.Add(n));

        }
        private void EditItem_Shown(object sender, EventArgs e) {
            this.nameBox.Text = Item.Name;
            this.descriptionBox.Text = Item.Description;
            this.taglistBox.Items.Clear();
            this.taglistBox.Items.AddRange(Item.Tags.ToArray());
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
    }
}
