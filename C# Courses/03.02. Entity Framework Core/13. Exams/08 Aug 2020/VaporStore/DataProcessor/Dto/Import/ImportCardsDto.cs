using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardsDto
    {
        [Required]
        [RegularExpression(@"[0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
