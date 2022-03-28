namespace Rhombus_of_Stars
{
    using Rhombus_of_Stars.Data;
    using Rhombus_of_Stars.Forms;

    public class Engine
    {
        private IDataReader dataReader;
        private IDataWriter dataWriter;

        public Engine(IDataReader dataReader, IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            int size = int.Parse(this.dataReader.Read());
            var form = new Rhombus();
            var printForm = form.CreateForm(size);

            dataWriter.WriteLine(printForm);
        }
    }
}