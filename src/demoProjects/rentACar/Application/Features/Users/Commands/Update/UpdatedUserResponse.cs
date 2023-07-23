using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Update
{
    public class UpdatedUserResponse:IResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public UpdatedUserResponse()
        {
            FirstName = string.Empty;
            LastName=string.Empty;
            Email = string.Empty;
        }

        public UpdatedUserResponse(int id,string firstName,string lastName,string email,bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Status = status;
        }
    }
}
