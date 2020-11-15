using AutoFixture;
using TelecomProvider.Exceptions;
using TelecomProvider.Repositories;
using Xunit;

namespace TelecomProvider.UnitTests.Repositories
{
    public class InMemoryTelecomProviderRepositoryShould
    {
        private readonly Fixture fixture;
        private InMemoryTelecomProviderRepository inMemoryRepository;

        private readonly int A_CUSTOMER;
        private readonly int A_PHONE_NUMBER;
        private readonly int A_SECOND_PHONE_NUMBER;

        public InMemoryTelecomProviderRepositoryShould()
        {
            fixture = new Fixture();
            inMemoryRepository = new InMemoryTelecomProviderRepository();

            A_CUSTOMER = fixture.Create<int>();
            A_PHONE_NUMBER = fixture.Create<int>();
            A_SECOND_PHONE_NUMBER = fixture.Create<int>();
        }

        [Fact]
        public void return_empty_phones_when_no_customer_has_registered()
        {
            var phones = inMemoryRepository.GetAll();

            Assert.Empty(phones);
        }

        [Fact]
        public void return_phones_from_same_customer()
        {
            inMemoryRepository.Save(A_CUSTOMER, A_PHONE_NUMBER);
            inMemoryRepository.Save(A_CUSTOMER, A_SECOND_PHONE_NUMBER);

            var phones = inMemoryRepository.GetCustomerPhones(A_CUSTOMER);

            Assert.Equal(2, phones.Count);
        }

        [Fact]
        public void register_customer_and_its_phone()
        {
            inMemoryRepository.Save(A_CUSTOMER, A_PHONE_NUMBER);
            var phones = inMemoryRepository.GetAll();

            Assert.Single(phones);

            Assert.Contains(phones, c => c.Number == A_PHONE_NUMBER);
        }

        [Fact]
        public void throw_already_registered_exception_when_customer_contains_number()
        {
            inMemoryRepository.Save(A_CUSTOMER, A_PHONE_NUMBER);

            Assert.Throws<AlreadyRegisteredException>(() =>
            {
                inMemoryRepository.Save(A_CUSTOMER, A_PHONE_NUMBER);
            });
        }
    }
}
