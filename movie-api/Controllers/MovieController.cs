using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movie_api.Data;
using movie_api.Models;

namespace movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _MovieRepo;
        private readonly IMovieSource _MoviRest;

        public MovieController(IMovieRepository movieRepo,IMovieSource movieRest)
        {
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
                     this._MovieRepo.AddNewMovie(movie);
                }
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
             }
             return movie;
        }

        private MovieModel CallMovieRest(string imdbID,string title)
        {
            MovieModel movie = null;
            movie = this._MoviRest.GetMovie<MovieModel>(imdbID??"",title??"");
            return movie;
        }

    }
}