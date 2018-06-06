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
        private Dictionary<Type, Object> managedObjects;

        public MyIoC()
        {
            managedObjects= new Dictionary<Type, Object>();
        }

        public void initialize()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                RepoInterfaceImpl repoInterfaceImpl = (RepoInterfaceImpl)type.GetCustomAttribute(typeof(RepoInterfaceImpl));
                if (repoInterfaceImpl != null)
                {
                    managedObjects.Add(repoInterfaceImpl.TypeOfSuper, Activator.CreateInstance(type));
                }
            }


        }

        public Object get(Type type)
        {
            if (managedObjects.ContainsKey(type))
            {
                return managedObjects[type];
            }
            return null;
        }
    }
}
