using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCF.Models;

public class Subscription
{
    [Key]
    public int IdSubscription { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public int RenewalPeriod { get; set; }

    public DateTime EndTime { get; set; }

    [Column(TypeName="money")]
    public decimal Price { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    
    public virtual ICollection<Payment> Payments { get; set; } 

    public Subscription(int idSubscription, string name, int renewalPeriod, DateTime endTime, decimal price)
    {
        IdSubscription = idSubscription;
        Name = name;
        RenewalPeriod = RenewalPeriod;
        EndTime = endTime;
        Price = price;
    }
}