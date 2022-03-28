namespace Rhombus_of_Stars.Data
{
    using System;
    public class ConsoleDataWriter : IDataWriter
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
