namespace GithubViewer.Utils.Domain
{
    /// <summary>
    /// Interface for text serialization
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serialize object of type of T into string
        /// </summary>
        /// <typeparam name="T">Type to serialize</typeparam>
        /// <param name="objectToSerialize">Object of type of T to serialize</param>
        /// <returns>Serialized object into string or string.empty</returns>
        string Serialize<T>(T objectToSerialize);
        /// <summary>
        /// Deserialize string into object of type of T
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="stringToDeserialize">string to deserialize</param>
        /// <returns>Deserialized object of type of T</returns>
        T Deserialize<T>(string stringToDeserialize);
    }
}