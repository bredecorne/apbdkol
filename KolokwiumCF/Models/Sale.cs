using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCF.Models;

public class Sale
{
    [Key]
    public int IdSale { get; set; }

    [ForeignKey("IdClient")]
    public int IdClient { get; set; }

    [ForeignKey("IdSubscription")]
    public int IdSubscription { get; set; }

    public DateTime CreatedAt { get; set; }

    public Sale(int idSale, int idClient, int idSubscription, DateTime createdAt)
    {
        IdSale = idSale;
        IdClient = idClient;
        IdSubscription = idSubscription;
        CreatedAt = createdAt;
    }
}