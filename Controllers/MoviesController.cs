using Api_MyFavMovies.Entities;
using Api_MyFavMovies.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_MyFavMovies.Controllers
{
    [ApiController]
    [Route("api/MyFavMovies-movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MyFavMoviesDbContext _context;

        public MoviesController(MyFavMoviesDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll(Guid id)
        {
            var movies = _context.Movies.Where(u => !u.IsDeleted && u.IdUser == id).ToList();

            return Ok(movies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var users = _context.Movies.Include(u => u).SingleOrDefault(u=>u.Id == id);
            return users is null ? NotFound() : Ok(users); 
        }

         [HttpPost]
        public IActionResult CreateMovie(Movie movies)
        {
            _context.Movies.Add(movies);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = movies.Id}, movies);
        }

         [HttpPut("{id}")]
        public IActionResult UpdateMovie(Guid id, Movie Input)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
                return NotFound();
            movie.Update(Input.Title, Input.Description);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(Guid id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id == id);
            if(movie == null)
                return NotFound();
            movie.Delete();
            _context.SaveChanges();
            return NoContent();
        }

    }
}