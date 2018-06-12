using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class Controller : Attribute
    {
        private Type[] listTypeOfModel;
        public Controller(Type[] listTypeOfModel)
        {
            this.listTypeOfModel = listTypeOfModel;
        }

        public virtual Type[] ListTypeOfModel
        {
            get { return listTypeOfModel; }
        }
    }
}
