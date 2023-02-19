using DevList.Domain.Interfaces;
using DevList.Domain.Models;
using DevList.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Domain.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository<Developer> _developerRepository;

        public DeveloperService(IRepository<Developer> developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public IQueryable<Developer> QueryAll()
        {
            var result = _developerRepository.QueryAll();

            return result;
        }

        public Developer Query(Guid key)
        {
            var result = _developerRepository.Query(key);

            return result;
        }

        public void Insert(Developer developer)
        {
            _developerRepository.Insert(developer);
        }

        public void Update(Developer developer)
        {
            developer.UpdateModel();

            _developerRepository.Update(developer);
        }

        public void Delete(Guid id)
        {
            _developerRepository.Delete(id);
        }
    }
}
