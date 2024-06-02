using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer : BaseEntity
{ 
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }

    public virtual ICollection<BankAccount> Accounts { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}

