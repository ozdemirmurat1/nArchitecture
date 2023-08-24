using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register
{
    // RegisteredDto api den alacağımız dönüş
    public class RegisterCommand:IRequest<RegisteredResponse>
    {
        public Core.Security.Dtos.UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public RegisterCommand()
        {
            UserForRegisterDto = null!;
            IpAddress=string.Empty;
        }

        public RegisterCommand(Core.Security.Dtos.UserForRegisterDto userForRegisterDto,string ipAddress)
        {
            UserForRegisterDto=userForRegisterDto;
            IpAddress = ipAddress;
        }
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
                
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, passwordHash: out byte[] passwordHash, passwordSalt: out byte[] passwordSalt);

                User newUser = new()
                {
                    Email= request.UserForRegisterDto.Email,
                    PasswordHash= passwordHash,
                    PasswordSalt= passwordSalt,
                    FirstName= request.UserForRegisterDto.FirstName,
                    LastName=request.UserForRegisterDto.LastName,
                    Status=true
                };

                User createdUser = await _userRepository.AddAsync(newUser);
                AccessToken createdAccessToken=await _authService.CreateAccessToken(createdUser);
                Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredResponse registeredResponse = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };

                return registeredResponse;
            }
        }
    }
}
