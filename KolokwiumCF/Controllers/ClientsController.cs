using KolokwiumCF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF.Controllers;

[Route("api/[controller]")]
[Controller]
public class ClientsController : ControllerBase
{
    private SubscriptionAppContext _dbContext;

    public ClientsController(SubscriptionAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{idClient:int}")]
    public async Task<IActionResult> GetClientAndListOfSubscriptions(int idClient)
    {
        var client = await _dbContext.Clients
            .Include(c => c.Sales)
            .ThenInclude(s => s.Subscription)
            .FirstOrDefaultAsync(c => c.IdClient == idClient);
        

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }
}