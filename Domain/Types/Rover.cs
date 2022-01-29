using System;
using Domain.Enum;
using Domain.Exceptions;

namespace Domain.Types
{
    public class Rover
    {
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
        public Plateau Plateau { get; set; }

        public Rover(Coordinate coordinate, Plateau plateau, Direction direction = Direction.N)
        {
            Coordinate = coordinate;
            Plateau = plateau;
            Direction = direction;
        }
        
        /// <summary>Execute rovers input commands</summary>
        public void ExecuteCommands(string commands)
        {
            var charArr = commands.ToCharArray();
            foreach (var input in charArr)
            {
                switch (input)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new InvalidCommandException($"The command '{input}' is invalid.");
                }
            }
        }
        /// <summary>Calculate the new coordinate of th rover</summary>
        private Coordinate GenerateNewPosition(Coordinate coordinate, Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    coordinate.Y++;
                    break;
                case Direction.E:
                    coordinate.X++;
                    break;
                case Direction.S:
                    coordinate.Y--;
                    break;
                case Direction.W:
                    coordinate.X--;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return coordinate;
        }
        
        /// <summary>Rovers movement act. Check its new coordinate is valid</summary>
        private void Move()
        {
            var newPosition = GenerateNewPosition(Coordinate, Direction);
            if (Plateau.IsValidPosition(newPosition))
                Coordinate = newPosition;
            else
                throw new OutOfPlateauException("The next position(" + newPosition + ") is not valid.");
        }

        private void TurnRight()
        {
            Direction = (Direction + 1) > Direction.W ? Direction.N : Direction + 1;
        }

        private void TurnLeft()
        {
            Direction = (Direction - 1) < Direction.N ? Direction.W : Direction - 1;
        }

        public string GetCurrentPosition()
        {
            return Coordinate.X + " " + Coordinate.Y + " " + Direction;
        }
        /// <summary>Generate rover with input string. And check its valid or not</summary>
        public static Rover DeployRover(string input, Plateau plateau)
        {
            if (string.IsNullOrEmpty(input)) throw new InvalidRoverDefinitionException("Definition of rover is empty.");
            var inputArray = input.Split(' ');
            if (inputArray.Length != 3)
                throw new InvalidRoverDefinitionException("Definition of rover doesn't have the proper format.");
            Coordinate coordinate;
            Direction direction;
            try
            {
                coordinate = new Coordinate(Convert.ToInt32(inputArray[0]), Convert.ToInt32(inputArray[1]));
                direction = System.Enum.Parse<Direction>(inputArray[2]);
            }
            catch (Exception e)
            {
                throw new InvalidRoverDefinitionException("Invalid rover definition.", e);
            }

            if (!plateau.IsValidPosition(coordinate))
                throw new OutOfPlateauException("The position(" + coordinate + ") is not valid.");
            return new Rover(coordinate, plateau, direction);
        }
    }
}