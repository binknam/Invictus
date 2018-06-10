using Invictus.Forms;
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
    public partial class ManageUserForm : InvictusBaseForm<InvictusUser, String>
    {
        public ManageUserForm()
        {
            InitializeComponent();
            manageUserLink.Text = "Manage role";
        }

        private void manageUserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageRoleForm manageRoleForm = new ManageRoleForm();
            manageRoleForm.setCurrentUser(currentUser);
            manageRoleForm.Show();
            Close();
        }
    }
}
