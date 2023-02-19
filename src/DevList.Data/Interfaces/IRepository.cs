using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Infra.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();
        T Query(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Guid id);
    }
}
