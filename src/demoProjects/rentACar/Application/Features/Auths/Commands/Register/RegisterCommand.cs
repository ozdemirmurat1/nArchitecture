﻿using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    // RegisteredDto api den alacağımız dönüş
    public class RegisterCommand:IRequest<RegisteredResponse>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public RegisterCommand()
        {
            UserForRegisterDto = null;
            IpAddress=string.Empty;
        }

        public RegisterCommand(UserForRegisterDto userForRegisterDto,string ipAddress)
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
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

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
