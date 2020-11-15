namespace ElevatorKata
{
    public class Person
    {
        public string Name { get;}
        public int Weight { get; set; }
        public int FromFloor { get; set; }
        public int ToFloor { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string personName, int personWeight, int fromFloor, int toFloor)
        {
            Name = personName;
            Weight = personWeight;
            FromFloor = fromFloor;
            ToFloor = toFloor;
        }
    }
}