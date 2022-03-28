namespace Point_in_Rectangle
{
    using Point_in_Rectangle.Data;
    using Point_in_Rectangle.Forms;
    using System.Linq;

    public class Engine
    {
        private IDataWriter dataWriter;
        private IDataReader dataReader;

        public Engine(IDataReader dataReader,
            IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            int[] pointsInRectangle = this.dataReader.Read()
                                                     .Split()
                                                     .Select(int.Parse)
                                                     .ToArray();


            var topLeftPoint = new Point(pointsInRectangle[0], pointsInRectangle[1]);
            var bottomRightPoint = new Point(pointsInRectangle[2], pointsInRectangle[3]);

            var rectangle = new Rectangle(topLeftPoint, bottomRightPoint);


            int howManyChecks = int.Parse(this.dataReader.Read());


            for (int i = 0; i < howManyChecks; i++)
            {
                int[] coordinates = this.dataReader.Read()
                                                   .Split()
                                                   .Select(int.Parse)
                                                   .ToArray();
                int x = coordinates[0];
                int y = coordinates[1];

                Point newPoint = new Point(x, y);

                this.dataWriter.WriteLine(rectangle.Contains(newPoint));
            }
        }
    }
}
