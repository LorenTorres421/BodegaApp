using Common.Dtos;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUser()
        {
            return _userRepository.GetUsers();
        }

        public void RegisterUser(LoginDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            var newUser = new User
            {
                Username = user.Username,
                Password = user.Password
            };

            _userRepository.AddUser(newUser);
        }

        public User? AuthenticateUser(string username, string password)
        {
            User? userToReturn = _userRepository.Get(username);
            if (userToReturn is not null && userToReturn.Password == password)
                return userToReturn;
            return null;
        }

    }
}

