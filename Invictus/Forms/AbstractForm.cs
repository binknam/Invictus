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

namespace Invictus.Forms
{
    public partial class AbstractForm<E, I> : Form
    {
        protected GenericRepository<E, I> repository;
        protected MyIoC myIoc;
        public AbstractForm()
        {
            InitializeComponent();
        }

        protected void AbstractForm_Load(object sender, EventArgs e)
        {

        }
    }
}
