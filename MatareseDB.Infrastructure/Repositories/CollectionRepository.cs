using System.Text;

namespace MatareseDB.Infrastructure.Repositories
{
    public class CollectionRepository
    {
        private const string BasePath = "../MatareseDB.Infrastructure/Data/";

        public async Task<int> GetIndexOfLastCollectionEnd(string databaseName, CancellationToken cancellationToken = default)
        {
            var fullPath = BasePath + databaseName + ".matdb";
            var allText = await File.ReadAllTextAsync(fullPath, cancellationToken);

            return allText.LastIndexOf('}') + 1;
        }

        public async Task<int> GetIndexOfLastItemEndInCollection(string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var fullPath = BasePath + databaseName + ".matdb";
            var allText = await File.ReadAllTextAsync(fullPath, cancellationToken);
            var searchText = $"{collectionName}={{";
            var collectionDataStartIndex = allText.IndexOf(searchText);
            var collectionDataEndIndex = allText.IndexOf('}', collectionDataStartIndex);
            var collectionData = allText[collectionDataStartIndex..collectionDataEndIndex];

            return (collectionData.LastIndexOf(';') > -1 ? collectionData.LastIndexOf(';') + 1 : searchText.Length) + collectionDataStartIndex;
        }

        public async Task<IEnumerable<string>> GetCollection(string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var collectionData = await GetCollectionString(databaseName, collectionName, cancellationToken);
            var collectionObjects = collectionData.Split(';');

            return collectionObjects[..(collectionObjects.Length - 1)];
        }

        public async Task AddCollection(string databaseName, string content, int insertionIndex, CancellationToken cancellationToken = default)
        {
            var fullPath = BasePath + databaseName + ".matdb";
            var originalContents = await File.ReadAllTextAsync(fullPath, cancellationToken);
            var stream = new FileStream(fullPath, FileMode.Open);
            var insertBytes = Encoding.ASCII.GetBytes(content);
            var endBytes = Encoding.ASCII.GetBytes(originalContents.Substring(insertionIndex));

            stream.Position = insertionIndex;
            await stream.WriteAsync(insertBytes, cancellationToken);
            await stream.WriteAsync(endBytes, cancellationToken);
            await stream.DisposeAsync();
        }

        public async Task<string> GetCollectionString(string databaseName, string collectionName, CancellationToken cancellationToken = default)
        {
            var fullPath = BasePath + databaseName + ".matdb";
            var allText = await File.ReadAllTextAsync(fullPath, cancellationToken);
            var searchText = $"{collectionName}={{";
            var collectionDataStartIndex = allText.IndexOf(searchText);
            var collectionDataEndIndex = allText.IndexOf('}', collectionDataStartIndex);
            var collectionData = allText[(collectionDataStartIndex + searchText.Length)..collectionDataEndIndex];

            return collectionData;
        }
    }
}
