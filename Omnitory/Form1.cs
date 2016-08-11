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
using NHttp;
using Newtonsoft.Json;
using Omnitory.Model;
using System.Linq.Expressions;

namespace Omnitory {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Filter = n => true;
        }
 
        public Model.Container CurrentContainer;
        private void RenderTagList() {
            taglistView.Items.Clear();
            var list = Db.Context.Tags.ToList().Select(n => new SpecialListViewItem<Model.Tag>(n) { ImageIndex = 1 }).ToArray();
            taglistView.Items.Clear();
            taglistView.Items.AddRange(list);

        }
        private void RenderItemList() {
            ItemListView.Items.Clear();
            List<Model.Container> continers;
            List<Model.Item> items;

            if (CurrentContainer == null) {
                continers = Db.Context.Containers.OrderBy(n => n.Name).Where(n => n.Container == null).ToList();
                items = Db.Context.Items.OrderBy(n=> n.Name).Where(n => n.Container == null).Where(Filter).ToList().Where(n => !(n is Model.Container)).ToList();
            } else {
            
                continers = Db.Context.Containers.OrderBy(n => n.Name).Where(n => n.Container.Id == CurrentContainer.Id).ToList();
                items = Db.Context.Items.OrderBy(n => n.Name).Where(n => n.Container.Id == CurrentContainer.Id).ToList().Where(n => !(n is Model.Container)).ToList();
            }


            ItemListView.Items.Clear();
            if (CurrentContainer != null) {
                ItemListView.Items.Add(new SpecialListViewItem<Model.Container>(CurrentContainer.Container) { Text = "..", ImageIndex = 1 });
            }
            foreach (var container in continers) {
                ItemListView.Items.Add(new SpecialListViewItem<Model.Container>(container) { ImageIndex = 1 });
            }
            foreach (var item in items) {
                ItemListView.Items.Add(new SpecialListViewItem<Model.Item>(item) { ImageIndex = 0});
            }
        }

        NHttp.HttpServer server;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            server.Stop();
            server.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e) {
            RenderTagList();
            RenderItemList();
            server = new NHttp.HttpServer();
            server.EndPoint.Port = 7331;
            server.RequestReceived += requestRecived;
            server.Start();
        }

        private void WriteToOutput(string text, HttpRequestEventArgs e) {
            var bytes = System.Text.Encoding.UTF8.GetBytes(text);
            e.Response.ContentType = "text/plain";
            e.Response.OutputStream.Write(bytes, 0, bytes.Count());
        }
        private void GetMethod(HttpRequestEventArgs e) {
            if (e.Request.QueryString.AllKeys.Contains("id")) {
                var id = e.Request.QueryString["id"];
                var item = DAL.Db.Context.Items.FirstOrDefault(n => n.Id == id);
                if (item != null) {
                    var itemText = JsonConvert.SerializeObject(item);
                    e.Response.ContentType = "application/json";
                    WriteToOutput(itemText, e);         
                }
            }
        }
        private void AddToContainer(HttpRequestEventArgs e) {
            if (e.Request.QueryString.AllKeys.Contains("containerId") && e.Request.QueryString.AllKeys.Contains("itemId")) {
                try {
                    var containerId = e.Request.QueryString["containerId"];
                    var itemId = e.Request.QueryString["itemId"];
                    var item = DAL.Db.Context.Items.FirstOrDefault(n => n.Id == itemId);
                    if (item != null) {
                        item.ContainerId = containerId;
                        DAL.Db.Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        DAL.Db.Context.SaveChanges();
                        WriteToOutput(true.ToString(), e);
                    } else {
                        WriteToOutput(false.ToString(), e);
                    }
                } catch (Exception) {
                    WriteToOutput(false.ToString(), e);
                }
            }
        }
        private void requestRecived(object sender, HttpRequestEventArgs e) {
            GetMethod(e);
            AddToContainer(e);
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
                    if (value != null) {
                        this.Text = value.ToString();
                    }
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
                DeleteDialog.TagName.Text = tag.Name;

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
                if (CurrentContainer.Items == null) {
                    CurrentContainer.Items = new List<Model.Item>();
                }
                CurrentContainer.Items.Add(AddItemdialog);
                Db.Context.Entry(CurrentContainer).State = System.Data.Entity.EntityState.Modified;
                RenderItemList();
            } else {
                if (AddItemdialog is Model.Container) {
                    if (Db.Context.Containers.Count(n => n.Id == AddItemdialog.Id) > 0) {
                        AddItemdialog.ContainerId = CurrentContainer?.Id ?? null;
                        Db.Context.Entry(AddItemdialog).State = System.Data.Entity.EntityState.Modified;
                    } else {


                        Db.Context.Containers.Add(AddItemdialog as Model.Container);
                    }  
                      
                    RenderItemList();
                } else if (AddItemdialog is Model.Item) {
                    if (Db.Context.Items.Count(n=> n.Id == AddItemdialog.Id) > 0) {
                        AddItemdialog.ContainerId = CurrentContainer?.Id ?? null;

                        Db.Context.Entry(AddItemdialog).State = System.Data.Entity.EntityState.Modified;
                    } else {
                        Db.Context.Items.Add(AddItemdialog as Model.Item);
                    }
                    RenderItemList();
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

        private void ItemListView_DoubleClick(object sender, EventArgs e) {
            if (ItemListView.SelectedItems.Count > 0) {
                var container = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container>;
                var item = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item>;

            
                if (container != null) {
                    CurrentContainer = container.Special;
                    RenderItemList();
                }



            }

        }

        private void ItemListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (ItemListView.SelectedItems.Count > 0) {
                editItemToolStripMenuItem.Enabled = true;
                deleteItemToolStripMenuItem.Enabled = true;
            } else {
                editItemToolStripMenuItem.Enabled = false;
                deleteItemToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ItemListView.SelectedItems.Count > 0) {
                var item = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item> as SpecialListViewItem<Model.Item>;
                var container_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container> as SpecialListViewItem<Model.Container>;
                if (item != null) {
                    DeleteDialog.TagName.Text = item.Special.Name;
                    var x = DeleteDialog.ShowDialog();
                    if (x == DialogResult.OK) { 
                        Db.Context.Items.Remove(item.Special);
                        Db.Context.SaveChanges();
                        RenderItemList();
                    }
                }
                if (container_ != null) {
    
                   // Db.Context.Containers.Remove(container_.Special);
                   // Db.Context.SaveChanges();
                  //  RenderItemList();
                }
            }
        }
        EditItem editItemDialog = new EditItem();

        public Expression<Func<Item, bool>> Filter { get; private set; }

        private void EditItem(Model.Item item = null) {
            if (item == null) {
                var item_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item>;
                var container_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container>;

                if (item_ != null) {
                    editItemDialog.Item = item_.Special;
                }
                if (container_ != null) {
                    editItemDialog.Item = container_.Special;
                }
            } else {
                editItemDialog.Item = item;
            }
            if (editItemDialog.ShowDialog() == DialogResult.OK) {
                Db.Context.Entry(editItemDialog.Item).State = System.Data.Entity.EntityState.Modified;
                Db.Context.SaveChanges();
                RenderItemList();
            }
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ItemListView.SelectedItems.Count > 0) {

                EditItem();


            }
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e) {
            var item = Db.Context.Items.FirstOrDefault(n => n.Id == toolStripTextBox1.Text);
            if (item != null) {
                if (item is Model.Container) {
                    CurrentContainer = item as Model.Container;
                    RenderItemList();
                    toolStripTextBox1.Text = "";
                } else {
                    editItemDialog.Item = item;
                    if (editItemDialog.ShowDialog() == DialogResult.OK) {
                        EditItem(editItemDialog.Item);
                    }
                    toolStripTextBox1.Text = "";
                }
            }
        }

  
    }
}
