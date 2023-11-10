using Microsoft.EntityFrameworkCore;
using MovieManager.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MovieManager.DAL
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define one-to-many relationship between Movie and Genre
            modelBuilder.Entity<Movie>()
        .HasMany(m => m.Genres)
        .WithOne(m => m.Movie)
        .HasForeignKey(m => m.MovieId)
        .IsRequired();

        }
    }

}
