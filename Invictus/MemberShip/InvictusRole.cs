using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.MemberShip
{
    [Table("InvictusRoles")]
    public class InvictusRole
    {
        [Id]
        [Column("Name")]
        public String Name { get; set; }
        [Column("canCreate")]
        public bool canCreate { get; set; }
        [Column("canRead")]
        public bool canRead { get; set; }
        [Column("canUpdate")]
        public bool canUpdate { get; set; }
        [Column("canDelete")]
        public bool canDelete { get; set; }
    }
}
