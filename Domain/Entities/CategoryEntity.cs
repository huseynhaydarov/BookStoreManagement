using Domain.Abstract;

namespace Domain.Entities;

public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<BookEntity> Books { get; set; }
}