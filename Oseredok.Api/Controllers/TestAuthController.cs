using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Oseredok.Api.Controllers
{
    [Route("[controller]")]
    public class TestAuthController : ApiController
    {
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok((Array.Empty<string>()));
        }
    }
}