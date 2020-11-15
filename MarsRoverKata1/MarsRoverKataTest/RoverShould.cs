using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTest
{
    [TestFixture]
    public class RoverShould
    {
        private MarsRover marsRover;

        [Test]
        public void HaveStartingPointAndDirection()
        {
            marsRover = new MarsRover(5, 6, Direction.N);

            Assert.AreEqual(marsRover.X, 5);
            Assert.AreEqual(marsRover.Y, 6);
            Assert.AreEqual(marsRover.FacingDirection, Direction.N);
        }
        
        [TestCase(1, 1, Direction.N, 1, 2)]
        [TestCase(1, 1, Direction.E, 2, 1)]
        [TestCase(1, 1, Direction.S, 1, 0)]
        [TestCase(1, 1, Direction.W, 0, 1)]
        public void MoveForward_OneUnit_AccordingToDirection(int startingX, int startingY, Direction startingDirection,
            int expectedX, int expectedY)
        {
            marsRover = new MarsRover(startingX, startingY, startingDirection);

            marsRover.Move(Movement.Forward);
            Assert.AreEqual(expectedX, marsRover.X);
            Assert.AreEqual(expectedY, marsRover.Y);
        }
        
        [TestCase(1, 1, Direction.S, 1, 2)]
        [TestCase(1, 1, Direction.W, 2, 1)]
        [TestCase(1, 1, Direction.N, 1, 0)]
        [TestCase(1, 1, Direction.E, 0, 1)]
        public void MoveBackward_OneUnit_AccordingToDirection(int startingX, int startingY, Direction startingDirection,
            int expectedX, int expectedY)
        {
            marsRover = new MarsRover(startingX, startingY, startingDirection);

            marsRover.Move(Movement.Backward);
            Assert.AreEqual(expectedX, marsRover.X);
            Assert.AreEqual(expectedY, marsRover.Y);
        }

        [TestCase(1, 1, Direction.N, 1, 2, 'f', 'b', 'f')]
        [TestCase(1, 1, Direction.E, 0, 1, 'b', 'b', 'f')]
        [TestCase(1, 1, Direction.S, 1, -2, 'f', 'f', 'f')]
        [TestCase(1, 1, Direction.W, 2, 1, 'b', 'b', 'f')]
        public void ActOn_AnyMovementCommands(int startingX, int startingY, Direction startingDirection,
            int expectedX, int expectedY, params char[] commands)
        {
            marsRover = new MarsRover(startingX, startingY, startingDirection);

            marsRover.Commands(commands);

            Assert.AreEqual(expectedX, marsRover.X);
            Assert.AreEqual(expectedY, marsRover.Y);
        }
        
        [TestCase(Direction.N, SpinCommand.RIGHT, Direction.E)]
        [TestCase(Direction.E, SpinCommand.RIGHT, Direction.S)]
        [TestCase(Direction.S, SpinCommand.RIGHT, Direction.W)]
        [TestCase(Direction.W, SpinCommand.RIGHT, Direction.N)]
        [TestCase(Direction.N, SpinCommand.LEFT, Direction.W)]
        [TestCase(Direction.W, SpinCommand.LEFT, Direction.S)]
        [TestCase(Direction.S, SpinCommand.LEFT, Direction.E)]
        [TestCase(Direction.E, SpinCommand.LEFT, Direction.N)]
        public void Spin(Direction startingDirection, SpinCommand spinCommand, Direction expectedDirection)
        {
            marsRover = new MarsRover(1, 1, startingDirection);

            marsRover.Spin(spinCommand);

            Assert.AreEqual(expectedDirection, marsRover.FacingDirection);
        }

        [TestCase(Direction.N, Direction.N, 'r', 'r', 'r', 'r')]
        [TestCase(Direction.E, Direction.N, 'r', 'l', 'l')]
        [TestCase(Direction.S, Direction.N, 'l', 'l')]
        [TestCase(Direction.W, Direction.N, 'r', 'l', 'r')]
        public void ActOn_AnySpinCommands(Direction startingDirection,
            Direction expectedDirection, params char[] commands)
        {
            marsRover = new MarsRover(1, 1, startingDirection);

            marsRover.Commands(commands);

            Assert.AreEqual(expectedDirection, marsRover.FacingDirection);
        }
    }
}
