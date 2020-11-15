using NUnit.Framework;
using MarsRoverKata;
using System;

namespace MarsRoverKataTest
{

    [TestFixture]
    public class MarsRoverShould
    {
        [TestCase(0, 0, "N")]
        [TestCase(0, 0, "E")]
        [TestCase(0, 0, "S")]
        [TestCase(0, 0, "W")]
        [TestCase(2, 1, "N")]
        [TestCase(0, 4, "N")]
        public void Receive_ValidStartingData(int x, int y, string direction)
        {
            MarsRover marsRover = new MarsRover(x, y, direction);

            Assert.AreEqual(marsRover.X, x);
            Assert.AreEqual(marsRover.Y, y);
            Assert.AreEqual(marsRover.D, direction);
        }

        [Test]
        public void Move_AccordingToCommands()
        {
            int x = 5;
            int y = 5;
            string direction = "N";
            int forward_amount = 3;
            int backward_amount = 1;

            MarsRover marsRover = new MarsRover(x, y, direction);
            string[] commands = { "F", "B", "F", "F" };

            marsRover.Move(commands);

            Assert.AreEqual(y + (forward_amount - backward_amount), marsRover.Y);

        }

    }
}
