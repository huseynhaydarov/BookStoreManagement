using Application.Common.Interfaces.Repositories;
using Contracts.Pagination;
using Domain.Abstract;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BookRepository : BaseRepository<BookEntity>, IBookRepository
{
    public BookRepository(EFContext context) : base(context)
    {
    }
}