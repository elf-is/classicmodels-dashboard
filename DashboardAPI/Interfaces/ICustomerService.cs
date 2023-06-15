using Dashboard.Data.DTO;

namespace Dashboard.Interfaces;

public interface ICustomerService
{
    /// <summary>
    ///     Get a customer by id
    /// </summary>
    /// <param name="id">The id of the customer</param>
    /// <returns>A <see cref="CustomerDTO" /></returns>
    Task<CustomerDTO?> GetCustomer(int id);

    /// <summary>
    ///     Get a list of orders for a customer
    /// </summary>
    /// <param name="id">The id of the customer</param>
    /// <returns>A list of <see cref="OrderDTO" /></returns>
    Task<List<OrderDTO>> GetCustomerOrders(int id);

    /// <summary>
    ///     Get a list of order details for an order
    /// </summary>
    /// <param name="id">The id of the order</param>
    /// <returns>A list of <see cref="OrderDetailDTO" /></returns>
    Task<List<OrderDetailDTO>> GetOrderDetails(int id);
}