using System;
using Domain.Exceptions;

namespace Domain.Types
{
    public class Plateau
    {
        public Coordinate Coordinate { get; set; }

        public Plateau(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        /// <summary>Checks that the coordinate is inside plateau</summary>
        public bool IsValidPosition(Coordinate coordinatesToCheck)
        {
            if (coordinatesToCheck.Y > Coordinate.Y) return false;
            if (coordinatesToCheck.X > Coordinate.X) return false;
            if (coordinatesToCheck.X < 0) return false;
            if (coordinatesToCheck.Y < 0) return false;

            return true;
        }
        /// <summary>Take plateau input string and create object. Also check input errors</summary>
        public static Plateau Init(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new InvalidPlateauDefinition("Definition of plateau is empty.");
            var coordinates = input.Split(' ');
            if (coordinates.Length != 2)
                throw new InvalidPlateauDefinition("Definition of plateau doesn't have the proper format.");
            Coordinate coordinate;
            try
            {
                coordinate = new Coordinate(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
            catch (Exception ex)
            {
                throw new InvalidPlateauDefinition("Invalid plateau definition.", ex);
            }

            if (coordinate.X < 0 || coordinate.Y < 0)
                throw new InvalidPlateauDefinition("Invalid plateau definition.");

            return new Plateau(coordinate);
        }
    }
}