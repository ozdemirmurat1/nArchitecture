using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public class DeletedUserOperationClaimResponse:IResponse
    {
        public int Id { get; set; }
    }
}
