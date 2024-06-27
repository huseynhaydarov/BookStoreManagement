using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository<OrderEnitity>, IOrderRepository
{
    public OrderRepository(EFContext context) : base(context)
    {
    }
}