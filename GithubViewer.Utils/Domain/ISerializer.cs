namespace GithubViewer.Utils.Domain
{
    public interface ISerializer
    {
        string Serialize<T>(T objectToSerialize);
        T Deserialize<T>(string stringToDeserialize);
    }
}