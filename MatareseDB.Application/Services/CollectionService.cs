using MatareseDB.Application.Helpers;
using MatareseDB.Infrastructure.Repositories;

namespace MatareseDB.Application.Services
{
    public class CollectionService(CollectionRepository collectionRepository)
    {
        public async Task<IEnumerable<string>> GetCollection(string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var objects = await collectionRepository.GetCollection(databaseName, collectionName, cancellationToken);
            var convertedObjects = new List<string>();

            foreach (var dataObject in objects)
            {
                convertedObjects.Add(MatareseDbSerializer.Deserialize(dataObject));
            }

            return convertedObjects;
        }

        public async Task AddCollection(string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var content = ContentBuilder.GetCollectionContent(collectionName);
            var index = await collectionRepository.GetIndexOfLastCollectionEnd(databaseName, cancellationToken);

            await collectionRepository.AddCollection(databaseName, content, index, cancellationToken);
        }
    }
}
