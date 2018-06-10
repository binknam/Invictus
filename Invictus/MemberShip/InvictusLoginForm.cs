using Invictus.Controls;
using Invictus.Forms;
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
        private GenericRepository<InvictusUser, String> userRepository;
        private MyIoC myIoC;
        private InvictusUser user;
        public InvictusLoginForm()
        {
            myIoC = MyIoC.getInstance();
            userRepository = (GenericRepository<InvictusUser, String>) myIoC.get(typeof(InvictusUser));
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
                user = userRepository.findById(user.Username);
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
            ObjectDetailsForm<InvictusUser, String>  createForm = new ObjectDetailsForm<InvictusUser, String>();
            createForm.type = ObjectDetailsForm<InvictusUser, String>.REGISTER_MODE;
            createForm.Show();
        }
    }
}
