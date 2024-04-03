using Npgsql;

namespace WebApp.DataContext;

public class DapperContext
{
    private readonly string _connectionString = "Server = localhost;Port=5432;Database=Web_db1;User Id=postgres;Password=11223344;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
