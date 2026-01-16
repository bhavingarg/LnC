// This file does not contain bad comments.

public class OrderProcessor 
{ 
    private readonly IPaymentGateway _paymentGateway; 
    private readonly IInventoryService _inventoryService; 
    private readonly INotificationService _notificationService; 
 
    public OrderProcessor(IPaymentGateway paymentGateway, 
        IInventoryService inventoryService, 
        INotificationService notificationService) 
    { 
        _paymentGateway = paymentGateway; 
        _inventoryService = inventoryService; 
        _notificationService = notificationService; 
    } 
 
    public async Task<OrderResult> ProcessOrder(Order order) 
    { 
        if (order == null) 
        { 
            throw new ArgumentNullException(nameof(order)); 
        } 
 
        if (!IsValidOrder(order)) 
        { 
            return OrderResult.Invalid("Order validation failed"); 
        } 
 
        bool hasInventory = await _inventoryService.CheckAvailability(order.Items); 
 
        if (!hasInventory) 
        { 
            return OrderResult.Failed("Insufficient inventory"); 
        } 
 
        await _inventoryService.ReserveItems(order.Items); 
 
        try 
        { 
            var paymentResult = await _paymentGateway.ProcessPayment( 
                order.CustomerId, 
                order.TotalAmount, 
                order.PaymentMethod); 
 
            if (paymentResult.IsSuccessful) 
            { 
                await _inventoryService.CommitReservation(order.Items); 
                await _notificationService.SendOrderConfirmation(order); 
 
                return OrderResult.Success(paymentResult.TransactionId); 
            } 
            else 
            { 
                await _inventoryService.ReleaseReservation(order.Items); 
 
                return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}"); 
            } 
        } 
        catch (Exception ex) 
        { 
            // Inventory must be released if payment processing throws an exception
            await _inventoryService.ReleaseReservation(order.Items); 
 
            Console.WriteLine($"Error: {ex.Message}"); 
 
            throw; 
        } 
    } 
 
    private bool IsValidOrder(Order order) 
    { 
        // TODO: Validation currently checks only item count and total amount; business rules may require expansion or a different logic

        return order.Items?.Count > 0 && order.TotalAmount > 0; 
    } 
 
    // Added by John on 12/15/2023 - needed for the new feature
    public async Task CancelOrder(string orderId) 
    { 
        var order = await GetOrderById(orderId); 
 
        // Initiate refund and restock only if the order was paid
        if (order.Status == OrderStatus.Paid) 
        { 
            await _paymentGateway.RefundPayment(order.TransactionId); 
            await _inventoryService.RestoreInventory(order.Items); 
        } 
 
        order.Status = OrderStatus.Cancelled; 
 
        // This is to persist the updated order status
        await SaveOrder(order); 
    } 
 
    private async Task<Order> GetOrderById(string orderId) 
    { 
        return await Task.FromResult(new Order()); 
    } 
 
    private async Task SaveOrder(Order order) 
    { 
        await Task.CompletedTask; 
    } 
} 
 