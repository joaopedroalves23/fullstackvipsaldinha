using Movies.API.Models;
using Movies.API.Request;

namespace Movies.API.Interfaces.Repository;

public interface IRepositoryMovie
{
    bool Create(MovieCreateRequest movie);
    Movie? GetById(int id);
    bool Update(int id, MovieUpdateRequest movie);
    bool Delete(int id);
    List<Movie> GetAll();
}