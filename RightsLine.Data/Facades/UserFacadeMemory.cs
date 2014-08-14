using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using RightsLine.Data.Models;

namespace RightsLine.Data.Facades {
    public class MemoryDataStore {
        private static MemoryDataStore _memoryDataStore;
        private static int _referenceCount = 0;
        public List<User> Users { get; set; }

        private MemoryDataStore() { }

        public static MemoryDataStore GetMemoryDataStore() {
            if (_memoryDataStore == null) {
                _memoryDataStore = new MemoryDataStore();
                _memoryDataStore.Users = new List<User>();
            }

            _referenceCount++;

            return _memoryDataStore;
        }
    }

    public class UserFacadeMemory : IUserFacade {
        private readonly MemoryDataStore _memoryDataStore;
        public UserFacadeMemory() {
            _memoryDataStore = MemoryDataStore.GetMemoryDataStore();
        }

        public IEnumerable<User> GetUsers() {
            return _memoryDataStore.Users;
        }

        public User GetUser(ObjectId id) {
            return _memoryDataStore.Users.SingleOrDefault(x => x.ID == id);
        }

        public User CreateUser(User user) {
            user.ID = new ObjectId(DateTime.Now, 1, 9, 3);
            _memoryDataStore.Users.Add(user);

            return user;
        }

        public User UpdateUser(string id, User user) {
            var curUser = _memoryDataStore.Users.FirstOrDefault(x => x.ID == new ObjectId(id));
            if (curUser != null) {
                curUser.BirthDate = user.BirthDate;
                curUser.Email = user.Email;
                curUser.Gender = user.Gender;
                curUser.IsActive = user.IsActive;
                curUser.Name = user.Name;
                curUser.Phone = user.Phone;
            }

            return curUser;
        }

        public void DeleteUser(ObjectId id) {
            var u = _memoryDataStore.Users.FirstOrDefault(x => x.ID == id);
            _memoryDataStore.Users.Remove(u);
        }
    }
}
