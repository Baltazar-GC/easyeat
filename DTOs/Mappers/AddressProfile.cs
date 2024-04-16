using AutoMapper;
using easyeat.DTOs.Addresses;

namespace easyeat.DTOs.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<NewAddress, Business.Model.Address>();

            CreateMap<Business.Model.Category, Address>();
            CreateMap<Address, Business.Model.Address>();
        }
    }
}