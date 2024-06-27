using Domain.Abstract;

namespace Domain.Entities;

public class PublisherEntity : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public virtual ICollection<BookEntity> Books { get; set; }
}