using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly TokenOptions _tokenOptions;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository; 
        
        

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository,IRefreshTokenRepository refreshTokenRepository,ITokenHelper tokenHelper,IConfiguration configuration,AuthBusinessRules authBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;

            const string tokenOptionsConfigurationSection = "TokenOptions";
            _tokenOptions=configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>() ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken); 
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
           IPaginate<UserOperationClaim> userOperationClaims=await _userOperationClaimRepository.GetListAsync(u=>u.UserId==user.Id,include:u=>u.Include(u=>u.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

            AccessToken accessToken=_tokenHelper.CreateToken(user,operationClaims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user,string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress); 
            return await Task.FromResult(refreshToken);
        }

        public Task DeleteOldRefreshTokens(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetRefreshTokenByToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
        {
            throw new NotImplementedException();
        }

        public Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string reason = null, string replacedByToken = null)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            throw new NotImplementedException();
        }
    }
}
