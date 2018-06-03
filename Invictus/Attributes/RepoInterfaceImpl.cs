using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class RepoInterfaceImpl : Attribute
    {
        private Type typeOfSuper;
        public RepoInterfaceImpl(Type typeOfSuper)
        {
            this.typeOfSuper = typeOfSuper;
        }

        public virtual Type TypeOfSuper
        {
            get { return typeOfSuper; }
        }
    }
}
