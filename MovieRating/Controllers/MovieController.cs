using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieRating.Controllers
{
    [ApiController]
    [Route("/Movie")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

       

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] 
        [Route("/Movies")] 
        public IActionResult GetMovies()
        {
            var movieData = _db.Movies;
            return Ok(movieData);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovieId(int? id)
        {

            var movie = _db.Movies.FindAsync(id);

           return Json(movie);
        }

        [HttpPost]
        [Route("post")]
        public void Post(Movie NewMovie)
        {
            _db.Movies.Add(NewMovie);
            _db.SaveChanges();
        }

        [HttpPost]
        [Route("Edit")]
        public void Edit(int id, Movie movie)
        {
            movie.Id = id;
            _db.Movies.Update(movie);
            _db.SaveChanges();

        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int? id)
        {
            Movie newMovie = _db.Movies.Find(id);
            _db.Movies.Remove(newMovie);
            _db.SaveChanges();
        }

    }
}
