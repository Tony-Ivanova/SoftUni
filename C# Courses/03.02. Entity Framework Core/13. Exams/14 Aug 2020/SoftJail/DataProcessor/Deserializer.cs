namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {

        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartments
            = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoners
            = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficers
          = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var sb = new StringBuilder();

            var validDepartments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (departmentDto.Cells.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!departmentDto.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cell in departmentDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    });
                }

                validDepartments.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartments, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonersDto[]>(jsonString);

            var sb = new StringBuilder();

            var validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!prisonerDto.Mails.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                var isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!IsValid(incarcerationDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                var isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!IsValid(isReleaseDateValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = !string.IsNullOrEmpty(prisonerDto.ReleaseDate) ? releaseDate : (DateTime?)null,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                foreach (var mail in prisonerDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address,
                    });
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoners, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersDto[]), new XmlRootAttribute("Officers"));
            var officersDto = (ImportOfficersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var validOfficers = new List<Officer>();
            var sb = new StringBuilder();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Position validPosition;
                var isValidPosition = Enum.TryParse(officerDto.Position, out validPosition);

                if (!isValidPosition)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Weapon validWeapon;
                var isValidWeapon = Enum.TryParse(officerDto.Weapon, out validWeapon);

                if (!isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = validPosition,
                    Weapon = validWeapon,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisoner in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisoner.Id
                    });
                }

                validOfficers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficers, officer.FullName, officer.OfficerPrisoners.Count));
            }
            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}