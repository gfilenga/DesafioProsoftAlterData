using DevList.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Domain.Interfaces
{
    public interface IDeveloperService
    {
        IQueryable<Developer> QueryAll();
        Developer Query(Guid key);
        void Insert(Developer developer);
        void Update(Developer developer);
        void Delete(Guid id);
    }
}
