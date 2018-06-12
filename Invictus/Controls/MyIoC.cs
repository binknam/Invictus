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
                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    managedObjects.Add(repoInterfaceImpl.TypeOfModel, constructor.Invoke(new object[0]));
                }
            }
            foreach (Type type in assembly.GetTypes())
            {
                Controller controller = (Controller)type.GetCustomAttribute(typeof(Controller));
                if (controller != null)
                {
                    Type[] listTypeOfModel = controller.ListTypeOfModel;
                    Type typeObject = typeof(object[]);
                    Type[] typeObjects = new Type[1];
                    typeObjects[0] = typeObject;
                    ConstructorInfo constructor = type.GetConstructor(typeObjects);
                    object[] repositories = new object[listTypeOfModel.Length];
                    for (int i = 0; i < listTypeOfModel.Length; i++)
                    {
                        repositories[i] = get(listTypeOfModel[i]);
                    }
                    Object a = constructor.Invoke(new object[] {repositories });
                    managedObjects.Add(type, a);
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
