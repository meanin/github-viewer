using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using GithubViewer.Utils.Domain;

namespace GithubViewer.Utils.Services
{
    public class XmlSerializerService : ISerializer
    {
        public string Serialize<T>(T objectToSerialize)
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = false,
                Indent = false,
                NewLineHandling = NewLineHandling.None,
                Encoding = new UTF8Encoding(false)
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var stringWriter = new StringWriter();

            var writer = XmlWriter.Create(stringWriter, settings);
            var serializer = new XmlSerializer(objectToSerialize.GetType());

            serializer.Serialize(writer, objectToSerialize, namespaces);
            return stringWriter.ToString();
        }

        public T Deserialize<T>(string stringToDeserialize)
        {
            return (T) new XmlSerializer(typeof(T)).
                Deserialize(new StringReader(stringToDeserialize));
        }
    }
}
