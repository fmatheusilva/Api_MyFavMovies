using Api_MyFavMovies.Entities;
using Api_MyFavMovies.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_MyFavMovies.Controllers
{
    [ApiController]
    [Route("api/MyFavMovies-user")]
    public class UsersController : ControllerBase
    {
         private readonly MyFavMoviesDbContext _context;

         public UsersController(MyFavMoviesDbContext context)
         {
            _context = context;
         }       
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.Where(u => !u.IsDeleted).ToList();
            return users is null ? NotFound() : Ok(users); 
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var users = _context.Users.Include(u => u.Movies).SingleOrDefault(u=>u.Id == id);
            return users is null ? NotFound() : Ok(users); 
        }

        [HttpPost]
        public IActionResult CreateUser(User users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = users.Id}, users);
        }      
       
    }
}