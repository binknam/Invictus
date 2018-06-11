using Invictus.Controls;
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

namespace Invictus.MemberShip.Forms
{
    public partial class UserDetailForm : Form
    {
        protected GenericRepository<InvictusUser, String> userRepository;
        protected GenericRepository<InvictusRole, String> roleRepository;
        protected MyIoC myIoC;
        protected InvictusUser currentUser;
        protected InvictusRole currentUserRole;
        protected int type;
        protected String oldPassword;
        public static String RoleDefautId = "Admin";
        public UserDetailForm()
        {
            type = 1;
            myIoC = MyIoC.getInstance();
            userRepository = (GenericRepository <InvictusUser, String>)myIoC.get(typeof(InvictusUser));
            roleRepository = (GenericRepository <InvictusRole, String>)myIoC.get(typeof(InvictusRole));
            InitializeComponent();
        }

        public UserDetailForm(InvictusUser user)
        {
            type = 0;
            myIoC = MyIoC.getInstance();
            userRepository = (GenericRepository<InvictusUser, String>)myIoC.get(typeof(InvictusUser));
            roleRepository = (GenericRepository<InvictusRole, String>)myIoC.get(typeof(InvictusRole));
            currentUser = user;
            currentUserRole = roleRepository.findById(currentUser.RoleName);
            InitializeComponent();
        }

        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            if (type == 0)
            {
                userNameTxt.Enabled = false;
                passwordTxt.Enabled = false;

                newPWTxt.Visible = false;
                newPasswordLb.Visible = false;
                confirmPasswordLb.Visible = false;
                confirmPWTxt.Visible = false;

                canCreateCkb.Enabled = false;
                canReadCkb.Enabled = false;
                canUpdateCkb.Enabled = false;
                canDeleteCkb.Enabled = false;
            }
            if (type == 1)
            {
                currentUser = new InvictusUser();
                userNameTxt.Enabled = true;
                passwordTxt.Enabled = true;

                newPWTxt.Visible = false;
                newPasswordLb.Visible = false;
                confirmPasswordLb.Visible = true;
                confirmPWTxt.Visible = true;

                canCreateCkb.Visible = false;
                canReadCkb.Visible = false;
                canUpdateCkb.Visible = false;
                canDeleteCkb.Visible = false;
                resetPWLb.Visible = false;
            }
            userNameTxt.DataBindings.Add("Text", currentUser, "Username");
            passwordTxt.DataBindings.Add("Text", currentUser, "Password");

            canCreateCkb.DataBindings.Add("Checked", currentUserRole, "canCreate");
            canReadCkb.DataBindings.Add("Checked", currentUserRole, "canRead");
            canUpdateCkb.DataBindings.Add("Checked", currentUserRole, "canUpdate");
            canDeleteCkb.DataBindings.Add("Checked", currentUserRole, "canDelete");
        }

        private void resetPWLb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            oldPassword = currentUser.Password;
            passwordTxt.Text = "";
            currentUser.Password = "";
            passwordTxt.Enabled = true;
            newPWTxt.Visible = true;
            newPasswordLb.Visible = true;
            confirmPasswordLb.Visible = true;
            confirmPWTxt.Visible = true;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                if (currentUser.Password == oldPassword && newPWTxt.Text == confirmPWTxt.Text)
                {
                    currentUser.Password = newPWTxt.Text;
                    userRepository.update(currentUser);

                }
            }
            if (type == 1)
            {
                if (currentUser.Password == confirmPWTxt.Text && currentUser.Username != "" && currentUser.Password != "")
                {
                    currentUser.RoleName = roleRepository.findById(RoleDefautId).Name;
                    userRepository.create(currentUser);
                }
            }
            Close();
        }
    }
}
