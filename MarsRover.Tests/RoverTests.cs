using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTest
    {
    
        [Test]
        public void Should_TravelToFirstTestLocation()
        {
            //arrange
            Plateau plateau = new Plateau(5,5);
            Rover rover = new Rover
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = Direction.N
            };
            string commands = "LMLMLMLMM";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(1, rover.CoordinateX);
            Assert.AreEqual(3, rover.CoordinateY);
            Assert.AreEqual(Direction.N, rover.Direction);

        }

        [Test]
        public void Should_TravelToSecondTestLocation()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = Direction.E
            };
            string commands = "MMRMMRMRRM";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(5, rover.CoordinateX);
            Assert.AreEqual(1, rover.CoordinateY);
            Assert.AreEqual(Direction.E, rover.Direction);

        }

        [Test]
        public void Should_NotTravelBeyondPlateauBorders()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Direction = Direction.W 
            };
            string commands = "MM";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(0, rover.CoordinateX);
            Assert.AreEqual(1, rover.CoordinateY);
            Assert.AreEqual(Direction.W, rover.Direction);

        }

        [Test]
        public void Should_ContinueTravel_When_PlateauBorderReached()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Direction = Direction.W
            };
            string commands = "MMMRMM";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(0, rover.CoordinateX);
            Assert.AreEqual(3, rover.CoordinateY);
            Assert.AreEqual(Direction.N, rover.Direction);

        }
        [Test]
        public void Should_NotTravel_When_NoCommandsSpecified()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 2,
                CoordinateY = 2,
                Direction = Direction.W
            };
            string commands = "";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(2, rover.CoordinateX);
            Assert.AreEqual(2, rover.CoordinateY);
            Assert.AreEqual(Direction.W, rover.Direction);

        }

        [Test]
        public void Should_NotTravel_When_CommandsUnknown()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 2,
                CoordinateY = 2,
                Direction = Direction.W
            };
            string commands = "TEST";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(2, rover.CoordinateX);
            Assert.AreEqual(2, rover.CoordinateY);
            Assert.AreEqual(Direction.W, rover.Direction);

        }
        [Test]
        public void Should_NotTravel_When_CommandsAreSpinOnly()
        {
            //arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Direction = Direction.N
            };
            string commands = "RRR";
            RoverController controller = new RoverController(rover, plateau);

            //act
            controller.Travel(commands);

            //assert
            Assert.AreEqual(1, rover.CoordinateX);
            Assert.AreEqual(1, rover.CoordinateY);
            Assert.AreEqual(Direction.W, rover.Direction);

        }
    }
}
