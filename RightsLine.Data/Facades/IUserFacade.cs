using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using RightsLine.Data.Models;

namespace RightsLine.Data.Facades {
    public interface IUserFacade {
        IEnumerable<User> GetUsers();
        User GetUser(ObjectId id);
        User CreateUser(User user);
        User UpdateUser(string id, User user);
        void DeleteUser(ObjectId id);
    }
}
