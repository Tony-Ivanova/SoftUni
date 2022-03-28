using System;
namespace Point_in_Rectangle.Data
{
    public class DataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
