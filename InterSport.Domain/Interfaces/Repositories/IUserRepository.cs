using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetListUsers();
        User GetUserById(int userId);
        bool DeleteUserById(int userId);
        bool UpdateUser(User user);
        int CreateUser(User user);

    }
}
