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
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;

namespace Omnitory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Filter = n => true;
            AddItemdialog = new AddItem(imageList1);
            editItemDialog = new EditItem(imageList1);
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}Images/";
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles("*.png");
            foreach (var file in files)
            {
                var key = file.Name.Replace(file.Extension, "");
                imageList1.Images.Add(key, Image.FromFile(file.FullName));
            }

        }
        EditItem editItemDialog;
        AddItem AddItemdialog;
        public Model.Container CurrentContainer;
        private void RenderTagList()
        {
            taglistView.Items.Clear();
            var list = Db.Context.Tags.OrderBy(n => n.Name).ToList().Select(n => new SpecialListViewItem<Model.Tag>(n) { ImageIndex = 1 }).ToArray();
            taglistView.Items.Clear();
            taglistView.Items.AddRange(list);

        }
        bool restartIminent = false;

        private void RenderItemList()
        {
            if (!restartIminent)
            {
                ItemListView.Items.Clear();
                List<Model.Container> continers;
                List<Model.Item> items;


                if (CurrentContainer == null)
                {
                    continers = Db.Context.Containers.OrderBy(n => n.Name).Where(n => n.Container == null).ToList();

                    items = Db.Context.Items.OrderBy(n => n.Name).Where(n => n.Container == null).Where(Filter).ToList().Where(n => !(n is Model.Container)).ToList();
                }
                else
                {

                    continers = Db.Context.Containers.OrderBy(n => n.Name).Where(n => n.Container.Id == CurrentContainer.Id).ToList();

                    items = Db.Context.Items.OrderBy(n => n.Name).Where(n => n.Container.Id == CurrentContainer.Id).ToList().Where(n => !(n is Model.Container)).ToList();
                }



                ItemListView.Items.Clear();
                if (CurrentContainer != null)
                {
                    ItemListView.Items.Add(new SpecialListViewItem<Model.Container>(CurrentContainer.Container) { Text = "..", ImageKey = "_folder" });
                }
                foreach (var container in continers)
                {
                    ItemListView.Items.Add(new SpecialListViewItem<Model.Container>(container) { Special = container, ImageKey = "_folder" });
                }
                foreach (var item in items)
                {
                    if (File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}Images\{item.Id}.png"))
                    {
                        ItemListView.Items.Add(new SpecialListViewItem<Model.Item>(item) { Special = item, ImageKey = item.Id });
                    }
                    else
                    {
                        ItemListView.Items.Add(new SpecialListViewItem<Model.Item>(item) { Special = item, ImageKey = "_file" });
                    }
                }
            }
            else {
                this.Close();
            }
        }

        NHttp.HttpServer server;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            server.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RenderTagList();
            RenderItemList();
            server = new NHttp.HttpServer();
            server.EndPoint.Port = 7331;
            server.RequestReceived += requestRecived;
            server.Start();
        }

        private void WriteToOutput(string text, HttpRequestEventArgs e)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(text);
            e.Response.ContentType = "text/plain";
            e.Response.OutputStream.Write(bytes, 0, bytes.Count());
        }
        private void GetMethod(HttpRequestEventArgs e)
        {
            if (e.Request.QueryString.AllKeys.Contains("id"))
            {
                var id = e.Request.QueryString["id"];
                var item = DAL.Db.Context.Items.FirstOrDefault(n => n.Id == id);
                if (item != null)
                {
                    var itemText = JsonConvert.SerializeObject(item);
                    e.Response.ContentType = "application/json";
                    WriteToOutput(itemText, e);
                }
            }
        }
        private void ReadReaderData(HttpRequestEventArgs e) {
            if (e.Request.QueryString.AllKeys.Contains("ReaderData")){
                SendKeys.Send(e.Request.QueryString["ReaderData"]);
                SendKeys.Send("{TAB}");//change focus
            }
        }

        private void AddToContainer(HttpRequestEventArgs e)
        {
            if (e.Request.QueryString.AllKeys.Contains("containerId") && e.Request.QueryString.AllKeys.Contains("itemId"))
            {
                try
                {
                    var containerId = e.Request.QueryString["containerId"];
                    var itemId = e.Request.QueryString["itemId"];
                    var item = DAL.Db.Context.Items.FirstOrDefault(n => n.Id == itemId);
                    if (item != null)
                    {
                        item.ContainerId = containerId;
                        DAL.Db.Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        DAL.Db.Context.SaveChanges();
                        WriteToOutput(true.ToString(), e);
                    }
                    else
                    {
                        WriteToOutput(false.ToString(), e);
                    }
                }
                catch (Exception)
                {
                    WriteToOutput(false.ToString(), e);
                }
            }
        }
        private void requestRecived(object sender, HttpRequestEventArgs e)
        {
            GetMethod(e);
            AddToContainer(e);
            ReadReaderData(e);
        }

        public class SpecialListViewItem<T> : ListViewItem
        {
            public SpecialListViewItem(T item)
            {
                this.Special = item;
            }
            private T special;
            public T Special {
                get {
                    return special;
                }
                set {
                    special = value;
                    if (value != null)
                    {
                        this.Text = value.ToString();
                    }
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        AddTag AddDialog = new AddTag();
        EditTag EditDialog = new EditTag();
        DeleteTag DeleteDialog = new DeleteTag();

        private void addTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = AddDialog.ShowDialog();

            if (x == DialogResult.OK)
            {

                Db.Context.Tags.Add(new Model.Tag() { Id = Guid.NewGuid(), Name = AddDialog.TagName.Text });
                Db.Context.SaveChanges();
                RenderTagList();


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void editTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taglistView.SelectedItems.Count > 0)
            {
                var tag = (taglistView.SelectedItems[0] as SpecialListViewItem<Model.Tag>).Special;
                EditDialog.TagName.Text = tag.Name;

                var x = EditDialog.ShowDialog();

                if (x == DialogResult.OK)
                {

                    tag.Name = EditDialog.TagName.Text;
                    Db.Context.Entry(tag).State = System.Data.Entity.EntityState.Modified;
                    Db.Context.SaveChanges();
                    RenderTagList();


                }
            }
        }

        private void taglistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (taglistView.SelectedItems.Count == 0)
            {
                editTagToolStripMenuItem.Enabled = false;
                deleteTagToolStripMenuItem.Enabled = false;
            }
            else
            {
                editTagToolStripMenuItem.Enabled = true;
                deleteTagToolStripMenuItem.Enabled = true;
            }

        }

        private void deleteTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taglistView.SelectedItems.Count > 0)
            {
                var tag = (taglistView.SelectedItems[0] as SpecialListViewItem<Model.Tag>).Special;
                DeleteDialog.TagName.Text = tag.Name;

                var x = DeleteDialog.ShowDialog();

                if (x == DialogResult.OK)
                {

                    tag = Db.Context.Tags.FirstOrDefault(n => n.Id == tag.Id);
                    Db.Context.Tags.Remove(tag);
                    Db.Context.SaveChanges();
                    RenderTagList();


                }
            }
        }

        private void AddToContainer(Model.Item AddItemdialog)
        {
            if (CurrentContainer != null)
            {
                if (CurrentContainer.Items == null)
                {
                    CurrentContainer.Items = new List<Model.Item>();
                }
                CurrentContainer.Items.Add(AddItemdialog);
                Db.Context.Entry(CurrentContainer).State = System.Data.Entity.EntityState.Modified;
                RenderItemList();
            }
            else
            {
                if (AddItemdialog is Model.Container)
                {
                    if (Db.Context.Containers.Count(n => n.Id == AddItemdialog.Id) > 0)
                    {
                        AddItemdialog.ContainerId = CurrentContainer?.Id ?? null;
                        Db.Context.Entry(AddItemdialog).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {


                        Db.Context.Containers.Add(AddItemdialog as Model.Container);
                    }

                    RenderItemList();
                }
                else if (AddItemdialog is Model.Item)
                {
                    if (Db.Context.Items.Count(n => n.Id == AddItemdialog.Id) > 0)
                    {
                        AddItemdialog.ContainerId = CurrentContainer?.Id ?? null;

                        Db.Context.Entry(AddItemdialog).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        Db.Context.Items.Add(AddItemdialog as Model.Item);
                    }
                    RenderItemList();
                }
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AddItemdialog.ShowDialog() == DialogResult.OK)
            {
                AddToContainer(AddItemdialog.Result);
                Db.Context.SaveChanges();
                RenderItemList();
            }
        }

        private void ItemListView_DoubleClick(object sender, EventArgs e)
        {
            if (ItemListView.SelectedItems.Count > 0)
            {
                var container = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container>;
                var item = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item>;


                if (container != null)
                {
                    CurrentContainer = container.Special;
                    RenderItemList();
                }



            }

        }

        private void ItemListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemListView.SelectedItems.Count > 0)
            {
                editItemToolStripMenuItem.Enabled = true;
                deleteItemToolStripMenuItem.Enabled = true;
            }
            else
            {
                editItemToolStripMenuItem.Enabled = false;
                deleteItemToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemListView.SelectedItems.Count > 0)
            {
                var item = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item> as SpecialListViewItem<Model.Item>;
                var container_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container> as SpecialListViewItem<Model.Container>;
                if (item != null)
                {
                    DeleteDialog.TagName.Text = item.Special.Name;
                    var x = DeleteDialog.ShowDialog();
                    if (x == DialogResult.OK)
                    {
                        Db.Context.Items.Remove(item.Special);
                        Db.Context.SaveChanges();
                        RenderItemList();
                    }
                }
                if (container_ != null)
                {
                    if (MessageBox.Show("Are you sure? Doing this will dump any content into this container root container", "Delete Container", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var items = DAL.Db.Context.Items.Where(n => n.ContainerId == container_.Special.Id).ToList();
                        items.ForEach(n => { n.ContainerId = CurrentContainer?.Id ?? null; DAL.Db.Context.Entry(n).State = System.Data.Entity.EntityState.Modified; });
                        DAL.Db.Context.Containers.Remove(container_.Special);
                        DAL.Db.Context.SaveChanges();
                        RenderItemList();
                    }
                    // Db.Context.Containers.Remove(container_.Special);
                    // Db.Context.SaveChanges();
                    //  RenderItemList();
                }
            }
        }


        public Expression<Func<Item, bool>> Filter { get; private set; }

        private void EditItem(Model.Item item = null)
        {
            if (item == null)
            {
                var item_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Item>;
                var container_ = ItemListView.SelectedItems[0] as SpecialListViewItem<Model.Container>;

                if (item_ != null)
                {
                    editItemDialog.Item = item_.Special;
                }
                if (container_ != null)
                {
                    editItemDialog.Item = container_.Special;
                }
            }
            else
            {
                editItemDialog.Item = item;
            }
            if (editItemDialog.ShowDialog() == DialogResult.OK)
            {
                Db.Context.Entry(editItemDialog.Item).State = System.Data.Entity.EntityState.Modified;
                Db.Context.SaveChanges();


                if (editItemDialog.IsContainer.Checked)
                {
                    MakeContainer(editItemDialog.Item);
                }
                else
                {
                    MakeItem(editItemDialog.Item);
                }


                RenderItemList();
            }
        }

        private int? CountContainers(Item item, IDbConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"select count(id) from Containers where id = @id";
            var parameter = command.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = item.Id;
            command.Parameters.Add(parameter);
            return command.ExecuteScalar() as int?;
        }
        private void MakeItem(Item item)
        {
            using (IDbConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                var count = CountContainers(item, connection);
                if (count.HasValue)
                {
                    if (count == 1)
                    {
                        if (MessageBox.Show("This action will require application Restart", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            DeleteContainerPart(item, connection);
                            restartIminent = true;
                        }
                    }
                }
            }
        }

        private void DeleteContainerPart(Item item, IDbConnection connection)
        {
         
                var command = connection.CreateCommand();
                command.CommandText = @"Delete from Containers where id = @id";
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = item.Id;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
          
        }

        private void MakeContainer(Item item)
        {
            using (IDbConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                var count = CountContainers(item, connection);
                if (count.HasValue)
                {
                    if (count == 0)
                    {
                        if (MessageBox.Show("This action will require application Restart", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            CreateContainerPart(item, connection);
                            restartIminent = true;
                        }
                    }
                }
            }
        }

        private void CreateContainerPart(Item item, IDbConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"Insert into Containers (id) values (@id)";
            var parameter = command.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = item.Id;
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemListView.SelectedItems.Count > 0)
            {

                EditItem();


            }
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            var item = Db.Context.Items.FirstOrDefault(n => n.Id == toolStripTextBox1.Text);
            if (item != null)
            {
                if (item is Model.Container)
                {
                    CurrentContainer = item as Model.Container;
                    RenderItemList();
                    toolStripTextBox1.Text = "";
                }
                else
                {
                    editItemDialog.Item = item;
                    if (editItemDialog.ShowDialog() == DialogResult.OK)
                    {
                        EditItem(editItemDialog.Item);
                    }
                    toolStripTextBox1.Text = "";
                }
            }
        }

        private List<string> NonIds()
        {
            List<string> result = new List<string>();
            while (result.Count < 28) //yes yes i know this could be an infinity loop... but it will work for now... still have the issue of generating non-sequential numbers without getting excesivly large barcodes.. when i make the android app i might switch to QR code so i can use full guids
            {
                var key = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
                while (DAL.Db.Context.Items.Count(n => n.Id == key) > 0 && (!result.Contains(key)))
                {
                    key = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
                }
                result.Add(key);
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += BarcodeDoc_PrintPage;
            doc.PrinterSettings.MaximumPage = 1;
            doc.Print();
         




        }

        private void BarcodeDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
      
            ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter();
            writer.Format = ZXing.BarcodeFormat.CODE_128;
            Bitmap[] ids = new Bitmap[0];
            try
            {
                ids = NonIds().Select(n => writer.Write(n)).ToArray();
                var maxX = ids.Max(n => n.Width + 10);
                var maxY = ids.Max(n => n.Height + 10);
                //  using (Bitmap image = new Bitmap(maxX * 4, maxY * 7))
                //  {
                //      using (Graphics g = Graphics.FromImage(image))
                //     {
                e.Graphics.FillRectangle(Brushes.White, 0, 0, maxX * 2, maxY * 5);
                e.Graphics.DrawImage(ids[0], maxX * 0, maxY * 0);  e.Graphics.DrawImage(ids[7], maxX * 1, maxY * 0);  e.Graphics.DrawImage(ids[14], maxX * 2, maxY * 0);  e.Graphics.DrawImage(ids[21], maxX * 3, maxY * 0);
                e.Graphics.DrawImage(ids[1], maxX * 0, maxY * 1);  e.Graphics.DrawImage(ids[8], maxX * 1, maxY * 1);  e.Graphics.DrawImage(ids[15], maxX * 2, maxY * 1);  e.Graphics.DrawImage(ids[22], maxX * 3, maxY * 1);
                e.Graphics.DrawImage(ids[2], maxX * 0, maxY * 2);  e.Graphics.DrawImage(ids[9], maxX * 1, maxY * 2);  e.Graphics.DrawImage(ids[16], maxX * 2, maxY * 2);  e.Graphics.DrawImage(ids[23], maxX * 3, maxY * 2);
                e.Graphics.DrawImage(ids[3], maxX * 0, maxY * 3);  e.Graphics.DrawImage(ids[10], maxX * 1, maxY * 3);  e.Graphics.DrawImage(ids[17], maxX * 2, maxY * 3);  e.Graphics.DrawImage(ids[24], maxX * 3, maxY * 3);
                e.Graphics.DrawImage(ids[4], maxX * 0, maxY * 4);  e.Graphics.DrawImage(ids[11], maxX * 1, maxY * 4);  e.Graphics.DrawImage(ids[18], maxX * 2, maxY * 4);  e.Graphics.DrawImage(ids[25], maxX * 3, maxY * 4);
                e.Graphics.DrawImage(ids[5], maxX * 0, maxY * 5);  e.Graphics.DrawImage(ids[12], maxX * 1, maxY * 5);  e.Graphics.DrawImage(ids[19], maxX * 2, maxY * 5);  e.Graphics.DrawImage(ids[26], maxX * 3, maxY * 5);
                e.Graphics.DrawImage(ids[6], maxX * 0, maxY * 6);  e.Graphics.DrawImage(ids[13], maxX * 1, maxY * 6);  e.Graphics.DrawImage(ids[20], maxX * 2, maxY * 6);  e.Graphics.DrawImage(ids[27], maxX * 3, maxY * 6);

                 //   }


                   // doc.
            //    }
            }
            finally
            {
                foreach (var item in ids) { item.Dispose(); }
            }
        }
    }
}
