using AutoMapper;
using HelpingHands_API.Models;
using HelpingHands_API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace HelpingHands_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
			CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
			CreateMap<ApplicationUser, IdentityUser>().ReverseMap();
			CreateMap<ApplicationRole, ApplicationRoleDTO>().ReverseMap();
			CreateMap<ApplicationRole, IdentityRole>().ReverseMap();
			CreateMap<ApplicationUserRole, ApplicationUserRoleDTO>().ReverseMap();
			CreateMap<ApplicationUserRole, IdentityUserRole<string>>().ReverseMap();
		}
    }
}
  

