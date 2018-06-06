using Invictus.Attributes;
using Invictus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    [RepoInterfaceImpl(typeof(Product))]
    class ProductRepositoryImpl : GenericRepositoryImpl<Product, int>
    {
        protected override Type getEntityClass()
        {
            return typeof(Product);
        }
    }
}
