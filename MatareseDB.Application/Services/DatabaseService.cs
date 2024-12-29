using MatareseDB.Domain.Constants;
using MatareseDB.Domain.Exceptions;
using MatareseDB.Infrastructure.Repositories;

namespace MatareseDB.Application.Services
{
    public class DatabaseService(DatabaseRepository databaseRepository)
    {
        public async Task CreateDatabase(string databaseName, CancellationToken cancellationToken = default)
        {
            var exisitngDbs = Directory.GetFiles(FileConstants.BasePath);

            if (exisitngDbs.Contains(FileConstants.BasePath + databaseName + ".matdb"))
            {
                throw new DatabaseAlreadyExistsException();
            }

            await databaseRepository.CreateDatabase(databaseName, cancellationToken);
        }

        public async Task DeleteDatabase(string databaseName, CancellationToken cancellationToken = default)
        {
            var exisitngDbs = Directory.GetFiles(FileConstants.BasePath);

            if (!exisitngDbs.Contains(FileConstants.BasePath + databaseName + ".matdb"))
            {
                throw new DatabaseNotExistingException();
            }

            databaseRepository.DeleteDatabase(databaseName, cancellationToken);
        }
    }
}
