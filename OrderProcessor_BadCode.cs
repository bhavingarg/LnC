// This file classifies the Comments.

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
 
    // This method processes an order  --> Redundant comment, method name is self-explanatory
    public async Task<OrderResult> ProcessOrder(Order order) 
    { 
        // Check if order is null --> Redundant comment, code is self-explanatory
        if (order == null) 
        { 
            throw new ArgumentNullException(nameof(order)); 
        } 
 
        // Validate the order --> Redundant comment, code is self-explanatory
        if (!IsValidOrder(order)) 
        { 
            return OrderResult.Invalid("Order validation failed"); 
        } 
 
        // Check inventory --> Redundant comment, code is self-explanatory
        bool hasInventory = await _inventoryService.CheckAvailability(order.Items); 
 
        // If no inventory, return failure --> Redundant comment, code is self-explanatory
        if (!hasInventory) 
        { 
            return OrderResult.Failed("Insufficient inventory"); 
        } 
 
        // Reserve inventory --> redundant comment, clear from method call
        await _inventoryService.ReserveItems(order.Items); 
 
        try 
        { 
            // Process payment --> redundant comment, method name is self-explanatory
            var paymentResult = await _paymentGateway.ProcessPayment( 
                order.CustomerId, 
                order.TotalAmount, 
                order.PaymentMethod); 
 
            // Check if payment succeeded --> redundant comment, obvious from condition
            if (paymentResult.IsSuccessful) 
            { 
                // Update inventory -->>> misleading comment, should be "Commit reservation"
                await _inventoryService.CommitReservation(order.Items); 
 
                // Send confirmation email --> redundant comment, method name is self-explanatory
                await _notificationService.SendOrderConfirmation(order); 
 
                // Return success --> noise comment, obvious from return statement
                return OrderResult.Success(paymentResult.TransactionId); 
            } 
            else 
            { 
                // Payment failed, release inventory --> redundant comment, code states the intent
                await _inventoryService.ReleaseReservation(order.Items); 
 
                // Return failure --> Redundant comment, method name is self-explanatory
                return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}"); 
            } 
        } 
        catch (Exception ex) 
        { 
            // Something went wrong
            await _inventoryService.ReleaseReservation(order.Items); 
 
            // Log the error --> redundant comment, obvious from code
            Console.WriteLine($"Error: {ex.Message}"); 
 
            // Throw it ---> redundant comment, obvious from code
            throw; 
        } 
    } 
 
    private bool IsValidOrder(Order order) 
    { 
        // TODO: Fix this later ---> weak comment, should specify what needs to be fixed
        return order.Items?.Count > 0 && order.TotalAmount > 0; 
    } 
 
    // Added by John on 12/15/2023 - needed for the new feature ----> Depends on context, could be useful for tracking changes if soure control is not used 
    public async Task CancelOrder(string orderId) 
    { 
        // Get the order --> redundant comment, method name is self-explanatory
        var order = await GetOrderById(orderId); 
 
        // John says we need to refund here --> misleading comment, should explain why refund is needed not who said it
        if (order.Status == OrderStatus.Paid) 
        { 
            // Refund the payment --> redundant comment, method name is self-explanatory
            await _paymentGateway.RefundPayment(order.TransactionId); 
 
            // Give back the items --> redundant comment, method name is self-explanatory
            await _inventoryService.RestoreInventory(order.Items); 
        } 
 
        // Update status 0--> redundant comment, code is self-explanatory   
        order.Status = OrderStatus.Cancelled; 
 
        // This is important!!! --> noise/emphasis comment, shows emotion not information
        await SaveOrder(order); 
    } 
 
    // Gets order by ID --> redundant comment, method name is self-explanatory
    private async Task<Order> GetOrderById(string orderId) 
    { 
        // Implementation here --> noise
        return await Task.FromResult(new Order()); 
    } 
 
    // Saves the order --> noise comment, method name is self-explanatory
    private async Task SaveOrder(Order order) 
    { 
        // Implementation here --> noise
        await Task.CompletedTask; 
    } 
} 
 

