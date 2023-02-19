using DevList.Domain.Interfaces;
using DevList.Infra.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DevList.Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IModel
    {
        private readonly IMongoCollection<T> _collectionName;

        protected Repository(IMongoCollection<T> collectionName)
        {
            _collectionName = collectionName;
        }

        protected Repository(IConnectionFactory connectionFactory, string databaseName, string collectionName)
        {
            _collectionName = connectionFactory.GetDatabase(databaseName).GetCollection<T>(collectionName);
        }

        public IQueryable<T> QueryAll()
        {
            return _collectionName.AsQueryable<T>();
        }

        public T Query(Guid id)
        {
            return _collectionName.AsQueryable<T>().FirstOrDefault(t => t.Id == id);
        }

        public void Insert(T obj)
        {
            _collectionName.InsertOne(obj);
        }

        public void Update(T obj)
        {
            var filter = Builders<T>.Filter.Eq(t => t.Id, obj.Id);
            _collectionName.FindOneAndReplace(filter, obj);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<T>.Filter.Eq(t => t.Id, id);
            _collectionName.FindOneAndDelete(filter);
        }
    }
}
