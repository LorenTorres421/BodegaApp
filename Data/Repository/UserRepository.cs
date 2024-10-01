using Common.Dtos;
using Data.Entities;
using Data.Repository;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public List<User> GetUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }

    }
}

