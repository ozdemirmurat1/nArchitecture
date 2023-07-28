﻿using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.VerifyEmailAuthenticator
{
    public class VerifyEmailAuthenticatorCommand:IRequest
    {
        public string ActivationKey { get; set; }

        public VerifyEmailAuthenticatorCommand()
        {
            ActivationKey=string.Empty;
        }

        public VerifyEmailAuthenticatorCommand(string activationKey)
        {
            ActivationKey = activationKey;
        }

        public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

            public VerifyEmailAuthenticatorCommandHandler(AuthBusinessRules authBusinessRules, IEmailAuthenticatorRepository emailAuthenticatorRepository)
            {
                _authBusinessRules = authBusinessRules;
                _emailAuthenticatorRepository = emailAuthenticatorRepository;
            }

            public async Task Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                EmailAuthenticator? emailAuthenticator=await _emailAuthenticatorRepository.GetAsync(
                    predicate:e=>e.ActivationKey==request.ActivationKey,
                    cancellationToken:cancellationToken);

                await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
                await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator!);

                emailAuthenticator!.ActivationKey = null;
                emailAuthenticator.IsVerified = true;

                await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
            }
        }
    }
}
