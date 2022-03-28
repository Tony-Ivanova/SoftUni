namespace StudentSystemCatalog
{
    using Commands;
    using Data;
    using Students;
    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        private IDataReaders dataReaders;
        private IDataWriter dataWriter;

        public Engine(
            CommandParser commandParser, 
            StudentSystem studentSystem, 
            IDataReaders dataReaders,
            IDataWriter dataWriter)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.dataReaders = dataReaders;
            this.dataWriter = dataWriter;
        }


        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = this.dataReaders.Read();
                    var command = commandParser.Parse(data);

                    if (command.Name == "Exit")
                    {
                        break;
                    }
                    else if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];

                        var student = studentSystem.Get(name);
                        this.dataWriter.Write(student);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
