using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.CustomerRequests;

public record UpdateCustomerRequestModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }
}
