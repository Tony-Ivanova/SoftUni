using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlAttribute("TasksCount")]
        public int TaskCount { get; set; }

        [XmlElement("HasEndDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ExportTaskJsonDto[] Tasks { get; set; }
    }
}
