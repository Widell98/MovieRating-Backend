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
        public IActionResult Get(int id)
        {
            var result = _db.Movies.Where(x => x.Id == id);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(_db.Movies.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(Movie NewMovie)
        {
            if (NewMovie == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Movies.Add(NewMovie);
            var count = _db.SaveChanges();
            if(count == 1)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "A problem happend handeling your request.");
            }

            //_db.Movies.Add(NewMovie);
            //_db.SaveChanges();

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
