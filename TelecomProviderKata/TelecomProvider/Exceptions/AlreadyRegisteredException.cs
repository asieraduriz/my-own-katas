using System;

namespace TelecomProvider.Exceptions
{
    public class AlreadyRegisteredException: Exception
    {
        private const string MESSAGE = "Customer {0} already has phone {1} registered";

        public AlreadyRegisteredException(int customerId, int phoneNumber)
            : base(string.Format(MESSAGE, customerId, phoneNumber))
        {
            
        }
    }
}
