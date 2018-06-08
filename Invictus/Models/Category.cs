using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{

    [Table("Categories")]
    public class Category
    {
        [Id]
        [Column("Id")]
        public Int64 Id
        {
            get;
            set;
        }
        [Column("Name")]
        public String Name
        {
            get;
            set;
        }
    }
}