using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUSACA.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0.0, 5000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(12), RegularExpression("^[0-9]{12}$")]
        public string Barcode { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
