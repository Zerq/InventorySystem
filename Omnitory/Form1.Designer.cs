namespace Omnitory {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.addTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ItemListView = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.taglistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(822, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.taglistView);
            this.tabPage1.Controls.Add(this.menuStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(814, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tags";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTagToolStripMenuItem,
            this.editTagToolStripMenuItem,
            this.deleteTagToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(808, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // addTagToolStripMenuItem
            // 
            this.addTagToolStripMenuItem.Name = "addTagToolStripMenuItem";
            this.addTagToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addTagToolStripMenuItem.Text = "Add";
            this.addTagToolStripMenuItem.Click += new System.EventHandler(this.addTagToolStripMenuItem_Click);
            // 
            // editTagToolStripMenuItem
            // 
            this.editTagToolStripMenuItem.Enabled = false;
            this.editTagToolStripMenuItem.Name = "editTagToolStripMenuItem";
            this.editTagToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editTagToolStripMenuItem.Text = "Edit";
            this.editTagToolStripMenuItem.Click += new System.EventHandler(this.editTagToolStripMenuItem_Click);
            // 
            // deleteTagToolStripMenuItem
            // 
            this.deleteTagToolStripMenuItem.Enabled = false;
            this.deleteTagToolStripMenuItem.Name = "deleteTagToolStripMenuItem";
            this.deleteTagToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteTagToolStripMenuItem.Text = "Delete";
            this.deleteTagToolStripMenuItem.Click += new System.EventHandler(this.deleteTagToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ItemListView);
            this.tabPage2.Controls.Add(this.menuStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Containers/items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ItemListView
            // 
            this.ItemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemListView.LargeImageList = this.imageList1;
            this.ItemListView.Location = new System.Drawing.Point(3, 27);
            this.ItemListView.Name = "ItemListView";
            this.ItemListView.Size = new System.Drawing.Size(808, 311);
            this.ItemListView.TabIndex = 0;
            this.ItemListView.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "item.png");
            this.imageList1.Images.SetKeyName(1, "container.png");
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.deleteItemToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(3, 3);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(808, 24);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addItemToolStripMenuItem.Text = "Add";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editItemToolStripMenuItem.Text = "Edit";
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteItemToolStripMenuItem.Text = "Delete";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "Tags";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // taglistView
            // 
            this.taglistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.taglistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taglistView.LargeImageList = this.imageList1;
            this.taglistView.Location = new System.Drawing.Point(3, 27);
            this.taglistView.Name = "taglistView";
            this.taglistView.Size = new System.Drawing.Size(808, 311);
            this.taglistView.TabIndex = 1;
            this.taglistView.UseCompatibleStateImageBehavior = false;
            this.taglistView.View = System.Windows.Forms.View.Details;
            this.taglistView.SelectedIndexChanged += new System.EventHandler(this.taglistView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tags";
            this.columnHeader1.Width = 728;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 391);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView ItemListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTagToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ListView taglistView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

