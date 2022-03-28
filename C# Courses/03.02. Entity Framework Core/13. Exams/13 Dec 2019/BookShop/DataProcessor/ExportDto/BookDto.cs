namespace BookShop.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class BookDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlAttribute("Pages")]
        public int Pages { get; set; }
        
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
