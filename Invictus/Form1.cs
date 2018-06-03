using Invictus.Models;
using Invictus.Repository;
using Invictus.Repository.Impl;
using Invictus.Utils;
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
using System.Xml;

namespace Invictus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            CategoryRepository categoryRepository = new CategoryRepositoryImpl();
            Category category = categoryRepository.findById(1);

            textBox1.DataBindings.Add("Text", category, "Id");
            textBox2.DataBindings.Add("Text", category, "Name");

            category.Name = "MY PHjONE";
            categoryRepository.delete(5);
        }
    }
}
