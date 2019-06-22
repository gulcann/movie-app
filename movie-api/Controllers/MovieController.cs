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

        public MovieController(IMovieRepository movieRepo)
        {
            this._MovieRepo = movieRepo;
        }

        // GET api/movie
        [HttpGet("getbytitle/{Title}")]
        public ActionResult<MovieModel> GetSearch(string Title)
        {
            var movie = this._MovieRepo.GetBySearch(Title).Result;
            return movie;
        }
         // GET api/movie/tt3896198
        [HttpGet("getbyid/{imdbID}")]
        public ActionResult<MovieModel> Get(string imdbID)
        {
             var movie= this._MovieRepo.GetByID(imdbID).Result;
             return movie;
        }

        // POST api/movie
        [HttpPost]

        public void Post([FromBody] string value)
        {
        }

        // PUT api/movie/tt3896198
        [HttpPut("{imdbID}")]
        public void Put(int imdbId, [FromBody] string value)
        {
        }

        // DELETE api/movie/tt3896198
        [HttpDelete("{imdbID}")]
        public void Delete(int id)
        {
        }
    }
}