using System.Collections.Generic;
using TelecomProvider.Model;
using TelecomProvider.Repositories;
using ContractPhone = TelecomProvider.Controllers.TelecomProviderContract.DTO.Phone;

namespace TelecomProvider.Handlers
{
    public class TelecomProviderHandler : ITelecomProviderHandler
    {
        private readonly ITelecomProviderRepository telecomProviderRepository;

        public TelecomProviderHandler(ITelecomProviderRepository telecomProviderRepository)
        {
            this.telecomProviderRepository = telecomProviderRepository;
        }

        public List<Phone> GetAllPhones()
        {
            return telecomProviderRepository.GetAll();
        }

        public List<Phone> GetCustomerPhones(int customerId)
        {
            return telecomProviderRepository.GetCustomerPhones(customerId);
        }

        public void ActivatePhone(ContractPhone newPhone)
        {
            telecomProviderRepository.Save(newPhone.CustomerId, newPhone.PhoneNumber);
        }
    }
}
