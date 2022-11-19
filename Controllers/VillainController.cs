using Microsoft.AspNetCore.Mvc;
using tour_of_villains_api.Models;

namespace tour_of_villains_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VillainController : ControllerBase
{
    private VillainContext _context;

    public VillainController(VillainContext context)
    {
        _context = context;
    }

    // GET: /villain
    [HttpGet("{heroName}")]
    public Villain GetVillain(string heroName)
    {
        //return new Villain { Name = "This is a test" };
        return _context.Villains.Where<Villain>(v => v.Hero == heroName).SingleOrDefault();
    }

    // POST: /villain
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Villain>> PostHero(Villain villain)
    {
        _context.Villains.Add(villain);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVillain), new { heroName = villain.Hero }, villain);
    }
}
