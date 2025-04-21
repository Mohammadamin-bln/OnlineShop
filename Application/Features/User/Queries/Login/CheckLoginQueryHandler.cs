using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces.OtpService;
using Application.Interfaces.PasswordHasher;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Queries.Login
{
    public class CheckLoginQueryHandler : IRequestHandler<CheckLoginQuery, string>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IOtpService _otpServoce;

        public CheckLoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher, IOtpService otpServoce)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _otpServoce = otpServoce;
        }

        public async Task<string> Handle(CheckLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByPhoneNumber(request.PhoneNumber);
            if (user == null)
            {
                throw new NotFoundException("phone number not found");
            }
            var isPasswordCorrect =  _passwordHasher.Verify(request.PasswordHash, user.PasswordHash);
            if (!isPasswordCorrect)
            {
                throw new UnauthorizedAccessException("wrong password!");
            }

            await _otpServoce.SendOtpAsync(request.PhoneNumber);
            return $"verify code sent to{user.PhoneNumber} ";
        }
    }
}
