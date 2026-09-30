using Movies.API.Models;
using Movies.API.Users;

namespace Movies.API.Interfaces.Repository;

    public interface IRepositoryUser
    {
        bool Create(UserCreateRequest user);
        User? GetById(int id);
        bool Update(int id, UserUpdateRequest user);
        bool Delete(int id);
        IEnumerable<User> GetAll();
    }
}
}
