using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Direction Direction { get; set; }

        public void PrintState()
        {
            Console.WriteLine($"{CoordinateX} {CoordinateY} {Direction}");
        }
    }
}
