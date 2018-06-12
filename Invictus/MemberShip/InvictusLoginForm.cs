using Invictus.Controllers;
using Invictus.Controls;
using Invictus.Forms;
using Invictus.MemberShip.Forms;
using Invictus.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invictus.MemberShip
{
    public partial class InvictusLoginForm : Form
    {
        private LoginController loginController;
        private MyIoC myIoC;
        private InvictusUser user;
        public InvictusLoginForm()
        {
            myIoC = MyIoC.getInstance();
            loginController = (LoginController) myIoC.get(typeof(LoginController));
            user = new InvictusUser();
            InitializeComponent();
        }


        private void InvictusLoginForm_Load(object sender, EventArgs e)
        {
            usernamTxt.DataBindings.Add("Text", user, "Username");
            passwordTxt.DataBindings.Add("Text", user, "Password");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(usernamTxt.Text!="" && passwordTxt.Text!="")
            {
                user = loginController.invictusUserRepository.findById(user.Username);
                if (user.Password != null && user.Password == passwordTxt.Text)
                {
                    CategoryForm categoryForm = new CategoryForm();
                    categoryForm.setCurrentUser(user);
                    categoryForm.Show();
                    Hide();
                }
            }
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDetailForm userDetailForm = new UserDetailForm();
            userDetailForm.Show();
        }
    }
}
