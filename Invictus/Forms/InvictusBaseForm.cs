using Invictus.Attributes;
using Invictus.Controls;
using Invictus.MemberShip;
using Invictus.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invictus.Forms
{
    public partial class InvictusBaseForm<E, I> : Form
    {
        protected IGenericRepository<E, I> repository;
        protected MyIoC myIoC;
        protected ObjectDetailsForm<E, I> createForm;
        protected ObjectDetailsForm<E, I> updateForm;
        protected InvictusUser currentUser;
        protected InvictusRole currentUserRole;
        protected InvictusRoleRepository roleRepository;
        protected List<E> objects;
        protected BindingList<E> bindingList;
        protected PropertyInfo[] props;

        protected int columnIdIndex = 0;
        protected I selectedEntityId;

        public InvictusBaseForm()
        {
            myIoC = MyIoC.getInstance();
            repository = (IGenericRepository<E, I>)myIoC.get(typeof(E));
            roleRepository = new InvictusRoleRepository();
            currentUser = new InvictusUser();
            currentUserRole = new InvictusRole();
            InitializeComponent();
        }

        private void InvictusBaseForm_Load(object sender, EventArgs e)
        {
            if (currentUser.RoleName == "Admin")
            {
                //manageUserLink.Visible = true;
            }
            Table table = (Table)typeof(E).GetCustomAttribute(typeof(Table));
            tableNamelb.Text = table.Name;
            if (currentUserRole.canRead)
            {
                String columnIdName = "";

                props = typeof(E).GetProperties(
                         BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                for (int i = 0; i < props.Length; i++)
                {
                    Id idAnnotation = (Id)props[i].GetCustomAttribute(typeof(Id));
                    Column column = (Column)props[i].GetCustomAttribute(typeof(Column));
                    if (idAnnotation != null)
                    {
                        columnIdName = column.Name;
                        break;
                    }
                }

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Name == columnIdName)
                    {
                        columnIdIndex = i;
                        break;
                    }
                }
                objects = repository.findAll();
                bindingList = new BindingList<E>(objects);
                dataGridView.DataSource = bindingList;
            }

            if (!currentUserRole.canCreate)
            {
                createBtn.Enabled = false;
            }

            if (!currentUserRole.canDelete)
            {
                deleteBtn.Enabled = false;
            }

            if (!currentUserRole.canUpdate)
            {
                updateBtn.Enabled = false;
            }

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            createForm = new ObjectDetailsForm<E, I>(this);
            createForm.type = ObjectDetailsForm<E, I>.CREATE_MODE;
            createForm.Show();
            Enabled = false;
        }

        public void updateDataGridView()
        {
            InvictusBaseForm_Load(null, null);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEntityId = (I)dataGridView.CurrentRow.Cells[columnIdIndex].Value;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            repository.delete(selectedEntityId);
            updateDataGridView();
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            selectedEntityId = (I)dataGridView.CurrentRow.Cells[columnIdIndex].Value;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentUserRole.canUpdate)
            {
                updateForm = new ObjectDetailsForm<E, I>(this);
                E entity = getCurrentEntity();
                updateForm.setEntity(entity);
                updateForm.type = ObjectDetailsForm<E, I>.UPDATE_MODE;
                updateForm.Show();
                Enabled = false;
            }
        }

        private void manageUserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Enabled = false;
            ManageUserForm manageUserForm = new ManageUserForm();
            manageUserForm.setCurrentUser(currentUser);
            manageUserForm.Show();
            Close();
        }

        public void setCurrentUser(InvictusUser user)
        {
            currentUser = user;
            currentUserRole = roleRepository.findById(currentUser.RoleName);
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private E getCurrentEntity()
        {
            E entity = default(E);
            foreach (E e in bindingList)
            {
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetCustomAttribute(typeof(Id)) != null)
                    {
                        if (prop.GetValue(e).Equals(selectedEntityId))
                        {
                            entity = e;
                        }
                    }
                }
            }
            return entity;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            E entity = getCurrentEntity();
            if (entity != null)
            {
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetCustomAttribute(typeof(Id)) == null)
                    {
                        if (((Column)prop.GetCustomAttribute(typeof(Column))).Name ==
                            dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name)
                        {
                            prop.SetValue(entity, dataGridView.CurrentCell.Value);
                        }
                    }
                }
                repository.update(entity);
            }
        }
    }
}
