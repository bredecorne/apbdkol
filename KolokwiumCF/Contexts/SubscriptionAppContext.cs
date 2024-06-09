using System.Collections.Immutable;
using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF;

public class SubscriptionAppContext :DbContext
{
    protected SubscriptionAppContext() {}
    
    public SubscriptionAppContext(DbContextOptions options) : base(options) {}
    
    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }
    
    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }
}