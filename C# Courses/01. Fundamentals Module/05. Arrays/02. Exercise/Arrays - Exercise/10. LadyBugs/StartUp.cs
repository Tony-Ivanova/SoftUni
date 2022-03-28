namespace _10._LadyBugs
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());         
            int[] field = new int[length];
            int[] ladyBugIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();  

            foreach (int index in ladyBugIndexes)  
            {
                if (index < 0 || index >= field.Length)
                {
                    continue;
                }
                field[index] = 1;       
            }

            while (true)
            {
                string command = Console.ReadLine();         
                if (command == "end")          
                {
                    break;
                }

                string[] directions = command
                    .Split(new[] { ' ' }, 
                    StringSplitOptions
                    .RemoveEmptyEntries); 

                int fromWhere = int.Parse(directions[0]);           
                string direction = directions[1];
                int flyLength = int.Parse(directions[2]);         

                if (fromWhere < 0 || fromWhere >= length)
                {
                    continue;
                }
                if (field[fromWhere] == 0)
                {
                    continue;
                }
                field[fromWhere] = 0;

                int position = fromWhere;

                while (true)
                {
                    if (direction == "left")            
                    {
                        position -= flyLength;
                    }
                    else if (direction == "right")
                    {
                        position += flyLength;
                    }
                    if (position < 0 || position >= length)    
                    {
                        break;
                    }
                    if (field[position] == 1)
                    {
                        continue;              
                    }
                    else
                    {
                        field[position] = 1;           
                        break;
                    }
                }

            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
