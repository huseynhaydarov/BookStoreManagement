using Domain.Abstract;
using System.Net;

namespace Domain.Entities;

public  class AuthorEntity : BaseEntity
{
    public string FullName { get;  set; }
    public DateTime DateOfBirth { get;  set; }
    public string Biography { get;  set; }
    public virtual ICollection<BookEntity> Books { get; set; }

   
    public static AuthorEntity Create(string fullName, DateTime dateOfBirth, string biography)
    {
        return new AuthorEntity
        {
            FullName = fullName,
            DateOfBirth = dateOfBirth,
            Biography = biography,
            Books = new List<BookEntity>()
        };
    }
}