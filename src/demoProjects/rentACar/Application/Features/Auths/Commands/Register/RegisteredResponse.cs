using Core.Application.Responses;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisteredResponse:IResponse
    {
        public AccessToken AccessToken { get;set; }

        public RefreshToken RefreshToken { get; set; }

        public RegisteredResponse()
        {
            AccessToken = null;
            RefreshToken = null;
        }

        public RegisteredResponse(AccessToken accessToken,RefreshToken refreshToken)
        {
            AccessToken=accessToken;
            RefreshToken=refreshToken;
        }
    }
}
