using Microsoft.AspNetCore.Mvc;

namespace WorkAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
