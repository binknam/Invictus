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
        public InvictusBaseForm()
        {
            myIoC = new MyIoC();
            myIoC.initialize();
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
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            createBtn.Text = "aa";
        }
    }
}
