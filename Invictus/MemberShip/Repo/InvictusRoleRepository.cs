using Invictus.Attributes;
using Invictus.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.MemberShip
{
    [RepoInterfaceImpl(typeof(InvictusRole))]
    public class InvictusRoleRepository : GenericRepositoryImpl<InvictusRole, String>
    {
        protected override Type getEntityClass()
        {
            return typeof(InvictusRole);
        }
    }
}
