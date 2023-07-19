using Application.Features.Auths.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Core.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand:IRequest<LoggedResponse>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public string IpAddress { get; set; }

        public LoginCommand()
        {
            UserForLoginDto = null!;
            IpAddress = string.Empty;
        }

        public LoginCommand(UserForLoginDto userForLoginDto,string ipAddress)
        {
            UserForLoginDto=userForLoginDto;
            IpAddress = ipAddress;
        }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthenticatorService _authenticatorService;
            private readonly IAuthService _authService;
            //private readonly IUserService _userService;
            public Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
