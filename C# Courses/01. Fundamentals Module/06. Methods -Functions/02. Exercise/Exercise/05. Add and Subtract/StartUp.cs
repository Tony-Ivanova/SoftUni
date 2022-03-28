namespace _05._Add_and_Subtract
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            int sumFirstSecond = Sum(firstInt, secondInt);
            int result = Substract(sumFirstSecond, thirdInt);

            Console.WriteLine(result);
        }
        private static int Sum(int firstInt, int secondInt)
        {
            int sumFirstSecond = firstInt + secondInt;
            return sumFirstSecond;
        }

        private static int Substract(int sumFirstSecond, int thirdInt)
        {
            int substractSumThird = sumFirstSecond - thirdInt;
            return substractSumThird;
        }

    }
}
