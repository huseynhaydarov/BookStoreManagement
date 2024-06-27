using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class OrderItemRepository : BaseRepository<OrderItemEntity>, IOrderItemRepository
{
    public OrderItemRepository(EFContext context) : base(context)
    {
    }
}