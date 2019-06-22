using System.Threading.Tasks;
using movie_api.Models;

namespace movie_api.Data
{
    public interface IMovieRepository
    {
        Task<MovieModel> GetByID(string id);    
        Task<MovieModel> GetBySearch(string searchValue);    
        Task<int> AddNewMovie(MovieModel entity);
    }
}