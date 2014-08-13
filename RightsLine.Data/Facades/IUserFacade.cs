using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RightsLine.Data.Models;

namespace RightsLine.Data.Facades {
    public interface IUserFacade
    {
        User GetUser(Guid id);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}
