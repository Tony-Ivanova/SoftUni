using SIS.MvcFramework;
using System;
using System.Collections.Generic;

namespace MUSACA.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Receipts = new HashSet<Receipt>();
        }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
