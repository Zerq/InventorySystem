﻿using Omnitory.DAL;
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
    public partial class AddItem : Form {
        public AddItem() {
            InitializeComponent();
        }


        private void RenderCombo() {
      
                tagCombo.Items.Clear();
            Db.Context.Tags.ToList().ForEach(n => tagCombo.Items.Add(n));
          
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
                    //select this item and exit dialog
                } else {
                    // reveal add item ui
                    this.Size = new Size(355, 417);
                }
        
        }

        private void AddItem_Shown(object sender, EventArgs e) {
            this.Size = new Size(355, 123);
            RenderCombo();
            Result = null;
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
    }
}