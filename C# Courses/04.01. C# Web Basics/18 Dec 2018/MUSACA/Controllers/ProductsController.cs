using MUSACA.Services;
using MUSACA.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProductInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(inputModel.Name?.Length < 3 || inputModel.Name?.Length > 100)
            {
                return this.Error("The name of the product must be between 3 and 100 chars");
            }

            if(inputModel.Price < 0.0m || inputModel.Price > 5000)
            {
                return this.Error("The price of the product must be between $0 and $5000");
            }

            if(inputModel.Barcode.Length != 12)
            {
                return this.Error("Invalid barcode");
            }

            this.productsService.Create(inputModel.Name, inputModel.Picture, inputModel.Price, inputModel.Barcode);           

            return this.Redirect("/Products/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var products = this.productsService.GetAll();

            return this.View(products);
        }
    }
}
