using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RevokeToken
{
    public class RevokedTokenResponse:IResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public RevokedTokenResponse()
        {
            Token = string.Empty;
        }

        public RevokedTokenResponse(int id,string token)
        {
            Id = id;
            Token = token;
        }
    }
}
