namespace InitialProject
{
    public class PaymentService
    {
        private readonly IUserValidator _userValidator;
        private readonly IPaymentGateway _paymentGateway;

        public PaymentService(IUserValidator userValidator, IPaymentGateway paymentGateway)
        {
            _userValidator = userValidator;
            _paymentGateway = paymentGateway;
        }

        public void ProcessPayment(User user, PaymentDetails paymentDetails)
        {
            if (_userValidator.IsValid(user))
            {
                _paymentGateway.Pay(paymentDetails);
            }
        }
    }
}
