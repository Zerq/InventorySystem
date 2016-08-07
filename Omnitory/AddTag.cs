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
    public partial class AddTag : Form {
        public AddTag() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {   
                DialogResult = DialogResult.OK;     
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
        private void ValidateOkButton() {
            if (TagName.Text == "") {
                button2.Enabled = false;
            } else {
                button2.Enabled = true;
            }
        }
        private void TagName_TextChanged(object sender, EventArgs e) {
            ValidateOkButton();
        }
        

        private void AddTag_Load(object sender, EventArgs e) {

        }

        private void AddTag_Shown(object sender, EventArgs e) {
            TagName.Text = "";
            button2.Enabled = false;
        }

        private void TagName_KeyPress(object sender, KeyPressEventArgs e) {
            ValidateOkButton();
        }
    }
}
