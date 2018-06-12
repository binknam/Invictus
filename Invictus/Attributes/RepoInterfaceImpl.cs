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
        private Type typeOfModel;
        public RepoInterfaceImpl(Type typeOfModel)
        {
            this.typeOfModel = typeOfModel;
        }

        public virtual Type TypeOfModel
        {
            get { return typeOfModel; }
        }
    }
}
