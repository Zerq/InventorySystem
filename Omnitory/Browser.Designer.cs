namespace Omnitory {
    partial class Browser {
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.back = new System.Windows.Forms.ToolStripMenuItem();
            this.forward = new System.Windows.Forms.ToolStripMenuItem();
            this.navbox = new System.Windows.Forms.ToolStripTextBox();
            this.GoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectOk = new System.Windows.Forms.ToolStripMenuItem();
            this.cansleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 292);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(608, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.back,
            this.forward,
            this.navbox,
            this.GoTo,
            this.SelectOk,
            this.cansleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // back
            // 
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(35, 23);
            this.back.Text = "<<";
            this.back.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // forward
            // 
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(35, 23);
            this.forward.Text = ">>";
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // navbox
            // 
            this.navbox.Name = "navbox";
            this.navbox.Size = new System.Drawing.Size(100, 23);
            // 
            // GoTo
            // 
            this.GoTo.Name = "GoTo";
            this.GoTo.Size = new System.Drawing.Size(30, 23);
            this.GoTo.Text = "@";
            this.GoTo.Click += new System.EventHandler(this.GoTo_Click);
            // 
            // SelectOk
            // 
            this.SelectOk.Name = "SelectOk";
            this.SelectOk.Size = new System.Drawing.Size(50, 23);
            this.SelectOk.Text = "Select";
            this.SelectOk.Click += new System.EventHandler(this.Select_Click);
            // 
            // cansleToolStripMenuItem
            // 
            this.cansleToolStripMenuItem.Name = "cansleToolStripMenuItem";
            this.cansleToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this.cansleToolStripMenuItem.Text = "Cansle";
            this.cansleToolStripMenuItem.Click += new System.EventHandler(this.cansleToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 27);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(608, 265);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 314);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.Shown += new System.EventHandler(this.Browser_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem back;
        private System.Windows.Forms.ToolStripMenuItem forward;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripTextBox navbox;
        private System.Windows.Forms.ToolStripMenuItem GoTo;
        private System.Windows.Forms.ToolStripMenuItem SelectOk;
        private System.Windows.Forms.ToolStripMenuItem cansleToolStripMenuItem;
    }
}