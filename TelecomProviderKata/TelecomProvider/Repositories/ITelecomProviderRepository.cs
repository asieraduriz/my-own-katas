using System.Collections.Generic;
using TelecomProvider.Model;

namespace TelecomProvider.Repositories
{
    public interface ITelecomProviderRepository
    {
        List<Phone> GetAll();

        void Save(int customerId, int phoneNumber);

        List<Phone> GetCustomerPhones(int customerId);
    }
}