using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invictus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String config = System.IO.File.ReadAllText(@"DatabaseConfig.txt");
            if (config == "")
            {
                Application.Run(new InitForm());
            }
            else Application.Run(new Form1.Frdangnhap());
        }
    }
}
