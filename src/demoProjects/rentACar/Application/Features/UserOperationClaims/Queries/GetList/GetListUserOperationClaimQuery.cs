using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery:IRequest<GetListResponse<GetListUserOperationClaimListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public GetListUserOperationClaimQuery()
        {
            PageRequest = new PageRequest() { PageIndex=0,PageSize=10};
        }
    }
}
