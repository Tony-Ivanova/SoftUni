namespace _07._Store_Boxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }



    public class StartUp
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (line != "end")
            {
                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);

                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice
                };

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    Quantity = quantity,
                    PriceBox = item.Price * quantity
                };

                boxes.Add(box);

                line = Console.ReadLine();
            }

           var orderedBoxes = boxes.OrderByDescending(x => x.PriceBox);

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }
    }
}