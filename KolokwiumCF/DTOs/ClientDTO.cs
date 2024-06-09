using KolokwiumCF.Models;

namespace KolokwiumCF.DTOs;

public class ClientDTO
{
    public int IdClient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Discount> Discounts { get; set; }
    
    public decimal TotalSpent { get; set; }

    public ClientDTO(int idClient, string firstName, string lastName, string email, string phone, decimal totalSpent)
    {
        IdClient = idClient;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        TotalSpent = totalSpent;
    }
}