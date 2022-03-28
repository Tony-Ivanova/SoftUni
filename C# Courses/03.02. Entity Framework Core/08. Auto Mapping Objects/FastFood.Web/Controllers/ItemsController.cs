namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Items;
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var categories = this.context.Categories
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var items = this.mapper.Map<Item>(model);
            var category = this.context
                .Categories
                .FirstOrDefault(p => p.Name == model.CategoryName);

            items.CategoryId = category.Id;

            this.context.Items.Add(items);

            this.context.SaveChanges();

            return RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            var items = this.context
                .Items
                .ProjectTo<ItemsAllViewModels>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(items);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var item = context.Items.SingleOrDefault(e => e.Id == id);

            if (item == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var newView = new EditItemViewModel
            {
                MappedItem = this.mapper.Map<EditItemInputModel>(item),
                CategoryName = this.context.Categories.Select(x => x.Name).ToList()
            };

            return View(newView);
        }

        [HttpPost]
        public ActionResult Edit(EditItemInputModel model)
        {
            var item = this.mapper.Map<Item>(model);
            context.Entry(item).State = EntityState.Modified;

            var category = this.context
                .Categories
                .FirstOrDefault(p => p.Name == model.CategoryName);

            item.CategoryId = category.Id;

            context.SaveChanges();
            return this.RedirectToAction("All", "Items");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var item = context.Items.SingleOrDefault(e => e.Id == id);

            if (item == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var itemDetails = this.mapper.Map<DetailsItemInputModel>(item);

            var newDetailsView = new DetailsItemViewModel
            {
                DetailsItem = itemDetails,
                CategoryName = context.Categories.SingleOrDefault(x => x.Id == item.CategoryId).Name
            };

            return View(newDetailsView);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var item = context.Items.SingleOrDefault(e => e.Id == id);
            if (item == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var itemToDelete = this.mapper.Map<DeleteItemInputModel>(item);

            var newDeleteView = new DeleteItemViewModel
            {
                DeleteEmployee = itemToDelete,
                CategoryName = context.Positions.SingleOrDefault(x => x.Id == item.CategoryId).Name
            };

            return View(newDeleteView);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = context.Items.SingleOrDefault(x => x.Id == id);
            context.Items.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Items");
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
