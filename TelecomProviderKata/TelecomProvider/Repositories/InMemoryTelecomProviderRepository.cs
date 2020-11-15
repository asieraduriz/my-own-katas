using System;
using System.Collections.Generic;
using System.Linq;
using TelecomProvider.Exceptions;
using TelecomProvider.Model;

namespace TelecomProvider.Repositories
{
    public class InMemoryTelecomProviderRepository : ITelecomProviderRepository
    {
        public List<Customer> registeredCustomers;

        public InMemoryTelecomProviderRepository()
        {
            registeredCustomers = new List<Customer>();
        }

        public List<Phone> GetAll()
        {
            return registeredCustomers.SelectMany(c => c.Phones).ToList();
        }

        public List<Phone> GetCustomerPhones(int customerId)
        {
            var customer = registeredCustomers.FirstOrDefault(c => c.Id == customerId);
            return customer?.Phones;
        }

        public void Save(int customerId, int phoneNumber)
        {
            GuardAgainstCustomerWithAlreadyExistingPhoneNumber(customerId, phoneNumber);

            bool customerExists = TryGetCustomer(customerId, out Customer existingCustomer);

            if (customerExists)
            {
                existingCustomer.Phones.Add(new Phone { Number = phoneNumber});
            }
            else
            {
                Customer customer = CreateCustomerFrom(customerId, phoneNumber);
                registeredCustomers.Add(customer);
            }
        }

        private bool TryGetCustomer(int customerId, out Customer customer)
        {
            if (registeredCustomers.Any(c => c.Id == customerId))
            {
                customer = registeredCustomers.First(c => c.Id == customerId);
                return true;
            }

            customer = null;
            return false;
        }

        private Customer CreateCustomerFrom(int customerId, int phoneNumber)
        {
            return new Customer
            {
                Id = customerId,
                Phones = new List<Phone> { new Phone { Number = phoneNumber } }
            };
        }

        private void GuardAgainstCustomerWithAlreadyExistingPhoneNumber(int customerId, int phoneNumber)
        {
            var registeredCustomer = registeredCustomers.FirstOrDefault(c => c.Id == customerId);
            if (registeredCustomer == null) return;

            var existingPhone = registeredCustomer.Phones.Any(p => p.Number == phoneNumber);
            if (existingPhone)
            {
                throw new AlreadyRegisteredException(customerId, phoneNumber);
            }
        }
    }
}
