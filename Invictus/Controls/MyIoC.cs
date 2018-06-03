using Invictus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Controls
{
    public class MyIoC
    {
        private Dictionary<Type, Object> managedObjects = new Dictionary<Type, Object>();

        public void initialize()
        {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    RepoInterfaceImpl repoInterfaceImpl = (RepoInterfaceImpl)type.GetCustomAttribute(typeof(RepoInterfaceImpl));
                    managedObjects.Add(repoInterfaceImpl.TypeOfSuper, Activator.CreateInstance(type));
                }
            }

        }

        public Object get(Type type)
        {
            return managedObjects[type];
        }
    }
}
