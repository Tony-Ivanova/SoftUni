namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))

                {
                    throw new ArgumentException("Name cannot be empty");

                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");

                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get => this.bagOfProducts;
        }

        public string EnoughMoneyToPurchaseProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.money -= product.Cost;
                this.bagOfProducts.Add(product);
                return $"{this.Name} bought {product.Name}";
            }
        }
    }
}
