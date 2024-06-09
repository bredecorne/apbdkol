using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCF.Models;

public class Payment
{
    [Key]
    public int IdPayment { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey("Client")]
    public int IdClient { get; set; }
    
    [ForeignKey("Subscription")]  
    public int IdSubscription { get; set; } 
    
    public Client Client { get; set; }
    
    public Subscription Subscription { get; set; }

    public Payment(DateTime date, int idClient, int idSubscription)
    {
        Date = date;
        IdClient = idClient;
        IdSubscription = idSubscription;
    }

    public Payment(int idPayment, DateTime date, int idClient, int idSubscription)
    {
        IdPayment = idPayment;
        Date = date;
        IdClient = idClient;
        IdSubscription = idSubscription;
    }
}