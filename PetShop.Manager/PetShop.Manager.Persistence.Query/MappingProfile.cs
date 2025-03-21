using AutoMapper;
using PetShop.Manager.Application.Contracts.Models.ViewModels;
using PetShop.Manager.Persistence.DataModels.Security;

namespace PetShop.Manager.Persistence.Query
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDataModel, UserViewModel>(MemberList.Destination);
            CreateMap<RoleDataModel, RoleViewModel>(MemberList.Destination);
        }
    }
}
