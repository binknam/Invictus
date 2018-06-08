using Invictus.Attributes;
using Invictus.Controls;
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
        protected GenericRepository<E, I> repository;
        protected MyIoC myIoC;
        protected ObjectDetailsForm<E, I> createForm;
        protected ObjectDetailsForm<E, I> updateForm;

        protected int columnIdIndex = 0;
        protected I selectedEntityId;

        public InvictusBaseForm()
        {
            myIoC = MyIoC.getInstance();
            repository = (GenericRepository<E, I>)myIoC.get(typeof(E));
            InitializeComponent();
        }

        private void InvictusBaseForm_Load(object sender, EventArgs e)
        {
            Table table = (Table)typeof(E).GetCustomAttribute(typeof(Table));
            tableNamelb.Text = table.Name;
            List<E> objects = repository.findAll();
            BindingList<E> list = new BindingList<E>(objects);
            dataGridView.DataSource = list;

            String columnIdName = "";

            PropertyInfo[] props = typeof(E).GetProperties(
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
            updateForm = new ObjectDetailsForm<E, I>(this);
            E entity = repository.findById(selectedEntityId);
            updateForm.setEntity(entity);
            updateForm.type = ObjectDetailsForm<E,I>.UPDATE_MODE;
            updateForm.Show();
            Enabled = false;
        }
    }
}
