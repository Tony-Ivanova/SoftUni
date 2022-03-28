using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string CashierId { get; set; }
        public virtual User Cashier { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
