using MatareseDB.Application.Helpers;
using MatareseDB.Domain.Exceptions;
using MatareseDB.Infrastructure.Repositories;

namespace MatareseDB.Application.Services
{
    public class ObjectService(ObjectRepository objectRepository, CollectionRepository collectionRepository)
    {
        public async Task<string> GetObject(string databaseName, string collectionName, Guid id, CancellationToken cancellationToken = default)
        {
            var collection = await collectionRepository.GetCollection(databaseName, collectionName, cancellationToken) ?? throw new NotFoundException();
            var singleObject = collection.FirstOrDefault(x => x.Contains(id.ToString())) ?? throw new NotFoundException();

            return MatareseDbSerializer.Deserialize(singleObject);
        }

        public async Task AddObjectToCollection(object dataObject, string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var content = ContentBuilder.GetObjectContent(dataObject);
            var index = await collectionRepository.GetIndexOfLastItemEndInCollection(databaseName, collectionName, cancellationToken);

            await objectRepository.AddObject(content, databaseName, index, cancellationToken);
        }
    }
}
