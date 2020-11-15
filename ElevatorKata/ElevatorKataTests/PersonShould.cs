using System;
using ElevatorKata;
using NUnit.Framework;

namespace ElevatorKataTests
{

    [TestFixture()]
    class PersonShould
    {
        [Test]
        public void HaveAName()
        {
            Person person = new Person("any name");
            Assert.IsNotEmpty(person.Name);
        }

        [Test]
        public void Have_Initial_Setup()
        {
            string personName = Guid.NewGuid().ToString();
            int personWeight = 50;
            int fromFloor = 0;
            int toFloor = 3;
            Person person = new Person(personName, personWeight, fromFloor, toFloor);

            Assert.AreEqual(personName, person.Name);
            Assert.AreEqual(personWeight, person.Weight);
            Assert.AreEqual(fromFloor, person.FromFloor);
            Assert.AreEqual(toFloor, person.ToFloor);
        }
    }
}
