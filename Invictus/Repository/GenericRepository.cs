using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository
{
    public interface GenericRepository<E,I>
    {
        E findById(I id);
        List<E> findAll();
        void create(E entity);
        void update(E entity);
        void delete(I id);
        Boolean isExisted(I id);
    }
}
