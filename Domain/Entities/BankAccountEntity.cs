using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BankAccountEntity : BaseEntity
{
    public int AccountNumber { get; set; }

    public CustomerEntity Customer { get; set; }
    public int CustomerId { get; set; }
}
