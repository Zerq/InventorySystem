using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OmnicatzInventory.Model;

namespace OmnicatzInventory
{
    public partial class App : Form
    {

        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");
            db = new DAL.Context();
        }

        DAL.Context db;

        public class ContainerNode : TreeNode{
            Model.Container container;
            public Model.Container Container {
                get { return container; }
                set {
                    container = value;
                    this.Text = container.Name;
                }
            }
            public override string ToString()
            {
                return Container.Name;
            }
           
        }

        private void App_Load(object sender, EventArgs e)
        {
            var allContainers = db.Containers.ToList();

            var nodes = GetNodes(allContainers.Where(n => n.Container == null).ToList(), allContainers);

            treeView1.Nodes.AddRange(nodes.ToArray());

        }

        private List<ContainerNode> GetNodes(IEnumerable<Model.Container> currentDepth, List<Model.Container> all)
        {
            List<ContainerNode> result = new List<ContainerNode>();
            foreach (var itm in currentDepth) {
                var node = new ContainerNode { Container = itm };
                var childNodesSource = itm.Items.Where(n => n is Model.Container).Cast<Model.Container>();
                node.Nodes.AddRange(GetNodes(childNodesSource, all).ToArray());
                result.Add(node);
            }

            return result;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();

            var node = treeView1.SelectedNode as ContainerNode;

            if (node != null) {
                listView1.Items.AddRange(MakeItems(node.Container.Items));
            }

        }
        public class SpecialItem : ListViewItem {
            Model.Item item;
            public Model.Item Item {
                get { return item; }
                set {
                    item = value;
                    this.Text = item.Name;
                }
            }
            public override string ToString()
            {
                return item.Name;
            }


        }
        private ListViewItem[] MakeItems(List<Item> items)
        {
          return items.Select(n => new SpecialItem() { Item = n }).ToArray();
        }
    }
}
