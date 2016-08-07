namespace Omnitory {
    partial class AddItem {
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
            this.label1 = new System.Windows.Forms.Label();
            this.barcode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taglistBox = new System.Windows.Forms.ListBox();
            this.tagCombo = new System.Windows.Forms.ComboBox();
            this.Newtagbutton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.isContainer = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode:";
            // 
            // barcode
            // 
            this.barcode.Location = new System.Drawing.Point(79, 10);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(142, 20);
            this.barcode.TabIndex = 1;
            this.barcode.Leave += new System.EventHandler(this.barcode_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Print barcode";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 10);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 29);
            this.panel1.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(188, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(233, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 29);
            this.panel2.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(248, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(326, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(13, 29);
            this.panel4.TabIndex = 7;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(79, 47);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(228, 20);
            this.nameBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(79, 73);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(228, 63);
            this.descriptionBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tags:";
            // 
            // taglistBox
            // 
            this.taglistBox.FormattingEnabled = true;
            this.taglistBox.Location = new System.Drawing.Point(79, 173);
            this.taglistBox.Name = "taglistBox";
            this.taglistBox.Size = new System.Drawing.Size(228, 134);
            this.taglistBox.TabIndex = 15;
            this.taglistBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tagCombo
            // 
            this.tagCombo.FormattingEnabled = true;
            this.tagCombo.Location = new System.Drawing.Point(80, 146);
            this.tagCombo.Name = "tagCombo";
            this.tagCombo.Size = new System.Drawing.Size(227, 21);
            this.tagCombo.TabIndex = 16;
            // 
            // Newtagbutton
            // 
            this.Newtagbutton.Location = new System.Drawing.Point(17, 173);
            this.Newtagbutton.Name = "Newtagbutton";
            this.Newtagbutton.Size = new System.Drawing.Size(56, 23);
            this.Newtagbutton.TabIndex = 19;
            this.Newtagbutton.Text = "Add";
            this.Newtagbutton.UseVisualStyleBackColor = true;
            this.Newtagbutton.Click += new System.EventHandler(this.Newtagbutton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(17, 202);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(56, 27);
            this.removeButton.TabIndex = 20;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // isContainer
            // 
            this.isContainer.AutoSize = true;
            this.isContainer.Location = new System.Drawing.Point(80, 314);
            this.isContainer.Name = "isContainer";
            this.isContainer.Size = new System.Drawing.Size(82, 17);
            this.isContainer.TabIndex = 22;
            this.isContainer.Text = "Is Container";
            this.isContainer.UseVisualStyleBackColor = true;
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 386);
            this.Controls.Add(this.isContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.Newtagbutton);
            this.Controls.Add(this.tagCombo);
            this.Controls.Add(this.taglistBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddItem";
            this.Text = "AddItem";
            this.Load += new System.EventHandler(this.AddItem_Load_1);
            this.Shown += new System.EventHandler(this.AddItem_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox barcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox taglistBox;
        private System.Windows.Forms.ComboBox tagCombo;
        private System.Windows.Forms.Button Newtagbutton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.CheckBox isContainer;
    }
}