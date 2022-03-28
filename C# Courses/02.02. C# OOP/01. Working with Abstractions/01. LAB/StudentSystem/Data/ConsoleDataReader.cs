namespace StudentSystemCatalog.Data
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
