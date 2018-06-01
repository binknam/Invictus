using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class Id : Attribute
    {
        public Id() { }
    }
}
