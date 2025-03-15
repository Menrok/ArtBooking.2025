using Microsoft.AspNetCore.Mvc;
 
namespace Backend.Controllers;
 
/// <summary>
/// Controller for managing user accounts
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet()]
    public ActionResult Check()
    {
        return Ok(new
        {
            Message = "Check successfull"
        });
    }
}