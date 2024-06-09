using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCF.Models;

public class Payment
{
    [Key]
    public int IdPayment { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey("IdClient")]
    public int IdClient { get; set; }

    [ForeignKey("IdSubscription")]
    public int IdSubscription { get; set; }

    public Payment(int idPayment, DateTime date, int idClient, int idSubscription)
    {
        IdPayment = idPayment;
        Date = date;
        IdClient = idClient;
        IdSubscription = idSubscription;
    }
}