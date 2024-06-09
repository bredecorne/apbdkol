using Microsoft.EntityFrameworkCore;

namespace KolokwiumCF;

public class SubscriptionAppContext :DbContext
{
    protected SubscriptionAppContext() {}
    
    public SubscriptionAppContext(DbContextOptions options) : base(options) {}
}