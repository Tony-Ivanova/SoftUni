namespace Point_in_Rectangle.Data
{
    using System;

    public class DataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
