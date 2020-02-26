using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        private static readonly List<Tuple<Rover, string>> roversCommands = new List<Tuple<Rover, string>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide upper-right coordinates of the plateau");
            Plateau plateau = InputParser.CreatePlateau();

            InsertRoverInformation();
            Console.WriteLine("Would you like to add another rover? Y/N");


            while (Console.ReadKey().KeyChar == 'Y' || Console.ReadKey().KeyChar == 'y')
            {
                Console.WriteLine();
                InsertRoverInformation();
                Console.WriteLine("Would you like to add another rover? Y/N");
            }

            Console.WriteLine();
            foreach (var roverCommand in roversCommands)
            {
                RoverController controller = new RoverController(roverCommand.Item1, plateau);
                controller.Travel(roverCommand.Item2);
                roverCommand.Item1.PrintState();
            }
            Console.ReadLine();

        }

        private static void InsertRoverInformation()
        {
            Console.WriteLine("Please provide rover's initial position");
            Rover rover = InputParser.CreateRover();
            
            Console.WriteLine("Please provide commands for the rover");
            string commands = InputParser.CreateCommands();
            roversCommands.Add(new Tuple<Rover, string>(rover, commands));
        }
    }
}
