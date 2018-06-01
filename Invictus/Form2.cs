using Invictus.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Invictus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            String dataSource = "";
            String dataBase = "";
            FileStream fs = new FileStream("databaseConfig.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("datasource");
            dataSource = xmlnode[0].InnerText.Trim();
            xmlnode = xmldoc.GetElementsByTagName("database");
            dataBase = xmlnode[0].InnerText.Trim();
            String url = @"Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=True";
            ConnectionManager connectionManager = ConnectionManager.getInstance();
            connectionManager.initialize(url, null, null);
            SqlDataAdapter dap = new SqlDataAdapter("Select * from categories", connectionManager.getConnection());
            var table = new DataTable();
            dap.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
