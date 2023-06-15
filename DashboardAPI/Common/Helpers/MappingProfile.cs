using AutoMapper;
using Dashboard.Data.DTO;
using Dashboard.Data.Models;

namespace Dashboard.Common.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.ContactName,
                opt => opt.MapFrom<CustomerContactValueResolver>())
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom<CustomerAddressValueResolver>());
        CreateMap<Order, OrderDTO>();
    }
}