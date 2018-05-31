using Invictus.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Models
{

    [Table("Categories")]
    class Category
    {
        [Id]
        [Column("Id")]
        private int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        [Column("Name")]
        private String Name
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}