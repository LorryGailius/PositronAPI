namespace PositronAPI.Models.Order
{
    public enum OrderStatus
    {
        Pending,        // Order has been created but not processed yet
        Completed,      // Order has been completed and received by the customer
        Cancelled,      // Order has been cancelled
    }
}
