namespace Cinema.DataProcessor.ExportDto
{
    
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class CustomerDto
    {
        [XmlAttribute("FirstName")]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement("SpentMoney")]
        public string SpentMoney { get; set; }

        [XmlElement("SpentTime")]
        public string SpentTime { get; set; }
    }
}
