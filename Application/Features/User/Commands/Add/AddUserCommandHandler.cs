using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces.PasswordHasher;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.Add
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public AddUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var checkExists= await _unitOfWork.UserRepository.ExistsAsync(u=>u.PhoneNumber == request.PhoneNumber);
            if (checkExists)
            {
                throw new ConflictException("the user with this phone number allready exists");
            }
            var user = _mapper.Map<Domain.Entities.User>(request);
            user.PasswordHash = _passwordHasher.Hash(request.PasswordHash);
            await _unitOfWork.UserRepository.AddAsync(user,cancellationToken);
            await _unitOfWork.SaveAsync();
            

            return user.Id;
        }
    }
}
