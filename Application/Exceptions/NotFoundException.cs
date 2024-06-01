using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public long Id { get; }
    public string EntityName { get; }

    public NotFoundException(string entityName, long id) : base($"{entityName} with Id: {id} not found")
    {
        EntityName = entityName;
        Id = id;
    }
}