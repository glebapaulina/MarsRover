using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public static class InputParser
    {
        public static Plateau CreatePlateau()
        {
            string[] plateauSize = Console.ReadLine()?.Split(' ');
            
            int.TryParse(plateauSize[0], out int x);
            int.TryParse(plateauSize[1], out int y);

            Plateau plateau = new Plateau(x,y);

            return plateau;
        }

        public static Rover CreateRover()
        {
            string[] roverData = Console.ReadLine()?.Split(' ');

            int.TryParse(roverData[0], out int x);
            int.TryParse(roverData[1], out int y);
            Enum.TryParse(roverData[2], out Direction direction);

            Rover rover = new Rover
            {
                CoordinateX = x,
                CoordinateY = y,
                Direction = direction
            };

            return rover;

        }

        public static string CreateCommands()
        {
           return Console.ReadLine();
        }

    }
}
