using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RightsLine.Common.Mongo;
using RightsLine.Data.Models;

namespace RightsLine.Data.Facades {
    public class UserFacade : IUserFacade {
        private readonly MongoDataStore _dataStore;
        private readonly MongoDatabase _database;
        private readonly MongoCollection _usersCollection;
        public UserFacade() {
            _dataStore = new MongoDataStore("mongodb://localhost");
            _database = _dataStore.GetDatabase("RightsLine");
            _usersCollection = _database.GetCollection<User>("Users");
        }

        public User GetUser(Guid id) {
            var query = Query<User>.EQ(x => x.ID, id);
            return _usersCollection.FindOneAs<User>(query);
        }

        public User CreateUser(User user) {
            _usersCollection.Insert(user);
            return user;
        }

        public User UpdateUser(User user) {
            var query = Query<User>.EQ(x => x.ID, user.ID);
            var updatedUser = Update<User>.Replace(user);
            _usersCollection.Update(query, updatedUser);

            return user;
        }

        public void DeleteUser(Guid id) {
            var query = Query<User>.EQ(x => x.ID, id);
            _usersCollection.Remove(query);
        }
    }
}
