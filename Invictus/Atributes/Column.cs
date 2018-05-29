using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Atributes
{
    [AttributeUsage(AttributeTargets.All)]
    class Column : Attribute
    {
        private String name;
        public Column(String name)
        {
            this.name = name;
        }

        public virtual String Name
        {
            get { return name; }
        }
    }
}
