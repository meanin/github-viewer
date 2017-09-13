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
            var serializedString = string.Empty;
            try
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
                serializedString = stringWriter.ToString();
            }
            catch
            {
                // ignored
            }
            return serializedString;
        }

        public T Deserialize<T>(string stringToDeserialize)
        {
            var obj = default(T);
            try
            {
                obj = (T)new XmlSerializer(typeof(T)).
                    Deserialize(new StringReader(stringToDeserialize));
            }
            catch
            {
                // ignored
            }
            return obj;
        }
    }
}
