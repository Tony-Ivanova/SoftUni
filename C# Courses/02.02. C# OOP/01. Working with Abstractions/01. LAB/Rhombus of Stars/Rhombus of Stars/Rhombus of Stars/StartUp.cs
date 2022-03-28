namespace Rhombus_of_Stars
{
    using Rhombus_of_Stars.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var dataReader = new ConsoleDataReader();
            var dataWriter = new ConsoleDataWriter();

            var engine = new Engine(dataReader, dataWriter);

            engine.Run();
        }
    }
}