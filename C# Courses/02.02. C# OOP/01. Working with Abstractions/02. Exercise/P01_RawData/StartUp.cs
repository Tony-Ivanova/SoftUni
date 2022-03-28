namespace P01_RawData
{
    using P01_RawData.Data;
   
    public class RawData
    {
        public static void Main()
        {
            var dataReader = new ConsoleDataReader();
            var dataWriter = new ConsoleDataWriter();

            var engine = new Engine(
                dataReader,
                dataWriter);

            engine.Run();           
        }
    }
}
