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

        private static MyIoC instance = new MyIoC();

        private MyIoC()
        {
            managedObjects= new Dictionary<Type, Object>();
            initialize();
        }

        private void initialize()
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

        public static MyIoC getInstance()
        {
            return instance;
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
