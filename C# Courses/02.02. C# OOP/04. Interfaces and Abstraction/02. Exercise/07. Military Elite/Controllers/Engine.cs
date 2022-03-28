namespace _08.Military_Elite.Controllers
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private SoldiersManager Manager;
        private StringBuilder Stat;

        public Engine()
        {
            this.Manager = new SoldiersManager();
            this.Stat = new StringBuilder();
        }

        public void Run()
        {
            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                this.ExecuteCommand(command);
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(this.Stat.ToString().Trim());
        }

        private void ExecuteCommand(string[] command)
        {
            var id = command[1];
            var firstName = command[2];
            var lastName = command[3];
            double salary;
            string corps;
            string cmdResult;

            try
            {
                switch (command[0])
                {
                    case "Private": // “Private <id> <firstName> <lastName> <salary>”
                        salary = double.Parse(command[4]);
                        cmdResult = this.Manager.RegisterPrivate(id, firstName, lastName, salary);
                        this.Stat.AppendLine(cmdResult);
                        break;
                    case "LeutenantGeneral": // “LeutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>”
                        salary = double.Parse(command[4]);
                        cmdResult = this.Manager.RegisterLeutenantGeneral(id, firstName, lastName, salary, command.Skip(5));
                        this.Stat.AppendLine(cmdResult);
                        break;
                    case "Engineer": // “Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>” 
                        salary = double.Parse(command[4]);
                        corps = command[5];
                        cmdResult = this.Manager.RegisterEngineer(id, firstName, lastName, salary, corps, command.Skip(6).ToArray());
                        this.Stat.AppendLine(cmdResult);
                        break;
                    case "Commando": // “Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>”
                        salary = double.Parse(command[4]);
                        corps = command[5];
                        cmdResult = this.Manager.RegisterCommando(id, firstName, lastName, salary, corps, command.Skip(6).ToArray());
                        this.Stat.AppendLine(cmdResult);
                        break;
                    case "Spy": // “Spy <id> <firstName> <lastName> <codeNumber>”
                        var codeNumber = int.Parse(command[4]);
                        cmdResult = this.Manager.RegisterSpy(id, firstName, lastName, codeNumber);
                        this.Stat.AppendLine(cmdResult);
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException)
            {
                return;
            }
        }
    }
}