using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Web.ViewModels.Items
{
    public class DetailsItemInputModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public int CategoryId { get; set; }

        
        public Category Category { get; set; }

       
        public decimal Price { get; set; }
    }
}
