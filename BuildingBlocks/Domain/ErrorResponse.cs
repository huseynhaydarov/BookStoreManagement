using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Domain;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Title { get; set; }
}
