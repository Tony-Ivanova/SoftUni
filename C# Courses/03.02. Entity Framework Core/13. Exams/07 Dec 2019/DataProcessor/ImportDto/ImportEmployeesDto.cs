namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeesDto
    {
        [MinLength(3), MaxLength(40)]
        [RegularExpression("^[A-Za-z0-9]+$")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
