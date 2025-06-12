using Microsoft.EntityFrameworkCore;
using Orm.Movies.DataModels;

namespace Orm.Movies.Ef
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        ///  Represents a collection of entities of a specific 
        ///  type that can be queried from the database. 
        ///  Each DbSet corresponds to a table in the database.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// A method where you can configure the model using the ModelBuilder API. 
        /// This is where you define relationships, constraints, and other configurations.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
