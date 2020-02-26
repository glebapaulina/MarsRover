using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class RoverController
    {
        private readonly Rover _rover;
        private readonly Plateau _plateau;

        public RoverController(Rover rover, Plateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
        }

        public void Travel(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'M')
                {
                    MoveForward();
                }
                else
                {
                    Turn(commands[i]);
                }
            }
        }

        private void MoveForward()
        {
            switch (_rover.Direction)
            {
                case Direction.N:
                    _rover.CoordinateY++;
                    break;
                case Direction.S:
                    _rover.CoordinateY--;
                    break;
                case Direction.W:
                    _rover.CoordinateX--;
                    break;
                case Direction.E:
                    _rover.CoordinateX++;
                    break;
            }

            HandlePlateauBorder();

        }

        private void Turn(char spinDirection)
        {

            if (spinDirection == 'L')
            {
                _rover.Direction--;
            }

            if (spinDirection == 'R')
            {
                _rover.Direction++;
            }
            HandleRotation();
        }

        private void HandleRotation()
        {
            if (_rover.Direction < 0)
            {
                _rover.Direction = Direction.W;
            }

            if ((int)_rover.Direction > 3)
            {
                _rover.Direction = Direction.N;
            }
        }

        private void HandlePlateauBorder()
        {
            _rover.CoordinateX = _rover.CoordinateX > _plateau.MaxCoordinateX ? _plateau.MaxCoordinateX : _rover.CoordinateX;
            _rover.CoordinateY = _rover.CoordinateY > _plateau.MaxCoordinateY ? _plateau.MaxCoordinateY : _rover.CoordinateY;
            _rover.CoordinateX = _rover.CoordinateX < 0 ? 0 : _rover.CoordinateX;
            _rover.CoordinateY = _rover.CoordinateY < 0 ? 0 : _rover.CoordinateY;
        }

    }
}
