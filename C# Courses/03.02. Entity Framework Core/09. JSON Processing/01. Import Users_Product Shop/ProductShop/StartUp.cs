namespace ProductShop
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                //var inputJason = File.ReadAllText(@"..\Datasets\categories-products.json");
                var result = GetUsersWithProducts(db);
                Console.WriteLine(result);
            }
        }


        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            var categoriesThatAreNotNull = categories
                .Where(p => p.Name != null)
                .ToList();

            context.Categories.AddRange(categoriesThatAreNotNull);
            context.SaveChanges();

            return $"Successfully imported {categoriesThatAreNotNull.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var productCategory = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(productCategory);
            context.SaveChanges();

            return $"Successfully imported {productCategory.Length}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(s => s.ProductsSold.Count >= 1 &&
               s.ProductsSold.Any(b => b.Buyer != null))
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.LastName)
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    soldProducts = s.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,
                    }),
                }).ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }


        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("f2"),

                }).ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(s => s.ProductsSold.Count >= 1
                && s.ProductsSold.Any(b => b.Buyer != null))
                .OrderByDescending(s => s.ProductsSold.Count(p => p.Buyer != null))
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    age = s.Age,

                    soldProducts = new
                    {
                        count = s.ProductsSold.Count(b => b.Buyer != null),

                        products = s.ProductsSold.Where(b => b.Buyer != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                        }),
                    },
                }).ToList();

            var results = new
            {
                usersCount = users.Count,
                users = users,
            };

            var json = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            return json;
        }
    }
}