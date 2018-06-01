using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
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
