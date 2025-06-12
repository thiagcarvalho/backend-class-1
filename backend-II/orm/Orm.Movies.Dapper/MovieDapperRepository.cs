using Dapper;
using Orm.Movies.DataModels;
using System.Data;

namespace Orm.Movies.Dapper
{
    public class MovieDapperRepository : IMovieRepository
    {
        private readonly IDbConnection _connection;

        public MovieDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Guid Add(Movie movie)
        {
            movie.Id = Guid.NewGuid();

            var sql = @"INSERT INTO ""Movies""(""Id"", ""Name"", ""Description"", ""Year"") 
                        VALUES (@Id, @Name, @Description, @Year)";

            _connection.Execute(sql, movie);

            return movie.Id.Value;
        }

        public bool Delete(Guid id)
        {
            var sql = @"DELETE FROM ""Movies"" WHERE ""Id"" = @Id";

            var rowsAffected = _connection.Execute(sql, new { Id = id });

            return rowsAffected > 0;
        }

        public IEnumerable<Movie> GetAll()
        {
            var sql = @"SELECT * FROM ""Movies""";

            return _connection.Query<Movie>(sql);
        }

        public Movie? GetById(Guid id)
        {
            var sql = @"SELECT * FROM ""Movies"" WHERE ""Id"" = @Id";

            return _connection.QueryFirstOrDefault<Movie>(sql, new { Id = id });
        }

        public bool Update(Movie movie)
        {
            var sql = @"UPDATE ""Movies"" 
                        SET ""Name"" = @Name, 
                            ""Description"" = @Description,
                            ""Year"" = @Year
                        WHERE ""Id"" = @Id";

            var rowsAffected = _connection.Execute(sql, movie);

            return rowsAffected > 0;
        }
    }
}
