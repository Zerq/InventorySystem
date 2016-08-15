namespace Omnitory {
    partial class EditItem {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.Newtagbutton = new System.Windows.Forms.Button();
            this.tagCombo = new System.Windows.Forms.ComboBox();
            this.taglistBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.editItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IsContainer = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 29);
            this.panel1.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(162, 0);
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
            this.panel2.Location = new System.Drawing.Point(207, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 29);
            this.panel2.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(222, 0);
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
            this.panel4.Location = new System.Drawing.Point(300, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(13, 29);
            this.panel4.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 332);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 10);
            this.panel3.TabIndex = 26;
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(10, 163);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(56, 27);
            this.removeButton.TabIndex = 36;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Newtagbutton
            // 
            this.Newtagbutton.Location = new System.Drawing.Point(10, 134);
            this.Newtagbutton.Name = "Newtagbutton";
            this.Newtagbutton.Size = new System.Drawing.Size(56, 23);
            this.Newtagbutton.TabIndex = 35;
            this.Newtagbutton.Text = "Add";
            this.Newtagbutton.UseVisualStyleBackColor = true;
            this.Newtagbutton.Click += new System.EventHandler(this.Newtagbutton_Click);
            // 
            // tagCombo
            // 
            this.tagCombo.FormattingEnabled = true;
            this.tagCombo.Location = new System.Drawing.Point(73, 107);
            this.tagCombo.Name = "tagCombo";
            this.tagCombo.Size = new System.Drawing.Size(227, 21);
            this.tagCombo.TabIndex = 34;
            this.tagCombo.SelectedIndexChanged += new System.EventHandler(this.tagCombo_SelectedIndexChanged);
            // 
            // taglistBox
            // 
            this.taglistBox.FormattingEnabled = true;
            this.taglistBox.Location = new System.Drawing.Point(72, 134);
            this.taglistBox.Name = "taglistBox";
            this.taglistBox.Size = new System.Drawing.Size(228, 134);
            this.taglistBox.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tags:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(72, 34);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(228, 63);
            this.descriptionBox.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Description:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(72, 8);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(228, 20);
            this.nameBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Name:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(190, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 23);
            this.button4.TabIndex = 38;
            this.button4.Text = "Print id barcode";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // editItemBindingSource
            // 
            this.editItemBindingSource.DataSource = typeof(Omnitory.EditItem);
            // 
            // IsContainer
            // 
            this.IsContainer.AutoSize = true;
            this.IsContainer.Location = new System.Drawing.Point(10, 280);
            this.IsContainer.Name = "IsContainer";
            this.IsContainer.Size = new System.Drawing.Size(82, 17);
            this.IsContainer.TabIndex = 39;
            this.IsContainer.Text = "Is Container";
            this.IsContainer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IsContainer);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
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
            this.Name = "EditItem";
            this.Text = "EditItem";
            this.Load += new System.EventHandler(this.EditItem_Load);
            this.Shown += new System.EventHandler(this.EditItem_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button Newtagbutton;
        private System.Windows.Forms.ComboBox tagCombo;
        private System.Windows.Forms.ListBox taglistBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.BindingSource editItemBindingSource;
        public System.Windows.Forms.CheckBox IsContainer;
        private System.Windows.Forms.Button button1;
    }
}