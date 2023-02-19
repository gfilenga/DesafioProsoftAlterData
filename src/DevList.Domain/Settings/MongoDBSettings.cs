using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevList.Domain.Settings
{
    public sealed class MongoDBSettings
    {
        public MongoDBSettings(string databaseName, string collectionName, string connectionString)
        {
            DatabaseName = databaseName;
            CollectionName = collectionName;
            ConnectionString = connectionString;
        }
        public MongoDBSettings(){}

        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}
