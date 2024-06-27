using Domain.Abstract;

namespace Domain.Entities;

public class BankAccountEntity : BaseEntity
{
    public int AccountNumber { get; set; }

    public CustomerEntity Customer { get; set; }
    public int CustomerId { get; set; }
}