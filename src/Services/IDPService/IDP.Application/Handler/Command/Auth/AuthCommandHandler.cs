using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Application.Command.Auth;
using IDP.Domain.IRepository.Command;
using MediatR;

namespace IDP.Application.Handler.Command.User
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;

        public AuthCommandHandler(IOtpRedisRepository otpRedisRepository)
        {
                _otpRedisRepository = otpRedisRepository;
        }
        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            _otpRedisRepository.Add(new Domain.DTO.Otp { UserId = 230, OtpCode = "12345", IsUse = false });
            return true;
        }
    }
}
