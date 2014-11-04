namespace Shop.Net.Model.Order
{
    public enum OrderStatus
    {
        AwatingForPaymentConfirmation,
        Rejected,
        PaymentRecieved,
        PaymentError,
        Shipped,
        InPreperation,
        RecievedByTheCustomer
    }
}