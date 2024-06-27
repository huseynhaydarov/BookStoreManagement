using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class PublisherRepository : BaseRepository<PublisherEntity>, IPublisherRepository
{
    public PublisherRepository(EFContext context) : base(context)
    {
    }
}