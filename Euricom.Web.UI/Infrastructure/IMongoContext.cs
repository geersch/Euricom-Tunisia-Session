using MongoDB.Driver;

namespace Euricom.Web.UI.Infrastructure
{
    public interface IMongoContext
    {
        MongoCollection<T> GetCollection<T>();
    }
}