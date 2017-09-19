using GithubViewer.Utils.Domain;
using Newtonsoft.Json;

namespace GithubViewer.Utils.Services
{
    public class JsonSerializerService : ISerializer
    {
        public string Serialize<T>(T objectToSerialize)
        {
            var serializedString = JsonConvert.SerializeObject(objectToSerialize);
            return serializedString == "null" ? string.Empty : serializedString;
        }

        public T Deserialize<T>(string stringToDeserialize)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(stringToDeserialize);
            }
            catch
            {
                return default(T);
            }
        }
    }
}