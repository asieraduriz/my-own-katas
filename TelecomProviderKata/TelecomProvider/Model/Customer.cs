using System.Collections.Generic;

namespace TelecomProvider.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public List<Phone> Phones { get; set; }
    }
}
