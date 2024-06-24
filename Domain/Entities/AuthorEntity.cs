using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class AuthorEntity : BaseEntity
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
    public virtual ICollection<BookEntity> Books { get; set; }
}
