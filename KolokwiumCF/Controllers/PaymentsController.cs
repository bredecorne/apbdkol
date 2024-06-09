using KolokwiumCF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF.Controllers;

[Route("api/[controller]")]
[Controller]
public class PaymentsController : ControllerBase
{
    private SubscriptionAppContext _dbContext;

    public PaymentsController(SubscriptionAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddPayment(int idClient, int idSubscription, decimal price)
    {
        // 1 i 2
        var client = await _dbContext.Clients
            .Include(c => c.Discounts)
            .Include(c => c.Sales)
            .FirstOrDefaultAsync();
        var subscription = await _dbContext.Subscriptions
            .Include(s => s.Sales)
            .FirstOrDefaultAsync(s => s.IdSubscription == idSubscription);

        if (client == null || subscription == null)
        {
            return NotFound();
        }
        
        // 3
        if (subscription.EndTime > DateTime.Now)
        {
            return BadRequest();
        }
        
        // 4
        // if (client.Sales.Contains())

        // 5
        if (!subscription.Price.Equals(price))
        {
            return BadRequest();
        }

        var payment = new Payment(DateTime.Now, idClient, idSubscription);

        await _dbContext.AddAsync(payment);
        await _dbContext.SaveChangesAsync();

        return Ok(payment.IdPayment);

    }
}