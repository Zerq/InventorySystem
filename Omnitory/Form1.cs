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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public Model.Container CurrentContainer;
        private void RenderTagList() {
            var list = Db.Context.Tags.ToList().Select(n => new SpecialListViewItem<Model.Tag>(n) { ImageIndex = 1 }).ToArray();
            taglistView.Items.Clear();
            taglistView.Items.AddRange(list);

        }
        private void RenderItemList() {
            var continers = Db.Context.Containers.Where(n => n.Container == CurrentContainer).ToList();
            var items = Db.Context.Containers.Where(n => n.Container == CurrentContainer).ToList().Where(n=> n.GetType() == typeof(Model.Item)).ToList();
            ItemListView.Items.Clear();
            foreach (var container in continers) {
                ItemListView.Items.Add(new SpecialListViewItem<Model.Container>(container) { ImageIndex = 0 });
            }
            foreach (var item in items) {
                ItemListView.Items.Add(new SpecialListViewItem<Model.Item>(item) { ImageIndex = 1 });
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            RenderTagList();
            RenderItemList();
        }

        public class SpecialListViewItem<T> : ListViewItem {
            public SpecialListViewItem(T item) {
                this.Special = item;
            }
            private T special;
            public T Special {
                get {
                    return special;
                }
                set {
                    special = value;
                    this.Text = value.ToString();
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }
        AddTag AddDialog = new AddTag();
        EditTag EditDialog = new EditTag();
        DeleteTag DeleteDialog = new DeleteTag();

        private void addTagToolStripMenuItem_Click(object sender, EventArgs e) {
            var x = AddDialog.ShowDialog();

            if (x == DialogResult.OK) {

                Db.Context.Tags.Add(new Model.Tag() { Id = Guid.NewGuid(), Name = AddDialog.TagName.Text });
                Db.Context.SaveChanges();
                RenderTagList();


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void editTagToolStripMenuItem_Click(object sender, EventArgs e) {
            if (taglistView.SelectedItems.Count > 0) {
                var tag = (taglistView.SelectedItems[0] as SpecialListViewItem<Model.Tag>).Special;
                EditDialog.TagName.Text = tag.Name;

                var x = EditDialog.ShowDialog();

                if (x == DialogResult.OK) {

                    tag.Name = EditDialog.TagName.Text;
                    Db.Context.Entry(tag).State = System.Data.Entity.EntityState.Modified;
                    Db.Context.SaveChanges();
                    RenderTagList();


                }
            }
        }

        private void taglistView_SelectedIndexChanged(object sender, EventArgs e) {
            if (taglistView.SelectedItems.Count == 0) {
                editTagToolStripMenuItem.Enabled = false;
                deleteTagToolStripMenuItem.Enabled = false;
            } else {
                editTagToolStripMenuItem.Enabled = true;
                deleteTagToolStripMenuItem.Enabled = true;
            }

        }

        private void deleteTagToolStripMenuItem_Click(object sender, EventArgs e) {
            if (taglistView.SelectedItems.Count > 0) {
                var tag = (taglistView.SelectedItems[0] as SpecialListViewItem<Model.Tag>).Special;
                EditDialog.TagName.Text = tag.Name;

                var x = DeleteDialog.ShowDialog();

                if (x == DialogResult.OK) {

                    tag = Db.Context.Tags.FirstOrDefault(n => n.Id == tag.Id);
                    Db.Context.Tags.Remove(tag);
                    Db.Context.SaveChanges();
                    RenderTagList();


                }
            }
        }
        AddItem AddItemdialog = new AddItem();
        private void AddToContainer(Model.Item AddItemdialog) {
            if (CurrentContainer != null) {
                CurrentContainer.Items.Add(AddItemdialog);
                Db.Context.Entry(CurrentContainer).State = System.Data.Entity.EntityState.Modified;
            } else {
                if (AddItemdialog is Model.Container) {
                    Db.Context.Containers.Add(AddItemdialog as Model.Container);

                } else if (AddItemdialog is Model.Item) {
                    Db.Context.Items.Add(AddItemdialog as Model.Item);
                }
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e) {
            if (AddItemdialog.ShowDialog() == DialogResult.OK) {
                AddToContainer(AddItemdialog.Result);
                Db.Context.SaveChanges();
                RenderItemList();
            }
        }
    }
}
