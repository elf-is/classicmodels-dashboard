using AutoMapper;
using Dashboard.Data.DTO;
using Dashboard.Data.Models;

namespace Dashboard.Common.Helpers;

public class CustomerAddressValueResolver : IValueResolver<Customer, CustomerDTO, string>
{
    public string Resolve(Customer source, CustomerDTO destination, string destMember, ResolutionContext context)
    {
        return source.AddressLine1 + " " + source.AddressLine2 + " " + source.City + " " + source.State + " " +
               source.PostalCode + " " + source.Country;
    }
}