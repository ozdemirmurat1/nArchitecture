using Core.Application.Responses;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RefreshToken
{
    public class RefreshedTokensResponse:IResponse
    {
        public AccessToken AccessToken { get; set; }
        public Core.Security.Entities.RefreshToken RefreshToken { get; set; }

        public RefreshedTokensResponse()
        {
            AccessToken = null!;
            RefreshToken = null!;
        }

        public RefreshedTokensResponse(AccessToken accessToken, Core.Security.Entities.RefreshToken refreshToken)
        {
            AccessToken= accessToken;
            RefreshToken= refreshToken;
        }
    }
}
