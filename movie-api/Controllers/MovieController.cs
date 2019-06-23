using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using movie_api.Data;
using movie_api.Models;

namespace movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMovieRepository _MovieRepo;
        private readonly IMovieSource _MoviRest;

        public MovieController(IConfiguration config,IMovieRepository movieRepo,IMovieSource movieRest)
        {
            _config = config;
            this._MovieRepo = movieRepo;
            this._MoviRest = movieRest;
        }

        // GET api/movie
        [HttpGet("getbytitle/{Title}")]
        //12 minute cache
        [ResponseCache(Duration = 720)]
        public ActionResult<MovieModel> GetSearch(string Title)
        {
            var movie = this._MovieRepo.GetBySearch(Title).Result;
             if(movie == null)
             {
                movie = CallMovieRest("",Title);
                if(movie.ImdbID == null)
                {
                    return null;
                }else{
                     movie.RecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                     this._MovieRepo.AddNewMovie(movie);
                }
             }else if(ControlRecordDate(movie.RecordDate))
             {
                 DeleteAndInsertNewMovie(movie);
             }
             return movie;
        }
         // GET api/movie/tt3896198
        [HttpGet("getbyid/{imdbID}")]
         //12 minute cache
        [ResponseCache(Duration = 720)]
        public ActionResult<MovieModel> Get(string imdbID)
        {
             var movie= this._MovieRepo.GetByID(imdbID).Result;
             if(movie == null)
             {
                movie = CallMovieRest(imdbID,"");
                if(movie.ImdbID == null)
                {
                    return null;
                }else
                {
                    this._MovieRepo.AddNewMovie(movie);
                }              
             }else if(ControlRecordDate(movie.RecordDate))
             {
                 DeleteAndInsertNewMovie(movie);
             }
             return movie;
        }

        private void DeleteAndInsertNewMovie(MovieModel movie)
        {
            this._MovieRepo.DeleteMovie(movie.ImdbID);
            movie.RecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            this._MovieRepo.AddNewMovie(movie);
        }

        private MovieModel CallMovieRest(string imdbID,string title)
        {
            MovieModel movie = null;
            movie = this._MoviRest.GetMovie<MovieModel>(imdbID??"",title??"");
            return movie;
        }
        private bool ControlRecordDate(string recordDate)
        {
            DateTime dbRecordDate = Convert.ToDateTime(recordDate);
            TimeSpan span = DateTime.Now.Subtract ( dbRecordDate );
            string minute = _config.GetValue<String>("MySettings:DbUpdateInterval");
            if(span.TotalMinutes > Int32.Parse(minute))
            {
                return true;
            }
            return false;
        }

    }
}