using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using movie_api.Models;

namespace movie_api.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _config;

        public MovieRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }
        public async Task<MovieModel> GetByID(string id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT [Title],[Year],[Rated],[Released],[Runtime],[Genre],[Director]
                                        ,[Writer],[Actors],[Plot],[Language],[Country],[Awards],[Poster],[Metascore]
                                        ,[ImdbRating],[ImdbVotes],[Imdbid],[Type],[Dvd],[BoxOffice],[Production],[Website]
                                        ,[Response] FROM movie WHERE Imdbid = @ID";
                                    
                conn.Open();
                var result = await conn.QueryAsync<MovieModel>(sQuery, new { ID = id });
                var movie = result.FirstOrDefault();
                if(movie == null){return null;}   
                movie.Ratings = GetRatingsValue(id,conn).Result;
                return movie;
            }
        }
         public async Task<MovieModel> GetBySearch(string title)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT [Title],[Year],[Rated],[Released],[Runtime],[Genre],[Director]
                                        ,[Writer],[Actors],[Plot],[Language],[Country],[Awards],[Poster],[Metascore]
                                        ,[ImdbRating],[ImdbVotes],[Imdbid],[Type],[Dvd],[BoxOffice],[Production],[Website]
                                        ,[Response] FROM movie WHERE title LIKE '%' + @TITLE + '%'";
                                    
                conn.Open();
                var result = await conn.QueryAsync<MovieModel>(sQuery, new { TITLE = title });
                var movie = result.FirstOrDefault();
                if(movie == null){return null;}   
                movie.Ratings = GetRatingsValue(movie.ImdbID,conn).Result;
                return movie;
            }
        }
        private async Task<List<Rating>> GetRatingsValue(string id, IDbConnection con)
        {
             string sQuery = @"SELECT [Source],[Value] 
                             FROM rating
                           WHERE Imdbid = @ID";
             var ratings = await con.QueryAsync<Rating>(sQuery, new { ID = id });
             return ratings.ToList();
        }
    }
}