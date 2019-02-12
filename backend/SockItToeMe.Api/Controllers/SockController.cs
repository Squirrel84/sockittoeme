using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SockItToeMe.Application;

namespace SockItToeMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SockController : ControllerBase
    {
        private readonly ISockProvider _sockProvider = null;

        public SockController(ISockProvider sockProvider)
        {
            _sockProvider = sockProvider;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var model = await _sockProvider.GetSockByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Sock [{id}] was not found");
            }

            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return Ok(model);           
        }
    }
}