namespace FastFood.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<string> ItemNames { get; set; }

        public List<string> EmployeeNames { get; set; }
    }
}
