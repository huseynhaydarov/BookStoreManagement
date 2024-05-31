using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer : Person
{ 
    public DateTime RegisteredDate { get; set; }

    public virtual ICollection<BankAccount> Accounts { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}

