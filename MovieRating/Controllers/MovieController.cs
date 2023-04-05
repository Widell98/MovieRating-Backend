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
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
                                

        }

        [HttpPut]
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
