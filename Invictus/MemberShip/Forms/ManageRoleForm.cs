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
    public partial class ManageRoleForm : InvictusBaseForm<InvictusRole, String>
    {
        private ManageUserForm userForm;
        public ManageRoleForm(ManageUserForm userForm)
        {
            this.userForm = userForm;
            InitializeComponent();
        }

        private void ManageRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userForm.Enabled = true;
        }
    }
}
