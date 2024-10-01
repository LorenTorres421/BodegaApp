using Data.Repository;
using Common.Dtos;
using Data.Entities;

namespace Services
{
    public class UserService 
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUser()
        {
            return _userRepository.GetUsers();
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void RegisterUser(LoginDto user)
        {
            // Convertir LoginDto a una entidad User antes de pasarlo al repositorio
            var newUser = new User
            {
                Username = user.Username,
                Password = user.Password
            };

            _userRepository.AddUser(newUser); // Pasar la entidad User al repositorio
        }

    }
}