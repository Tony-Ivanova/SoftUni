namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using Data;
    using Models;
    using ViewModels.Positions;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class PositionsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public PositionsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //GET
        public IActionResult Create()
        {
            return this.View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = this.mapper.Map<Position>(model);

            this.context.Positions.Add(position);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            var categories = this.context
                .Positions
                .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = context.Positions.SingleOrDefault(e => e.Id == id);
            if (position == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var positionData = this.mapper.Map<EditPositionInputModel>(position);

            return View(positionData);
        }

        [HttpPost]
        public ActionResult Edit(EditPositionInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newEntity = this.mapper.Map<Position>(model);
                context.Entry(newEntity).State = EntityState.Modified;
                context.SaveChanges();
                return this.RedirectToAction("All", "Positions");
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

            var position = context.Positions.SingleOrDefault(e => e.Id == id);

            if (position == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var positionDetails = this.mapper.Map<DetailsPositionInputModel>(position);

            return View(positionDetails);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = context.Positions.SingleOrDefault(e => e.Id == id);
            if (position == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var positionToDelete = this.mapper.Map<DeletePositionInputModel>(position);

            return View(positionToDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {           

            var position = context.Positions.SingleOrDefault(x => x.Id == id);
            context.Positions.Remove(position);
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

