using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator
{
    public class EnabledOtpAuthenticatorResponse:IResponse
    {
        public string SecretKey { get; set; }

        public EnabledOtpAuthenticatorResponse()
        {
            SecretKey=string.Empty;
        }

        public EnabledOtpAuthenticatorResponse(string secretKey)
        {
            SecretKey =secretKey;
        }
    }
}
