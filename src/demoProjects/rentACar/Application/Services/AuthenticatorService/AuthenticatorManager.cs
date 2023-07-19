using Application.Services.Repositories;
using Core.Mailing;
using Core.Security.EmailAuthenticator;
using Core.Security.Entities;
using Core.Security.OtpAuthenticator;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Services.AuthenticatorService
{
    public class AuthenticatorManager : IAuthenticatorService
    {
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IMailService _mailService;
        private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;
        private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;

        public AuthenticatorManager(IEmailAuthenticatorHelper emailAuthenticatorHelper, IEmailAuthenticatorRepository emailAuthenticatorRepository, IMailService mailService, IOtpAuthenticatorHelper otpAuthenticatorHelper, IOtpAuthenticatorRepository otpAuthenticatorRepository)
        {
            _emailAuthenticatorHelper = emailAuthenticatorHelper;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _mailService = mailService;
            _otpAuthenticatorHelper = otpAuthenticatorHelper;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
        }

        public async Task<string> ConvertSecretKeyToString(byte[] secretKey)
        {
            string result=await _otpAuthenticatorHelper.ConvertSecretKeyToString(secretKey);
            return result;
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            EmailAuthenticator emailAuthenticator =
                 new()
                 {
                     UserId = user.Id,
                     ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                     IsVerified = false
                 };

            return emailAuthenticator;
        }

        public async Task<OtpAuthenticator> CreateOtpAuthenticator(User user)
        {
            OtpAuthenticator otpAuthenticator =
                new()
                {
                    UserId = user.Id,
                    SecretKey = await _otpAuthenticatorHelper.GenerateSecretKey(),
                    IsVerified = false
                };
            return otpAuthenticator;
        }

        public Task SendAuthenticatorCode(User user)
        {
            throw new NotImplementedException();
        }

        public Task VerifyAuthenticatorCode(User user, string authenticatorCode)
        {
            throw new NotImplementedException();
        }

        private async Task VerifyAuthenticatorCodeWithOtp(User user,string authenticatorCode)
        {
            OtpAuthenticator otpAuthenticator=await _otpAuthenticatorRepository.GetAsync(predicate:e=>e.UserId == user.Id);

            if (otpAuthenticator is null)
                throw new NotFoundException("Otp Authenticator Not Found.");

            bool result=await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);
            if (!result)
                throw new BusinessException("Authenticator code is invalid");
        }
    }
}
