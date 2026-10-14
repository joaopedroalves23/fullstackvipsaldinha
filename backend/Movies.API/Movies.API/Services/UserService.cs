using Microsoft.EntityFrameworkCore;
using Movies.API.DatabaseContext;
using Movies.API.Encrypt;
using Movies.API.Interfaces.Repository;
using Movies.API.Models;
using Movies.API.Request.Users;
using Movies.API.Users;

namespace Movies.API.Services;

public class UserService : IRepositoryUser
{
    public bool Create(UserCreateRequest request)
    {
        using var connection = new DataContext();
        try
        {
            var hash = PasswordEncryptor.EncryptPassword(request.Password);
            var user = new User(request.Username, hash);
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
            return connection.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public bool Update(int id, UserUpdateRequest request)
    {
        using var connection = new DataContext();
        try
        {
            var user = connection.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            user.Username = request.Username;
            user.Password = PasswordEncryptor.EncryptPassword(request.Password);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        using var connection = new DataContext();
        try
        {
            var user = connection.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

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

    public IEnumerable<User> GetAll()
    {
        using var connection = new DataContext();
        try
        {
            return connection.Users.AsNoTracking().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<User>();
        }
    }
}