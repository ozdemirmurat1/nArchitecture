using Application.Features.Auths.Commands.RevokeToken;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auths.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
        }
    }
}
