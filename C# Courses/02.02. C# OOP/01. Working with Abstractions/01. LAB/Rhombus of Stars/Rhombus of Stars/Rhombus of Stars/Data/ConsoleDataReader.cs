namespace Rhombus_of_Stars.Data
{
    using System;

    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
