using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCF.Models;

public class Discount
{
    [Key]
    public int IdDiscount { get; set; }

    public int Value { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    [ForeignKey("IdClient")]
    public int IdClient { get; set; }

    public Discount(int idDiscount, int value, DateTime dateFrom, DateTime dateTo, int idClient)
    {
        IdDiscount = idDiscount;
        Value = value;
        DateFrom = dateFrom;
        DateTo = dateTo;
        IdClient = idClient;
    }
}