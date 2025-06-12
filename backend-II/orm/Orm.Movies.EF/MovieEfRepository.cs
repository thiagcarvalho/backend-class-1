using Orm.Movies.DataModels;

namespace Orm.Movies.Ef
{
    public class MovieEfRepository : IMovieRepository
    {
        private readonly AppDbContext _dbContext;

        public MovieEfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Add(Movie movie)
        {
            movie.Id = Guid.NewGuid();

            _dbContext.Add(movie);
            _dbContext.SaveChanges();

            return movie.Id.Value;
        }

        public bool Delete(Guid id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is not null) {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges(true);
                return true;
            }

            return false;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.OrderBy(x => x.Name);
        }

        public Movie? GetById(Guid id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Movie movie)
        {
            if (_dbContext.Movies.Any(x => x.Id == movie.Id))
            {
                _dbContext.Movies.Update(movie);
                _dbContext.SaveChanges(true);
                return true;
            }

            return false;
        }
    }
}
