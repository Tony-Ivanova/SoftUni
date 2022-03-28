namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    public class ExportCountProductsAndUsersDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportProductsAndUsersDto[] Users { get; set; }
    }
}
