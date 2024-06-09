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
        
        if (subscription.EndTime > DateTime.Now)
        {
            return BadRequest();
        }
        
        if (client.Sales.Count > 0)
        {
            return BadRequest();
        }

        if (!subscription.Price.Equals(price))
        {
            return BadRequest();
        }
        
        var discount = client.Discounts.FirstOrDefault();
        if (discount != null)
        {
            price *= (1 - discount.Value);
        }

        var payment = new Payment(DateTime.Now, idClient, idSubscription);

        await _dbContext.AddAsync(payment);
        await _dbContext.SaveChangesAsync();

        return Ok(payment.IdPayment);

    }
}