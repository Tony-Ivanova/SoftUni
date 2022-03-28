namespace _04._List_of_Products
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine()); 
            List<string> product = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string currentProduct = Console.ReadLine(); 
                product.Add(currentProduct);
            }
            product.Sort(); 

            for (int i = 0; i < product.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{product[i]}"); 
            }
        }
    }
}
