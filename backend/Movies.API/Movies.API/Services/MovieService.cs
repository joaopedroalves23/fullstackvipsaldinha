using Microsoft.EntityFrameworkCore;
using Movies.API.DatabaseContext;
using Movies.API.Encrypt;
using Movies.API.Interfaces;
using Movies.API.Interfaces.Repository;
using Movies.API.Models;
using Movies.API.Request.Movies;

namespace Movies.API.Services;

public class MovieService : IRepositoryMovie
{
    public MovieService()
    {

    }

    public bool Create(MovieCreateRequest request)
    {
        using var connection = new DataContext();

        var movie = new Movie(request.Title, request.PosterUrl, request.Overview);

        try
        {
            connection.Movies.Add(movie);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public Movie? GetById(int id)
    {
        using var connection = new DataContext();
        try
        {
            var movie = connection.Movies.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (movie is null)
                return null;

            return movie;
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
            var movie = connection.Movies.FirstOrDefault(x => x.Id == id);
            if (movie is null)
                return false;
            connection.Movies.Remove(movie);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public List<Movie> GetAll()
    {
        using var connection = new DataContext();
        try
        {
            return connection.Movies.AsNoTracking().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Movie>();
        }
    }

    public bool Update(int id, MovieUpdateRequest request)
    {
        using var connection = new DataContext();
        try
        {
            var movie = connection.Movies.FirstOrDefault(x => x.Id == id);
            if (movie is null)
                return false;

            movie.Title = request.Title;
            movie.PosterUrl = request.PosterUrl;
            movie.Overview = request.Overview;

            connection.Movies.Update(movie);
            connection.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
