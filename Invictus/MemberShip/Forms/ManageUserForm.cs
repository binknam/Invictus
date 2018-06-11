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
        }

        private void manageRoleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageRoleForm manageRoleForm = new ManageRoleForm(this);
            manageRoleForm.setCurrentUser(currentUser);
            manageRoleForm.Show();
            Enabled = false;
        }
    }
}
