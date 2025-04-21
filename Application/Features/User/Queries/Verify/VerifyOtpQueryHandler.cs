using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces.OtpService;
using Application.Interfaces.PasswordHasher;
using Application.Interfaces.TokenProvider;
using Application.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Features.User.Queries.Verify
{
    public class VerifyOtpQueryHandler : IRequestHandler<VerifyOtpQuery, string>
    {

        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenProvider _tokenProvider;

        public VerifyOtpQueryHandler(IOtpService otpService, IUnitOfWork unitOfWork, ITokenProvider tokenProvider)
        {
            _otpService = otpService;
            _unitOfWork = unitOfWork;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> Handle(VerifyOtpQuery request, CancellationToken cancellationToken)
        {
            var isOtpValid = await _otpService.VerifyOtpAsync(request.PhoneNumber, request.OtpCode);
            if (!isOtpValid)
            {
                throw new UnauthorizedAccessException("invalid  or expired otp code");
            }

            var user = await _unitOfWork.UserRepository.GetUserByPhoneNumber(request.PhoneNumber);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return _tokenProvider.Create(user);
        }
    }
}
