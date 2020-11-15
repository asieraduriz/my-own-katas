using AutoFixture;
using Courier.Controllers;
using Courier.Handlers;
using Courier.Models;
using Moq;
using Xunit;

namespace Courier.UnitTests.Controllers
{
    public class CourierControllerShould
    {
        [Fact]
        public void redirect_courier_request()
        {
            var fixture = new Fixture();
            var aCourierQuery = fixture.Create<CourierQuery>();
            var handler = new Mock<ICourierHandler>();
            var controller = new CourierController(handler.Object);

            controller.Post(aCourierQuery);

            handler
                 .Verify(m => m.Handle(aCourierQuery), Times.Once);
        }
    }
}
