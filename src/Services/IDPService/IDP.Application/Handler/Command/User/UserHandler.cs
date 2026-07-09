using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Application.Command.User;
using IDP.Domain.IRepository.Command;
using MediatR;

namespace IDP.Application.Handler.Command.User
{
    public class UserHandler : IRequestHandler<UserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var res = await _userRepository.Insert(new Domain.Entities.User
            {
                FullName = request.FullName,
                CodeNumber = request.CodeNumber
            });
            return true;
        }
    }
}
