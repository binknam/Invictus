using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invictus.Controls;
using Invictus.Models;

namespace Invictus
{
    public partial class InitForm : Form
    {
        private String dataSource;
        private String dataBase;
        private MainControls controls;

        public InitForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtDataBase.Text !=  "" && txtDataSource.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void txtDataBase_TextChanged(object sender, EventArgs e)
        {
            if (txtDataBase.Text != "" && txtDataSource.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSource = txtDataSource.Text;
            dataBase = txtDataBase.Text;
            controls = MainControls.GetControls(dataBase, dataSource);
            CreateParam param = new CreateParam();
            param.tableName = "users";
            param.columns = new String[4];
            param.columns[0] = "id";
            param.columns[1] = "username";
            param.columns[2] = "password";
            param.columns[3] = "name";

            param.dataTypes = new String[4];
            param.dataTypes[0] = "bigint";
            param.dataTypes[1] = "nvarchar(255)";
            param.dataTypes[2] = "nvarchar(255)";
            param.dataTypes[3] = "nvarchar(255)";
            param.primaryKey = "id";
            controls.doActions("CREATE", param);
            this.Hide();
            (new RegisterForm()).Show();
        }
    }
}
