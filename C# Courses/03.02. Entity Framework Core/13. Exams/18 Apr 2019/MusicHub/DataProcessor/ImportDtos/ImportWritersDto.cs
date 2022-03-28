namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    public class ImportWritersDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }
    }
}
