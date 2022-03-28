namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, EditPositionInputModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<EditPositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, DetailsPositionInputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<DetailsPositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));            

            this.CreateMap<Position, DeletePositionInputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));


            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()            
             .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();          

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            this.CreateMap<EditEmployeeInputModel, Employee>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Employee, EditEmployeeInputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));       

            this.CreateMap<Position, EditEmployeeInputModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<EditEmployeeInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));
       

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                   .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Category, EditCategoryInputModel>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<EditCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<DetailsCategoriesInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, DetailsCategoriesInputModel>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            this.CreateMap<EditItemInputModel, Item>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Item, EditItemInputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Item, DeleteEmployeeInputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<DetailsItemInputModel, Item>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));


            //Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                 .ForMember(x => x.Customer, y => y.MapFrom(c => c.Customer));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Customer, y => y.MapFrom(s => s.Customer))
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("g")));
        }
    }
}
