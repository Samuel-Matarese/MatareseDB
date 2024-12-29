namespace MatareseDB.Application.Helpers
{
    public static class ContentBuilder
    {
        public static string GetCollectionContent(string collectionName)
        {
            return $"{collectionName}={{}}";
        }

        public static string GetObjectContent(object dataObjext)
        {
            var stringifiedObject = MatareseDbSerializer.Serialize(dataObjext);
            return stringifiedObject;
        }
    }
}
