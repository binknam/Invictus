using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Id]
        [Column("Id")]
        public int id
        {
            get;
            set;
        }

        [Column("Name")]
        public String name
        {
            get;
            set;
        }
        [Column("CategoryId")]
        public int CategoryId
        {
            get;
            set;
        }
        [Column("Description")]
        public String DesCription
        {
            get;
            set;
        }
    }
}
