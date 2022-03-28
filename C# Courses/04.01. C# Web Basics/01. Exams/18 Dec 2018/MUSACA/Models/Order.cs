using MUSACA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUSACA.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Status = Status.Active;
        }

        public string Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public string CashierId { get; set; }
        public virtual User Cashier { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
