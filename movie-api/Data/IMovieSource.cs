using System.Threading.Tasks;
using movie_api.Models;

namespace movie_api.Data
{
    public interface IMovieSource
    {
        T GetMovie<T>(string id,string title);    
    }
}