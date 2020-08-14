using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error/{code}")]
        public IActionResult Error(int code)

        => new ObjectResult(new ApiResponse(code));
    }
}
