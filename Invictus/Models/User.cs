using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{
    [Table("Users")]
    public class User
    {
        [Id]
        [Column("Username")]
        public String Username
        {
            get;
            set;
        }
        [Column("Password")]
        public String Password
        {
            get;
            set;
        }
    }
}
