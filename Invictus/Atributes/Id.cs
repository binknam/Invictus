using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Atributes
{
    [AttributeUsage(AttributeTargets.All)]
    class Id : Attribute
    {
        public Id() { }
    }
}
