using System.Collections.Generic;
using TelecomProvider.Model;
using ContractPhone = TelecomProvider.Controllers.TelecomProviderContract.DTO.Phone;

namespace TelecomProvider.Handlers
{
    public interface ITelecomProviderHandler
    {
        List<Phone> GetAllPhones();

        List<Phone> GetCustomerPhones(int customerId);

        void ActivatePhone(ContractPhone newPhone);
    }
}