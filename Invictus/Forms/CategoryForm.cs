using Invictus.MemberShip;
using Invictus.MemberShip.Forms;
using Invictus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invictus.Forms
{
    public partial class CategoryForm : InvictusBaseForm<Category, Int64>
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void manageUserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageUserForm manageUserForm = new ManageUserForm();
            manageUserForm.setCurrentUser(currentUser);
            manageUserForm.Show();
            Close();
        }

        private void userDetailLb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDetailForm userDetailForm = new UserDetailForm(currentUser);
            userDetailForm.Show();
        }
    }
}
