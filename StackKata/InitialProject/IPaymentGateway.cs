namespace InitialProject
{
    public interface IPaymentGateway
    {
        void Pay(PaymentDetails paymentDetails);
    }
}