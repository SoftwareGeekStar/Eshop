using DPI.Api.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDP.Application.Command.User;
using Asp.Versioning;
using IDP.Application.Query.Auth;

namespace DPI.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(2)]
    [Route("api/v{v:apiversion}/Auth")]
    public class AuthController : IBaseController
    {
        public readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthQuery authQuery)
        {
            var res = await _mediator.Send(authQuery);
            return Ok(res);
        }
    }
}
