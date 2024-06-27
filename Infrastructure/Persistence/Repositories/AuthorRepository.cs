using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
{
    public AuthorRepository(EFContext context) : base(context)
    {
    }
}