namespace Market.Application.Common.Mappings;

using Market.Domain.Entities.Identity;
using Market.Shared.Dtos.Identity;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
    }
}
