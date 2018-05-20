using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Form1
{
    public partial class Frdangnhap : Form
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=INVICTUS-PC\SQLEXPRESS;Initial Catalog=invictus;Integrated Security=True");
        public Frdangnhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntdangnhap_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != String.Empty && txtpass.Text!= String.Empty)
            {
                var dap = new SqlDataAdapter("select * from dbo.users where dbo.users.username = @username", sqlConnection);
                dap.SelectCommand.Parameters.AddWithValue("@username", txtusername.Text);

                var table = new DataTable();
                dap.Fill(table);
                if (table.Rows.Count == 1)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if ((String)row["password"] == txtpass.Text)
                        {
                            grbdangnhap.Text = "Dang nhap thanh cong";
                        }
                        else
                        {
                            grbdangnhap.Text = "Sai Pass";
                        }
                    }
                }
                else
                {
                    grbdangnhap.Text = "Sai ten tai khoan!";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
