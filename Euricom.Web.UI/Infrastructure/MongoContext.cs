using System.Configuration;
using MongoDB.Driver;

namespace Euricom.Web.UI.Infrastructure
{
    public class MongoContext : IMongoContext
    {
        private MongoDatabase _database;
        private readonly string _connectionstring;

        public MongoContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public MongoContext()
            : this(ConfigurationManager.AppSettings["MONGOHQ_URL"]) { }

        private MongoDatabase Database
        {
            get { return _database ?? (_database = MongoDatabase.Create(_connectionstring)); }
        }

        public MongoCollection<T> GetCollection<T>()
        {
            return Database.GetCollection<T>(typeof(T).ToString());
        }
    }
}