using DevList.Domain.Models;
using DevList.Infra.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Infra.Repositories
{
    public sealed class DeveloperRepository : Repository<Developer>
    {
        public DeveloperRepository(IMongoCollection<Developer> collectionName) : base(collectionName)
        {
        }

        public DeveloperRepository(IConnectionFactory connectionFactory, string databaseName, string collectionName)
            : base(connectionFactory, databaseName, collectionName)
        {
        }
    }
}
