using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.MemberShip
{
    
    [Table("InvictusUsers")]
    public class InvictusUser
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

        [Column("RoleName")]
        public String RoleName
        {
            get;
            set;
        }
    }
}
