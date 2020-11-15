using AutoFixture;
using Moq;
using TelecomProvider.Controllers;
using TelecomProvider.Controllers.TelecomProviderContract.DTO;
using TelecomProvider.Handlers;
using Xunit;

namespace TelecomProvider.UnitTests.Controllers
{
    public class TelecomProviderControllerShould
    {
        private Mock<ITelecomProviderHandler> telecomHandlerMock;
        private TelecomProviderController telecomController;

        public TelecomProviderControllerShould()
        {
            telecomHandlerMock = new Mock<ITelecomProviderHandler>();
            telecomController = new TelecomProviderController(telecomHandlerMock.Object);
        }

        [Fact]
        public void redirect_get_all_phones_request()
        {
            telecomController.Get();

            telecomHandlerMock
                .Verify(m => m.GetAllPhones(), Times.Once);
        }

        [Fact]
        public void redirect_get_single_customer_phones_request()
        {
            int customerId = 1;

            telecomController.Get(id: customerId);

            telecomHandlerMock
                .Verify(m => m.GetCustomerPhones(customerId), Times.Once);
        }

        [Fact]
        public void redirect_activate_phone_number_request()
        {
            var newPhone = new Fixture().Create<Phone>();

            telecomController.Post(newPhone);

            telecomHandlerMock
                .Verify(m => m.ActivatePhone(newPhone), Times.Once);
        }
    }
}
