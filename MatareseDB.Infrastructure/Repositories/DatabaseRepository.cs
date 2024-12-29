using MatareseDB.Domain.Constants;

namespace MatareseDB.Infrastructure.Repositories
{
    public class DatabaseRepository
    {
        public async Task CreateDatabase(string databaseName, CancellationToken cancellationToken = default)
        {
            var databasePath = FileConstants.BasePath + databaseName + ".matdb";
            var stream = File.Create(databasePath);
            await stream.DisposeAsync();
        }

        public void DeleteDatabase(string databaseName, CancellationToken cancellationToken = default)
        {
            var databasePath = FileConstants.BasePath + databaseName + ".matdb";
            File.Delete(databasePath);
        }
    }
}
