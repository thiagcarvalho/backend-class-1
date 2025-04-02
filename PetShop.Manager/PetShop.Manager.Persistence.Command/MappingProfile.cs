using AutoMapper;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Command
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDataModel, CustomerInputModel>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
