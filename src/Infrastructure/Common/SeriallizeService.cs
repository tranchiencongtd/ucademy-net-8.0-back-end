using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Common
{
    public class SerializeService : ISeriallizeService
    {
        public T Deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text) ?? throw new InvalidOperationException("Deserialization resulted in null.");

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter> {
                    new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                }
            }); 
        }

        public string Serialize<T>(T obj, Type type)
        {
            return JsonConvert.SerializeObject(obj, type, new JsonSerializerSettings());
        }
    }
}
