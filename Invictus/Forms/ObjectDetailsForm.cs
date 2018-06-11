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
    public partial class ObjectDetailsForm<E, I> : Form
    {
        protected GenericRepository<E, I> repository;
        protected MyIoC myIoC;
        protected E entity;
        protected PropertyInfo[] props;

        public static int CREATE_MODE = 0;
        public static int UPDATE_MODE = 1;
        public static int REGISTER_MODE = 2;

        protected InvictusBaseForm<E, I> mainForm;

        private List<Label> labels = new List<Label>();
        private List<TextBox> textBoxes = new List<TextBox>();

        public int type = 0;
        public ObjectDetailsForm(InvictusBaseForm<E, I> mainForm)
        {
            myIoC = MyIoC.getInstance();
            repository = (GenericRepository<E, I>)myIoC.get(typeof(E));
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public ObjectDetailsForm()
        {
            myIoC = MyIoC.getInstance();
            repository = (GenericRepository<E, I>)myIoC.get(typeof(E));
            InitializeComponent();
        }

        private void ObjectDetailsForm_Load(object sender, EventArgs e)
        {
            props = typeof(E).GetProperties(
                     BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < props.Length; i++)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();
                Id idAnnotation = (Id)props[i].GetCustomAttribute(typeof(Id));
                Column column = (Column)props[i].GetCustomAttribute(typeof(Column));
                if (idAnnotation != null && type == 1)
                {
                    textBox.Enabled = false;
                }
                label.Text = column.Name;
                label.Top = 80 + (i + 1) * 40;
                label.Left = 50;
                label.Size = new Size(200, 30);
                label.Visible = true;
                labels.Add(label);
                textBox.Top = 80 + (i + 1) * 40;
                textBox.Left = 300;
                textBox.Visible = true;
                textBox.Size = new Size(200, 30);
                textBoxes.Add(textBox);
                Controls.Add(textBox);
                Controls.Add(label);
            }
            Height = props.Length * 200;
            createOrUpdateBtn.Top = Height - 100;
            if (type == CREATE_MODE || type == REGISTER_MODE)
            {
                createOrUpdateBtn.Text = "Create";
                entity = (E)Activator.CreateInstance(typeof(E));
                
            }
            if (type == UPDATE_MODE)
            {
                createOrUpdateBtn.Text = "Update";
            }
            for (int i = 0; i < props.Length; i++)
            {
                textBoxes[i].DataBindings.Add("Text", entity, props[i].Name);
            }
        }

        private void createOrUpdateBtn_Click(object sender, EventArgs e)
        {
            Boolean canDoAction = true;
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "")
                {
                    canDoAction = false;
                }
            }
            if (canDoAction)
            {
                if (type == CREATE_MODE || type == REGISTER_MODE)
                {
                    I id = (I)props[0].GetValue(entity);
                    if (!repository.isExisted(id))
                    {
                        repository.create(entity);
                    }
                }
                if (type == UPDATE_MODE)
                {
                    repository.update(entity);
                }
                if (type != REGISTER_MODE)
                {
                    mainForm.updateDataGridView();
                    mainForm.Enabled = true;
                }
                Close();
            }
        }

        private void ObjectDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (type != REGISTER_MODE)
            {
                mainForm.updateDataGridView();
                mainForm.Enabled = true;
            }
        }

        public void setEntity(E entity)
        {
            this.entity = entity;
        }
    }
}
