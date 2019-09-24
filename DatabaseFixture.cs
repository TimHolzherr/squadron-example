using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Squadron;
using squadron_example;
using Xunit;

namespace squadron_example
{
    public class DatabaseFixture : IAsyncLifetime
    {
        public DatabaseContext Context;

        private const string DbName = "MyDb";
        private readonly SqlServerResource _sqlServer;

        public DatabaseFixture()
        {
            _sqlServer = new SqlServerResource();
        }

        public async Task InitializeAsync()
        {
            await _sqlServer.InitializeAsync();
            var connectionString = _sqlServer.CreateConnectionString(DbName);
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connectionString)
               .Options;
            Context = new DatabaseContext(options);
            Context.Database.Migrate();
        }

        public async Task DisposeAsync()
        {
            await _sqlServer.DisposeAsync();
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}