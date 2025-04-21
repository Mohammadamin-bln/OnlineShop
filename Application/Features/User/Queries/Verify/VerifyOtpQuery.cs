using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.User.Queries.Verify
{
    public class VerifyOtpQuery : IRequest<string>
    {
        public string PhoneNumber { get; set; }

        public string OtpCode { get; set; }
    }
}
