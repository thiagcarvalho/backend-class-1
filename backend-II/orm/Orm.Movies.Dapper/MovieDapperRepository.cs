using Dapper;
using Orm.Movies.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Movies.Dapper
{
    public class MovieDapperRepository : IMovieRepository
    {
        private readonly IDbConnection _dbConnection;
        public MovieDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Guid Add(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            var sql = """INSERT INTO "Movies" ("Id", "Name", "Year") VALUES (@Id, @Name, @Year)""";
            _dbConnection.Execute(sql, movie);
            return movie.Id.Value;
        }

        public bool Delete(Guid id)
        {
            var sql = """DELETE FROM "Movies" WHERE "Id" = @Id""";
            var result = _dbConnection.Execute(sql, new { Id = id });
            return result == 1;
        }

        public IEnumerable<Movie> GetAll()
        {
            var sql = """SELECT * FROM "Movies" ORDER BY "Name" """;
            var movies = _dbConnection.Query<Movie>(sql).ToList();
            return movies;
        }

        public Movie? GetById(Guid id)
        {
            var sql = """SELECT * FROM "Movies" WHERE "Id" = @Id""";
            var movie = _dbConnection.Query<Movie>(sql, new { Id = id }).FirstOrDefault();
            return movie;
        }

        public bool Update(Movie movie)
        {
            var sql = """UPDATE "Movies" SET "Name" = @Name, "Year" = @Year WHERE "Id" = @Id""";
            var result = _dbConnection.Execute(sql, new {movie.Name, movie.Year, movie.Id });
            return result == 1;
        }
    }
}
