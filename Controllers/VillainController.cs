using Microsoft.AspNetCore.Mvc;
using tour_of_villains.Models;

namespace tour_of_villains_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VillainController : ControllerBase
{

    // GET: api/villain
    [HttpGet]
    public Hero GetVillain()
    {
        return new Hero
        {
            Name = "This is a test"
        };

    }
}