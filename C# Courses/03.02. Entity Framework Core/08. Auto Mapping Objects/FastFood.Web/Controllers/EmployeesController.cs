namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using ViewModels.Employees;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using FastFood.Web.ViewModels.Positions;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            var positions = this.context
                .Positions
                .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = this.mapper.Map<Employee>(model);
            var position = this.context
                .Positions
                .FirstOrDefault(p => p.Name == model.PositionName);

            employee.PositionId = position.Id;
            this.context.Employees.Add(employee);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var employees = this.context
                .Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(employees);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            
            var newView = new CreateEmployeeInputModel
            {                
                OhGodAbove = this.mapper.Map<EditEmployeeInputModel>(employee),
                ICantNoMore = this.context.Positions.Select(x => x.Name).ToList()                
            };

            return View(newView);
        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeInputModel model)
        {            
            var employee = this.mapper.Map<Employee>(model);
            context.Entry(employee).State = EntityState.Modified;

            var position = this.context
                .Positions
                .FirstOrDefault(p => p.Name == model.PositionName);

            employee.PositionId = position.Id;
           
            context.SaveChanges();
            return this.RedirectToAction("All", "Employees");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var employeeDetails = this.mapper.Map<DetailsEmployeeInputModel>(employee);

            var newDetailsView = new DetailsEmployeeViewModel
            {
                DetailsEmployee = employeeDetails,
                PositionName = context.Positions.SingleOrDefault(x => x.Id == employee.PositionId).Name
            };

            return View(newDetailsView);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var employeeToDelete = this.mapper.Map<DeleteEmployeeInputModel>(employee);

            var newDeleteView = new DeleteEmployeeViewModel
            {
                DeleteEmployee = employeeToDelete,
                PositionName = context.Positions.SingleOrDefault(x => x.Id == employee.PositionId).Name
            };

            return View(newDeleteView);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = context.Employees.SingleOrDefault(x => x.Id == id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return this.RedirectToAction("All", "Employees");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
