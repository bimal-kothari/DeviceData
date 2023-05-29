using DeviceData.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithNewtonsoftJson
    {
        private readonly string _sampleJsonFilePath;

        public ReadAndParseJsonFileWithNewtonsoftJson(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Foo1Models> UseUserDefinedObjectWithNewtonsoftJson()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<Foo1Models> Foo1Modelss = JsonConvert.DeserializeObject<List<Foo1Models>>(json);

            return Foo1Modelss;
        }

        public List<Foo1Models> UseJArrayParseInNewtonsoftJson()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);
            List<Foo1Models> Foo1Modelss = new();

            foreach (var item in jarray)
            {
                Foo1Models Foo1Models = item.ToObject<Foo1Models>();
                Foo1Modelss.Add(Foo1Models);
            }

            return Foo1Modelss;
        }

        public List<Foo1Models> UseJsonTextReaderInNewtonsoftJson()
        {
            var serializer = new JsonSerializer();
            List<Foo1Models> Foo1Modelss = new();
            using (var streamReader = new StreamReader(_sampleJsonFilePath))
            using (var textReader = new JsonTextReader(streamReader))
            {
                Foo1Modelss = serializer.Deserialize<List<Foo1Models>>(textReader);
            }

            return Foo1Modelss;
        }
    }
}