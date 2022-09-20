using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int CreateUser(User user)
        {
            if (user == null) return 0;
            return _userRepository.CreateUser(user);
        }

        public bool DeleteUserById(int userId)
        {
            if (userId <= 0) return false;
            return _userRepository.DeleteUserById(userId);
        }

        public List<User> GetListUsers()
        {
            return _userRepository.GetListUsers();
        }

        public User GetUserById(int userId)
        {
            if (userId <= 0) return null;
            return _userRepository.GetUserById(userId);
        }

        public bool UpdateUser(User user)
        {
            if (user == null) return false;
            return _userRepository.UpdateUser(user);
        }
    }
}
