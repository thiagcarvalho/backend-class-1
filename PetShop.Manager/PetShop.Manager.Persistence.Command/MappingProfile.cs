using AutoMapper;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Command
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDataModel, CustomerViewModel>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
