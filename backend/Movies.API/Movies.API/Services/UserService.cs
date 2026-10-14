using Microsoft.EntityFrameworkCore;
using Movies.API.DatabaseContext;
using Movies.API.Encrypt;
using Movies.API.Interfaces.Repository;
using Movies.API.Models;
using Movies.API.Request.Users;

namespace Movies.API.Services;

public class UserService : IRepositoryUser
{
    public UserService()
    {

    }

    public bool Create(UserCreateRequest request)
    {
        using var connection = new DataContext();

        var user = new User(request.Username, PasswordEncryptor.EncryptPassword(request.Password));

        try
        {
            connection.Users.Add(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public User? GetById(int id)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (user is null)
                return null;

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public bool Delete(int id)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
                return false;

            connection.Users.Remove(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public bool Update(int id, UserUpdateRequest request)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
                return false;

            user.Username = request.Username;
            user.Password = PasswordEncryptor.EncryptPassword(request.Password);

            connection.Users.Update(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        using var connection = new DataContext();
        return connection.Users.AsNoTracking().ToList();
    }
}
