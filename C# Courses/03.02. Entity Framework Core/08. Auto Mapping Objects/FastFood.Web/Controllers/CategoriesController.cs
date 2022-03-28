namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Categories;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = this.mapper.Map<Category>(model);

            this.context.Categories.Add(category);

            this.context.SaveChanges();

            return RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = this.context.Categories
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = context.Categories.SingleOrDefault(e => e.Id == id);

            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var categoryData = this.mapper.Map<EditCategoryInputModel>(category);

            return View(categoryData);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newEntity = this.mapper.Map<Category>(model);
                context.Entry(newEntity).State = EntityState.Modified;
                context.SaveChanges();
                return this.RedirectToAction("All", "Categories");
            }

            return View(model);
        }

        //GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = context.Categories.SingleOrDefault(e => e.Id == id);

            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var categoryDetails = this.mapper.Map<DetailsCategoriesInputModel>(category);

            return View(categoryDetails);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = context.Categories.SingleOrDefault(e => e.Id == id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var categoryToDelete = this.mapper.Map<DeleteCategoryInputModel>(category);

            return View(categoryToDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var category = context.Categories.SingleOrDefault(x => x.Id == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return this.RedirectToAction("All", "Positions");
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
