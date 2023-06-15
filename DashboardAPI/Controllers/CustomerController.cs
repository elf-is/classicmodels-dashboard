using Dashboard.Data.DTO;
using Dashboard.Data.Models;
using Dashboard.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    ///     Retrieve the customers data as a datatable
    /// </summary>
    /// <param name="request"><see cref="DatatableRequest" /> object</param>
    /// <param name="service"><see cref="IDataTableService{T}" /> service. <seealso cref="Customer" /></param>
    /// <returns><see cref="DatatableResponse{T}" /> object</returns>
    /// <response code="200">Returns the customer data as a datatable</response>
    [HttpPost]
    public ActionResult GetCustomers([FromBody] DatatableRequest request,
        [FromServices] IDataTableService<Customer> service)
    {
        var model = service.GetData();
        var response = service.GetDatatableObject(request, model);
        return Ok(response);
    }


    /// <summary>
    ///     Retrieve a customer data
    /// </summary>
    /// <param name="id">Customer id</param>
    /// <returns><see cref="CustomerDTO" /> object</returns>
    /// <response code="200">Returns the customer data</response>
    /// <response code="404">Customer not found</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
    {
        var customer = await _service.GetCustomer(id);
        if (customer == null)
        {
            _logger.LogError("GetCustomer: Customer {CustomerNumber} not found", id);
            return NotFound();
        }

        _logger.LogInformation("GetCustomer: Customer {CustomerNumber} found", customer.CustomerNumber);
        return Ok(customer);
    }


    /// <summary>
    ///     Retrieve a customer orders data
    /// </summary>
    /// <param name="id">Customer id</param>
    /// <returns><see cref="Order" /> object</returns>
    /// <response code="200">Returns the customer orders data</response>
    /// <response code="404">Customer not found</response>
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<List<Order>>> GetCustomerOrders(int id)
    {
        try
        {
            var orders = await _service.GetCustomerOrders(id);
            _logger.LogInformation("GetCustomerOrders: {OrdersCount} orders found for customer {CustomerNumber}",
                orders.Count, id);
            if (orders.Count == 0)
                _logger.LogWarning("GetCustomerOrders: No orders found for customer {CustomerNumber}", id);

            return Ok(orders);
        }
        catch (ArgumentNullException)
        {
            _logger.LogError("GetCustomerOrders: Customer {CustomerNumber} not found", id);
            return NotFound();
        }
    }

    [HttpGet("{id}/orders/{orderId}")]
    public async Task<ActionResult<List<OrderDetailDTO>>> GetOrderDetail(int orderId)
    {
        try
        {
            var orderDetail = await _service.GetOrderDetails(orderId);
            if (orderDetail.Count == 0)
                _logger.LogWarning("GetOrderDetail: No order details found for order {OrderNumber}", orderId);

            _logger.LogInformation("GetOrderDetail: {OrderDetailsCount} order details found for order {OrderNumber}",
                orderDetail.Count, orderId);
            return Ok(orderDetail);
        }
        catch (ArgumentNullException)
        {
            _logger.LogError("GetOrderDetail: Order {OrderNumber} not found", orderId);
            return NotFound();
        }
    }
}