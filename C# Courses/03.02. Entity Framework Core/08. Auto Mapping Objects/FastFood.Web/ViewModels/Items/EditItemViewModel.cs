using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Web.ViewModels.Items
{
    public class EditItemInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 5000.00)]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
