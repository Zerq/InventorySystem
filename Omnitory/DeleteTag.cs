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
    public partial class DeleteTag : Form {
        public DeleteTag() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void DeleteTag_Shown(object sender, EventArgs e) {
          
        }
    }
}
