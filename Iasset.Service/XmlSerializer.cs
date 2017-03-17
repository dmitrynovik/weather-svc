using System.IO;
using Iasset.Service.DataModel;

namespace Iasset.Service
{
    public static class XmlSerializer
    {
        public static T Deserialize<T>(string payload)
        {
            using (var reader = new StringReader(payload))
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CountryDataSet));
                return (T) xmlSerializer.Deserialize(reader);
            }
        }
    }
}
