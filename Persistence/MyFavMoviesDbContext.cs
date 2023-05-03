using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_MyFavMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_MyFavMovies.Persistence
{
    public class MyFavMoviesDbContext : DbContext
    {
        public MyFavMoviesDbContext(DbContextOptions<MyFavMoviesDbContext> options) :base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => {
                e.HasKey(us => us.Id);

                e.Property(us => us.Name).HasMaxLength(50).HasColumnType("varchar(50)");
                e.Property(us => us.Email).HasMaxLength(60).HasColumnType("varchar(60)");
                e.Property(us => us.Password).HasMaxLength(100).HasColumnType("varchar(100)");
                e.HasMany(us => us.Movies).WithMany();
            });

            modelBuilder.Entity<Movie>(e => {
                e.HasKey(us => us.Id);
            });
        } 
    }
}