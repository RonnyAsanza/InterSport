using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int CreateUser(User user)
        {
            using (var context = new InterSportContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserId;
            }
        }

        public bool DeleteUserById(int userId)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var response = context.Database.ExecuteSqlCommand("delete from Users where UserId = " + userId);

                    if (response > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public List<User> GetListUsers()
        {
            using (var context = new InterSportContext())
            {
                var users = context.Users.ToList();
                return users;
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = new InterSportContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                return user;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var query = (from u in context.Users
                                 where u.UserId == user.UserId
                                 select u).FirstOrDefault();
                    if (query != null)
                    {
                        query.FirstName = user.FirstName;
                        query.LastName = user.LastName;
                        query.Phone = user.Phone;
                        query.Direction = user.Direction;
                        query.Email = user.Email;
                        query.Password = user.Password;
                        query.RestorePassword = user.RestorePassword;
                        query.IsActive = user.IsActive;

                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }   
}
