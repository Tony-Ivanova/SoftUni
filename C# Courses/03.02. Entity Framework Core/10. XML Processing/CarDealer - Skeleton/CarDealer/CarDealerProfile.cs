namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

        }
    }
}
