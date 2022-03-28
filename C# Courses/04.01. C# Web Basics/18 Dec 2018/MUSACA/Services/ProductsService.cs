using MUSACA.Data;
using MUSACA.Models;
using MUSACA.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUSACA.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext db;

        public ProductsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string picture, decimal price, string barcode)
        {
            var product = new Product
            {
                Name = name,
                Picture = picture,
                Price = price,
                Barcode = barcode,                
            };

            db.Products.Add(product);
            db.SaveChanges();
        }
    
        public IEnumerable<ProductAllViewModel> GetAll()
        {
            var products = this.db.Products.Select(x => new ProductAllViewModel{
                Name = x.Name,
                Picture = x.Picture,
                Barcode = x.Barcode,
                Price = x.Price,
            }).ToArray();

            return products;
        }
    }
}
