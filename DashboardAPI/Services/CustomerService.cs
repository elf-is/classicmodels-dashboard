using AutoMapper;
using Dashboard.Data;
using Dashboard.Data.DTO;
using Dashboard.Data.Models;
using Dashboard.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Services;

public class CustomerService : ICustomerService
{
    private readonly ClassicModelsContext _context;
    private readonly IMapper _mapper;

    public CustomerService(ClassicModelsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO?> GetCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer == null ? null : _mapper.Map<Customer, CustomerDTO>(customer);
    }

    public async Task<List<OrderDTO>> GetCustomerOrders(int id)
    {
        var orders = await _context.Orders.Where(x => x.CustomerNumber == id)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<OrderDTO>>(orders);
    }

    public async Task<List<OrderDetailDTO>> GetOrderDetails(int id)
    {
        return await _context.Orderdetails.Where(x => x.OrderNumber == id)
            .Include(x => x.ProductCodeNavigation)
            .AsNoTracking()
            .Select(x => new OrderDetailDTO
            {
                SalesTotal = x.PriceEach * x.QuantityOrdered,
                ProductName = x.ProductCodeNavigation.ProductName
            }).ToListAsync();
    }
}