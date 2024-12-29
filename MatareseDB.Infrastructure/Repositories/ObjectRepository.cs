using System.Text;

namespace MatareseDB.Infrastructure.Repositories
{
    public class ObjectRepository
    {
        private const string BasePath = "../MatareseDB.Infrastructure/Data/";

        public async Task AddObject(string content, string databaseName, int insertionIndex, CancellationToken cancellationToken = default)
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
    }
}
