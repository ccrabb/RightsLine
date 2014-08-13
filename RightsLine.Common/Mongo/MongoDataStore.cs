using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace RightsLine.Common.Mongo {
    public class MongoDataStore {
        private readonly string _connectionString;
        private readonly MongoClient _mongoClient;

        private readonly MongoServer _mongoServer;

        public MongoDataStore(string connectionString) {
            _connectionString = connectionString;
            _mongoClient = new MongoClient(_connectionString);

            _mongoServer = _mongoClient.GetServer();
        }

        public MongoDatabase GetDatabase(string databaseName) {
            if (String.IsNullOrWhiteSpace(databaseName)) {
                throw new ArgumentException("databaseName must be provided", "databaseName");
            }

            if (_mongoServer == null) {
                throw new Exception("Error retrieving server");
            }

            return _mongoServer.GetDatabase(databaseName);
        }
    }
}
