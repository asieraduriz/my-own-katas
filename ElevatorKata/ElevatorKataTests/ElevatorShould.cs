using System;
using AutoFixture;
using ElevatorKata;
using NUnit.Framework;

namespace ElevatorKataTests
{
    [TestFixture]
    public class ElevatorShould
    {
        private Fixture fixture;

        private Elevator elevator;
        private const int INITIAL_FLOOR = 0;


        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();

            elevator = new Elevator(INITIAL_FLOOR);
        }

        [Test]
        public void Have_InitialFloorState()
        {
            Assert.AreEqual(INITIAL_FLOOR, elevator.GetCurrentFloor());
        }

        [TestCase(1, 1)]
        [TestCase(5, 5)]
        public void Go_ToFloor(int destinationFloor, int expectedFloor)
        {
            elevator.ReachFloor(destinationFloor);

            Assert.AreEqual(expectedFloor, elevator.GetCurrentFloor());
        }

        [TestCase(-2)]
        [TestCase(9)]
        public void NotReach_InvalidFloor(int destinationFloor)
        {
            Assert.Throws<Exception>(() => elevator.ReachFloor(destinationFloor));
        }

        [Test]
        public void AcceptNewPersons()
        {
            Person person = new Person("Test",50,0,5);
            elevator.addPerson(person);
            Assert.AreEqual(1,elevator.getPersons());

        }
    }
}
