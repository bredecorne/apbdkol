using System.ComponentModel.DataAnnotations;

namespace KolokwiumCF.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(100)]
    public string Phone { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    
    public virtual ICollection<Discount> Discounts { get; set; }
    
    public Client(int idClient, string firstName, string lastName, string email, string phone)
    {
        IdClient = idClient;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}