using Microsoft.AspNetCore.Mvc;
using WSVentaAPI.Models.Request;
using WSVentaAPI.Models.Response;
using WSVentaAPI.Services;

namespace WSVentaAPI.Controllers
{
    [ApiController]
    [Route("WSVenta/Users")]
    
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var userResponse = _userService.Auth(model);

            if(userResponse == null) 
            {
                response.Message = "User or password are incorrect";
                response.Success = false;
                return BadRequest(response);
            }

            response.Success=true;
            response.Data = userResponse;
                
            return Ok(response);
        }

    }
}
