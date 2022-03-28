using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories
{
    public class EditCategoryInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
