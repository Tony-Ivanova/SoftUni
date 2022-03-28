namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                            .Prisoners
                            .ToArray()
                            .Where(p => ids.Contains(p.Id))
                            .Select(pr => new
                            {
                                Id = pr.Id,
                                Name = pr.FullName,
                                CellNumber = pr.Cell.CellNumber,
                                Officers = pr.PrisonerOfficers
                                             .Select(o => new
                                             {
                                                 OfficerName = o.Officer.FullName,
                                                 Department = o.Officer.Department.Name
                                             })
                                             .OrderBy(o => o.OfficerName)
                                             .ToArray(),
                                TotalOfficerSalary = pr.PrisonerOfficers.Sum(s => s.Officer.Salary)
                            })
                            .OrderBy(pr=>pr.Name)
                            .ThenBy(pr=>pr.Id)
                            .ToArray();

            string json = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonerNamesResult = prisonersNames
                                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            var prisoners = context
                            .Prisoners
                            .ToArray()
                            .Where(p => prisonerNamesResult.Contains(p.FullName))
                            .Select(p => new ExportPrisonersDto
                            {
                                Id = p.Id,
                                Name = p.FullName,
                                IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture),
                                EncryptedMessages = p.Mails
                                                     .Select(m => new EncryptedMessagesDto
                                                     {
                                                         Description = Reverse(m.Description)
                                                     })
                                                     .ToArray()
                            })
                            .OrderBy(p=>p.Name)
                            .ThenBy(p=>p.Id)
                            .ToArray();


            var serializer = new XmlSerializer(typeof(ExportPrisonersDto[]),
                new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), prisoners, namespaces);

            return xml.ToString().TrimEnd();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}