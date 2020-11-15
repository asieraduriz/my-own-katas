using InitialProject;
using Moq;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class PaymentServiceShould
    {
        private static readonly User User = new User();
        private static readonly PaymentDetails PaymentDetails = new PaymentDetails();
        private readonly Mock<IUserValidator> _mockUserValidator = new Mock<IUserValidator>();
        private readonly Mock<IPaymentGateway> _mockPaymentGateway = new Mock<IPaymentGateway>();

        private PaymentService _paymentService;

        [SetUp]
        public void SetUp()
        {
            _paymentService = new PaymentService(_mockUserValidator.Object, _mockPaymentGateway.Object);
        }

        [Test]
        public void Throw_InvalidUserException_WhenUserIsNotValid()
        {           
            Assert.Throws<InvalidUserException>(
                () => _paymentService.ProcessPayment(
                    AnInvalidUser(),
                    PaymentDetails));
        }

        [Test]
        public void Send_Payment_To_Payment_Gateway_When_User_Is_Valid()
        {
            _paymentService.ProcessPayment(
                AValidUser(),
                PaymentDetails);

            _mockPaymentGateway
                .Verify(m => m.Pay(PaymentDetails), Times.Once);
        }

        private User AValidUser()
        {
            _mockUserValidator
                .Setup(m => m.IsValid(User))
                .Returns(true);

            return User;
        }

        private User AnInvalidUser()
        {
            _mockUserValidator
                .Setup(m => m.IsValid(User))
                .Throws(new InvalidUserException());

            return User;
        }
    }
}
