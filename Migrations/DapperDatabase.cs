using System.Linq;
using Dapper;
using Smartway.DataAccess;

namespace Smartway.Migrations
{
    public class DapperDatabase
    {
        private readonly DapperContext _context;

        public DapperDatabase(DapperContext context)
        {
            _context = context;
        }

        public void Create(string dbName)
        {
            var query = "SELECT * FROM pg_database WHERE datname = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using var connection = _context.MigratorConnection();
            var records = connection.Query(query, parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {dbName}");
            }
        }
    }
}