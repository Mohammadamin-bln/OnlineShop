using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.User.Queries.Login
{
    public class CheckLoginQuery : IRequest<string>
    {
        
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

    }
}
