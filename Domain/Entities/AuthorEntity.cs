using Domain.Abstract;

namespace Domain.Entities;

public class AuthorEntity : BaseEntity
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
    public virtual ICollection<BookEntity> Books { get; set; }
}