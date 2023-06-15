using AutoMapper;
using Dashboard.Data.DTO;
using Dashboard.Data.Models;

namespace Dashboard.Common.Helpers;

public class CustomerContactValueResolver : IValueResolver<Customer, CustomerDTO, string>
{
    public string Resolve(Customer source, CustomerDTO destination, string destMember, ResolutionContext context)
    {
        return source.ContactFirstName + " " + source.ContactLastName;
    }
}