using System;
using System.Collections;
using System.Collections.Generic;

namespace ElevatorKata
{
    public class Elevator
    {
        private int currentFloor;
        private readonly int minFloor;
        private readonly int maxFloor;
        private IList<Person> persons;

        public Elevator(int currentFloor)
        {
            this.currentFloor = currentFloor;
            this.minFloor = -1;
            this.maxFloor = 6;
            this.persons = new List<Person>();
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
        }

        public void ReachFloor(int destinationFloor)
        {
            if(destinationFloor < minFloor ||
                destinationFloor > maxFloor)
                throw new Exception();
            this.currentFloor = destinationFloor;
        }

        public void addPerson(Person person)
        {
            persons.Add(person);
        }

        public int getPersons()
        {
            return persons.Count;
        }
    }
}