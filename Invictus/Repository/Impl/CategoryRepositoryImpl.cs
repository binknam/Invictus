using Invictus.Attributes;
using Invictus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    [RepoInterfaceImpl(typeof(CategoryRepository))]
    class CategoryRepositoryImpl : GenericRepositoryImpl<Category, int>, CategoryRepository
    {
        protected override Type getEntityClass()
        {
            return typeof(Category);
        }
    }
}
