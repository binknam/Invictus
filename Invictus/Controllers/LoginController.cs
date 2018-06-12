using Invictus.Attributes;
using Invictus.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Controllers
{
    [Controller(new Type[] { typeof(InvictusUser) })]
    class LoginController
    {
        public InvictusUserRepository invictusUserRepository;

        public LoginController(object[] repositories)
        {
            invictusUserRepository = (InvictusUserRepository)repositories[0];
        }
    }
}
