using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract;

public abstract class Person : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}
