using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omnitory {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
