using System.IO;
using System.Xml.Serialization;
using Iasset.Service.DataModel;

namespace Iasset.Service
{
    public static class Serializer
    {
        public static T Deserialize<T>(string payload)
        {
            using (var reader = new StringReader(payload))
            {
                var xmlSerializer = new XmlSerializer(typeof(CountryDataSet));
                return (T) xmlSerializer.Deserialize(reader);
            }
        }
    }
}
