using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulDemo.ViewModels.Auth;

namespace RestfulDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel request)
        {

            return Ok();
        }
    }
}
