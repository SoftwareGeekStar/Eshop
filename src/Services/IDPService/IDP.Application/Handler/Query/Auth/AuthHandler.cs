using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Application.Command.User;
using IDP.Application.Query.Auth;
using MediatR;
using Auth;

using Microsoft.AspNetCore.Http.HttpResults;

namespace IDP.Application.Handler.Query.Auth;

public class AuthHandler : IRequestHandler<AuthQuery, bool>
{
    private readonly IJwtHandler _jwtHandler;

    public AuthHandler(IJwtHandler jwtHandler)
    {
        _jwtHandler = jwtHandler;
    }
    public async Task<bool> Handle(AuthQuery request, CancellationToken cancellationToken)
    {
        var token = _jwtHandler.create(34);
        return true;
    }
}
