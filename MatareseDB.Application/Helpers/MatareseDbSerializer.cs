using System.Text;
using System.Text.Json;

namespace MatareseDB.Application.Helpers
{
    public static class MatareseDbSerializer
    {
        public static string Serialize(object dataObject)
        {
            var properties = dataObject.GetType().GetProperties();
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Guid.NewGuid()},");

            using (var document = JsonDocument.Parse(dataObject.ToString() ?? throw new ArgumentException(nameof(dataObject))))
            {
                var root = document.RootElement;

                if (root.ValueKind == JsonValueKind.Object)
                {
                    foreach (var property in root.EnumerateObject())
                    {
                        stringBuilder.Append($"{property.Name}={property.Value},");
                    }
                }
            }

            stringBuilder.Length = stringBuilder.Length - 1;
            stringBuilder.Append(';');
            return stringBuilder.ToString();
        }

        public static string Deserialize(string dataString)
        {
            var data = dataString[(dataString.IndexOf('{') + 1)..];
            var properties = data.Split(',');
            var stringBuilder = new StringBuilder();
            var counter = 0;

            stringBuilder.Append('{');
            foreach (var property in properties)
            {
                if(counter == 0)
                {
                    stringBuilder.Append($"\"Id\": \"{property}\", ");
                }
                else
                {
                    var splitted = property.Split('=');
                    stringBuilder.Append($"\"{splitted[0]}\": \"{splitted[1]}\", ");
                }

                counter++;
            }

            stringBuilder.Length -= 2;
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }
    }
}
