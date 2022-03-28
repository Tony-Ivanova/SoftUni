using MUSACA.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Services
{
    public interface IProductsService
    {
        void Create(string name, string picture, decimal price, string barcode);

        IEnumerable<ProductAllViewModel> GetAll();
    }
}
