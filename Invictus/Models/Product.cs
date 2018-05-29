using Invictus.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{
    [Table("PRODUCTS")]
    class Product
    {
        [Id]
        [Column("Id")]
        private int id
        {
            get { return id; }
            set { id = value; }
        }
        
        [Column("Name")]
        private String name
        {
            get { return name; }
            set { name = value; }
        }
        [Column("CategoryId")]
        private int CategoryId
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }
        [Column("Description")]
        private String DesCription
        {
            get { return DesCription; }
            set { DesCription = value; }
        }
    }
}
