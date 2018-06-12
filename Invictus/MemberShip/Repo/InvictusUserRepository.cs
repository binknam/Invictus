using Invictus.Attributes;
using Invictus.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.MemberShip
{
    [RepoInterfaceImpl(typeof(InvictusUser))]
    public class InvictusUserRepository : GenericRepositoryImpl<InvictusUser, String>
    {
        protected override Type getEntityClass()
        {
            return typeof(InvictusUser);
        }
    }
}
