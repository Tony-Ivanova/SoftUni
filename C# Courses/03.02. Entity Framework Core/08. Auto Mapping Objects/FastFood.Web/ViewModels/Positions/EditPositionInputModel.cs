using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions
{
    public class EditPositionInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string PositionName { get; set; }
    }
}
