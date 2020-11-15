using AutoFixture;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TelecomProvider.Handlers;
using TelecomProvider.Model;
using TelecomProvider.Repositories;
using Xunit;
using ContractPhone = TelecomProvider.Controllers.TelecomProviderContract.DTO.Phone;

namespace TelecomProvider.UnitTests.Handlers
{
    public class TelecomProviderHandlerShould
    {
        private readonly Fixture fixture;
        private Mock<ITelecomProviderRepository> repositoryMock;
        private TelecomProviderHandler telecomHandler;

        public TelecomProviderHandlerShould()
        {
            fixture = new Fixture();
            repositoryMock = new Mock<ITelecomProviderRepository>();
            telecomHandler = new TelecomProviderHandler(repositoryMock.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void return_stored_phone_count(int storedPhoneCount)
        {
            repositoryMock
                .Setup(m => m.GetAll())
                .Returns(fixture.CreateMany<Phone>(storedPhoneCount).ToList());

            var allPhones = telecomHandler.GetAllPhones();

            Assert.Equal(storedPhoneCount, allPhones.Count);
        }

        [Fact]
        public void return_single_customer_phones()
        {
            int customerId = fixture.Create<int>();
            int phoneCount = 2;
            repositoryMock
                   .Setup(m => m.GetCustomerPhones(customerId))
                   .Returns(fixture.CreateMany<Phone>(phoneCount).ToList());

            var customerPhones = telecomHandler.GetCustomerPhones(customerId);

            Assert.Equal(phoneCount, customerPhones.Count);
        }

        [Fact]
        public void forward_contract_phone_as_converted_phone()
        {
            var aPhone = fixture.Create<ContractPhone>();

            telecomHandler.ActivatePhone(aPhone);

            repositoryMock
                .Verify(m => m.Save(aPhone.CustomerId, aPhone.PhoneNumber),
                    Times.Once);
        }
    }
}
