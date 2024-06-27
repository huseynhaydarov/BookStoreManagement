using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class BookRepository : BaseRepository<BookEntity>, IBookRepository
{
    public BookRepository(EFContext context) : base(context)
    {
    }
}