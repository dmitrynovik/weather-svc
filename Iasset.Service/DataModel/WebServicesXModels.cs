using System.Xml.Serialization;

namespace Iasset.Service.DataModel
{
    [XmlRoot(ElementName = "Table")]
    public class Table
    {
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class CountryDataSet
    {
        private Table[] _table;

        [XmlElement(ElementName = "Table")]
        public Table[] Table
        {
            get { return _table ?? new Table[0]; }
            set { _table = value; }
        }
    }
}
