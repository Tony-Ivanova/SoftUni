namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class ImportTasksDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0, 4)]
        public int LabelType { get; set; }
    }
}
