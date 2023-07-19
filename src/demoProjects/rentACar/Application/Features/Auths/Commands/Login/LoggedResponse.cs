using Core.Application.Responses;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoggedResponse:IResponse
    {
        public AccessToken? AccessToken { get; set; }

        public RefreshToken? RefreshToken { get; set; }

        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public LoggedHttpResponse ToHttpResponse()=>
            new() { AccessToken=AccessToken,RequiredAuthenticatorType=RequiredAuthenticatorType};
        public class LoggedHttpResponse
        {
            public AccessToken? AccessToken { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }
    }
}
