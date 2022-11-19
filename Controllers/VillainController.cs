using Microsoft.AspNetCore.Mvc;
using tour_of_villains_api.Models;

namespace tour_of_villains_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VillainController : ControllerBase
{
    // GET: /villain
    [HttpGet]
    public Villain GetVillain()
    {
        return new Villain { Name = "This is a test" };
    }
}
