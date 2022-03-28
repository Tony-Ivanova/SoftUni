namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Models;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using System.Text;
    using System;

    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                var inputXml = File.ReadAllText("../../../Datasets/products.xml");

                var results = ImportProducts(db, inputXml);

                Console.WriteLine(results);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImortUsersDto[]),
                new XmlRootAttribute("Users"));

            ImortUsersDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (ImortUsersDto[])xmlSerializer.Deserialize(reader);
            }

            var users = Mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]),
                new XmlRootAttribute("Products"));

            ImportProductsDto[] productsDtos;

            using (var reader = new StringReader(inputXml))
            {
                productsDtos = (ImportProductsDto[])xmlSerializer.Deserialize(reader);
            }

            var products = Mapper.Map<Product[]>(productsDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]),
                new XmlRootAttribute("Categories"));

            ImportCategoriesDto[] categoryDto;

            using (var reader = new StringReader(inputXml))
            {
                categoryDto = ((ImportCategoriesDto[])xmlSerializer
                    .Deserialize(reader)).Where(x => x.Name != null).ToArray();
            }

            var categories = Mapper.Map<Category[]>(categoryDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductCategoriesDto[]),
               new XmlRootAttribute("CategoryProducts"));

            ImportProductCategoriesDto[] categoryProductsDto;

            using (var reader = new StringReader(inputXml))
            {
                categoryProductsDto = ((ImportProductCategoriesDto[])xmlSerializer.Deserialize(reader))
                    .Where(x => context.Categories.Any(c => c.Id == x.CategoryId)
                                && context.Products.Any(p => p.Id == x.ProductId))
                    .ToArray();
            }

            var categoryProduct = Mapper.Map<CategoryProduct[]>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProduct);
            context.SaveChanges();

            return $"Successfully imported {categoryProduct.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(e => new ExportProductInRangeDto
                {
                    Name = e.Name,
                    Price = e.Price,
                    BuyerName = e.Buyer.FirstName + " " + e.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var xmlSerializar = new XmlSerializer(typeof(ExportProductInRangeDto[]),
                new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializar.Serialize(writer, products, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var users = context
                .Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new ExportProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializar = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializar.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
              .Categories
              .Select(c => new ExportCategoryProductsDto
              {
                  Name = c.Name,
                  Count = c.CategoryProducts.Count,
                  AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                  TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)

              })
              .OrderByDescending(c => c.Count)
              .ThenBy(c => c.TotalRevenue)
              .ToArray();

            var xmlSerializar = new XmlSerializer(typeof(ExportCategoryProductsDto[]),
                new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializar.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var users = context.Users
                 .Where(x => x.ProductsSold.Any())
                 .OrderByDescending(p => p.ProductsSold.Count)
                 .Select(x => new ExportProductsAndUsersDto
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Age = x.Age,
                     SoldProducts = new ExportSoldProductsDto
                     {
                         Count = x.ProductsSold.Count,
                         Products = x.ProductsSold.Select(p => new ExportProductDto
                         {
                             Name = p.Name,
                             Price = p.Price
                         })
                         .OrderByDescending(k => k.Price)
                         .ToArray()
                     }
                 })
                 .Take(10)
                 .ToArray();

            var result = new ExportCountProductsAndUsersDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializar = new XmlSerializer(typeof(ExportCountProductsAndUsersDto),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializar.Serialize(writer, result, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}