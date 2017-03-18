using System.IO;

namespace Iasset.Service
{
    public static class XmlSerializer
    {
        public static T Deserialize<T>(string payload)
        {
            using (var reader = new StringReader(payload))
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T) xmlSerializer.Deserialize(reader);
            }
        }
    }
}
