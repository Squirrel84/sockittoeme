using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SockItToeMe.API.Controllers.Base;
using SockItToeMe.API.Controllers.Interfaces;
using SockItToeMe.Application;

namespace SockItToeMe.API.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/sock")]
    [Route("api/[controller]")]
    [ApiController]
    public class SockController : ControllerBase<ISockProvider>, ISockController
    {
        public SockController(ISockProvider sockProvider) : base(sockProvider)
        {
            
        }

        [HttpGet(""), MapToApiVersion("1")]
        public IActionResult Default()
        {
            return Ok();
        }

        [HttpGet("get/{id}"), MapToApiVersion("1")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await this.Provider.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Sock [{id}] was not found");
            }

            return Ok(model);
        }
    }

    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/sock")]
    [ApiController]
    public class SockV2Controller : ControllerBase<ISockProvider>, ISockController
    {
        public SockV2Controller(ISockProvider provider) : base(provider)
        {
        }

        [HttpGet("get/{id}"), MapToApiVersion("2")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await this.Provider.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Sock [{id}] was not found");
            }

            return Ok(model);
        }

        [HttpGet("get/{id}"), MapToApiVersion("3")]
        public async Task<IActionResult> GetV3(int id)
        {
            var model = await this.Provider.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Sock [{id}] was not found");
            }

            return Ok(model);
        }
    }
}