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
    public partial class ManageRoleForm : ManageForm<InvictusRole, String>
    {
        public ManageRoleForm()
        {
            InitializeComponent();
        }

        private void ManageRoleForm_Load(object sender, EventArgs e)
        {
            manageUserLink.Visible = false;
        }
    }
}
