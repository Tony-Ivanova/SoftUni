namespace _01._Encrypt__Sort_and_Print_Array
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int sequence = int.Parse(Console.ReadLine());
            int[] nums = new int[sequence];
            int sum = 0;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };


            for (int i = 0; i < sequence; i++)
            {
                string name = Console.ReadLine();
                sum = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    if (vowels.Contains(name[j]))
                    {
                        sum += (int)name[j] * name.Length;
                    }
                    else
                    {
                        sum += (int)name[j] / name.Length;
                    }


                }
                nums[i] = sum;
            }
            Array.Sort(nums);
            foreach (int num in nums)
            {
                Console.WriteLine(num + " ");
            }
        }
    }
}
