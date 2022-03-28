namespace PointInRectangle
{
    using Point_in_Rectangle;
    using Point_in_Rectangle.Data;
    using Point_in_Rectangle.Forms;

    public class StartUp
    {
        public static void Main()
        {
            var dataReader = new DataReader();
            var dataWriter = new DataWriter();

            var engine = new Engine(dataReader, dataWriter);

            engine.Run();        
        }
    }
}
