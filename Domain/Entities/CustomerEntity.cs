using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CustomerEntity : BaseEntity
{ 
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }

    public virtual ICollection<BankAccountEntity> Accounts { get; set; }
    public virtual ICollection<OrderEnitity> Orders { get; set; }
}

