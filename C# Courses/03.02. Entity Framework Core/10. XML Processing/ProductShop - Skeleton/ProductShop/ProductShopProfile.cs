namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImortUsersDto, User>();
            this.CreateMap<ImportProductsDto, Product>();
            this.CreateMap<ImportCategoriesDto, Category>();
            this.CreateMap<ImportProductCategoriesDto, CategoryProduct>();

        }
    }
}
