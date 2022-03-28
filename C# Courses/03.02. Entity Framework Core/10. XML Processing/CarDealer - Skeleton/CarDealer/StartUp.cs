namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using CarDealer.Dtos.Export;
    using System.Text;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportSupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDto;

            using (var reader = new StringReader(inputXml))
            {
                supplierDto = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliers = Mapper.Map<Supplier[]>(supplierDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            ImportPartDto[] partDtos;

            using (var reader = new StringReader(inputXml))
            {
                partDtos = ((ImportPartDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(p => context.Suppliers.Any(x => x.Id == p.SupplierId))
                    .ToArray();
            }

            var parts = Mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),
                new XmlRootAttribute("Cars"));

            ImportCarDto[] carDtos;

            using (var reader = new StringReader(inputXml))
            {
                carDtos = ((ImportCarDto[])xmlSerializer.Deserialize(reader));
            }

            var cars = new List<Car>();

            var partCars = new List<PartCar>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var parts = carDto
                    .Parts
                    .Where(c => context.Parts.Any(p => p.Id == c.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var partId in parts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    };


                    partCars.Add(partCar);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] importCustomerDtos;

            using (var reader = new StringReader(inputXml))
            {
                importCustomerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            var customers = Mapper.Map<Customer[]>(importCustomerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
                new XmlRootAttribute("Sales"));

            ImportSalesDto[] salesDtos;

            using (var reader = new StringReader(inputXml))
            {
                salesDtos = ((ImportSalesDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(x => context.Cars.Any(c => c.Id == x.CarId))
                    .ToArray();
            }

            var sales = Mapper.Map<Sale[]>(salesDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlSerializar = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializar.Serialize(writer, carDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarsMakeBMW>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsMakeBMW[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var suppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportLocalSuppliersDto>()
                .ToArray();

            var xmlSerializar = new XmlSerializer(typeof(ExportLocalSuppliersDto[]),
                new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(stringBuilder))
            {
                xmlSerializar.Serialize(writer, suppliers, namespaces);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var stringBuilder = new StringBuilder();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportCarDto[]),
                new XmlRootAttribute("cars"));

            var cars = context
                .Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ProjectTo<ExportCarDto>()
                .ToArray();

            foreach (var car in cars)
            {
                car.Parts = car.Parts
                                .OrderByDescending(p => p.Price)
                                .ToArray();
            }

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var customers = context
                .Customers
                .Where(e => e.Sales.Count >= 1)
                .Select(e => new ExportCustomersByMoneySpent
                {
                    Name = e.Name,
                    BoughtCars = e.Sales.Count,
                    SpentMoney = e.Sales.Sum(c => c.Car.PartCars.Sum(x => x.Part.Price))
                })
                .OrderByDescending(e => e.SpentMoney)
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportCustomersByMoneySpent[]),
                new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var sales = context
                .Sales
                .Select(e => new ExportSalesWithAndWithoutDiscounts
                {
                    Car = new ExportCarDto
                    {
                        Make = e.Car.Make,
                        Model = e.Car.Model,
                        TravelledDistance = e.Car.TravelledDistance
                    },
                    Discount = e.Discount,
                    CustomerName = e.Customer.Name,
                    Price = e.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = e.Car.PartCars.Sum(pc => pc.Part.Price) - e.Car.PartCars.Sum(pc => pc.Part.Price) * e.Discount / 100
                })
                .ToArray();

            var xmlSerializer =
             new XmlSerializer(typeof(ExportSalesWithAndWithoutDiscounts[]),
             new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}