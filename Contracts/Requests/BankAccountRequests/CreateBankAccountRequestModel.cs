using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.BankAccount;

public record CreateBankAccountRequestModel
{
    public int AccountNumber { get; set; }
    
    public int CustomerId { get; set; }
}
