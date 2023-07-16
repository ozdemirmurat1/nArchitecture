using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserOperationClaims
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<UserOperationClaim> AddAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
                userOperationClaim.UserId,
                userOperationClaim.OperationClaimId
                );

           UserOperationClaim addedUserOperationClaim=await _userOperationClaimRepository.AddAsync( userOperationClaim );

            return addedUserOperationClaim;
        }

        public async Task<UserOperationClaim> DeleteAsync(UserOperationClaim userOperationClaim, bool permanent = false)
        {
            UserOperationClaim deletedUserOperationClaim=await _userOperationClaimRepository.DeleteAsync( userOperationClaim );
            return deletedUserOperationClaim;
        }

        public async Task<UserOperationClaim> GetAsync(Expression<Func<UserOperationClaim, bool>> predicate, Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>> include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            UserOperationClaim? userOperationClaim=await _userOperationClaimRepository.GetAsync(
                predicate,
                include,
                withDeleted,
                enableTracking,
                cancellationToken);

            return userOperationClaim;
        }

        public async Task<IPaginate<UserOperationClaim>> GetListAsync(Expression<Func<UserOperationClaim, bool>> predicate = null, Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>> orderBy = null, Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>> include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IPaginate<UserOperationClaim> userOperationClaimList = await _userOperationClaimRepository.GetListAsync(
                predicate,
                orderBy,
                include,
                index,
                size,
                withDeleted,
                enableTracking,
                cancellationToken
                );

            return userOperationClaimList;
        }

        public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
                userOperationClaim.Id,
                userOperationClaim.UserId,
                userOperationClaim.OperationClaimId);

            UserOperationClaim updatedUserOperationClaim=await _userOperationClaimRepository.UpdateAsync( userOperationClaim );

            return updatedUserOperationClaim;
        }
    }
}
