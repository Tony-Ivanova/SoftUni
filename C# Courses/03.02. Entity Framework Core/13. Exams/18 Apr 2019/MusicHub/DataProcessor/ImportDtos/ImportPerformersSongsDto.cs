namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class PerformersSongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}
