using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreatedUserResponse>, ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles => new[] { Admin, Write, Add };

        public CreateUserCommand()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        public CreateUserCommand(string firstName,string lastName,string email,string password)
        {
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Password=password;
        }
    }
}
