using Domain.Enum;
using Domain.Exceptions;
using Domain.Types;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Rover_Should_Be_Created_With_Correct_Position()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            Assert.That(rover.Coordinate.X, Is.EqualTo(1));
            Assert.That(rover.Coordinate.Y, Is.EqualTo(2));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
            Assert.That(rover.Plateau, Is.EqualTo(plateau));
        }

        [Test]
        public void Rover_Should_Be_Correct_Movement()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            rover.ExecuteCommands("LMLMLMLMM");
            Assert.That(rover.Coordinate.X, Is.EqualTo(1));
            Assert.That(rover.Coordinate.Y, Is.EqualTo(3));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
        }

        [Test]
        public void Rover_Should_Be_West_Direction()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            rover.ExecuteCommands("L");
            Assert.That(rover.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void Rover_Output_Should_Be_1_3_N()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            rover.ExecuteCommands("LMLMLMLMM");
            Assert.That(rover.Coordinate.X, Is.EqualTo(1));
            Assert.That(rover.Coordinate.Y, Is.EqualTo(3));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
        }
        
        [Test]
        public void Rover_Output_Should_Be_5_1_E()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(3, 3), plateau, Direction.E);
            rover.ExecuteCommands("MMRMMRMRRM");
            Assert.That(rover.Coordinate.X, Is.EqualTo(5));
            Assert.That(rover.Coordinate.Y, Is.EqualTo(1));
            Assert.That(rover.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void Rover_Output_Should_Be_4_2()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            rover.ExecuteCommands("RMLMLMLMLMMM");
            Assert.That(rover.Coordinate.X, Is.EqualTo(4));
            Assert.That(rover.Coordinate.Y, Is.EqualTo(2));
        }

        [Test]
        public void ExecuteBatchCommands_OutOfPlateauException()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            var rover = new Rover(new Coordinate(1, 2), plateau, Direction.N);
            Assert.Throws<OutOfPlateauException>(() => rover.ExecuteCommands("MMMMMMMM"));
        }

        [Test]
        public void CreateRover_With_WrongDefinitions()
        {
            var plateau = new Plateau(new Coordinate(5, 5));
            Assert.Throws<InvalidRoverDefinitionException>(() => Rover.DeployRover(null, plateau));
            Assert.Throws<InvalidRoverDefinitionException>(() => Rover.DeployRover("1 N", plateau));
            Assert.Throws<InvalidRoverDefinitionException>(() => Rover.DeployRover("1 2 2 N", plateau));
            Assert.Throws<InvalidRoverDefinitionException>(() => Rover.DeployRover("1 2 P", plateau));
            Assert.Throws<OutOfPlateauException>(() => Rover.DeployRover("1 22 E", plateau));
        }
    }
}