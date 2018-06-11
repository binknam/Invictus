using Invictus.Attributes;
using Invictus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    [RepoInterfaceImpl(typeof(Category))]
    class CategoryRepositoryImpl : GenericRepositoryImpl<Category, Int64>
    {
        protected override Type getEntityClass()
        {
            return typeof(Category);
        }
    }
}
