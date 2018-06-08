using Invictus.Models;
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
    public partial class UserForm : InvictusBaseForm<User, String>
    {
        public UserForm()
        {
            InitializeComponent();
        }
    }
}
