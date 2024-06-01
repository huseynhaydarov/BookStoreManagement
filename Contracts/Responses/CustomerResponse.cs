using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record CustomerResponse
{
    public int Id { get; set; }
    public DateTime RegisteredDate { get; set; }
}
