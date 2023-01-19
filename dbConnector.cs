using Npgsql;
using System.Data;

namespace TestEvaluation.Config{
    public class DbContext{
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = "Host=localhost;Database=devdb;Username=local;Password=password;";

        public DbContext(IConfiguration configuration){
            Console.WriteLine(_connectionString);
            _configuration = configuration;
        }
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

        public void ReleaseServerConnection(IDbConnection dbConnection){
            if (dbConnection == null)
                return;

            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();

            dbConnection.Dispose();
        }
    }
}