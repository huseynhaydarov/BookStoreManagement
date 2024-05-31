using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Author : Person
{
    public string Biography { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
