using Invictus.Attributes;
using Invictus.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Controllers
{
    [Controller(new Type[] { typeof(InvictusUser), typeof(InvictusRole)})]
    public class UserDetailController
    {
        public InvictusUserRepository invictusUserRepository;
        public InvictusRoleRepository invictusRoleRepository;

        public UserDetailController(object[] repositories)
        {
            invictusUserRepository = (InvictusUserRepository)repositories[0];
            invictusRoleRepository = (InvictusRoleRepository)repositories[1];
        }
    }
}
