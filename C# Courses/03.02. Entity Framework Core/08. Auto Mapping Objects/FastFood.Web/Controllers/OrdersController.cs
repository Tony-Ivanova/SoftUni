namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using AutoMapper.QueryableExtensions;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                ItemNames = this.context.Items.Select(x => x.Name).ToList(),
                EmployeeNames = this.context.Employees.Select(x => x.Name).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);

            order.DateTime = DateTime.Now;
            order.Type = Enum.Parse<OrderType>(model.OrderType);

            var employees = this.context
                .Employees
                .FirstOrDefault(p => p.Name == model.EmployeeName);

            order.EmployeeId = employees.Id;


            var items = this.context
                .Items
                .FirstOrDefault(p => p.Name == model.ItemName);
            

            order.OrderItems.Add(new OrderItem
            {     
                ItemId = items.Id,
                Order = order,
                Quantity = model.Quantity
            });      
            


            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return RedirectToAction("All", "Orders");

        }

        public IActionResult All()
        {
            var orders = this.context
             .Orders
             .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
             .ToList();

            return this.View(orders);
        }
    }
}
