using DPI.Api.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDP.Application.Command.User;
using Asp.Versioning;

namespace DPI.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(2)]
    [Route("api/v{v:apiversion}/user")]
    public class UserController : IBaseController
    {
        public readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// ورود اطلاعات کاربر
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        //[MapToApiVersion(1)]
        public async Task<IActionResult> Insert([FromBody] UserCommand userCommand)
        {
            var res = await _mediator.Send(userCommand);
            return Ok(res);
        }
    }
}
