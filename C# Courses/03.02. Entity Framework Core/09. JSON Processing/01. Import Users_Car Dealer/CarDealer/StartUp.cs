namespace CarDealer
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //var inputJason = File.ReadAllText(@"..\Datasets\sales.json");


                //var result = GetCarsFromMakeToyota(db);
                //Console.WriteLine(result);
            }
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supplier = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(supplier);
            context.SaveChanges();

            return $"Successfully imported {supplier.Length}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(e => new
                {
                    Name = e.Name,
                    BirthDate = e.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = e.IsYoungDriver
                }).ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter != true)
                .Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    PartsCount = e.Parts.Count
                }).ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },

                    parts = c.PartCars
                    .Select(pc => new
                    {
                        pc.Part.Name,
                        Price = $"{pc.Part.Price:f2}"
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(x => x.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenBy(c => c.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(x => x.Part.Price).ToString("f2"),
                    priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price) * (s.Discount / 100m)):f2}"
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}
