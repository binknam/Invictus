using Invictus.Attributes;
using Invictus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    [RepoInterfaceImpl(typeof(User))]
    class UserRepositoryImpl : GenericRepositoryImpl<User, String>
    {
        protected override Type getEntityClass()
        {
            return typeof(User);
        }
    }
}
