using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.CategoryRequests;

public record UpdateCategoryRequestModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
