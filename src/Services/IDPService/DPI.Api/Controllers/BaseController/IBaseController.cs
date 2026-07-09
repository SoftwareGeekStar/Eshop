using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPI.Api.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBaseController : ControllerBase
    {
    }
}
