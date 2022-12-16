using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tour_of_villains_api.Models;

namespace tour_of_villains_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VillainController : ControllerBase
{
    private VillainContext _context;
    private DaprClient _daprClient;

    public VillainController(VillainContext context, DaprClient daprClient)
    {
        _context = context;
        _daprClient = _daprClient;
    }

    // GET: /villain
    [HttpGet]
    public IEnumerable<Villain> GetVillains()
    {
        return _context.Villains.ToList();            
    }

    // GET: /villain
    [HttpGet("{heroName}")]
    public Villain GetVillain(string heroName)
    {
        return _context.Villains
            .Include(v => v.Hero)
            .Where<Villain>(v => v.Hero.Name == heroName)
            .SingleOrDefault();
    }

    // POST: /villain
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Villain>> PostHero(Villain villain)
    {
        _context.Villains.Add(villain);
        await _context.SaveChangesAsync();

        //Using Dapr SDK to publish a topic
        await _daprClient.PublishEventAsync("villain-pub-sub", "villains", villain);

        return CreatedAtAction(nameof(GetVillain), new { heroName = villain.Hero }, villain);
    }
}
