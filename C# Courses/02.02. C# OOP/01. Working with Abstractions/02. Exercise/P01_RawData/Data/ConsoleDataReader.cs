namespace P01_RawData.Data
{
    using System;
    public class ConsoleDataReader : IDataReaders
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
