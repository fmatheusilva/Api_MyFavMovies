using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_MyFavMovies.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Movie> Movies { get; set;}
        public bool IsDeleted {get;set;} 
        
        public void Update(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
        public void Delete(){
            IsDeleted = true;
        }

    }
}