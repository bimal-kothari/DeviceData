using DeviceData.API.Models;
using System.Text.Json;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithSystemTextJson
    {
        private readonly string _sampleJsonFilePath;

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ReadAndParseJsonFileWithSystemTextJson(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Foo1Models> UseStreamReaderWithSystemTextJson()
        {
            using StreamReader streamReader = new(_sampleJsonFilePath);
            var json = streamReader.ReadToEnd();
            List<Foo1Models> Foo1Modelss = JsonSerializer.Deserialize<List<Foo1Models>>(json, _options);

            return Foo1Modelss;
        }

        public List<Foo1Models> UseFileReadAllTextWithSystemTextJson()
        {
            var json = File.ReadAllText(_sampleJsonFilePath);
            List<Foo1Models> Foo1Modelss = JsonSerializer.Deserialize<List<Foo1Models>>(json, _options);

            return Foo1Modelss;
        }

        public List<Foo1Models> UseFileOpenReadTextWithSystemTextJson()
        {
            using FileStream json = File.OpenRead(_sampleJsonFilePath);
            List<Foo1Models> Foo1Modelss = JsonSerializer.Deserialize<List<Foo1Models>>(json, _options);

            return Foo1Modelss;
        }
    }
}