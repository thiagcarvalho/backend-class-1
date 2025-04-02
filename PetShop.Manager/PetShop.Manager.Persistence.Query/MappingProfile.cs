using AutoMapper;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Security;
using PetShop.Manager.Application.Contracts.Models.ViewModels.Store;
using PetShop.Manager.Persistence.DataModels.Security;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Query
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDataModel, CustomerViewModel>(MemberList.Destination).ReverseMap();
            CreateMap<UserDataModel, UserViewModel>(MemberList.Destination);
            CreateMap<RoleDataModel, RoleViewModel>(MemberList.Destination);
        }
    }
}
