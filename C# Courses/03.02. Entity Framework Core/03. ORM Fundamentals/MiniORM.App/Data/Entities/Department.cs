using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MiniORM.App.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; }


    }
}
