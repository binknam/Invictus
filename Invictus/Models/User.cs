using Invictus.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{
    [Table("Users")]
    class User
    {
        [Id]
        [Column("Username")]
        private String Username
        {
            get { return Username; }
            set { Username = value; }
        }
        [Column("Password")]
        private String Password
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}
