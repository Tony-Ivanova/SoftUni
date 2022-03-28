using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Web.ViewModels.Employees
{
    public class DeleteEmployeeInputModel
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public int Age { get; set; }


        public string Address { get; set; }

        public int PositionId { get; set; }


        public Position Position { get; set; }
    }
}
