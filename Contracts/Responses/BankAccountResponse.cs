using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record BankAccountResponse
{
    public int Id { get; set; }
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }
}
