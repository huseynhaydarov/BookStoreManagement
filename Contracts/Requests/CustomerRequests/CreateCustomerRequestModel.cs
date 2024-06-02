using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.CustomerRequests
{
    public record CreateCustomerRequestModel
    {
        public DateTime RegisteredDate { get; set; }
        public string Email {  get; set; }    
    }
}
