using GithubViewer.Utils.Domain;
using Newtonsoft.Json;

namespace GithubViewer.Utils.Services
{
    public class JsonSerializerService : ISerializer
    {
        public string Serialize<T>(T objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public T Deserialize<T>(string stringToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(stringToDeserialize);
        }
    }
}